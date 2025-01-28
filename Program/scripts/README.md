# Installing the aligners on Linux without admin rights

## Assumptions

For this guide it is assumed that you are working on a centrally administered Linux server and so don't have admin rights and only files in your home folder are safe from an automated file deletion policy. However, the home folder is too small for lots of data, so you work in a folder called /nobackup/workFolder. 

Consequently, open a terminal and make and enter the __programs__ folder.

> mkdir -p ~programs;   
>cd ~/programs; 

Each of the scripts on [GitHub](../scripts/) is then downloaded to this folder. 

***Note:*** 
I started the commands that run the scripts with ***bash***, however, if you make the scripts executable, you can omit the ***bash*** command. 

***Note:*** 
Since your web browser may wrap a single command of text across multiple lines, I've terminated each command with a ';' character. These can be omitted but will not affect the execution of the commands if retained. 

## Installing ClustalW2 and using the bash_clustalw.sh script
### Installing ClustalW2
> mkdir -p ~programs;   
>cd ~/programs;   
> wget http://www.clustal.org/download/current/clustalw-2.1-linux-x86_64-libcppstatic.tar.gz;  
> tar xvfz clustalw-2.1-linux-x86_64-libcppstatic.tar.gz;  

### Running clustalw2
> cd /nobackup/workFolder/;   
> bash ~/programs/bash_clustalw2.sh ~/programs/clustalw-2.1-linux-x86_64-libcppstatic/clustalw2 /nobackup/workFolder/;

The aligned data should appear in the /nobackup/workFolder/clustal folder along with a *.dnd file for each alignment. 

## Installing MAFFT and using the bash_mafft.sh script 
 ### Installing MAFFT  

> mkdir -p ~programs;   
>cd ~/programs;   
> wget https://mafft.cbrc.jp/alignment/software/mafft-7.526-linux.tgz;   
> tar xfvz programs/mafft-7.526-linux.tgz;    

### Running MAFFT
> cd /nobackup/workFolder/;  
> bash ~/programs/bash_mafft.sh ~/programs/mafft-linux64/mafft.bat /nobackup/workFolder/;

**Note:** Select the ___mafft.bat___ file, not the executable file in **~/programs/mafft-linux64/bin**  

The aligned data should appear in the /nobackup/workFolder/mafft.

## Installing PRANK and using the bash_prank.sh script
### Installing PRANK

> mkdir -p ~programs;   
>cd ~/programs;   
> wget http://wasabiapp.org/download/prank/prank.source.170427.tgz;   
> tar xvfz prank.source.170427.tgz;
> cd prank-msa/src;   
> make;   
  
### Running PRANK

> cd /nobackup/workFolder/;  
> bash ~/programs/bash_prank.sh ~/programs/prank-msa/src/prank /nobackup/workFolder/;
 
The aligned data should appear in the /nobackup/workFolder/prank.

## Installing Muscle and using the bash_muscle.sh script
### Installing muscle

> mkdir -p ~programs;   
>cd ~/programs;   
wget https://github.com/rcedgar/muscle/releases/download/5.1.0/muscle5.1.linux_intel64;   

### Running Muscle
> cd /nobackup/workFolder/;  
> bash ~/programs/bash_muscle.sh ~/programs/muscle5.1.linux_intel64 /nobackup/workFolder/;

The aligned data should appear in the /nobackup/workFolder/muscle.

## Combining the data files into a single alignment

Since the resultant file should be either all DNA sequences or protein sequences, if the alignment folder has both types of data, you need to place each type into separate subfolders. 

The [p_CombineMultiFastaFilesToOneMultiFasta.py](p_CombineMultiFastaFilesToOneMultiFasta.py) python script will combine fasta files based on the name of the sequence in each file, so all sequences linked to species "A" are combined to a single entry called "A", all sequences linked to species "B" are combined to a single entry called "B", etc.

### Running p_CombineMultiFastaFilesToOneMultiFasta.py

> cd /nobackup/workFolder/;  
> python ~/programs/p_CombineMultiFastaFilesToOneMultiFasta.py /nobackup/workFolder/clustal;

