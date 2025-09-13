<?php

declare(strict_types=1);

require_once 'src/Notification.php';
require_once 'src/AbstractNotification.php';
require_once 'src/EmailNotification.php';
require_once 'src/SMSNotification.php';

echo "=== Демонстрация системы уведомлений ===\n\n";

// Email уведомление
$email = new EmailNotification();
echo "📧 Email Уведомление:\n";
echo "Начальный статус: " . $email->getStatus() . "\n";
echo "Тип уведомления: " . $email->getType() . "\n";

$result = $email->send('Добро пожаловать в нашу систему! Ваш аккаунт успешно создан.');
echo "Результат отправки: " . $result . "\n";
echo "Статус после отправки: " . $email->getStatus() . "\n\n";

// SMS уведомление  
$sms = new SMSNotification();
echo "📱 SMS Уведомление:\n";
echo "Начальный статус: " . $sms->getStatus() . "\n";
echo "Тип уведомления: " . $sms->getType() . "\n";

$result = $sms->send('Ваш код подтверждения: 123456. Никому не сообщайте этот код.');
echo "Результат отправки: " . $result . "\n";
echo "Статус после отправки: " . $sms->getStatus() . "\n\n";

echo "✅ Все уведомления успешно отправлены!\n";