#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include<minesweeper.h>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    
private slots:
    void on_pushButton_clicked();
    void on_label_clicked(QMouseEvent *);
    void mark_brick();
    void click_on_brick();
    void clear_empty_neighbors(int x, int y, int lado);

private:
    Ui::MainWindow *ui;
    Minesweeper *mine;
};

#endif // MAINWINDOW_H
