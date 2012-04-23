// defines for setting and clearing register bits
#ifndef cbi
#define cbi(sfr, bit) (_SFR_BYTE(sfr) &= ~_BV(bit))
#endif
#ifndef sbi
#define sbi(sfr, bit) (_SFR_BYTE(sfr) |= _BV(bit))
#endif

int channelCount;
int fs;
int microsPerSample;
unsigned long lastTime;

void setMicrosPerSample()
{
  long x = 1000000;
  x = x / fs;
  microsPerSample = x;
}

void setup() {
  
  // Set AD Prescaler to 16
  sbi(ADCSRA,ADPS2);
  cbi(ADCSRA,ADPS1);
  cbi(ADCSRA,ADPS0);
  
  channelCount = 6;
  fs = 100; // 5k, or maximum that the serial interface can handle
  lastTime = 0;
  setMicrosPerSample();
  
  Serial.begin(260000);
}

void loop() {
  
  unsigned long now = micros();
  
  if(now < lastTime)
  {
    // micros() buffer overflow. Happens every ~70 minutes
  }
  else if((lastTime + microsPerSample) > now)
  {
    return;
  }
  
  lastTime = now;
  
  int stopValue = 0;
  Serial.write(stopValue);
  
  if(channelCount > 0)
  {
    int sensorValue0 = analogRead(A0);
    sensorValue0 = sensorValue0 / 4;
    if(sensorValue0 <= 0)
      sensorValue0 = 1;
    Serial.write(sensorValue0);
  }
  
  if(channelCount > 1)
  {
    int sensorValue1 = analogRead(A1);
    sensorValue1 = sensorValue1 / 4;
    if(sensorValue1 <= 0)
      sensorValue1 = 1;
    Serial.write(sensorValue1);
  }
  
  if(channelCount > 2)
  {
    int sensorValue2 = analogRead(A2);
    sensorValue2 = sensorValue2 / 4;
    if(sensorValue2 <= 0)
      sensorValue2 = 1;
    Serial.write(sensorValue2);
  }
  
  if(channelCount > 3)
  {
    int sensorValue3 = analogRead(A3);
    sensorValue3 = sensorValue3 / 4;
    if(sensorValue3 <= 0)
      sensorValue3 = 1;
    Serial.write(sensorValue3);
  }
  
  if(channelCount > 4)
  {
    int sensorValue4 = analogRead(A4);
    sensorValue4 = sensorValue4 / 4;
    if(sensorValue4 <= 0)
      sensorValue4 = 1;
    Serial.write(sensorValue4);
  }
  
  if(channelCount > 5)
  {
    int sensorValue5 = analogRead(A5);
    sensorValue5 = sensorValue5 / 4;
    if(sensorValue5 <= 0)
      sensorValue5 = 1;
    Serial.write(sensorValue5);
  }
  
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    int input = Serial.read(); 
    if(input >= 128)
    {
      input = input - 128;
      if(input > 100)
        input = 100;
        
      // fs = input/2 * 100hz;
      //      100  /2 * 100hz = 5k = maximum        
      fs = input * 50;
      setMicrosPerSample();
    }
    else
    {
      if (input < 14)
        channelCount = input;
    }
  }
}
