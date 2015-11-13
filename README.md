# Домашняя задача по проектированию

Сделайте fork этого репозитория и работайте в нем.

Вам нужно сделать генератор [облака слов](https://ru.wikipedia.org/wiki/%D0%9E%D0%B1%D0%BB%D0%B0%D0%BA%D0%BE_%D1%82%D0%B5%D0%B3%D0%BE%D0%B2) по произвольному тексту.
[Примеры](https://www.google.ru/search?q=%D0%9E%D0%B1%D0%BB%D0%B0%D0%BA%D0%BE+%D1%81%D0%BB%D0%BE%D0%B2&tbm=isch).

В облаке не должно быть повторяющихся слов, размер слова должен быть тем больше, чем чаще встречается слово, не должно быть "скучных" слов (предлогов, местоимений, ...).

## Дополнительные ограничения

### Точки расширения

В промышленном программировании при разработке далеко не всегда разумно создавать точки расширения "на будущее". 
Чаще руководствуются принципами YAGNI и KISS, поддерживая код как можно проще, а абстракции создаются и внедряются в код только в момент, 
когда понадобилось расширить функциональность.

Тем не менее для учебных целей в этой задаче мы требуем заранее предусмотреть точки расширения для наиболее вероятных потенциальных изменений в вашем продукте.
Результат вашей работы должен быть расширяем без модификации уже имеющегося кода (Принцип OCP).

### Полиморфизм вместо условных операторов

Вам запрещено использовать операторы if, switch, ?: и прочие условные операторы, если их можно заменить полиморфизмом.

### Dependency injection

Для сборки зависимостей используйте DI Container.

### Тесты

Все нетривиальные части покройте модульными тестами.
Добавьте несколько более крупных тестов, проверяющих работу всей программы в сборе.

## Функциональные требования и их возможные изменения

Ниже описаны обязательные пункты и возможные. 
Выполните обязательные требования, а потом выберите и реализуйте несколько понравившихся пункты из перспективы.

Даже если требование из перспективы не выполнено, соответствующая точка расширения в вашем коде уже должна быть.

### Исходный текст 

* Источником данных должен быть файл со словами по одному в строке.
* В перспективе — поддерживать ввод данных из литературного текста, с приведением слов в начальную форму.
* В перспективе — поддерживать разные форматы файлов (txt, doc, docx, ...)
* В перспективе — дать возможность влиять на список скучных слов, которые не попадут в облако.

### Формат результата

* В качестве результата программа должна генерировать png-файл. 
* Должна быть возможность задать цвета, шрифт и размер изображения.
* В перспективе — поддерживать разные форматы изображений.
* В перспективе — поддерживать разные способы расцветки слов.

### Алгоритм

* Придумайте или найдите алгоритм формирования облака тегов. 
* Сделайте так, чтобы по одному тексту можно было сгенерировать несколько облаков тегов с помощью разных алгоритмов или одного алгоритма с разными настройками.
* В перспективе — реализовать несколько алгоритмов формирования облака тегов.

### GUI или Console

* Организуйте код так, чтобы было легко сделать оба вида клиентов — и клиента командной строки, и GUI приложение с вводом параметров и интерактивным просмотром.
* Реализуйте одного клиента по вашему выбору.

## Дополнительные ссылки

* Библиотеки для разбора аргументов командной строки:
	
	* https://github.com/gsscoder/commandline
	* https://github.com/docopt/docopt.net

* Приведение слова к начальной форме:
	
	* Библиотека NHunspell http://www.crawler-lib.net/nhunspell
	* Утилита командной строки MyStem https://tech.yandex.ru/mystem/doc/usage-examples-docpage/
	
	
