// defines for setting and clearing register bits
#ifndef cbi
#define cbi(sfr, bit) (_SFR_BYTE(sfr) &= ~_BV(bit))
#endif
#ifndef sbi
#define sbi(sfr, bit) (_SFR_BYTE(sfr) |= _BV(bit))
#endif

#include "Channel.h"

int microsPerSample;
unsigned long lastTime;
Channel ch;

void setup()
{
  
  // Set AD Prescaler to 16
  sbi(ADCSRA,ADPS2);
  cbi(ADCSRA,ADPS1);
  cbi(ADCSRA,ADPS0);
  
  lastTime = 0;
  microsPerSample = 500000;
  
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
  
}
