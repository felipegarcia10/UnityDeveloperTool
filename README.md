**PG29Felipe**



# LUGGAGE GENERATION UNITY DEV TOOL:



**link to the design document**:

https://vfscom-my.sharepoint.com/:w:/g/personal/pg29felipe_vfs_com/IQD4rAZBgnEnRYy5dlSK0EhmAWLkIJWHGWh9oa7vm8jCTZI?e=XZFrLG



**Link to the GitHub repo**:

https://github.com/felipegarcia10/UnityDeveloperTool.git



#### **INSTRUCTIONS:**

* clone the GitHub repo.
* Open the project in Unity version 6.3.8f1
* Once the project is open, go to the "Tools" tab and select "Luggage Generator"
* The "Luggage Generator" window opens.
* for the "Prefab" field, grab one of the prefabs from the "Assets/Prefabs" folder
* fill the rest of the fields as you whish.
* click the "Generate" button to spawn the new piece of luggage
* click the generated piece on the hierarchy and see that piece in the inspector.
* The spawned piece contains a component called “Luggage Piece” that holds all the properties of that specific piece of luggage. 







#### **The Games’s High concept** 



Lobster Luggage Loader is a top-down isometric luggage organization and combo game where you command a tiny lobster called Lobert, who works for United Waterlines as a luggage loader. Your goal is to organize packages into a whale's mouth to ship the highest value combination of luggage. Base luggage gives you points, and specialty luggage acts as a multiplier; it is your job to strategically use these in tandem to generate the highest combo of points and fulfill the quota. 



&#x20;

#### 

#### **The Dev Tool**  



This tool helps the designers generate different variations of “luggage” pieces that they can use to test the points and multipliers system, grid completion, movement and rotations systems, look and feel, among other mechanics that involve these blocks, without having to create each piece variation one by one.  



&#x20;



Here is a description of each field in the “Luggage Generator” dev tool: 



**Block Size:** Each luggage piece is formed by a number of cubes; the “Block size” Defined the size of each individual cube. 



**Prefab:** The prefab of the cube to be used to form this luggage piece. 



**Luggage Shape:** the shape of the resulting luggage, these are all the different option for luggage shapes: 



**Multiplier:** Each Piece can have a multiplier value that changes the value of its neighbor pieces when placed on the grid. 



**Base Value:** The individual value of each piece of luggage. 



**Modifier:** A piece of luggage can have a modifier that adds constraints to it at the moment of placing it in the grid; These are the modifier options: 

&#x20;

Once the designer is ready to generate the piece of luggage, they can click the “Generate” button to spawn the piece in the world. The spawned piece contains a component called “Luggage Piece” that holds all the properties of that specific piece of luggage.  



&#x20;

