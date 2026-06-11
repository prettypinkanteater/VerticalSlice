# GDIM33 Vertical Slice
## Milestone 1 Devlog
A Visual Scripting graph in my game is the dialogue input graph under the DialogueController game object. It looks for player input, specifically the SPACE key, using the player input component with the dialogueInputAction input action asset. It does so in the graph with the On Keyboard Input Node. Each time space is first pressed, as denoted by the Action being "Down", the AdvanceDialogue() method is called from the DialogueAdvancer class, which is also under the same gameObject. The method and its class is its own node.

<img width="1226" height="920" alt="image" src="https://github.com/user-attachments/assets/e68c39f9-0d30-401e-a476-9a6662f1cbfe" />

In this new break-down, I simply changed the "location" of the game state managment. Previously, it was under the GameController object. Now, it is under its own object, the Game State one, because I am managing the game states using visual scripting, specifically with a state machine component. Functionally, it does the same as it did before, I just added more specificity with how it changes the player's avaliable input.

The state that occurs directly after starting the game is the Dialogue state, which locks the cursor and sets the camera as well as NPC's initial positions. In order to transition into the Examining/examination state, the player must press the Start Examination button. Once the Examination state is active, the positions of the aforementioned things are changed, the dialogue UI is no longer visible, and the exam UI is visible. Another system that is related to this is that the Figure attributes/anomalies gameobject becomes active and can be interacted with by the player to identify them. These identifications are further imparted to the GameController managing examination status, such as total attributes marked so far. The relevant objects (like UI) for both states are stored as object variables for the States gameobject. Currently, I have not yet implemented the ability to transition from examination to dialogue.

## Milestone 2 Devlog

### 1.
I did some of this before this milestone so I am partially reflecting what I did so far.
1. Code logic signaling end of shift
	1. Create a Shift Assessment state
	1. Add transition logic, like a button or a bool triggering the transition into the Shift Assessment state 
	2. In this state, hide all examination UI
2. Code logic comparing total Attributes and Figures with identified Attributes and Figures (this is mostly visible during the actual exam)
	1. Create variables storing both the amount of Attributes and Figures the player has identified
	2. Create variables storing the total amount of Figures and Attributes present in the shift
	3. Create a C# method seeing if the identified and total variables match up
	4. Call the C# method in the Shift Assessment state
3. Implement Visual/UI Feedback
	1. Create UI GameObject: Shift Grade Text 
	2. Make it so that the UI ONLY appears once the shift has ENDED
	3. Within the method comparing examination stats, update the shift quality text as fit

### 2. 
The task steps break-down activity & quiz both helped me build a feature for this Milestone because I was very specific about the components of each step. Though, I did not really reference it and mostly referenced my notes/documentation which were essentially the same thing just less contextualized. To be honest, I would not really improve anything in my break-downs to be more helpful because I overthink and try to specify in a heirarchy as much as I can.
### 3. 
I called a C# method from the GameController script in my GameState Graph so that the logic assessing shift quality runs once the state is Shift Assessment. This bridge exists
mostly because it is easier for me to access and compare variables. 
Lowkey a massive graph so hard to balance visibility and breadth of shot.
<img width="1058" height="817" alt="image" src="https://github.com/user-attachments/assets/e7c5dd36-5a64-4dcf-a3c7-7d5214ac5c49" />


### 4.
I used Timelines for the nail rotation and position animation that occurs after the nail trigger collides with an investigated attribute.
It also uses a Signal Emitter to tell the gameController when the animation has finished to update the amount of attributes marked. Currently, I have not implemented the nail resetting to a more suitable position after appearing again.

## Milestone 3 Devlog

### 1.
My Shader Graph creates an outline by utilizing the 2D texture image, in this case the sprite image that is stored as a graph property, of the nail that is used in the exam with a Sample Texture 2D node. Specifically, it displays, stores, and helps communicate the Alpha values, or opaqueness, of each pixel in it.
The graph does multiple things with this value, it subtracts the original opaque alpha values, where the sprite actually is, of the texture from the newly "added" alpha values, so that those pixels become the outline and not just a colorless silhouette. It then adds the original texture back to the resulting outline so that the sprite, and all the colors with those respective alpha values, are also visible.
Most importantly, the graph contains a sub-graph that references the texture's height and width and uses the divide node to divide those values by the offset value, manipulating the positional placement of the rendered opaque outline on the y-axis (upper + lower) and x-axis (left + right).  

#### Main Graph:
<img width="1627" height="949" alt="image" src="https://github.com/user-attachments/assets/aef1e350-51f4-4e32-a7ad-8e899a02973d" />

#### Sub-Graph
<img width="1431" height="647" alt="image" src="https://github.com/user-attachments/assets/83a62896-a065-441d-863f-36e4f09ac0e8" />

