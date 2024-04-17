# GeneMatrix User Guide

## Contents

## User interface

```GeneMatrix``` consists of a single window split in to the four sections: ***Import data***, ***Combine features with different names***, ***Save sequence*** and ***Align individual features***. Each section performs a task as suggested by its name. The upper three section need to be performed in a set order so only the ***Import data*** option is active. However, since the ***Align individual features*** works with data saved to disk it can be user when required and so is always enabled.

<hr />

![Figure 1](images/figure1.jpg)

Figure 1

<hr />


## Obtaining the sequence files

```GeneMatrix``` is designed to work with files downloaded from the NCBI web site that consist of a cohort of related sequences such as mitochondrial genomes from species in the same genus or viruses from the same family. For this guide I downloaded 144 mitochondrial genome sequences for the genus Chelonoidis. A fuller description of how to selection and download download the data is [here](obtainingFiles.md) while the [data file](../ExampleData/sequence.gb) is in the [ExampleData folder](../ExampleData/). 

## Importing sequence data

The  ***Import data*** section consists of just two controls which allow the selection of the data files. To import data press the ```Import``` button in the lower right of the panel (blue box Figure 2 a). If the ```Folder``` tick box is unchecked, pressing the ```Import``` button will result in a file selection dialogue box appearing that will accept files with a *.gb or *.genbank file extensions, while if checked, a folder selection dialogue box will be shown. When importing data from a folder, ```GeneMatrix``` will process any file in the folder with either the *.gb or *.genbank file extension, with each file containing one or more sequences.  

<hr />

![Figure 2](images/figure2a.jpg)

Figure 2: Data is imported by pressing the ```Import``` button.

<hr />

***Note:*** When importing a single file it is expected that the file contains multiple sequence, while when importing a folder of files each file can contain one or more sequences. If the same accession number is present twice, ```GeneMatrix``` will warn you and give the option to abort the process allowing you to remove the duplicated sequences or allow you to continue and ignoring the 2nd copy.

