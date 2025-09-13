<?php

declare(strict_types=1);

require_once 'AbstractNotification.php';

class SMSNotification extends AbstractNotification
{
    public function send(string $message): string
    {
        $this->status = 'отправлено';
        return "SMS отправлен с таким содержимым: {$message}";
    }

    public function getType(): string
    {
        return 'SMS';
    }
}