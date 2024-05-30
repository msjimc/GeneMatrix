import os, sys

# Path to the directory containing the trimmed sequence files
folder_path = sys.argv[1]

#Check it ends with correct file system delimitor
slash = ""
if os.name == 'nt':
    slash = "\\"
else:
    slash ="/"
    
if folder_path.endswith(slash) == False:
    folder_path = folder_path + slash


# List all the trimmed sequence files in the directory
file_list = os.listdir(folder_path)

# Sort the file list alphabetically if necessary
file_list.sort()

# Create an empty supermatrix
supermatrix = {}
subMatrix = {}
listOfNames = []
currentLength = 0

#get list of all animals in any of the files
for file_name in file_list:
    # Check if the file is a FASTA file
    if file_name.endswith(".fasta"):
        # Read the contents of the file
        with open(os.path.join(folder_path, file_name), "r") as file:
            lines = file.readlines()
            for line in lines:
                if line.startswith(">"):
                    line = line.strip()[1:]
                    if line not in listOfNames:
                        listOfNames.append(line)

listOfNames.sort() #the list

# Iterate through each file and get the sequence data
for file_name in file_list:
    # Check if the file is a FASTA file
    if file_name.endswith(".fasta"):
        # Read the contents of the file
        with open(os.path.join(folder_path, file_name), "r") as file:
            lines = file.readlines()
        
        # Extract the sequence identifier and sequence data
        sequence_id = None
        sequence_data = ""
        subMatrix.clear();
        for line in lines:
            line = line.strip()
            
            if line.startswith(">"):
                if len(sequence_data) > 0:
                    if sequence_id in subMatrix:
                        subMatrix[sequence_id] =  str(subMatrix[sequence_id]) + sequence_data
                    else:
                        subMatrix[sequence_id] = sequence_data
                sequence_id = line[1:]
                sequence_data = ""
            else:
                sequence_data += line
        if len(sequence_data) > 0:
            if sequence_id in subMatrix:
                subMatrix[sequence_id] =  str(subMatrix[sequence_id]) + sequence_data
            else:
                subMatrix[sequence_id] = sequence_data

    #get the maximum length of the sequences in the current file    
    lengthMax = 0
    for id in subMatrix:
        if len(str(subMatrix[id])) > lengthMax:
            lengthMax = len(str(subMatrix[id]))
    currentLength += lengthMax
    #go through the list of names and either add the (padded) sequence if in the current file or add a padding string 
    emptyString = ""
    if (len(supermatrix) > 0):
        for id in listOfNames:
            if id in supermatrix:
                if id in subMatrix:
                    supermatrix[id] = str(supermatrix[id]) + str(subMatrix[id]).ljust(lengthMax, '-')
                else:                    
                    supermatrix[id] = str(supermatrix[id]) + emptyString.ljust(lengthMax, '-')
            else:
                if id in subMatrix:
                    supermatrix[id] = emptyString.ljust(currentLength - lengthMax, '-') + str(subMatrix[id]).ljust(lengthMax, '-')
                else:                    
                    supermatrix[id] = emptyString.ljust(currentLength - lengthMax, '-') + emptyString.ljust(lengthMax, '-')
    else:
        for id in listOfNames:
            if id in subMatrix:
                supermatrix[id] = str(subMatrix[id]).ljust(lengthMax, '-')
            else:                    
                supermatrix[id] = emptyString.ljust(lengthMax, '-')
            



# Write the supermatrix to a file
output_file = folder_path + "supermatrix2.fa"

with open(output_file, "w") as file:
    for sequence_id in supermatrix:
        file.write(">" + sequence_id + "\n")
        file.write(supermatrix[sequence_id] + "\n")

print("Supermatrix created successfully!")







