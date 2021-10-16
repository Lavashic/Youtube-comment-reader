# Youtube-comment-reader
1. Заходишь на нужный стрим, жмёшь F12
![Alt text](/Screenshot_1.png?raw=true)
2. Идёшь в network, ищешь запросы типа get_live_chat
3. Копируешь параметр key в строке Request URL
![Alt text](/Screenshot_2.png?raw=true)
4. Копируешь параметр continuation в request payload
![Alt text](/Screenshot_3.png?raw=true)
5. Вставляешь в соответствующие строки в файле parameters.json в корне
![Alt text](/Screenshot_4.png?raw=true)
6. Запускаешь, комменты должны обновляться раз в секунду
Чо с получаемыми комментами делать дальше разберёшься