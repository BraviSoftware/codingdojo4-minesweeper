#include "minesweeper.h"
#include<stdlib.h>
#include<time.h>
#include<string.h>
#include<stdio.h>

Minesweeper::Minesweeper()
{   
}

void Minesweeper::generate_field(int width,int height, int numberbomb)
{
    memset(this->matrix, 0, sizeof this->matrix);
   // this->print_matrix(width, height);
    for(int i=0;i<numberbomb;i++){
        srand(i * time(NULL));
        int x = rand() % 10;
        int y = rand() % 10;        
        this->increment_matrix(width, height,  x + 1 , y + 1);
    }
}

void Minesweeper::increment_matrix(int width, int height, int x, int y)
{    
    x--; y--;
    if(matrix[x][y]==-1)
        return;
    matrix[x][y] = -1;
    if((x+1)<width && (y+1)<height && matrix[x+1][y+1]!=-1)
        matrix[x+1][y+1]++;
    if((x+1)<width && (y-1)>=0 && matrix[x+1][y-1]!=-1)
        matrix[x+1][y-1]++;
    if((x+1)<width && matrix[x+1][y+1]!=-1)
        matrix[x+1][y]++;
    if((x-1)>=0 && matrix[x-1][y]!=-1)
        matrix[x-1][y]++;
    if((x-1)>=0 && (y+1)<height && matrix[x-1][y+1]!=-1)
        matrix[x-1][y+1]++;
    if((x-1)>=0 && (y-1)>=0 && matrix[x-1][y-1]!=-1)
        matrix[x-1][y-1]++;
    if((y+1)<height && matrix[x][y+1]!=-1)
        matrix[x][y+1]++;
    if((y-1)<height && matrix[x][y-1]!=-1)
        matrix[x][y-1]++;
}

void Minesweeper::print_matrix(int width, int height)
{
    for(int i=0;i<height;i++)
    {
        for(int j=0;j<width;j++){
            printf("%d ", matrix[i][j]);
        }
        printf("\n");
    }
}
