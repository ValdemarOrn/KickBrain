// defines for setting and clearing register bits
// used to set the AD prescaler
#ifndef cbi
#define cbi(sfr, bit) (_SFR_BYTE(sfr) &= ~_BV(bit))
#endif
#ifndef sbi
#define sbi(sfr, bit) (_SFR_BYTE(sfr) |= _BV(bit))
#endif

byte Data[6]; // reserve space for channels

int ChannelCount;
int i; // -1 = zero (stop value)

void setup() {
  
  // Set AD Prescaler to 16 for faster AD operation
  sbi(ADCSRA,ADPS2);
  cbi(ADCSRA,ADPS1);
  cbi(ADCSRA,ADPS0);
  
  ChannelCount = 6;
  for(int k = 0; k < ChannelCount; k++)
    Data[k] = 0;
  
  i = -1;
  
  Serial.begin(115200);
  pinMode(12, OUTPUT); 
  pinMode(13, OUTPUT); 
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


void loop()
{
  
  for(int k=0; k < ChannelCount; k++)
  {
    
    int value = 0;
    value = analogRead(k);
    if(k == 5) // Hihat channel
      value = value >> 2;
    
    if (value > 255)
      value = 255;  
    if (value <= 0)
      value = 1;
    
    if(value > Data[k])
      Data[k] = (byte)value;
    
    TrySendSerial();
  }  
}

