# MarsRover
 #### Navigating robotic rovers to explore a plateau on Mars using given data.

 Sources Description
 ------------------
 * "Mission/" contains inputs of the misson, data handler and mission controller.
 * "NavigationLibrary/" contains rover navigation and position controllers.
 * "RoverTest/" contains tests of navigation handler, position handler, rover abilities and mission controller.
 
  #### You can insert your Input data to Mission/Inputs.txt file ad your Output data to RoverTest/Outputs.txt

Requirments
-----------
* Visual Studio 2022 (64 bit, Version 17.1.1)
* .NET Desktop Application Development Tools
* Target Framework .NET 6.0

Setup
-----
* Install Visual Studio 2022 (64 bit, Version 17.1.1) with .NET Desktop Application Development Tools
* Clone or Download the repository from GitHub

Clone:

      git clone https://github.com/GITburakdeniz/MarsRover.git
    
  Download:    
       
       https://github.com/GITburakdeniz/MarsRover/archive/refs/heads/master.zip
              
              
* If cloned open "MarsRover" folder
 If zip file downloaded, extract it and then open "MarsRover-master" folder.
* Open MarsRover.sln with Visual Studio from "MarsRover" or "MarsRover-master" folder.

Build and Run Project
---------------------------
By default "Startup Project" is "Mission".
In Visual Studio 2022;

* Build "MarsRover Solution" (Ctrl + Shift + B)
* Run "Mission" (F5)

 After run, "Mission" writes the result of the program to the console.

Run All Unit Tests and Output Test (RoverTest MStest Project)
------------------------------------------------------------
 * Run All Unit Tests:
 
    Test Menu -> Run All Tests (Ctrl+R, A)
    
    After run all tests,  "Test Explorer" will appear and all unit test results can be seen.
     
* Output Validation Test (RoverTest->MissionTest->TestMission)

  You can insert your Input data to Mission/Inputs.txt file and your output data to RoverTest/Outputs.txt.
  
   * Mission/Inputs.txt file contains mission input data.
  
   * RoverTest/Outputs.txt contains mission output data.
  
 * To run only "Mission Test" to validate project output data with expected data.
  
     Test Menu -> Test Explorer -> RoverTest-> MissionTest-> TestMission
     
     After run the test, test results can be seen in the explorer.
     
Sample Run and Test
--------------------
Inputs.txt

![Capture3](https://user-images.githubusercontent.com/22982122/158023542-2d26f123-3528-40bc-8b7f-06c24ba97231.PNG)

 Outputs.txt
 
![Capture4](https://user-images.githubusercontent.com/22982122/158023569-09357f71-5066-4615-9417-8417e9606db2.PNG)
 
 Run "Mission"
 
![Capture1](https://user-images.githubusercontent.com/22982122/158023628-6a513959-52f9-4ff9-b86f-64b0ce7530e1.PNG)

Run All Unit Test

![Capture](https://user-images.githubusercontent.com/22982122/158023674-43521b68-eddf-4565-ae4a-e7f3c0da7475.PNG)

 
 


