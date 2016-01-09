#include <cmath>
#include <vector>
#include <iostream>
#include <algorithm>
#include<cstdlib>
#include<ctime>
#include<cctype>
#include<conio.h>
using namespace std;
int main()
{
	//Setting Up The Words.
	
	const int max_letters = 8;
 	vector<string>words;
 	
 	words.push_back("FIFA");
 	words.push_back("DIABLO");
 	words.push_back("DOTA");
	words.push_back("NFS");
	words.push_back("SOUTHPARK");
 	words.push_back("NBA");
 	
 	srand(static_cast<unsigned int>(time(0)));
	random_shuffle(words.begin(),words.end());
	
 	string theWord=words[0];
	string WordSoFar (theWord.size(),'-');
	string usedwords="";
	
	int wrong=0;
	
 	//Taking Input From Player.
 	
	 char guess;
	 
 	cout<<"\nWELCOME TO HANGMAN:GUESS THE VIDEOGAME\n\n"<<endl;
 	cout<<"Total Number Of Chances "<<max_letters<<"\n\n";
 	cout<<"The Game-"<<endl;
 	
 	cout<<WordSoFar<<endl;
 	
 	while(wrong!= max_letters && WordSoFar!= theWord)
	 {
 		cout<<"Enter your guess: ";
    	cin>>guess;
    	
    	cout<<endl;
    	
    	guess = toupper(guess);
    	
 		while(usedwords.find(guess)!=string::npos)
 		{
 			cout<<"The letter "<<guess<<" is already used\n\n";
 			
 			cout<<"Guess Again: ";
 			cin>>guess;
 			
 			cout<<endl;
 		}
 		
 		usedwords = usedwords +" "+ guess;
 	
 		if(theWord.find(guess)!= string::npos)
 		{
 			cout<<"You Guessed Right"<<endl;
 	
 			for(int i= 0; i < WordSoFar.size(); i++)
 			{
 				if(theWord[i] == guess)
 				{
 						WordSoFar[i]=guess;
 				}
 				
 				cout<<WordSoFar[i];
 			}
 			
 			cout<<endl;
 		}
 		
 		else
 		{
 			cout<<"You guessed it Wrong \n\n";
 			
 			wrong++;
 			
 			cout<<"You Have "<<max_letters-wrong<<" Chances Left"<<endl;
 		}
 		
 		cout<<"\n Used Letters: "<<usedwords<<"\n\n";
 	}
 	
 	if(WordSoFar == theWord)
 	{
 		cout<<endl;
 		cout<<"COGRATULATIONS!!! You Won"<<endl;
	}
	 
 	else
 	{
 		cout<<endl;
 		cout<<"You are Hanged"<<endl;
	}
	 
	getch();
	return 0;
}
