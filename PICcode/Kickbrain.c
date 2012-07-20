
#define HIHAT_ENABLED 1 // sets whether this model has a hi-hat input
#define CHANNEL_COUNT 12 // 10 AD channel + Hihat Channel + 1 digital bit channel (contains 8 bits/switches)
unsigned char Data[CHANNEL_COUNT]; // reserve space for channels

int i; // -1 = zero (stop value)

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
	
	// wait for conversion
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
	
	TRISA = 0b11111111; // analog inputs
	TRISE = 0b11111111; // analog inputs
	TRISB = 0b11111111; // analog inputs
	
	TRISC = 0b10111111; // inputs, uart TX P6 Output
	TRISD = 0b11111110; // inputs, LED output P0

	PORTB = 0;
	PORTA = 0;
	PORTC = 0;
	PORTD = 0;
	
	// Disable external interrups, disable all interrputs
	INTCON = 0b00000000;
	INTCON2.F7 = 1;
	INTCON3.F4 = 0;
	INTCON3.F3 = 0;

	// ALERT: For the uart to work on 115200 baud rate, we must have a high clock ( >8Mhz)
	OSCCON = 0b11110000;    // speed of oscillator, 8Mhz
	OSCTUNE.F6 = 1; 		// PLL enabled, 8*4 = 32Mhz Operation
	
	ADCON0.F0 = 1;          // enable AD converter
	ADCON1 = 0b00000000;    // AD/digital; all analog
	ADCON2 = 0b10110101;	// 16 TAD, FOsc/16
	
	T0CON = 0b00000000;     // timer0 off

	// set up uart
	// ALERT: For the uart to work on 115200 baud rate, we must have a high clock ( >8Mhz)
	UART1_Init(115200);
	TXSTA = 0b00100100;

	// Set up AD
	//ADC_Init();
	
	for(k = 0; k < CHANNEL_COUNT; k++)
		Data[k] = 0;

	i = -1;

	// Blink the LED to indicate life
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

	if( TXSTA.F1 == 0) // check if transmit register is full
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
	if(i >= CHANNEL_COUNT)
		i = -1;
}

// main program loop
void loop()
{
	int value;
	int k;
	
	for(k=0; k < CHANNEL_COUNT; k++)
	{
		if(k == 10) // channel 10 is hihat channel
		{
			value = ADCsample(k);
			value = value >> 2;
			
			// Zeroes are interpreted as frame-markers, prevent values from containing zeros
			if (value <= 0)
				value = 1;

			Data[k] = (unsigned char)value;
		}
		else if (k == 11) // AD channels are 0-9, channel 10 is hihat, 11 is for digital switches
		{
			value = 1 | (!PORTC.F1 << 1) | (!PORTC.F2 << 2) | (!PORTC.F3 << 3);
			
			Data[k] = (unsigned char)value;
		}
		else // Read normal AD triggers
		{
			value = ADCsample(k);
				
			//value = value >> 2; // divide by 4
			
			if(value > 255)
				value = 255; // Make sure numbers don't overflow
				
			// Zeroes are interpreted as frame-markers, prevent values from containing zeros
			if (value <= 0)
				value = 1;

			if(value > Data[k]) // preserve peaks
				Data[k] = (unsigned char)value;
		}

		TrySendSerial();
	}  
	
	
}


void serialEvent() {
	while (UART1_Data_Ready())
	{
	// get the new byte:
		int input;
		input = UART1_Read(); 
		
		if(input >= 128)
		{
			input = input - 128;
		}
		else
		{
			//if (input <= MAX_CHANNELS)
			//  ChannelCount = input;
		}
	}
}