This creates the supermatrix2.fa file in /nobackup/workFolder/clustal

> python ~/programs/p_CombineMultiFastaFilesToOneMultiFasta.py /nobackup/workFolder/mafft;

This creates the supermatrix2.fa file in /nobackup/workFolder/mafft

> python ~/programs/p_CombineMultiFastaFilesToOneMultiFasta.py /nobackup/workFolder/prank;

This creates the supermatrix2.fa file in /nobackup/workFolder/prank

> python ~/programs/p_CombineMultiFastaFilesToOneMultiFasta.py /nobackup/workFolder/muscle;

This creates the supermatrix2.fa file in /nobackup/workFolder/muscle

## Installing GBlocks and using the bash_gblocks.sh script
### Notes
Like the combining of alignments, GBlocks requires different commands for DNA and protein alignments. Therefore, DNA and protein sequences need to be placed in different folders.

The different aligners and the p_CombineMultiFastaFilesToOneMultiFasta.py script produce files with *.fa, *.fas or *.fasta extensions and so the bash_gblocks.sh looks for each file extension in turn. However, this means that if you run GBlocks on a folder twice, it will process the original alignments plus those created by GBlocks on the first execution.

### Installing muscle

> mkdir -p ~programs;   
>cd ~/programs;   
wget  https://www.biologiaevolutiva.org/jcastresana/Gblocks/Gblocks_Linux64_0.91b.tar.Z;    
> tar xvf Gblocks_Linux64_0.91b.tar;   


### Running GBlocks for protein sequences
> cd /nobackup/workFolder/;  
> bash ~/programs/bash_gblocks.sh ~/programs/Gblocks_0.91b/Gblocks /nobackup/workFolder/protein p;

***Note***: the final ***p*** to denote protein sequences

### Running GBlocks for DNA sequences
> cd /nobackup/workFolder/;  
> bash ~/programs/bash_gblocks.sh ~/programs/Gblocks_0.91b/Gblocks /nobackup/workFolder/DNA d;

***Note***: the final ***d*** to denote DNA sequences

## Installing PartitionFinder2

***Note*** Since PartitionFinder3 requires the creation of a conda environment, no script is given, but you can install it manually with the commands below.

Unlike the other applications, PartitionFinder requires Python2.7 which is no longer supported on many systems. Consequently, you'll probably have to install Python 2.7 on your computer. This then may cause issues, as it probably already has a version of Python 3 installed. The commonest way around this issue is to install Python 2.7 in a conda environment, which requires Anaconda to be installed, which can be obtained [here](https://www.anaconda.com/download). 

Once Anaconda3 is installed, an environment can be created with:

> conda create --name myenv python=2.7

***Note***: __myenv__ is the name of your environment, which can be any (supported) name, such as __python2.7__. By using different names, you can have multiple environments on your computer.

Once created, the environment needs to be updated for PartitionFinder with:

> conda activate myenv   
> conda install numpy pandas pytables pyparsing scipy scikit-learn

Once activated and updated, the command:

> python --version

while indicate that python 2.7 is the active Python version used and not Python3.X.

The Conda environment can be turned off with:

> conda deactivate

### Installing PartitionFinder3 

PartitionFinder can be downloaded from [https://github.com/brettc/partitionfinder/archive/refs/tags/v2.1.1.tar.gz](https://github.com/brettc/partitionfinder/archive/refs/tags/v2.1.1.tar.gz)

with:

> wget https://github.com/brettc/partitionfinder/archive/refs/tags/v2.1.1.tar.gz
>  tar xvf partitionfinder-2.1.1.tar.gz

Once extracted, the python script can be found in partitionfinder-2.1.1/PartitionFinder.py

### Running PartitionFinder3 

To run PartitionFinder3, you need to activate the Conda environment with: 

> conda activate myenv 

**Note** you may get an error message stating you have to initiate conda in which case run 

> conda init
> conda activate myenv 

To run PartitionFinder use a standard command such as:

python PartitionFinder.py \data\analysis

where __PartitionFinder.py__ is the script file with its path and __\data\analysis__ is the location of the folder with the phylip-formatted alignment in it along with the partition_finder.cfg configuration file.