Note that due to the shape of the sprite, the outline on the head of the nail is a bit strange because I believe it has a difficult time seperating the edges of the upper, lower, and left-side outlines.

### 2.
I made the dialogue boxes change color in order to differentiate the dialogue speakers for narrative clarity. I also added a brief tutorial window/text during the first shift to guide the player through the gameplay loop.

### 3.
I added a new shift containing 2 more patient NPCs, one of them being a human so the potential of getting an incorrect attribute mark is possible. My gameplay loop involves greeting patients, examining patients by investigating any -> marking any Figure attributes then identifying the patient as Figure or human, and getting the quality of the shift's examinations assessed for accuracy.

#### Notes
There is no more intended content after the two shifts, have not implemented disability of new shift button. Gary is potentially placeholder content for testing "human" patients, I feel maternal towards him and I would mourn his removal. But, we shall see.

## Final Devlog

### 1. (this is lowkey the same stuff i talked about in my extra cred lol, also im not "brief" because theres sub concepts to the main concepts)
The core gameplay loop in my game is contained in "shifts", each consisting of the player greeting a/multiple patient(s) and administering an investigative body examination of them before finalizing their identification of the patient. At the end of each shift, the player's performance, based on the accuracy and/or quantity of their identifications and marked anomalous attribtutes, is assessed and their shift quality is communicated.
The content implemented in my game makes up 2 shifts and I have a total of 3 patient NPCs. Each NPC has their unique identity and attributes, either actual anomalous ones or suspicious human ones. This equates to the playthrough of the gameplay loop 3 times.

The original plan for my Vertical Slice was followed in terms of mechanics, significantly the body examinations and all its constituent mechanics, but I did add a little more content than planned for, another NPC, just because of milestone requirements. These implementations illustrate to the player what the final game will be like by giving them the experience of the core gameplay loop with a variety of patient characters to support their understanding of the environment.

### 2.
My rendering effect is activated when the mouse is hovered over the nail. This includes when it first makes contact with the nail and when the player drags it around. This is all done in the C# file called Nail. I used the OnPointerEnter() and OnPointerExit() Unity methods specifically. Firstly, I had to make the Nail class inherit from the IPointerEnterHandler and IPointerExitHandler interfaces in order to use the methods. As their names suggest, they are each called when the 
pointer/cursor does what their respective name entails. In the same class, I declared the dragging boolean variable. In hindsight, the name could have been changed to be more accurate to the action it was tracking. Anyways, the bool is set to true in OnPointerEnter() and false in OnPointerExit. In the Update() method in the same class, there is an if statement with the condition of the value of dragging. If it is true, then the mouse is on it and the material should be the outline material. 
If it is not, the mouse is not on it and the material should not be the outline material. In this case, I set it to null. Since the Update() method runs every frame, there is timely visual feedback when it comes to the mouse position in relativity to the nail.

### 3.
My process for breaking down a large project into specific systems is pretty much using the bubble diagram break-downs we used in all the GDIM 30 classes. The precursor foundation of this for me is specifying the mechanics I intend to implement so I can then work towards defining the details that support them, like the variables or methods. Having the visual/textual support of the diagram helps with retaining and/or referencing all the outlined specifics/details.

As such, I will likely use the bubble diagrams in my planning process because I like their clear depiction of objects and their constituent parts, both behaviour/methods and information/variables, as well as the relationships between objects based on their parts. Big fan of the use of visual and text compositional hierarchy to illustrate this.

Breaking down projects can help you see the scope of it because you're able to more accurately assess the workload/depth of tasks required and understand if completion is realistic or not. By depth, I mean the knowledge required in order to accomplish it. If a mechanic seems difficult to nail down the specifics about, it should signal a lack of knowledge, thus the need to gain that knowledge, and more time than available required to implement it.

I think this was effective for the process of creating my Vertical Slice. I spent a lot of effort with detail designing the breakdown, the objects and constituents, so I ended up internalizing the specifics of what I needed to do relatively early on in my process. It made it less daunting to actually work on because nothing was vague or undefined. For example, I knew that the nails needed to be able to be dragged upon the player clicking and dragging so I focused on understanding how to sense the cursor's location/interaction with it. All in all, this solidifies my willingness to use this process/diagram again.

## Open-source assets
- [Abandoned Hospital Assets](https://calv182.itch.io/abandoned-hospital-assetpack)
- [A pile of rusty nails isolated on transparent background](https://stock.adobe.com/Library/urn:aaid:sc:VA6C2:8b1ac274-ebeb-4b5f-8173-ced036f1e8f8?asset_id=1780890752)
- [nail, old rusty nail isolated from background](https://stock.adobe.com/Library/urn:aaid:sc:VA6C2:8b1ac274-ebeb-4b5f-8173-ced036f1e8f8?asset_id=699233079)
- [Flesh Impact Sound Effect](https://pixabay.com/sound-effects/film-special-effects-flesh-impact-266316/)