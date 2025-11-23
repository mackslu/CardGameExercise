## Outcome of this project
This project actually helped me learn alot more many different area's of both C# and development as a whole, and gave me the opportunity to deepen my understanding across the board. 
In my current role - I mainly make use of ATDD (Acceptance Test-Driven Development),writing tests before any development has occured and then visiting them after development, and iterating over them until they have passed.
This differs somewhat from TDD, as the tests are largely forgotten about until the end of the development cycle. I found that TDD was a much better alternative to ATDD, as it meant I stayed engaged with the overall goals and criteria of the project
and didn't lost track of any functionality. Despite this being a different approach to what I'm used to - I felt as though I ended up excelling with TDD and writing much better code. Alongside TDD,
I also learnt a whole lot about NUnit - a testing framework bundled with JetBrains Rider. Coming from a much less technical testing framework in my current role, NUnit was definetely refreshing and
easy enough to pick-up and understand, with it's strict, non-interpretive assertions giving me a much clearer route for my code. My approach to structuring this project focused on seperation of concerns, which
you can clearly see in the project. I have a seperate project for the tests, the actual backend, and the GUI & CUI components. This means that changes I make within the GUI, or CUI etc are completely
seperate, and will not effect the core backend functionality of the CardGameExercise library - which in my eyes is the correct way to do it, as the GUI, CUI and Testing should rely on the library,
not be interlinked / making use of each other, a dependency relationship. I also considered the accessibility of data within the library. For example, I made sure 'lstCards' was public, as it could be helpful later down the line in one of the other 'child' projects, and has no reason to be abstracted or hidden from the developer.
Ofcourse, there is an extreme to this, things such as lists for error messages - which are purely used internally and are exposed to the developer in other ways have no reason to be public.

Overall, this project definetely reinforced the value of consise and clean architecture, and how important it is to use a modern & widely-used testing-framework as often as possible.
