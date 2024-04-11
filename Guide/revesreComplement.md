# GeneMatrix

## Substitution table when reverse complementing a sequence.

When finding the reverse complement of a sequence, the sequence is read from the end to the beginning with each base in the original sequence substituted for its complement. Since GenBank sequences may contain ambiguous positions these are substituted as shown in the table. Spaces, formatting characters and numbers are ignored.

|Base in Genbank<br />sequence|Represents|Base after reverse<br />complementing |Represents|
|-|-|-|-|
|A||t||
|C||g||
|G||c||
|T||a||
|R|A + G|Y|C + T|
|Y|C + T|R|A + G|
|K|T + G|M|A + C|
|M|A + C|K|T + G|
|W|A + T|W| A + T
|S| C + G|S| C + G|
|B |T + C + G|V|A + C + G|
|D|A + T + G|H|A + T + C|
|H|A + T + G|D|A + T + G|
|V|A + C + G| B|T + C + G|
|White space or 0 to 9|(Formatting)|Ignored|NA|
|N or any other character|A + C + G + T|N|A + C + G + T|  

Table 1: Sequence substitution when reverse complementing a sequence 