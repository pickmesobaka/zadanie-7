<?php

declare(strict_types=1);

require_once 'Notification.php';

abstract class AbstractNotification implements Notification
{
    protected string $status = 'ожидание';
    protected string $timestamp;

    public function __construct()
    {
        $this->timestamp = date('Y-m-d H:i:s');
    }

    public function getStatus(): string
    {
        return $this->status;
    }

    abstract public function send(string $message): string;
    abstract public function getType(): string;
}