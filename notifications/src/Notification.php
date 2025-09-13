<?php

declare(strict_types=1);

interface Notification
{
    public function send(string $message): string;
    public function getStatus(): string;
    public function getType(): string;
}