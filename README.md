# GDIM33 Vertical Slice
## Milestone 1 Devlog
A Visual Scripting graph in my game is the dialogue input graph under the DialogueController game object. It looks for player input, specifically the SPACE key, using the player input component with the dialogueInputAction input action asset. It does so in the graph with the On Keyboard Input Node. Each time space is first pressed, as denoted by the Action being "Down", the AdvanceDialogue() method is called from the DialogueAdvancer class, which is also under the same gameObject. The method and its class is its own node.

<img width="1226" height="920" alt="image" src="https://github.com/user-attachments/assets/e68c39f9-0d30-401e-a476-9a6662f1cbfe" />

In this new break-down, I simply changed the "location" of the game state managment. Previously, it was under the GameController object. Now, it is under its own object, the Game State one, because I am managing the game states using visual scripting, specifically with a state machine component. Functionally, it does the same as it did before, I just added more specificity with how it changes the player's avaliable input.

The state that occurs directly after starting the game is the Dialogue state, which locks the cursor and sets the camera as well as NPC's initial positions. In order to transition into the Examining/examination state, the player must press the Start Examination button. Once the Examination state is active, the positions of the aforementioned things are changed, the dialogue UI is no longer visible, and the exam UI is visible. Another system that is related to this is that the Figure attributes/anomalies gameobject becomes active and can be interacted with by the player to identify them. These identifications are further imparted to the GameController managing examination status, such as total attributes marked so far. The relevant objects (like UI) for both states are stored as object variables for the States gameobject. Currently, I have not yet implemented the ability to transition from examination to dialogue.
## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- [Abandoned Hospital Assets](https://calv182.itch.io/abandoned-hospital-assetpack)
- 
