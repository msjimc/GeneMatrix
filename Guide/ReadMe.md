# GeneMatrix User Guide

## Contents

## Obtaining the sequence files

```GeneMatrix``` is designed to work with files downloaded from the NCBI web site that consist of a cohort of related sequences such as mitochondrial genomes from species in the same genus or viruses from the same family. The NCBI is a large site that as multiple ways to access the same data depending how you want to search for it. In this example I will create a single GenBank sequence files containing mitochondrial genomes for animals in the Chelonoidis genus. 

First navigate to the NCBI Taxonomy site ([ NCBI - Taxonomy](https://www.ncbi.nlm.nih.gov/taxonomy)) and enter **Chelonoidis** in the search bar and press the ```Search``` button (Figure 1).

<hr />

![Figure 1](images/figure1.jpg)

Figure 1

<hr />

Next click on the ___Nucleotide___ link (blue box in Figure 1) below the ___Chelonoidis___ title to navigate to the next page. This page lists all the nucleotide sequences available for species in this genus with 66,291 available. Many of the sequences do not represent mitochondrial genomes and so the results require filtering using the option on the left of the web site (Figure 2) 

<hr />

![Figure 2](images/figure%202.jpg)

Figure 2

<hr />

Limiting the sequences to those linked to the key word ___Mitochondrion___ reduces the list to 2,013 sequences (blue box Figure 2), while selecting a size range (red box Figure 2) of 12,000 to 20,000 bp reduces it 144 (Figure 3)

<hr />


![Figure 3](images/figure3.jpg)

Fiugre 3

<hr />

It is not a matter of going through the list and selecting the sequences you are interested in 

## Importing sequence data

### Selecting sequences based on their names

### Combining sequences with different names

### Deselecting sequences

### Resetting the selection

### Saving the selected gene sequences

## Aligning the sequences in the exported files

### Using Muscle

### Using Clustal

### Combining the individual alignments 