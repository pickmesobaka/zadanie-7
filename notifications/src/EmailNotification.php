<?php

declare(strict_types=1);

require_once 'AbstractNotification.php';

class EmailNotification extends AbstractNotification
{
    public function send(string $message): string
    {
        $this->status = 'отправлено';
        return "Email отправлен с таким содержимым: {$message}";
    }

    public function getType(): string
    {
        return 'Email';
    }
}