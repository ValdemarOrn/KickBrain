# KickBrain #



![](./raw/master/ReadmeFiles/Icon-small.png)


# Introduction #

KickBrain is a combination of hardware and PC software that enables drummers to connect their electronic drum set to a computer. It consists of two parts:

[Video showing how to Set Up a simple Snare trigger (Coming soon)]()

## Download

You can download the latest version of the [KickBrain software Here](https://github.com/ValdemarOrn/KickBrain/tree/master/Releases)

Schematics and PCB layouts can be found
[here](https://github.com/ValdemarOrn/KickBrain/tree/master/Schematic)
## The Hardware

![](./raw/master/ReadmeFiles/PCB.png)

KickBrain is a single, very simple PCB. It is laid out as a single sided, through-hole component board and is ideal for hobbyists. The board is powered by a cheap PIC18 8-bit microcontroller. It function is to read the analog input voltages from the inputs and convert them into a digital format.

Unlike most drum modules KickBrain does not actually produce any sound. And what's more, unlike some other *dedicated trigger boxes* it doesn't even output MIDI! Instead, the board acts only as a simple analog-to-digital layer and sends the raw input data to a PC via a RS232 Serial Port. RS232 is an old, simple and well understood technology with plenty of support and information for hobbyists. It's data carrying capacity is not large, but it is enough to provide us with 14 channels of data with latency low enough that is won't bother anyone ( < 2ms).

## The Software

The software part is written in C# and runs on the .NET platform. It will run under Windows 7 and newer without any problems, users of Windows Vista or earlier will need to install .NET framework.

The software provides a visual representation of the input signals that are connected to the hardware device. These signals can then be manipulated and configured in order to set up the best trigger sensitivity. You can re-map signals to shape the velocity curves as you want and each signal can be sent to multiple midi outputs. Another important feature is the ability to filter out crosstalk from individual channels.

**Input Panel**

![](./raw/master/ReadmeFiles/screenshot-small.png)

**Output Panel**

![](./raw/master/ReadmeFiles/screenshot2-small.png)



# FAQ #

## Why not process the signals on the PIC and output MIDI?? ##

Because I wanted the system to be flexible and maintainable. A new version of a Windows executable is trivial to set up, just download and run. Flashing a PIC on the other hand takes more effort and not everyone has a PIC burner available.

## What is the current status of the software?

Stable, but CPU intesive. I won't lie, it's not exactly "light". That said, I can still run two instances on my 2-year old Lenovo X200, along with Reaper, Addictive Drums, Ambience VST and I see about 55% CPU load. So most laptops should be able to run it, just be sure to enable the High Performance power scheme :)

## What is "Background Mode" ? 

You can select Background mode in the File menu. It hides the main window and turns off all the graphical processing and removes those components from the event list so they are not invoked. The graphics are actually responsible for a lot of the CPU load, since it's only using GDI+ and WinForms to draw, so it can be slow.

## Why did you use RS232 instead of USB?

Because USB is a very complex standard and is not suitable for beginners. I wanted to build the simplest board I possibly could to make it easy for everyone to build.

## Will you build me one?

Nope, sorry.

## Should I build one?

hmmmm, that depends. This is still a work in progress. Although both the hardware and software are currently stable with no obvious flaws, there is still work to be done, mainly in lowering the CPU usage of the software. But if you have a beefy computer then you should have no problems.

## I'm getting horrible latency!

That's not a question. But in case of audible latency (which totally messes up your groove, I know!) it's most likely due to the audio driver. Make sure you're using an ASIO drive, and set the latency to 256 samples or lower. Personally I've had good results with a Behringer UCA 202. It's cheap, but I can run it at 5ms latency without any dropouts. 

## What about KickBrain's inherent latency?

KickBrain itself has a latency of about 1.5ms due to the low baudrate of the RS232 bus. The hardware does sampling on a much higher frequency than the PC software works on. If preserves peak-values and then down-samples the signal by dropping unnecessary samples. The peak values are then sent over the serial bus, with each channel having a samplerate of about 750Hz, meaning a maximum latency of 1.33 ms per hit, the average being half that.