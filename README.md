# Unity-Synthesizer-in-C-Sharp
A synthesizer written in C# utilizing Unity's OnAudioFilterRead method.

[![Alt text](https://img.youtube.com/vi/JHRrez_RK4Q/0.jpg)](https://www.youtube.com/watch?v=JHRrez_RK4Q)

Initially written for a rhythm game prototype as a junior Unity dev years ago, I recently updated the project for compatibility in Unity 2017.
The most interesting and useful component, the synth, is under the Assets/Scripts section- it requires an AudioSource object for the OnAudioFilterRead() function to produce sound.

To test it out, download the project and open the SynthBoard scene. Now, click somewhere. Drag your finger around. Is it making music? Congratulations! Is it not making music? Feel free to click the Issues tab above and we'll sort it out.

Check out the Synth object in the scene for how to build the object in your own projects. 
