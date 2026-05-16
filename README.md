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
<img width="1361" height="512" alt="image" src="https://github.com/user-attachments/assets/17b26ad3-d5be-456b-ad85-43421ee73288" />

### 4.
I used Timelines for the nail rotation and position animation that occurs after the nail trigger collides with an investigated attribute.
It also uses a Signal Emitter to tell the gameController when the animation has finished to update the amount of attributes marked.

## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.

## Open-source assets
- [Abandoned Hospital Assets](https://calv182.itch.io/abandoned-hospital-assetpack)
- [A pile of rusty nails isolated on transparent background](https://stock.adobe.com/Library/urn:aaid:sc:VA6C2:8b1ac274-ebeb-4b5f-8173-ced036f1e8f8?asset_id=1780890752)
- [nail, old rusty nail isolated from background](https://stock.adobe.com/Library/urn:aaid:sc:VA6C2:8b1ac274-ebeb-4b5f-8173-ced036f1e8f8?asset_id=699233079)
