
_ADCsample:

;Kickbrain.c,12 :: 		unsigned ADCsample(unsigned short channel)
;Kickbrain.c,16 :: 		channel = (channel & 0x0F) << 2;
	MOVLW       15
	ANDWF       FARG_ADCsample_channel+0, 0 
	MOVWF       R2 
	MOVF        R2, 0 
	MOVWF       R0 
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R0, 1 
	BCF         R0, 0 
	MOVF        R0, 0 
	MOVWF       FARG_ADCsample_channel+0 
;Kickbrain.c,17 :: 		ADCON0 = ADCON0 & 0b11000011;
	MOVLW       195
	ANDWF       ADCON0+0, 1 
;Kickbrain.c,18 :: 		ADCON0 = ADCON0 | channel;
	MOVF        R0, 0 
	IORWF       ADCON0+0, 1 
;Kickbrain.c,19 :: 		ADCON0.F1 = 1;
	BSF         ADCON0+0, 1 
;Kickbrain.c,22 :: 		while(ADCON0.F1 == 1)
L_ADCsample0:
	BTFSS       ADCON0+0, 1 
	GOTO        L_ADCsample1
;Kickbrain.c,23 :: 		{TrySendSerial();}
	CALL        _TrySendSerial+0, 0
	GOTO        L_ADCsample0
L_ADCsample1:
;Kickbrain.c,25 :: 		output = (ADRESH & 0b00000011);
	MOVLW       3
	ANDWF       ADRESH+0, 0 
	MOVWF       ADCsample_output_L0+0 
	CLRF        ADCsample_output_L0+1 
	MOVLW       0
	ANDWF       ADCsample_output_L0+1, 1 
	MOVLW       0
	MOVWF       ADCsample_output_L0+1 
;Kickbrain.c,26 :: 		output = output * 256;
	MOVF        ADCsample_output_L0+0, 0 
	MOVWF       R1 
	CLRF        R0 
	MOVF        R0, 0 
	MOVWF       ADCsample_output_L0+0 
	MOVF        R1, 0 
	MOVWF       ADCsample_output_L0+1 
;Kickbrain.c,27 :: 		output = output + ADRESL;
	MOVF        ADRESL+0, 0 
	ADDWF       R0, 1 
	MOVLW       0
	ADDWFC      R1, 1 
	MOVF        R0, 0 
	MOVWF       ADCsample_output_L0+0 
	MOVF        R1, 0 
	MOVWF       ADCsample_output_L0+1 
;Kickbrain.c,28 :: 		return output;
;Kickbrain.c,29 :: 		}
	RETURN      0
; end of _ADCsample

_main:

;Kickbrain.c,31 :: 		void main()
;Kickbrain.c,35 :: 		TRISA = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISA+0 
;Kickbrain.c,36 :: 		TRISE = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISE+0 
;Kickbrain.c,37 :: 		TRISB = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISB+0 
;Kickbrain.c,39 :: 		TRISC = 0b10111111; // inputs, uart TX P6 Output
	MOVLW       191
	MOVWF       TRISC+0 
;Kickbrain.c,40 :: 		TRISD = 0b11111110; // inputs, LED output P0
	MOVLW       254
	MOVWF       TRISD+0 
;Kickbrain.c,42 :: 		PORTB = 0;
	CLRF        PORTB+0 
;Kickbrain.c,43 :: 		PORTA = 0;
	CLRF        PORTA+0 
;Kickbrain.c,44 :: 		PORTC = 0;
	CLRF        PORTC+0 
;Kickbrain.c,45 :: 		PORTD = 0;
	CLRF        PORTD+0 
;Kickbrain.c,48 :: 		INTCON = 0b00000000;
	CLRF        INTCON+0 
;Kickbrain.c,49 :: 		INTCON2.F7 = 1;
	BSF         INTCON2+0, 7 
;Kickbrain.c,50 :: 		INTCON3.F4 = 0;
	BCF         INTCON3+0, 4 
;Kickbrain.c,51 :: 		INTCON3.F3 = 0;
	BCF         INTCON3+0, 3 
;Kickbrain.c,54 :: 		OSCCON = 0b11110000;    // speed of oscillator, 8Mhz
	MOVLW       240
	MOVWF       OSCCON+0 
;Kickbrain.c,55 :: 		OSCTUNE.F6 = 1; 		// PLL enabled, 8*4 = 32Mhz Operation
	BSF         OSCTUNE+0, 6 
;Kickbrain.c,57 :: 		ADCON0.F0 = 1;          // enable AD converter
	BSF         ADCON0+0, 0 
;Kickbrain.c,58 :: 		ADCON1 = 0b00000000;    // AD/digital; all analog
	CLRF        ADCON1+0 
