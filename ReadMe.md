>_PLEASE NOTE that the project is still in early phase and structural changes are possible. Documentation will be extended._

### Introduction

Overal inspiration comes from my desire to have a project where I can just define a new command using some convention, implement the command, define the command payload and everything will automatically become available for execution (either using CLI or Web).

In the past, for many times I was in the situation where I needed to create or maintain the project that just executes different commands either as a part of the bigger project or as a general-purpose project that holds some cross-project commands and tools. The purpose of those commands is broad and literally the command can do anything. For example, scheduled jobs that just copy some data, specific exports/backups from database or multiple databases, scheduled downloads, reports, health checks, triggers, etc... Basically anything that can be executed as an independent/isolated piece of functionality on demand or scheduled.

The idea is to have commands isolated from each other and that each command represents only one piece of functionality. If there are some commands that operate in the same context they can be grouped, but that's only for easier navigation through the list of available commands. 

Project structure and conventions will be explained in upcoming documentation updates.










