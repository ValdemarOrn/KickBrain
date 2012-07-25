# KickBrain #



![](https://github.com/ValdemarOrn/KickBrain/raw/master/ReadmeFiles/Icon-small.png)


# Introduction #

KickBrain is a combination of hardware and PC software that enables drummers to connect their electronic drumset to a computer.

[Video showing how to Set Up a simple Snare trigger](http://www.youtube.com/watch?v=PUKn4v0qlmI)

<iframe width="560" height="315" src="http://www.youtube.com/embed/PUKn4v0qlmI" frameborder="0" allowfullscreen></iframe>

## Download

You can download the latest version of the [KickBrain software Here](https://github.com/ValdemarOrn/KickBrain/tree/master/Releases)

Schematics and PCB layouts can be found
[here](https://github.com/ValdemarOrn/KickBrain/tree/master/Schematic)
## The Hardware

![](https://github.com/ValdemarOrn/KickBrain/raw/master/ReadmeFiles/PCB.png)

KickBrain is a single, very simple PCB. It is laid out as a single sided, through-hole component board and is ideal for hobbyists. The board is powered by a cheap PIC18 8-bit microcontroller. Its function is to read the analog input voltages from the inputs and convert them into a digital format.

Unlike most drum modules KickBrain does not actually produce any sound. And what's more, unlike some other *dedicated trigger boxes* it doesn't even output MIDI. Instead, the board acts only as a simple analog-to-digital layer and sends the raw input data to a PC via a RS232 Serial Port. RS232 is an old, simple and well understood technology with plenty of support and information for hobbyists. It's data carrying capacity is not large, but it is enough to provide us with 14 channels of data with latency low enough that is won't bother anyone ( < 1.5ms).

## The Software

The software part is written in C# and runs on the .NET platform. It will run under Windows 7 and newer versions without any problems, users of Windows Vista or earlier will need to install .NET framework 4.0.

The software provides a visual representation of the input signals that are connected to the hardware device. These signals can then be manipulated and configured in order to set up the best trigger sensitivity. You can re-map signals to shape the velocity curves as you want and each signal can be sent to multiple midi outputs. Another important feature is the ability to filter out crosstalk from individual channels.

**Input Panel**

![](https://github.com/ValdemarOrn/KickBrain/raw/master/ReadmeFiles/screenshot-small.png)

**Output Panel**

![](https://github.com/ValdemarOrn/KickBrain/raw/master/ReadmeFiles/screenshot2-small.png)



# FAQ #

## How is KickBrain licensed?

It is licensed under the very permissive MIT license. You can read the license [here](https://raw.github.com/ValdemarOrn/KickBrain/master/license.txt). Feel free to play around with the code and the schematic as you like. If you make any great improvements then please consider contributing them back to the project so that everyone can benefit from them.

## Why not process the signals on the PIC and output MIDI?? ##

Because I wanted the system to be flexible and maintainable. A new version of a Windows executable is trivial to set up, just download and run. Flashing a PIC on the other hand takes more effort and not everyone has a PIC burner available.

## What is the current status of the software?

Stable, but CPU intesive. I won't lie, it's not exactly "light". That said, I can still run two instances on my 2-year old Lenovo X200, along with Reaper, Addictive Drums, Ambience VST and I see about 55% CPU load. So most laptops should be able to run it, just be sure to enable the High Performance power scheme :)

## What is "Background Mode" ? 

You can select Background mode in the File menu. It hides the main window and turns off all the graphical processing and removes those components from the event list so they are not invoked. The graphics are actually responsible for a lot of the CPU load, since it's only using GDI+ and WinForms to draw, so it can be slow.

## Why did you use RS232 instead of USB?

Because USB is a very complex standard and is not suitable for beginners. I wanted to build the simplest board I possibly could to make it easy for everyone to build.

## What is the format of the input signal?

It's very simple. The software can work with any number of channels. The input signal is of this form:

0, ch1, ch2, ch3..... chN, 0, ch1, ch2, ch3.... chN, 0....

It is simply a stream of bytes, with zero marking the start of a new frame, followed by the value of each channel. This means signals can only be in the range of 1...255. The samplerate is kept floating and new input is processed as soon as it is available.

## What about digital switches?

The KickBrain board has 3 digital switches. Those inputs are multiplexed into a single channel, with each bit in the channel representing one digital switch. Currently, bit 0 is always set to 1, with bits 1,2,3 representing inputs 1,2 and 3 respectively.

## Will you build me a circuit board?

Nope, sorry.

## Should I build one?

That depends. This is still a work in progress. Although both the hardware and software are currently stable with no obvious flaws, there is still work to be done, mainly in lowering the CPU usage of the software. But if you have a beefy computer then you should have no problems. But if you own an Arduino, try using that first.

## What.. I can use an Arduino?!

Yes. You see, since the input protocol is so simple you can set up just about anything to serve as an input module, and that includes an Arduino. There is an Arduino sketch in the Git repository, under ArduinoAudioFastSerial. It simply reads the analog inputs, from zero to five, and outputs the data to the serial port. Channel 5 is used for the hi-hat input, the only difference being that the hi-hat input value is divided by 4, but trigger inputs are simply limited between 1 and 255. You still have to place two protection diodes on every input, one to prevent the signal from going negative, and another to prevent it going (too far) above 5V. **If you don't do this it may damage your Arduino board!** (Schematics will be added soon).

## I'm getting horrible latency!

That's not a question. But in case of audible latency (which totally messes up your groove, I know!) it's most likely due to the audio driver. Make sure you're using an ASIO driver, and set the latency to 256 samples or lower. Personally I've had good results with a Behringer UCA 202. It's cheap, but I can run it at 5ms latency without any dropouts. 

## What about KickBrain's inherent latency?

KickBrain itself has a latency of about 1ms due to the low baudrate of the RS232 bus. The hardware does sampling on a much higher frequency than the PC software works on. It preserves peak values and then down-samples the signal by dropping unnecessary samples. The peak values are then sent over the serial bus, with each channel having a samplerate of about 750Hz, meaning a maximum latency of 1.33 ms per hit, the average being half that.

