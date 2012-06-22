#line 1 "C:/Src/_Tree/Audio/KickBrain/PICcode/Kickbrain.c"




unsigned char Data[ 11 ];

int i;

int reference;

void loop();
void serialEvent();
void TrySendSerial();

unsigned ADCsample(unsigned short channel)
{
 unsigned output;

 channel = (channel & 0x0F) << 2;
 ADCON0 = ADCON0 & 0b11000011;
 ADCON0 = ADCON0 | channel;
 ADCON0.F1 = 1;


 while(ADCON0.F1 == 1)
 {TrySendSerial();}

 output = (ADRESH & 0b00000011);
 output = output * 256;
 output = output + ADRESL;
 return output;
}

void main()
{
 int k;

 TRISA = 0b11111111;
 TRISE = 0b11111111;
 TRISB = 0b11111111;

 TRISC = 0b10111111;
 TRISD = 0b11111110;

 PORTB = 0;
 PORTA = 0;
 PORTC = 0;
 PORTD = 0;


 INTCON = 0b00000000;
 INTCON2.F7 = 1;
 INTCON3.F4 = 0;
 INTCON3.F3 = 0;


 OSCCON = 0b11110000;
 OSCTUNE.F6 = 1;

 ADCON0.F0 = 1;
 ADCON1 = 0b00000000;
 ADCON2 = 0b10110101;

 T0CON = 0b00000000;



 UART1_Init(115200);
 TXSTA = 0b00100100;




 for(k = 0; k <  11 ; k++)
 Data[k] = 0;

 i = -1;


 reference = ADCsample( 10 );


 PORTD.F0 = 1;
 Delay_ms(200);
 PORTD.F0 = 0;
 Delay_ms(200);
 PORTD.F0 = 1;
 Delay_ms(200);
 PORTD.F0 = 0;
 Delay_ms(200);
 PORTD.F0 = 1;
 Delay_ms(200);
 PORTD.F0 = 0;
 Delay_ms(200);
 PORTD.F0 = 1;
 Delay_ms(200);

 while(1)
 {
 loop();
 }
}

void TrySendSerial()
{
 unsigned char output;

 if( TXSTA.F1 == 0)
 return;

 if(i == -1)
 {
 output = 0;
 TXREG = 0;
 }
 else
 {
 output = Data[i];
 TXREG = output;
 Data[i] = 0;
 }

 i++;
 if(i >=  11 )
 i = -1;
}


void loop()
{
 int value;
 int k;






 reference = (reference * 7 + ADCsample( 10 )) >> 3;

 for(k=0; k <  11 ; k++)
 {
 if(k == 9 &&  1 )
 {
 value = ADCsample(k);
 value = value >> 2;


 if (value <= 0)
 value = 1;

 if(value > Data[k])
 Data[k] = (unsigned char)value;
 }
 else if (k == 10)
 {
 value = 1 | (PORTC.F0 << 4) | (PORTC.F1 << 5);

 Data[k] = (unsigned char)value;
 }
 else
 {
 value = ADCsample(k);
 value = (value-reference);

 if(value < 0)
 value = 0;



 if(value > 255)
 value = 255;


 if (value <= 0)
 value = 1;

 if(value > Data[k])
 Data[k] = (unsigned char)value;
 }

 TrySendSerial();
 }


}


void serialEvent() {
 while (UART1_Data_Ready())
 {

 int input;
 input = UART1_Read();

 if(input >= 128)
 {
 input = input - 128;
 }
 else
 {


 }
 }
}
