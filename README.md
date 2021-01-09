# NaiveBayes
Using Naive-Bayes for text classification. The goal is to classify Email and Form texts into one of 20 categories.

All data and the split into 20 categories was taken from:
http://archive.ics.uci.edu/ml/datasets/Twenty+Newsgroups
by Tom Mitchell

I used the mini-newsgroups files (2000 in total, 100 per category) for Training.

# HowTo
If you want to use the classifier you have to create a new folder inside "res" called "TestData"
The classifier is looking for directories inside the "TestData" and uses their name as the real classification. 
That way you are able to test the accuracy of the classifier.
If you don't know you real class of a file you can just put it into a folder but then the given error rate at the end will be wrong.