;Kickbrain.c,59 :: 		ADCON2 = 0b10110101;	// 16 TAD, FOsc/16
	MOVLW       181
	MOVWF       ADCON2+0 
;Kickbrain.c,61 :: 		T0CON = 0b00000000;     // timer0 off
	CLRF        T0CON+0 
;Kickbrain.c,65 :: 		UART1_Init(115200);
	MOVLW       16
	MOVWF       SPBRG+0 
	BSF         TXSTA+0, 2, 0
	CALL        _UART1_Init+0, 0
;Kickbrain.c,66 :: 		TXSTA = 0b00100100;
	MOVLW       36
	MOVWF       TXSTA+0 
;Kickbrain.c,71 :: 		for(k = 0; k < CHANNEL_COUNT; k++)
	CLRF        main_k_L0+0 
	CLRF        main_k_L0+1 
L_main2:
	MOVLW       128
	XORWF       main_k_L0+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main33
	MOVLW       12
	SUBWF       main_k_L0+0, 0 
L__main33:
	BTFSC       STATUS+0, 0 
	GOTO        L_main3
;Kickbrain.c,72 :: 		Data[k] = 0;
	MOVLW       _Data+0
	ADDWF       main_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      main_k_L0+1, 0 
	MOVWF       FSR1H 
	CLRF        POSTINC1+0 
;Kickbrain.c,71 :: 		for(k = 0; k < CHANNEL_COUNT; k++)
	INFSNZ      main_k_L0+0, 1 
	INCF        main_k_L0+1, 1 
;Kickbrain.c,72 :: 		Data[k] = 0;
	GOTO        L_main2
L_main3:
;Kickbrain.c,74 :: 		i = -1;
	MOVLW       255
	MOVWF       _i+0 
	MOVLW       255
	MOVWF       _i+1 
;Kickbrain.c,77 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,78 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main5:
	DECFSZ      R13, 1, 1
	BRA         L_main5
	DECFSZ      R12, 1, 1
	BRA         L_main5
	DECFSZ      R11, 1, 1
	BRA         L_main5
	NOP
;Kickbrain.c,79 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,80 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main6:
	DECFSZ      R13, 1, 1
	BRA         L_main6
	DECFSZ      R12, 1, 1
	BRA         L_main6
	DECFSZ      R11, 1, 1
	BRA         L_main6
	NOP
;Kickbrain.c,81 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,82 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main7:
	DECFSZ      R13, 1, 1
	BRA         L_main7
	DECFSZ      R12, 1, 1
	BRA         L_main7
	DECFSZ      R11, 1, 1
	BRA         L_main7
	NOP
;Kickbrain.c,83 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,84 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main8:
	DECFSZ      R13, 1, 1
	BRA         L_main8
	DECFSZ      R12, 1, 1
	BRA         L_main8
	DECFSZ      R11, 1, 1
	BRA         L_main8
	NOP
;Kickbrain.c,85 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,86 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main9:
	DECFSZ      R13, 1, 1
	BRA         L_main9
	DECFSZ      R12, 1, 1
	BRA         L_main9
	DECFSZ      R11, 1, 1
	BRA         L_main9
	NOP
;Kickbrain.c,87 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,88 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main10:
	DECFSZ      R13, 1, 1
	BRA         L_main10
	DECFSZ      R12, 1, 1
	BRA         L_main10
	DECFSZ      R11, 1, 1
	BRA         L_main10
	NOP
;Kickbrain.c,89 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,90 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main11:
	DECFSZ      R13, 1, 1
	BRA         L_main11
	DECFSZ      R12, 1, 1
	BRA         L_main11
	DECFSZ      R11, 1, 1
	BRA         L_main11
	NOP
;Kickbrain.c,92 :: 		while(1)
L_main12:
;Kickbrain.c,94 :: 		loop();
	CALL        _loop+0, 0
;Kickbrain.c,95 :: 		}
	GOTO        L_main12
;Kickbrain.c,96 :: 		}
	GOTO        $+0
; end of _main

_TrySendSerial:

;Kickbrain.c,98 :: 		void TrySendSerial()
;Kickbrain.c,102 :: 		if( TXSTA.F1 == 0) // check if transmit register is full
	BTFSC       TXSTA+0, 1 
	GOTO        L_TrySendSerial14
;Kickbrain.c,103 :: 		return;
	RETURN      0
L_TrySendSerial14:
;Kickbrain.c,105 :: 		if(i == -1)
	MOVLW       255
	XORWF       _i+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__TrySendSerial34
	MOVLW       255
	XORWF       _i+0, 0 
L__TrySendSerial34:
	BTFSS       STATUS+0, 2 
	GOTO        L_TrySendSerial15
;Kickbrain.c,108 :: 		TXREG = 0;
	CLRF        TXREG+0 
;Kickbrain.c,109 :: 		}
	GOTO        L_TrySendSerial16
