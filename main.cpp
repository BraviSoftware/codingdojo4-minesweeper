#include<iostream>
#include<stdio.h>
#include<string.h>

using namespace std;

void increment_matrix(int matrix[][100], int width, int height, int x, int y)
{
    x--; y--;
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

void print_matrix(int matrix[][100], int width, int height)
{
    for(int i=0;i<width;i++){
        for(int j=0;j<height;j++)
            matrix[i][j]==-1?printf("* "):printf("%d ", matrix[i][j]);
        printf("\n");

    }
}

int main()
{

    int width, height, x, y;
    printf("Digite o tamanho do campo minado: (largura - altura) - maximo 100x100\n");
    scanf("%d %d", &width, &height);
    printf("Digite o local das bombas: (x - y) ou 0 0 para sair:\n");
    int matrix[100][100];
    memset(matrix, 0, sizeof matrix);
    while(true)
    {
        scanf("%d %d", &x, &y);
        if(x==0 || y==0)
            break;
        increment_matrix(matrix, width, height, x, y);
    }
    print_matrix(matrix, width, height);
    scanf("%d", &x);
    return 0;
}