Once imported ```GeneMatrix``` states the number of retained entries and lists any with no relevant annotation (contained no tRNA, rRNA or CDS features): these sequences will be omitted from all subsequent processing (Figure 3 and see [Feature selection](#features-names) below).

<hr />

![Figure 3](images/figure3.jpg)

Figure 3

<hr />

## Retained data

### Genbank entry level data: accession ID, species name and sequence
When reading an entry, ```GeneMatrix``` identifies the entry's accession number, species name and its sequence as follows:   
* The accession ID is obtained from the line beginning with ___VERSION___.   
* The species name is taken from the line starting with two spaces and then ___ORGANISM___.  
* The sequence is considered as any text after the line starting with ___ORIGIN___ and before the starting with ___\\\\___. When all the features from an entry have been stored the sequence data is discarded. 
 
### Selection of sequences to be retained

The level of annotation in GenBank entries is very variable, some entries only have the sequence and genome level annotation such as accession ID, species taxonomy and submitter details, while other are extensively annotated. For instance in the sequence.gb file downloaded in the [Obtaining the sequence files](obtainingFiles.md), 18 contain no relevant annotation. Not all of the features are relevant to the production of sequence alignments for phylogenetic studies consequently, ```GeneMatrix``` limits the features retain to those tagged with the CDS, tRNA or rRNA. These were selected as they have very well defined starting and ending points, with their sequence consistent between species, whereas features such as  those linked to the ___variation___, ___gene___ and ___misc_feature___ are not. For example:

* ___variation___ : these features are not consistent between species
* ___gene___: poorly defined start and end points with interesting sequences present in the ___CDS___ features
* ___misc_feature___: these are poorly defined features with variable meanings between entries resulting in no set feature list between similar GenBank accession sequences.

#### Feature's Names
Due to variation in the annotation of different GenBank entries, when extracting data for a specific feature ```GeneMatrix``` looks for lines containing the tags: ___/gene=___, ___/product=___,  ___/protein_id=___ and ___/locus_tag=___.  When more than one tag is present, the feature's name is taken as the first tag to be given a value in the order of ___/gene=___ then ___/product=___ followed by  ___/protein_id=___ and finally ___/locus_tag=___.

#### Protein sequence
Typically a ___CDS___ feature is linked to a protein sequence which is found by searching for the ___/translation=___ tag and retaining the subsequence text until a ine ending with a __&rdquo;__ is found.  Obviously ___tRNA___ and ___rRNAs___ never linked to a protein sequence.  

#### Sequence coordinates
For a short, simple sequence such as a tRNA or mitochondrial CDS, the sequence is present as a single run of nucleotides. In these situations the coordinates simply follow the feature's tag (___CDS___, ___rRNA___ or ___tRNA___) with the start and end points separated by two periods (Table 1, row 1). In these cases the coordinates of each feature are extracted from the GenBank entry's sequence and stored.  
However, the sequence of a ___CDS___ feature may be contained in a number of exons or in the case of a circular genome a feature may span the beginning and the end of the sequence. In these cases the feature's tag is followed by a series of start/end coordinates separated by commas with the whole series placed in brackets following the word ___join___ (Table 1, row 2). In these case the sequence identified each pair of coordinates is extracted and concatenated to form one sequence.  

|Scenario|Example|
|-|-|
|Contiguous sequence on forward strand| 4226..15369|
|Sequence in two exons on forward strand|join(4226..5266,7492..9002)|
|Contiguous sequence on reverse strand| complement(4226..15369)|
|Sequence in two exons on reverse strand|complement(join(4226..5266,7492..9002))|

Table 1: Feature coordinates

If the feature is encoded on the reverse strand, the coordinates are places in brackets following the complement key word (Table 1, rows 3 and 4). In these cases the sequence is extracted as above and then the reverse complement sequence is determined and stored. This [page](revesreComplement.md) gives the conversion table including the ambiguous codes.  

Occasionally, the exact coordinates for a sequence are not know, in these cases the coordinates may contain one or both '<' '>' characters suggesting the sequences starts or ends beyond the region suggested. In these situations ```GeneMatrix``` just uses the coordinates supplied i.e. the entry: <1..532 would be treated as: 1..532.   
In the data file downloaded in the [Obtaining the sequence files](obtainingFiles.md) section, sequence MG912796.1 contains the sequence for a tRNA-Leu as located at ***complement(<13358)***, in this case with so little information the tRNA is ignored.


## Working with the imported sequences

Once the data has been imported, the ```Combine features with different names``` section becomes active. The area consists of two tree view panels with the data arranged as nodes in a tree like structure. The root of the trees is the ___Sequence___ node, which contains up to three child nodes (___CDS___, ___rRNA___ and ___tRNA___). The panel on the left represents  unselected data, while the panel on the right represents the selected features. Consequently, initially the ___CDS___, ___rRNA___ and ___tRNA___ nodes on the right contain no child nodes, while those on the left do as shown by the cross to the right of the text (Figure 4). If no data is found for a feature type, the linked node will not be displayed.

<hr />

![Figure 4](images/figure4.jpg)

Figure 4

<hr />

```GeneMatrix``` is designed for the collation of orthologue sequences, which is achieved  with user interaction by selecting features with the required names rather than similar sequences. This decision was made as it is hoped that the sequences would be correctly annotated, and while this may not be the case, there are many situation where the use of sequence homology can be equally troublesome. For instance, many viruses contain open reading frames which give rise to a number of different proteins though different mechanisms such as RNA editing, ribosome stalling or protein cleavage. What these features represent is typically obvious from the feature's name, but may not be that obvious from the sequence, for example:  
* The CDV virus genome contains a PVC or PCV open reading frame that generates the P, V and C proteins which have overlapping sequences. Some CDV genomes in the [CDV_genomes.gb](../ExampleData/CDV_genomes.gb) file contains a PVC/PCV feature, while other have one or more of the P, V, and C sequences. Trying to group these features base on sequence homology could result in situations where some species have the whole PVC/PCV sequence included while others had the overlapping P, V and C sequences with or without the PVC/PCV sequence, which could ultimately result in erroneous results.  
  
## Selecting sequences for export based on their names

Ideally, ```GeneMatrix``` would automate the selection of the features based on their name, however, because features are not named in a consistent, systematic manner in this step requires user interaction. For example, in the [CDV_genomes.gb](../ExampleData/CDV_genomes.gb) file, there are eight different names for the Haemagglutinin protein H ___CDS___ feature. 

<hr >

![Figure 5](images/figure5.jpg)

Figure 5: 

<hr />

Multiple features can be selected at once as long as they all are the same type (i.e. they are all ___CDS___ features.) To select an orthologue for inclusion in the exported data set, click on the feature's name in the left hand panel using the left mouse button. This should change the features's icon from a light grey to a green. Clicking on the node a second time will deselect it as indicated by the now light grey icon. If an orthologue has multiple names, initially select the node which has the preferred name and then include the other sequences as outlined in the next section. Once you have selected all the features, click on the relevant node in the right hand panel using the mouse's left hand button. This will move the features from the left hand tree to the right hand tree (Figure 6).  

<hr />

![Figure 6](images/figure6.jpg)

Figure 6: In Figure 6 a, all the features in the ___CDS___ set except ***cytb***, ***NADH dehydrogenase subunit 1*** and ***NADH dehydrogenase subunit 5*** have been selected. Figure 6 b shows the movement of the selected nodes to the right hand tree after left mouse clicking on the CDS node in the right hand panel.

### Amalgamating sequences with different names

In Figure 7 a it can be seen that the ***NADH dehydrogenase subunit 1*** and ***NADH dehydrogenase subunit 5*** nodes are now child nodes of the ***ND1*** and ***ND5*** nodes respectively. As a result, features with the ***NADH dehydrogenase subunit 1*** name will be combined with those called ***ND1*** in to a data set called ***ND1***. Similarly, ***NADH dehydrogenase subunit 5*** features will be exported with the ***ND5*** features.
To combine the unselected ***cytb*** features with the selected  ***CYTB*** features, left mouse click the ***cytb*** feature in the left hand panel and then click the ***CYTB*** text using the left mouse button (Figure 7 b). 

<hr />

![Figure 7](images/figure7.jpg)

Figure 7

<hr />

### Deselecting sequences for export

Deselecting a feature for export is achieved by clicking on the node using the right hand mouse button. This removes the node from the right hand tree, returning it to left hand tree. If a node contains child nodes, these are removed from the node and also placed in the left hand tree (Figure 8). 

<hr />

![Figure 8](images/figure8.jpg)

Figure 8: Right mouse clicking on the ***CYTB*** node in the right hand panel (Figure 8 a), returns both the the ***CYTB*** node and its child ***cytb*** to the ***CDS*** node on the left hand panel.

<hr />


### Resetting the selection of sequences for export

The ```Reset``` button in the lower right hand corner of the ```Combine features with different names``` section allows you to discard the current selection of sequences for export. Pressing it will remove all child nodes of the ___CDS___, ___rRNA___ and ___tRNA___ nodes in the right hand panel, moving them to the appropriate node in the left hand panel. 


### Saving the selected gene sequences

Once at least one feature has been selected for export the the ```Save``` button in the ```Save sequences``` section becomes active (blue box in Figure 9). Pressing this button will prompt you to select a folder to save the data too. If it contains a file with the same name as a file that its exported, the old file will be overwritten (Figure 10).

<hr />

![Figure 9](images/figure9.jpg)

Figure 9

<hr />

![Figure 10](images/figure10.jpg)

Figure 10

<hr />

The ```Save sequences``` section also contains three options: ***Just DNA sequences***, ***Just protein sequences*** and ***Both types of sequence*** (red box in Figure 9). These options select whether DNA, protein or both types of sequence data is exported when the ***Save*** button is pressed. Files containing DNA sequences are named \<feature type>-\<feature name>_DNA.fasta, while protein sequence files are called \<feature type>-\<feature name>_Protein.fasta. The \<feature name> is replaced by the sequence's feature name unless it was added as a child to another term. For instance in Figure 8 a, all DNA sequences represented by the ***ATP6*** name will be stored in a file called ***CDS-ATP6_DNA.fasta***. However, all the sequences linked to ***NADH dehydrogenase subunit 1*** will be saved in the parent's file which is called ***CDS-ND1_DNA.fasta***. 

Not all names can be used in file names as some contain characters that are not allowed such as '\\', '?' or ":". Consequently, characters that are letters, numbers, '-', '_', ' ' or '.' are replaced by '_'.

#### Sequence names

The name of the files denotes the which feature it contains, while each individual sequence in the file is named after the GenBank's accession ID and the species name:

    <Accession ID>-<Species name>

To make the names compatible with various multiple alignment programs, any ' ' characters are replaced by '_', otherwise the names may be truncated in an alignment file generated by programs such as Muscle (see [below](#using-muscle)). 

#### Absent data

Sequences that are shorter than the longest sequence are padded with ' ' characters to make all sequences the same length. If a GenBank entry doesn't contain any sequence data for a particular feature, its sequence in the exported file will be a series of 'n' (DNA) or 'x' (protein) characters that is the same length as the longest sequence in that set. However, if no entries have data (i.e. no tRNA or rRNA feature will have a protein sequence) no file will be produced.

## Automating the alignment of the the exported sequences

The exported files can then be aligned by a third party alignment program and then if required combined to create a single alignment file that may be used by an application that determines the level of similarity or relatedness between the different species. 

Two commonly used applications for the creation of multiple alignments are ClustalW and Muscle. Their stand alone executable files are available from their web sites (see below) as well as in this pages [Program folder](../Program/). The lower section of ```GeneMatrix``` contains two buttons (```Muscle``` and ```ClustalW```) that will automate the alignment of the exported files using Muscle or Clustal (if the executable is on your computer) (Figure 11).

<hr />

![Figure 11](images/figure11.jpg)

Figure 11

<hr />

When automating the use of either of these programs ```GeneMatrix``` will check if it has used the program before and if so attempt to use the same program file, otherwise it will look in the same folder as the ```GeneMatrix``` executable for the executable. Finally, if no program file was found it will ask you for its location. 

Once GeneMatrix as found the executable (currently: clustalw2.exe and muscle5.1.win64.exe), it will prompt you to select the folder of files to be aligned. It will then search this folder for files ending _DNA.fasta or _Protein.fasta, if any are found it will process each in turn by creating a batch file which it will then attempt to run in the cmd.exe shell window. cmd.exe is an integral component of Windows that provides a simple method to automate commands written as text. It as a very simple interface that just displays text written by you or any programs you have asked it to run (Figure 12)  

<hr />

![Figure 12](images/figure12.jpg)

Figure 12

<hr />

By default, the cmd.exe interface is hidden by ```Genematrix``` and the only feed back is given by the ```Status``` label, which is updated as the ```GeneMatrix``` works through the list of files. During this time, ```GeneMatrix``` will be locked and will not respond to any user input. To see if Muscle or Clustal is running you may need to either open Task Manger (type Task Manager in the box at the bottom left of your primary monitor) and see if Clustal or Muscle is shown in the application list (Figure 13). When using Muscle, it will use all the computers processes and may limit the computers ability to do other things,  Clustal will typically use less processors. 

<hr />

![Figure 13](images/figure13.jpg)

Figure 13

<hr />


If the ```Show command window``` option is checked (black line in Figure 11), the cmd.exe window will not be hidden and you'll be able to see the output generated by the alignment program (Figures 14 and 15). Closing this window will halt the alignment and ```GeneMatrix``` will start the alignment of the next file. Once started, the only way to stop the alignments may be to kill ```GeneMatrix``` and then the aligner in the Task Manager window or change the data folders name and then kill the aligner in Task Manager. 

If the ```Combine all the alignments``` option is checked, when all the alignments have been made, ```GeneMatrix``` will collate all the sequences in to a single fasta file such that all the exported sequences for an GenBank entry will be concatenated in to one line in the resultant fasta file. This file can then be used as the input for a program that creates phylogenic trees for example.


***Note:*** If you want to change the version of the executable, either swap the file or check the ```Reselect alignment program``` option on the lower left of the ```Align individual features``` section (yellow line in Figure 11) before pressing the ```Muscle``` or ```ClustalW``` buttons: this will force ```GeneMatrix``` to ask for the executable's location.

## About Muscle

Muscle v5 was a major rewrite of the original program and is reportedly the most accurate aligner when tested in 2021. 

#### Command

> muscle5.1.win64.exe -align \<input file> -output \<results file>

where:
* \<input file> is the fasta file to align
* \<results file > is the name of the file to save the alignment too.

##### Website

https://www.drive5.com/muscle/

##### References

> RC Edgar. MUSCLE: multiple sequence alignment with high accuracy and high throughput. Nucleic acids research 32 (5), 1792-1797

## About Clustal 
The Clustal algorithm first published in 1988 with the last version released in 17th, Oct 2010. It is available as a desktop, console and web server application, with a number of sites hosting the web server. While it is old, it is still routinely used to create multiple sequence alignments. 

#### Command

The command issued to Clustalw2 is:

> clustalw2.exe -INFILE=[input file>]-TYPE=[DNA or PROTEIN] -OUTPUT=FASTA -OUTPUT=FASTA -OUTFILE=[results file]

where:
* [input file] is the fasta file to align
* [DNA or protein] is the type of sequence to align.
* [results file] is the name of the file to save the alignment too.

##### Website

http://www.clustal.org/clustal2/

##### References

First publication: 
> Higgins,D.G. and Sharp,P.M. (1988). CLUSTAL: a package for performing multiple sequence alignment on a microcomputer. Gene, 73, 237-244.

Last publication:
> Larkin MA, Blackshields G, Brown NP, Chenna R, McGettigan PA, McWilliam H, Valentin F, Wallace IM, Wilm A, Lopez R, Thompson JD, Gibson TJ, Higgins DG.
(2007). Clustal W and Clustal X version 2.0. Bioinformatics, 23, 2947-2948.

### About MAFFT
#### Command

> mafft --auto --retree 2 --inputorder [input file (Linux)] \> [results file (Linux)]

where:
* --auto - prompts MAFFT to use the best options for the alignment: rom L-INS-i, FFT-NS-i and FFT-NS-2, according to data size.
* --retree 2 - Guide tree is built number times in the progressive stage. Valid with 6mer distance. Default: 2 
* --inputorder - Output order: same as input.
* [input file] is the fasta file to align.  The file name uses the Linux '/' rather than the Windows '\\' separators.
* [results file] is the name of the file to save the alignment too.  The file name uses the Linux '/' rather than the Windows '\\' separators

##### Website

https://mafft.cbrc.jp/alignment/server/index.html
(Manual: https://mafft.cbrc.jp/alignment/software/manual/manual.html)

##### References

First publication
> Katoh K, Misawa K, Kuma K, Miyata T. MAFFT: a novel method for rapid multiple sequence alignment based on fast Fourier transform. Nucleic Acids Res. 2002;30:3059-66

Last publication
> Katoh K, Standley DM. MAFFT multiple sequence alignment software version 7: improvements in performance and usability. Mol Biol Evol. 2013;30:772-80. 
### About PRANK

http://wasabiapp.org/software/prank/

#### Command
prank.exe-d=[input file (Linux)] -o=[results file (Linux)]


where:
* [input file (Linux)] is the fasta file to align. The file name uses the Linux '/' rather than the Windows '\\' separators
* [results file (Linux)] is the name of the file to save the alignment too.  The file name uses the Linux '/' rather than the Windows '\\' separators

##### Website
##### References

> Löytynoja, A. (2014). Phylogeny-aware alignment with PRANK. In: Russell, D. (eds) Multiple Sequence Alignment Methods. Methods in Molecular Biology, vol 1079. Humana Press, Totowa, NJ. https://doi.org/10.1007/978-1-62703-646-7_10

## Combining the individual alignments 