L_TrySendSerial15:
;Kickbrain.c,112 :: 		output = Data[i];
	MOVLW       _Data+0
	ADDWF       _i+0, 0 
	MOVWF       R0 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      _i+1, 0 
	MOVWF       R1 
	MOVFF       R0, FSR0L
	MOVFF       R1, FSR0H
	MOVF        POSTINC0+0, 0 
	MOVWF       TXREG+0 
;Kickbrain.c,113 :: 		TXREG = output;
;Kickbrain.c,114 :: 		Data[i] = 0;
	MOVFF       R0, FSR1L
	MOVFF       R1, FSR1H
	CLRF        POSTINC1+0 
;Kickbrain.c,115 :: 		}
L_TrySendSerial16:
;Kickbrain.c,117 :: 		i++;
	INFSNZ      _i+0, 1 
	INCF        _i+1, 1 
;Kickbrain.c,118 :: 		if(i >= CHANNEL_COUNT)
	MOVLW       128
	XORWF       _i+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__TrySendSerial35
	MOVLW       12
	SUBWF       _i+0, 0 
L__TrySendSerial35:
	BTFSS       STATUS+0, 0 
	GOTO        L_TrySendSerial17
;Kickbrain.c,119 :: 		i = -1;
	MOVLW       255
	MOVWF       _i+0 
	MOVLW       255
	MOVWF       _i+1 
L_TrySendSerial17:
;Kickbrain.c,120 :: 		}
	RETURN      0
; end of _TrySendSerial

_loop:

;Kickbrain.c,123 :: 		void loop()
;Kickbrain.c,128 :: 		for(k=0; k < CHANNEL_COUNT; k++)
	CLRF        loop_k_L0+0 
	CLRF        loop_k_L0+1 
L_loop18:
	MOVLW       128
	XORWF       loop_k_L0+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop36
	MOVLW       12
	SUBWF       loop_k_L0+0, 0 
L__loop36:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop19
;Kickbrain.c,130 :: 		if(k == 10) // channel 10 is hihat channel
	MOVLW       0
	XORWF       loop_k_L0+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop37
	MOVLW       10
	XORWF       loop_k_L0+0, 0 
L__loop37:
	BTFSS       STATUS+0, 2 
	GOTO        L_loop21
;Kickbrain.c,132 :: 		value = ADCsample(k);
	MOVF        loop_k_L0+0, 0 
	MOVWF       FARG_ADCsample_channel+0 
	CALL        _ADCsample+0, 0
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,133 :: 		value = value >> 2;
	MOVF        R0, 0 
	MOVWF       R2 
	MOVF        R1, 0 
	MOVWF       R3 
	RRCF        R3, 1 
	RRCF        R2, 1 
	BCF         R3, 7 
	BTFSC       R3, 6 
	BSF         R3, 7 
	RRCF        R3, 1 
	RRCF        R2, 1 
	BCF         R3, 7 
	BTFSC       R3, 6 
	BSF         R3, 7 
	MOVF        R2, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R3, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,136 :: 		if (value <= 0)
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       R3, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop38
	MOVF        R2, 0 
	SUBLW       0
L__loop38:
	BTFSS       STATUS+0, 0 
	GOTO        L_loop22
;Kickbrain.c,137 :: 		value = 1;
	MOVLW       1
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop22:
;Kickbrain.c,139 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        loop_value_L0+0, 0 
	MOVWF       POSTINC1+0 
;Kickbrain.c,140 :: 		}
	GOTO        L_loop23
L_loop21:
;Kickbrain.c,141 :: 		else if (k == 11) // AD channels are 0-9, channel 10 is hihat, 11 is for digital switches
	MOVLW       0
	XORWF       loop_k_L0+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop39
	MOVLW       11
	XORWF       loop_k_L0+0, 0 
L__loop39:
	BTFSS       STATUS+0, 2 
	GOTO        L_loop24
;Kickbrain.c,143 :: 		value = 1 | (!PORTC.F1 << 1) | (!PORTC.F2 << 2) | (!PORTC.F3 << 3);
	BTFSC       PORTC+0, 1 
	GOTO        L__loop40
	BSF         4056, 0 
	GOTO        L__loop41
L__loop40:
	BCF         4056, 0 
L__loop41:
	CLRF        R3 
	BTFSC       4056, 0 
	INCF        R3, 1 
	MOVF        R3, 0 
	MOVWF       R0 
	MOVLW       0
	MOVWF       R1 
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	MOVLW       1
	IORWF       R0, 0 
	MOVWF       R4 
	MOVF        R1, 0 
	MOVWF       R5 
	MOVLW       0
	IORWF       R5, 1 
	BTFSC       PORTC+0, 2 
	GOTO        L__loop42
	BSF         4056, 0 
	GOTO        L__loop43
