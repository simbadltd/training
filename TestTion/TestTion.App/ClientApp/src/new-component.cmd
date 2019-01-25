@echo off
@echo Generating new component "%1"
@echo example new-component finstat
ng generate component %1 --module=app
