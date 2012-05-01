// defines for setting and clearing register bits
#ifndef cbi
#define cbi(sfr, bit) (_SFR_BYTE(sfr) &= ~_BV(bit))
#endif
#ifndef sbi
#define sbi(sfr, bit) (_SFR_BYTE(sfr) |= _BV(bit))
#endif

#define MAX_CHANNELS 20
byte Data[MAX_CHANNELS]; // reserve space for 20 channels

int ChannelCount;
int Delay;
int i; // -1 = zero (stop value)

int reference;

void setup() {
  
  // Set AD Prescaler to 16
  sbi(ADCSRA,ADPS2);
  cbi(ADCSRA,ADPS1);
  cbi(ADCSRA,ADPS0);
  
  for(int k = 0; k < MAX_CHANNELS; k++)
    Data[k] = 0;
  
  ChannelCount = 6;
  i = -1;
  Delay = 0;
  
  Serial.begin(230000);
  reference = analogRead(5);
}

void TrySendSerial()
{
  // check if serial interface is busy. If it is, abort transmission
  // better luck next time
  if( !(UCSR0A & (1 << UDRE0)) )
    return;
  
  if(i == -1)
    UDR0 = 0;
  else
  {  
    UDR0 = Data[i];
    Data[i] = 0;
  }
    
  i++;
  if(i >= ChannelCount)
    i = -1;
}

void loop() {
  
  reference = (reference * 7 + analogRead(5)) >> 3; // (7*ref + 1*read) / 8
  
  for(int k=0; k < ChannelCount; k++)
  {
    int value = analogRead(k % 6);
    value = (value-reference);
    if(value < 0) value = -value;
    value = value >> 2;
    if (value <= 0)
      value = 1;
      
    if(value > Data[k])
      Data[k] = (byte)value;
      
    TrySendSerial();
  }  
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    int input = Serial.read(); 
    if(input >= 128)
    {
      input = input - 128;
      Delay = input * 10;
    }
    else
    {
      if (input <= MAX_CHANNELS)
        ChannelCount = input;
    }
  }
}
