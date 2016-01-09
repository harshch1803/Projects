
#include <iostream>
#include <vector>
#include<string>
#include <algorithm>
#include<conio.h>

using namespace std;


//Intializing Global Variables.

const char X ='X';
const char O ='O';
const char TIE ='T';
const char EMPTY =' ';
const char NO_ONE ='N';


//Function Prototyping

void instructions();
void displayBoard(const vector<char>&board);
char humanpiece();
char opposition(char &user);
char askYesOrNo(string ques);
int askNumber(string ques,int high,int low=0);
bool IsLegalMove(const vector<char>&board,int choice);
int humanMove(const vector<char> &board,char human);
int compMove(vector<char> board,char comp);
char winner(const vector<char>&board);
void announceWinner(char winner, char comp, char human);


int main()
{
	int move;
	
	//Maximum Number of Entries.
	const int Max_Squares = 9;
	
	char turn = X;
	
	//Vector to Store the Board.
	vector<char>board(Max_Squares,EMPTY);
    
    	//Display Instructions.
	instructions();	
	
	//Returns 'X' or 'O' based on Player's Choice.
	char human = humanpiece();
	
	//Returns 'O' or 'X' based on Player Choice.
	char comp = opposition(human);
	
	//Display The Board.
	displayBoard(board);
	
	//Checks for Player Won / Comp Won / Tie.
	while(winner(board) == NO_ONE)
	{
		//Check if it's Player Turn.
		if(turn == human)
		{	
			//Returns the Location decided by the Player.
			move = humanMove(board,human);
			
			//Update the move on the Board.
			board[move] = human;
  		}
  		
  		//Check if it's Computer's Turn.
    		else
    		{
    			//Returns the Location decided by the Computer.
    			move = compMove(board,comp);
    		
    			//Update the move on the Board.
    			board[move] = comp;
    		}
    	
    		//Switch the Turn.
   		turn = opposition(turn);
   		
   		//Display the Board. 
    		displayBoard(board);
	}
	
	 announceWinner(winner(board),comp,human);
	 
	 getch();
	 return 0;
}


void instructions()
{
	cout<<"Welcome To The Ultimate Man-Machine Showdown\n"<<endl;
	cout<<"Make your move by entering a number\n";
	cout<<"Corresponds to desired board position as shown\n\n";
	cout<<"\t1|2|3\n";
	cout<<"\t-----\n";
	cout<<"\t4|5|6\n";
	cout<<"\t-----\n";
	cout<<"\t7|8|9\n";
	cout<<"\t-----\n";
	cout<<"Preapare Yourself Human.The Battle is ON\n\n";
}


void displayBoard(const vector<char> &board)
{
	cout<<"\t"<<board[0]<<"|"<<board[1]<<"|"<<board[2];
	cout<<"\n\t"<<"-----";
	cout<<"\n\t"<<board[3]<<"|"<<board[4]<<"|"<<board[5];
	cout<<"\n\t"<<"-----";
	cout<<"\n\t"<<board[6]<<"|"<<board[7]<<"|"<<board[8];
	cout<<"\n\n";
}

char askYesOrNo(string ques)
{
	char answer;
	
	cout<<ques<<endl;
	cout<<"Enter 'y' or 'n'"<<endl;
	cin>>answer;
	
	while(answer!='y' && answer!='n')
	{
		cout<<"Are You Dumb Human"<<endl;
		cout<<"Enter 'y' or 'n'\n";
		cin>>answer;
	}
	
	cout<<"\n\n";

	return answer;
}


int askNumber(string ques,int high,int low=0)
{
	int number;
	
	cout<<ques;
	cin>>number;
	
	number = number-1;
	
	while(number > high || number < low)
	{
		cout<<"Are You Really That Dumb Human"<<endl;
		
		cout<<"Enter Again"<<endl;
		cin>>number;
	}
	
	return number;
}


bool IsLegalMove(const vector<char>&board, int choice)
{
	//Checks if the given Location is Empty.
	return(board[choice] == EMPTY);
}


