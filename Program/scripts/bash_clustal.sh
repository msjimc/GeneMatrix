#!/bin/bash
#Usage <path>bash_clustal.sh <clustalw2 file with path> <folder to process> 

clustalw2=$1
folder=$2

if [ -d $folder ] ; then
	echo $folder is a folder.
else
	echo Error $folder is not a folder
	exit 1
fi


if [ -f $clustalw2 ] ; then
	echo $clustalw2 is a folder.
else
	echo Error $clustalw2 is not a file
	exit 1
fi

mkdir -p $folder/"clustal"


for file in $folder/*fasta ; do
	echo $file
	fileName=`basename $file`
	echo $fileName
	result=$folder"/clustal/"${fileName%".fa"*}"_clustal.fasta"
	echo $result
	$clustalw2 -INFILE=$file -OUTPUT=FASTA -OUTFILE=$result
done

mv $folder/*.dnd $folder/"clustal"