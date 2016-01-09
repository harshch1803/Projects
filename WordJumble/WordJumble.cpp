
#include <vector>
#include <iostream>
#include <algorithm>
#include<ctime>
#include<conio.h>

using namespace std;

int main()
{
	//Creating a set of Words
	
	enum WORDS{word,hint,num_fields};
	const int maxwords= 5;

	string a[maxwords][num_fields]
	{
		{"disney","Who has won more Oscars than anybody else?"},
		{"aeroplane","The South American city of Brazillia is built in the shape of what?"},
		{"basketball","Which indoor sport is the most popular in the US?"},
		{"michelangelo","Who painted the ceiling of the Sistine Chapel?"},
		{"trumpet","Which instrument did Miles Davis, the jazz musician, play?"}
	};
	
	//Picking a word to Jumble
	
	srand(static_cast<unsigned int>(time(0)));
	
	int choice = rand()%maxwords;
	
	string mainword = a[choice][word];
	string mainhint = a[choice][hint];
	
	//Jumbling the word
	
	string jumble = mainword;
	int len = jumble.length();
	
	for(int i=0;i<len;i++)
	{
		int index1 = rand()%len;
		int index2 = rand()%len;
		char temp = jumble[index1];
		
		jumble[index1] = jumble[index2];
		jumble[index2] = temp;
	}
	
	//Taking Input from the player
	
	string guess;
	
	cout<<"THE JUMBLED WORD: "<<jumble<<endl;
	cout<<endl;
	cout<<"ENTER 'Q' TO QUIT"<<endl;
	cout<<"ENTER 'Hint' TO GET HINT"<<endl;
		
	cout<<"\n Your Guess: ";
	cin>>guess;
	
	transform(guess.begin(),guess.end(),guess.begin(),::tolower);
	
	cout<<endl;
	
	//Entering the Game Loop
	
	while(guess!="q"&&guess!= mainword)
	{
		if(guess =="hint")
		cout<<mainhint<<endl;
		
		else
		cout<<"Wrong Answer"<<endl;
		
		cout<<"Guess :";
		cin>>guess;
		cout<<endl;
	}
	
	//Ending Game Loop
	
	if(guess == mainword)
	{
		cout<<"YOU WON "<<endl;
	}
	
	cout<<"Thanks For Playing"<<endl;
	
	getch();
	return 0;
}
