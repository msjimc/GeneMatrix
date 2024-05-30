#!/bin/bash
#Usage <path>bash_mafft.sh <mafft.bat file with path> <folder to process> 

mafft=$1
folder=$2

if [ -d $folder ] ; then
	echo $folder is a folder.
else
	echo Error $folder is not a folder
	exit 1
fi

mkdir -p $folder/"mafft"

if [ -f $mafft ] ; then
	echo $mafft is a folder.
else
	echo Error $mafft is not a file
	exit 1
fi

for file in $folder/*fasta ; do
	echo $file
	fileName=`basename $file`
	echo $fileName
	result=$folder"/mafft/"${fileName%".fa"*}"_mafft.fasta"
	echo $result
	$mafft --auto --retree 2 --inputorder $file > $result
done
