xmlfsm
======

> **Note:** This project is no longer maintained. It was created for the .NET Frameowrk 1.1 in 2003. I am just archiving it on GitHub as part of a consolidation of my projects. You can find the original article for this project on [The Code Project](http://www.codeproject.com/KB/cs/xmlfsm.aspx).

xmlfsm demonstrates using the .NET Framework to implement a finite state machine (FSM). This project was inspired by the MSDN article [Design Patterns: Solidify Your C# Application Architecture with Design Patterns](http://msdn.microsoft.com/msdnmag/issues/01/07/patterns/patterns.asp). Like the article's author, I believe that using State objects is a more powerful way of implementing this particular design pattern. However, for those that believe in XP's principle of "doing the simplest thing that could possibly work", table-driven FSMs are quite simple to implement.

To make the implementation of the FSM more interesting, I chose to define the table using XML. The format is very simple and defines state and transition elements. Using the example from the MSDN article, here is the state table in XML.

	<?xml version="1.0" ?>

	<fsm name="Vending Machine">
    	<states>
        	<state name="start">
            	<transition input="nickel" next="five" />
            	<transition input="dime" next="ten" />
            	<transition input="quarter" next="start" action="dispense" />
        	</state>
        	<state name="five">
            	<transition input="nickel" next="ten" />
            	<transition input="dime" next="fifteen" />
            	<transition input="quarter" next="start" action="dispense" />
        	</state>
        	<state name="ten">
            	<transition input="nickel" next="fifteen" />
            	<transition input="dime" next="twenty" />
            	<transition input="quarter" next="start" action="dispense" />
        	</state>
        	<state name="fifteen">
            	<transition input="nickel" next="twenty" />
            	<transition input="dime" next="start" action="dispense" />
            	<transition input="quarter" next="start" action="dispense" />
        	</state>
        	<state name="twenty">
            	<transition input="nickel" next="start" action="dispense" />
            	<transition input="dime" next="start" action="dispense" />
            	<transition input="quarter" next="start" action="dispense" />
        	</state>
    	</states>
	</fsm>

Pretty simple. The class XMLStateMachine has three properties (Action, CurrentState, and StateTable) and one method, Next. To use it, simply create an instance of XMLStateMachine, set the StateTable property to the XML file you wish to use and set the CurrentState property to the initial state.

	XMLStateMachine fsm = new XMLStateMachine();
	fsm.StateTable = "vending.xml";
	fsm.CurrentState ="start";

Then, call the Next method with an appropriate input argument. Next returns the new state as well as modifies the CurrentState property.

[NAnt](http://nant.sourceforge.net/) is used to build the sample project. It is based on the [Apache Ant](http://ant.apache.org/) project, which is used to build many Java-based projects. If you cannot afford Visual Studio .NET, or prefer to use your own editor and the command line compilers I highly recommend NAnt.

The code presented here could be expanded in many ways. The Action property could be replaced with an event. The System.Xml.XPath.XPathNavigator class could be used instead of System.Xml.XmlTextReader. But, that would defeat the purpose of implementing "the simplest thing that could possibly work"!

Demo
====

The demo project is a simple command line application that simulates a vending machine using the state table shown above. It randomly generates "currency" and inserts it into the machine. When a sufficient amount of coins has been inserted, a "soda" is dispensed.

License
=======

(The MIT License)

Copyright (c) 2010 Kevin Stewart

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
'Software'), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.