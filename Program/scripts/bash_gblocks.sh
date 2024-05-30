#!/bin/bash
#Usage <path>bash_gblocks.sh <GBlocks file with path> <folder to process> <sequence type p (protein) or d (DNA)

gblocks=$1
folder=$2
seqType=$3

if [ -d $folder ] ; then
	echo $folder is a folder.
else
	echo Error $folder is not a folder
	exit 1
fi

if [ -f $gblocks ] ; then
	echo $gblocks is a folder.
else
	echo Error $gblocks is not a file
	exit 1
fi

if [ $seqType == "d" ] ; then
	echo DNA sequences
elif [ $seqType == "p" ] ; then
	echo Protein sequences
else
	echo Unknown sequence type
	exit 1
fi

for file in $folder/*.fa ; do	
	if [[ $file  != $folder/\*.fa ]]; then
		echo $file
		$gblocks $file -t=$seqType -e=.fa
	fi
done

for file in $folder/*.fasta ; do	
	if [[ $file  != $folder/\*.fasta ]]; then
		echo $file
		$gblocks $file -t=$seqType -e=.fa
	fi
done

for file in $folder/*.fas ; do	
	if [[ $file  != $folder/\*.fas ]]; then
		echo $file
		$gblocks $file -t=$seqType -e=.fa
	fi
done


