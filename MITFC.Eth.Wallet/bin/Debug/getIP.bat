@echo off
set subnet1=15
set subnet2=16
set subnet3=20

set /a num=0
for /f "tokens=2 delims=:" %%i in ('ipconfig^|findstr "Address"') do (
    echo =====================
    set var=%%i
    echo var=%%i

    for /f "tokens=1 delims= " %%a in ("%%i") do (
        set var2=%%a
        echo var2=%%a

	for /f "tokens=1 delims=." %%x in ("%%a") do (
    	    set var3=%%x
    	    echo var3=%%x

	if %%x==%subnet1% (
	    echo "yes yes yes"
	    echo "This is end of script"
	    set /a num+=1
	    goto jumpout
	) else ( if %%x==%subnet2% (
		     echo "yes yes yes"
	             echo "This is end of script"
		     set /a num+=1
	             goto jumpout
	         ) else ( if %%x==%subnet3% (
		         echo "yes yes yes"
	                 echo "This is end of script"
		         set /a num+=1
	                 goto jumpout
	                  ) else (
	                     echo "no no no"
			         )
                        )
	       )

        )
    )

)

:jumpout
echo JUMPOUT RESULT IS %var%
echo num=%num%

REM if not "%var%"=="" (
if not %num%==0 (
    goto jumpend
)

for /f "tokens=2 delims=:" %%i in ('ipconfig^|findstr "µÿ÷∑"') do (
    echo =====================
    set var=%%i
    echo var=%%i

    for /f "tokens=1 delims= " %%a in ("%%i") do (
        set var2=%%a
        echo var2=%%a

	for /f "tokens=1 delims=." %%x in ("%%a") do (
    	    set var3=%%x
    	    echo var3=%%x

	if %%x==%subnet1% (
	    echo "yes yes yes"
	    echo "This is end of script"
	    goto jumpend
	) else ( if %%x==%subnet2% (
		     echo "yes yes yes"
	             echo "This is end of script"
	             goto jumpend
	         ) else (
	             echo "no no no"
			)
	       )

        )
    )

)


:jumpend
echo %var%