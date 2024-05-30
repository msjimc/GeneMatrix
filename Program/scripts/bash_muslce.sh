#!/bin/bash
#Usage <path>bash_muscle.sh <muscle file with path> <folder to process> 

muscle=$1
folder=$2

if [ -d $folder ] ; then
	echo $folder is a folder.
else
	echo Error $folder is not a folder
	exit 1
fi

mkdir -p $folder/"muscle"

if [ -f $muscle ] ; then
	echo $muscle is a folder.
else
	echo Error $muscle is not a file
	exit 1
fi

for file in $folder/*fasta ; do
	echo $file
	fileName=`basename $file`
	echo $fileName
	result=$folder"/muscle/"${fileName%".fa"*}"_musclel.fasta"
	echo $result
	$muscle -align $file -output $result
done
