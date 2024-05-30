#!/bin/bash
#Usage <path>bash_prank.sh <prank file with path> <folder to process> 

prank=$1
folder=$2

if [ -d $folder ] ; then
	echo $folder is a folder.
else
	echo Error $folder is not a folder
	exit 1
fi

mkdir -p $folder/"prank"

if [ -f $prank ] ; then
	echo $prank is a folder.
else
	echo Error $prank is not a file
	exit 1
fi

for file in $folder/*fasta ; do
	echo $file
	fileName=`basename $file`
	echo $fileName
	result=$folder"/prank/"${fileName%".fa"*}"_prank.fasta"
	echo $result
	$prank -d=$file -o=$result
done
