## Installing Python 2.7 and running PartitionFinder in a conda environment

An easy way to install an old version of an application that requires an atypical configuration that may clash with other applications if globally installed is by using a Conda environment. These environments run on top of an existing operating system but may provide a completely different environment to the programs running them.  
Conda environments are hosted by a program such as Anaconda or Miniconda which can be downloaded from (https://www.anaconda.com/download/success)[https://www.anaconda.com/download/success]. For this guide I installed Anaconda by downloading it and then running the *.msi installation executable file. If installed for all users, it is installed at:  
> C:\ProgramData\Anaconda3\,   

while if installed for a single user, it is placed at:

> C:\users\<user name>Anaconda3\

Once Anaconda is installed, a conda environment can be created using:

conda create --name myenv python=2.7 

Where myenv is the environment's name and can be any text, such as Python2.7 or partitionfinder. The environment has to be activated before it can be used:

> conda activate myenv

You may have to run:

> conda init

after creating the environment. Once activated, the command prompt will change to show you are in an environment, for example:

> C:\Users\msjimc>

changes too:

>  (myenv) C:\Users\msjimc>


While the environment has Python 2.7, some packages need adding for PartitionFinder2 to run. These can be added with:

> conda install numpy pandas pytables pyparsing scipy scikit-learn

Once the environment is updated, partition finder can be run by issuing this command:

> python \<path>PartitionFinder.py <work folder>

Where:
 \<path> is the location of the PartitionFinder.py file.
 \<work folder> is the folder that contains the alignment and the configuration file and in which the results will be saved.

 Once it has been set up, all analysis can be run with the following commands:

 > conda activate myenv   
 > python \<path>PartitionFinder.py <work folder>

### Batch files

The analysis can be run using a batch file (*.bat); however, to get all the commands to run you may need to add the __call__ keyword to the commands:

 > call conda activate myenv   
 > call python PartitionFinder.py folder1  
 > call python PartitionFinder.py folder2  
 > call python PartitionFinder.py folder3  

In this case, PartitionFinder runs three times processing data in folder1, then folder2 and finally forder3.

