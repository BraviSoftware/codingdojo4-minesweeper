#-------------------------------------------------
#
# Project created by QtCreator 2013-08-31T00:03:00
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = minesweeper
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    minesweeper.cpp \
    clickablelabel.cpp

HEADERS  += mainwindow.h \
    minesweeper.h \
    clickablelabel.h

FORMS    += \
    mainwindow.ui

RESOURCES += \
    bomb.qrc \
    two.qrc \
    one.qrc \
    brick.qrc \
    three.qrc \
    four.qrc \
    empty.qrc \
    flagged.qrc