char humanpiece()
{
	//Provides a choice to the Player to Start the Game.
	char choice;
	
	//Returns 'y' or 'n' based on Player's Choice.
	char ans = askYesOrNo("Would Like To Start First");
	
	if(ans =='y')
	{
		choice = X;
		cout<<"Trying to be Too brave Human\n"<<endl;
	}
	
	else
	{
		choice = O;
		cout<<"As I expected, Coward\n"<<endl;
	}
	
	return choice;
}


char opposition(char &user)
{
	
	//Selects Character Opposite to User's Choice.
	char opp;
	
	if(user == X)
	opp = O;
	
	else
	opp = X;
	
	return opp;
}


char winner(const vector<char> &board)
{
	char winner = NO_ONE;
	int Winning_Rows[8][3] = {{0,1,2},{3,4,5},{6,7,8},{0,3,6},{1,4,7},{2,5,8},{0,4,8},{2,4,6}};
	
	for(int r = 0; r < 8; r++)
	{
	
		if((board[Winning_Rows[r][0]]!= EMPTY)&&(board[Winning_Rows[r][0]] == board[Winning_Rows[r][1]])&& (board[Winning_Rows[r][1]] == board[Winning_Rows[r][2]]))
		{
			winner = board[Winning_Rows[r][0]];
			break;
		}
    	}
    
    	if( count(board.begin(),board.end(),EMPTY)== 0 )
    	{
    		winner = TIE;
    	}
    
	return winner;
}


int humanMove(const vector<char> &board,char human)
{
	//Returns the Position to be filled on the Board by Player.
	int move = askNumber("What Is Your Move Human <1-9>: ",board.size()-1);
	
	//Checks if Player's move is Legal.
	while(!IsLegalMove(board,move))
	{
		cout<<"\nThat Square is already occupied,You Fool\n\n";
		move = askNumber("What Is Your Move Human <1-9>: ",board.size()-1);
	}
	
	cout<<"Fine\n\n"<<endl;
	
	return move;
}


int compMove(vector<char> board,char comp)
{
	int move = 0;
	bool found = false;
	
	//Checks for a Winning Move.
	while(!found && move < board.size())
	{
		if(IsLegalMove(board,move))
		{
			board[move] = comp;
			found = (winner(board) == comp);
			board[move] = EMPTY;
		}
		
		if(!found)
		{
			++move;
		}
	}
	
	if(!found)
	{
		//Checks To Block Player's Winnig Move.
		move = 0;
		char human = opposition(comp);
		
		while(!found && move < board.size())
		{
			if( IsLegalMove(board,move) )
			{
				board[move] = human;
				found = (winner(board)== human);
				board[move] = EMPTY;
			}
			
			if(!found )
			{
				++move;
			}
		}
	}
	
	if(!found)
	{
		//Checks if the Below Positions are available.
		move = 0;
		int i = 0;
		int Best_Moves[] = {4,0,2,6,8,1,3,5,7};
	
		while(!found && i < board.size())
		{
			move = Best_Moves[i];
			
			if(IsLegalMove(board,move))
			{
				found = true;
			}
			
			i++;
		}
	}
	
	cout<<"I will take Square number "<<move<<"\n\n";
	
	return move;
}


void announceWinner(char winner, char comp, char human)
{
	if (winner == comp)
     	{
		 cout << winner << "'s won!\n";
		 cout << "As I predicted, human, I am triumphant once more -- proof\n";
		 cout << "that computers are superior to humans in all regards.\n";
    	}

	else if (winner == human)
	{
		 cout << winner << "'s won!\n";
		 cout << "No, no!  It cannot be!  Somehow you tricked me, human.\n";
		 cout << "But never again!  I, the computer, so swear it!\n";
	 }

	else
	{
        	cout << "It's a tie.\n";
		 cout << "You were most lucky, human, and somehow managed to tie me.\n";
        	cout << "Celebrate... for this is the best you will ever achieve.\n";
	}
}

