Jiggler
=======

About
-----
Jiggler allows you to "Jiggle" assemblies by adding a call to a static method at the start of every non ctor method in an assembly.  We use this to add a random sleep to the start of each method to randomize multi-threaded code and (hopefully) surface hard to find threading issues.

Jiggler makes use of Mono.Cecil to re-write your .NET assemblies.

Usage
-----
	PS> JigglerConsole.exe <Assembly-to-jiggle> <Namespace-to-jiggle> <Jiggle-assembly> <Jiggle-method>
	
Example:

If I had an assembly AssemblyToJiggle.exe with a root namespace AssemblyToJiggleNamespace, and another assembly MyJiggleAssembly.dll that has a static method MyJiggleAssemblyNamespace.MyJiggleClass::MyJiggleStaticMethod() that I wanted to apply to all methods in AssemblyToJiggleNamespace, I would run the following:

	PS> JigglerConsole.exe AssemblyToJiggle.exe AssemblyToJiggleNamespace MyJiggleAssembly.dll MyJiggleAssemblyNamespace.MyJiggleClass.MyJiggleStaticMethod


Build
-----
Build and execute all unit tests.

    PS> .\build
    
Test
----
Run all tests (includes end to end).

	PS> .\build -t runalltests

List all build tasks
--------------------
List of the build tasks.

    PS> .\build -t ?

Notes
-----
A proof of concept is provided by applying the Jiggle.Jiggles.RandomSleepJiggle::Jiggle() method to the SampleApp.
	
License
-------
FreeBSD (see LICENSE.txt)