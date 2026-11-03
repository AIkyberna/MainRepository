import sys
sys.stdout.reconfigure(encoding='utf-8')

# Проверяем, пришло ли сообщение от C#
if len(sys.argv) > 1:
    message = sys.argv[1]
    print(f"Успех! Python получил от C#: '{message}'")
else:
    print("Ошибка: аргументы не переданы.")