L__loop42:
	BCF         4056, 0 
L__loop43:
	CLRF        R3 
	BTFSC       4056, 0 
	INCF        R3, 1 
	MOVF        R3, 0 
	MOVWF       R0 
	MOVLW       0
	MOVWF       R1 
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	MOVF        R0, 0 
	IORWF       R4, 1 
	MOVF        R1, 0 
	IORWF       R5, 1 
	BTFSC       PORTC+0, 3 
	GOTO        L__loop44
	BSF         4056, 0 
	GOTO        L__loop45
L__loop44:
	BCF         4056, 0 
L__loop45:
	CLRF        R3 
	BTFSC       4056, 0 
	INCF        R3, 1 
	MOVLW       3
	MOVWF       R2 
	MOVF        R3, 0 
	MOVWF       R0 
	MOVLW       0
	MOVWF       R1 
	MOVF        R2, 0 
L__loop46:
	BZ          L__loop47
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	ADDLW       255
	GOTO        L__loop46
L__loop47:
	MOVF        R4, 0 
	IORWF       R0, 1 
	MOVF        R5, 0 
	IORWF       R1, 1 
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,145 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        R0, 0 
	MOVWF       POSTINC1+0 
;Kickbrain.c,146 :: 		}
	GOTO        L_loop25
L_loop24:
;Kickbrain.c,149 :: 		value = ADCsample(k);
	MOVF        loop_k_L0+0, 0 
	MOVWF       FARG_ADCsample_channel+0 
	CALL        _ADCsample+0, 0
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,153 :: 		if(value > 255)
	MOVLW       128
	MOVWF       R2 
	MOVLW       128
	XORWF       R1, 0 
	SUBWF       R2, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop48
	MOVF        R0, 0 
	SUBLW       255
L__loop48:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop26
;Kickbrain.c,154 :: 		value = 255; // Make sure numbers don't overflow
	MOVLW       255
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop26:
;Kickbrain.c,157 :: 		if (value <= 0)
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       loop_value_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop49
	MOVF        loop_value_L0+0, 0 
	SUBLW       0
L__loop49:
	BTFSS       STATUS+0, 0 
	GOTO        L_loop27
;Kickbrain.c,158 :: 		value = 1;
	MOVLW       1
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop27:
;Kickbrain.c,160 :: 		if(value > Data[k]) // preserve peaks
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR2L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR2H 
	MOVF        POSTINC2+0, 0 
	MOVWF       R1 
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       loop_value_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop50
	MOVF        loop_value_L0+0, 0 
	SUBWF       R1, 0 
L__loop50:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop28
;Kickbrain.c,161 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        loop_value_L0+0, 0 
	MOVWF       POSTINC1+0 
L_loop28:
;Kickbrain.c,162 :: 		}
L_loop25:
L_loop23:
;Kickbrain.c,164 :: 		TrySendSerial();
	CALL        _TrySendSerial+0, 0
;Kickbrain.c,128 :: 		for(k=0; k < CHANNEL_COUNT; k++)
	INFSNZ      loop_k_L0+0, 1 
	INCF        loop_k_L0+1, 1 
;Kickbrain.c,165 :: 		}
	GOTO        L_loop18
L_loop19:
;Kickbrain.c,168 :: 		}
	RETURN      0
; end of _loop

_serialEvent:

;Kickbrain.c,171 :: 		void serialEvent() {
;Kickbrain.c,172 :: 		while (UART1_Data_Ready())
L_serialEvent29:
	CALL        _UART1_Data_Ready+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_serialEvent30
;Kickbrain.c,176 :: 		input = UART1_Read();
	CALL        _UART1_Read+0, 0
	MOVF        R0, 0 
	MOVWF       serialEvent_input_L1+0 
	MOVLW       0
	MOVWF       serialEvent_input_L1+1 
;Kickbrain.c,178 :: 		if(input >= 128)
	MOVLW       128
	XORWF       serialEvent_input_L1+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__serialEvent51
	MOVLW       128
	SUBWF       serialEvent_input_L1+0, 0 
L__serialEvent51:
	BTFSS       STATUS+0, 0 
	GOTO        L_serialEvent31
;Kickbrain.c,180 :: 		input = input - 128;
	MOVLW       128
	SUBWF       serialEvent_input_L1+0, 1 
	MOVLW       0
	SUBWFB      serialEvent_input_L1+1, 1 
;Kickbrain.c,181 :: 		}
	GOTO        L_serialEvent32
L_serialEvent31:
;Kickbrain.c,186 :: 		}
L_serialEvent32:
;Kickbrain.c,187 :: 		}
	GOTO        L_serialEvent29
L_serialEvent30:
;Kickbrain.c,188 :: 		}
	RETURN      0
; end of _serialEvent
