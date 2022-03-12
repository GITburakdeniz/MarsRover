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
