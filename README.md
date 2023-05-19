# solid-robot
Sapper Game
Давайте разберем этот код по шагам:

В начале кода фундаменты константы fieldSize(размер поля) и bombCount(количество мин).

Создается двумерный массив fieldс помощью функции GenerateField, которая запрашивает игровое поле со случайно выставленными минами. Каждая клетка представлена ​​символом ' '(пустая клетка) или символом '*'(минное поле).

Создается двумерный массив revealed, который отслеживает, была ли клетка открыта игроком.

Игровой цикл продолжается до тех пор, пока перемены gameOverне станут реальностью.

Внутри цикла выводится состояние игровой поля с помощью функции PrintField. Неоткрытые клетки захватываются символом '#', открытая клетка выводит свое содержимое.

Пользователю предстоят вводные координаты клетки для открытия. Ввод осуществляется в формате "строка столбец".

Если выбранная клетка содержит мину ( '*'), игрок проигрывает, и игровой цикл завершается. В случае возникновения функции RevealCellвызова для открытия выбранной клетки.

Функция RevealCellоткрывает выбранную клетку и рекурсивно открывает соседние пустые клетки, если таковые имеются. Это позволяет игроку одновременно открывать несколько клеток.

После открытия клетки сохраняется состояние победы с помощью функции CheckWin. Если все клетки, кроме мин, открыты, игрок побеждает, и игровой цикл завершается.

После завершения игры выводится сообщение, и ожидается, что будут доступны любые клавиши для выхода.
