–(
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Areas\Gamification\Controllers\UserBadgeController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Areas  
.  !
Gamification! -
.- .
Controllers. 9
{ 
[ 
Area 	
(	 

$str
 
) 
] 
[ 
Route 

(
 
$str #
)# $
]$ %
public 

class 
UserBadgeController $
:% & 
SecureBaseController' ;
{ 
private 
readonly  
IUserBadgeAppService -
userBadgeAppService. A
;A B
public 
UserBadgeController "
(" # 
IUserBadgeAppService# 7
userBadgeAppService8 K
)K L
{ 	
this 
. 
userBadgeAppService $
=% &
userBadgeAppService' :
;: ;
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	

Dictionary 
< 
string 
, 
UiInfoAttribute .
>. /
badges0 6
=7 8
SetBadgeList9 E
(E F
)F G
;G H
ViewData 
[ 
$str 
] 
=  
badges! '
;' (
return   
View   
(   
)   
;   
}!! 	
[## 	
Route##	 
(## 
$str## 
)## 
]## 
public$$ 
IActionResult$$ 
List$$ !
($$! "
Guid$$" &
id$$' )
)$$) *
{%% 	!
OperationResultListVo&& !
<&&! "
UserBadgeViewModel&&" 4
>&&4 5
badges&&6 <
=&&= >
userBadgeAppService&&? R
.&&R S
	GetByUser&&S \
(&&\ ]
id&&] _
)&&_ `
;&&` a
return(( 
View(( 
((( 
$str(( 
,((  
badges((! '
.((' (
Value((( -
)((- .
;((. /
})) 	
private** 
static** 

Dictionary** !
<**! "
string**" (
,**( )
UiInfoAttribute*** 9
>**9 :
SetBadgeList**; G
(**G H
)**H I
{++ 	
List,, 
<,, 
KeyValuePair,, 
<,, 
string,, $
,,,$ %
UiInfoAttribute,,& 5
>,,5 6
>,,6 7
list,,8 <
=,,= >
new,,? B
List,,C G
<,,G H
KeyValuePair,,H T
<,,T U
string,,U [
,,,[ \
UiInfoAttribute,,] l
>,,l m
>,,m n
(,,n o
),,o p
;,,p q
IEnumerable.. 
<.. 
	BadgeType.. !
>..! "
badges..# )
=..* +
Enum.., 0
...0 1
	GetValues..1 :
(..: ;
typeof..; A
(..A B
	BadgeType..B K
)..K L
)..L M
...M N
Cast..N R
<..R S
	BadgeType..S \
>..\ ]
(..] ^
)..^ _
;.._ `
badges00 
.00 
ToList00 
(00 
)00 
.00 
ForEach00 #
(00# $
x00$ %
=>00& (
{11 
var22 
uiInfo22 
=22 
x22 
.22 
GetAttributeOfType22 1
<221 2
UiInfoAttribute222 A
>22A B
(22B C
)22C D
;22D E
string33 
displayTitle33 #
=33$ %
uiInfo33& ,
.33, -
Display33- 4
;334 5
string44 
description44 "
=44# $
uiInfo44% +
.44+ ,
Description44, 7
;447 8
list66 
.66 
Add66 
(66 
new66 
KeyValuePair66 )
<66) *
string66* 0
,660 1
UiInfoAttribute662 A
>66A B
(66B C
x66C D
.66D E
ToString66E M
(66M N
)66N O
,66O P
uiInfo66Q W
)66W X
)66X Y
;66Y Z
}77 
)77 
;77 

Dictionary99 
<99 
string99 
,99 
UiInfoAttribute99 .
>99. /
dict990 4
=995 6
list997 ;
.99; <
OrderBy99< C
(99C D
x99D E
=>99F H
x99I J
.99J K
Value99K P
.99P Q
Order99Q V
)99V W
.99W X
ToDictionary99X d
(99d e
x99e f
=>99g i
x99j k
.99k l
Key99l o
,99o p
x99q r
=>99s u
x99v w
.99w x
Value99x }
)99} ~
;99~ 
return;; 
dict;; 
;;; 
}<< 	
}== 
}>> Ô
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Areas\Member\Controllers\Base\MemberBaseController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Areas  
.  !
Member! '
.' (
Controllers( 3
.3 4
Base4 8
{		 
[

 
Area

 	
(

	 

$str


 
)

 
]

 
public 

class  
MemberBaseController %
:& ' 
SecureBaseController( <
{ 
} 
} ¥
vC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Areas\Member\Controllers\MessageController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Areas  
.  !
Member! '
.' (
Controllers( 3
{		 
public

 

class

 
MessageController

 "
:

# $ 
MemberBaseController

% 9
{ 
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
} 
} É
zC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Areas\Member\Controllers\PreferencesController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Areas  
.  !
Member! '
.' (
Controllers( 3
{ 
public 

class !
PreferencesController &
:' ( 
MemberBaseController) =
{ 
private 
readonly &
IUserPreferencesAppService 3
_appService4 ?
;? @
public !
PreferencesController $
($ %&
IUserPreferencesAppService% ?

appService@ J
)J K
{ 	
_appService 
= 

appService $
;$ %
} 	
public 
IActionResult 
Edit !
(! "
)" #
{ 	$
UserPreferencesViewModel $
vm% '
=( )
_appService* 5
.5 6
GetByUserId6 A
(A B
CurrentUserIdB O
)O P
;P Q
return 
View 
( 
$str $
,$ %
vm& (
)( )
;) *
}   	
["" 	
HttpPost""	 
]"" 
public## 
IActionResult## 
Save## !
(##! "$
UserPreferencesViewModel##" :
vm##; =
)##= >
{$$ 	
try%% 
{&& 
vm'' 
.'' 
UserId'' 
='' 
CurrentUserId'' )
;'') *
_appService)) 
.)) 
Save))  
())  !
vm))! #
)))# $
;))$ %
var++ 
selectedCulture++ #
=++$ %
vm++& (
.++( )

UiLanguage++) 3
.++3 4
GetAttributeOfType++4 F
<++F G
UiInfoAttribute++G V
>++V W
(++W X
)++X Y
.++Y Z
Culture++Z a
;++a b
SetLanguage-- 
(-- 
selectedCulture-- +
)--+ ,
;--, -
return00 
Json00 
(00 
new00 
OperationResultVo00  1
(001 2
true002 6
)006 7
)007 8
;008 9
}11 
catch22 
(22 
	Exception22 
ex22 
)22  
{33 
return44 
Json44 
(44 
new44 
OperationResultVo44  1
(441 2
ex442 4
.444 5
Message445 <
)44< =
)44= >
;44> ?
}55 
}66 	
public88 
void88 
SetLanguage88 
(88  
string88  &
culture88' .
)88. /
{99 	
Response:: 
.:: 
Cookies:: 
.:: 
Append:: #
(::# $(
CookieRequestCultureProvider;; ,
.;;, -
DefaultCookieName;;- >
,;;> ?(
CookieRequestCultureProvider<< ,
.<<, -
MakeCookieValue<<- <
(<<< =
new<<= @
RequestCulture<<A O
(<<O P
culture<<P W
)<<W X
)<<X Y
,<<Y Z
new== 
CookieOptions== !
{==" #
Expires==$ +
===, -
DateTimeOffset==. <
.==< =
UtcNow=== C
.==C D
AddYears==D L
(==L M
$num==M N
)==N O
,==O P
IsEssential==Q \
===] ^
true==_ c
}==d e
)>> 
;>> 
}?? 	
}@@ 
}AA Î
|C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Areas\Staff\Controllers\Base\StaffBaseController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Areas  
.  !
Staff! &
.& '
Controllers' 2
.2 3
Base3 7
{		 
[

 
Area

 	
(

	 

$str


 
)

 
]

 
public 

class 
StaffBaseController $
:% & 
SecureBaseController' ;
{ 
} 
} Â
}C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Areas\Staff\Controllers\FeaturedContentController.cs
	namespace		 	
IndieVisible		
 
.		 
Web		 
.		 
Areas		  
.		  !
Staff		! &
.		& '
Controllers		' 2
{

 
[ 
Route 

(
 
$str "
)" #
]# $
public 

class %
FeaturedContentController *
:+ ,
StaffBaseController- @
{ 
private 
readonly "
IUserContentAppService /
_contentService0 ?
;? @
private 
readonly &
IFeaturedContentAppService 3
_service4 <
;< =
public %
FeaturedContentController (
(( )"
IUserContentAppService) ?
contentService@ N
,N O&
IFeaturedContentAppServiceP j
servicek r
)r s
{ 	
_contentService 
= 
contentService ,
;, -
_service 
= 
service 
; 
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
[!! 	
Route!!	 
(!! 
$str!! 
)!! 
]!! 
public"" 
IActionResult"" 
List"" !
(""! "
)""" #
{## 	
IEnumerable$$ 
<$$ ,
 UserContentToBeFeaturedViewModel$$ 8
>$$8 9
model$$: ?
=$$@ A
_service$$B J
.$$J K"
GetContentToBeFeatured$$K a
($$a b
)$$b c
;$$c d
return&& 
PartialView&& 
(&& 
$str&& &
,&&& '
model&&( -
)&&- .
;&&. /
}'' 	
[** 	
HttpPost**	 
(** 
$str** 
)** 
]** 
public++ 
IActionResult++ 
Add++  
(++  !
Guid++! %
id++& (
,++( )
string++* 0
title++1 6
,++6 7
string++8 >
introduction++? K
)++K L
{,, 	
var-- 
operationResult-- 
=--  !
_service--" *
.--* +
Add--+ .
(--. /
CurrentUserId--/ <
,--< =
id--> @
,--@ A
title--B G
,--G H
introduction--I U
)--U V
;--V W
return// 
Json// 
(// 
operationResult// '
)//' (
;//( )
}00 	
[33 	
HttpPost33	 
(33 
$str33 
)33 
]33 
public44 
IActionResult44 
Remove44 #
(44# $
Guid44$ (
id44) +
,44+ ,
string44- 3
title444 9
,449 :
string44; A
introduction44B N
)44N O
{55 	
OperationResultVo66 
operationResult66 -
;66- .
try88 
{99 
operationResult:: 
=::  !
_service::" *
.::* +
	Unfeature::+ 4
(::4 5
id::5 7
)::7 8
;::8 9
};; 
catch<< 
(<< 
	Exception<< 
ex<< 
)<<  
{== 
operationResult>> 
=>>  !
new>>" %
OperationResultVo>>& 7
(>>7 8
ex>>8 :
.>>: ;
Message>>; B
)>>B C
;>>C D
}?? 
returnAA 
JsonAA 
(AA 
operationResultAA '
)AA' (
;AA( )
}BB 	
}CC 
}DD Ó
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Areas\Staff\Controllers\SuperPowersController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Areas  
.  !
Staff! &
.& '
Controllers' 2
{		 
public

 

class

 !
SuperPowersController

 &
:

' (
StaffBaseController

) <
{ 
public 
IActionResult 
Index "
(" #
)# $
{ 	
CookieMgrService 
. 
Set  
(  !
$str! 0
,0 1
$str2 8
,8 9
$num: ;
); <
;< =
ViewData 
[ 
$str $
]$ %
=& '
true( ,
;, -
return 
View 
( 
) 
; 
} 	
} 
} ≈
YC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\ConfigOptions.cs
	namespace 	
IndieVisible
 
. 
Web 
{ 
public 

class 
ConfigOptions 
{		 
public

 
string

 
FacebookAppId

 #
{

$ %
get

& )
;

) *
set

+ .
;

. /
}

0 1
} 
} ÚÃ
iC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\AccountController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
[ 
	Authorize 
] 
[ 
Route 

(
 
$str "
)" #
]# $
public 

class 
AccountController "
:# $ 
SecureBaseController% 9
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
SignInManager &
<& '
ApplicationUser' 6
>6 7
_signInManager8 F
;F G
private   
readonly   
IProfileAppService   +
_profileAppService  , >
;  > ?
private!! 
readonly!! 
IEmailSender!! %
_emailSender!!& 2
;!!2 3
private"" 
readonly"" 
ILogger""  
_logger""! (
;""( )
public$$ 
AccountController$$  
($$  !
UserManager%% 
<%% 
ApplicationUser%% '
>%%' (
userManager%%) 4
,%%4 5
SignInManager&& 
<&& 
ApplicationUser&& )
>&&) *
signInManager&&+ 8
,&&8 9
IProfileAppService'' 
profileAppService'' 0
,''0 1
IEmailSender(( 
emailSender(( $
,(($ %
ILogger)) 
<)) 
AccountController)) %
>))% &
logger))' -
,))- .
IMapper** 
mapper** 
)** 
:** 
base** "
(**" #
)**# $
{++ 	
_userManager,, 
=,, 
userManager,, &
;,,& '
_signInManager-- 
=-- 
signInManager-- *
;--* +
_profileAppService.. 
=..  
profileAppService..! 2
;..2 3
_emailSender// 
=// 
emailSender// &
;//& '
_logger00 
=00 
logger00 
;00 
}11 	
[33 	
TempData33	 
]33 
public44 
string44 
ErrorMessage44 "
{44# $
get44% (
;44( )
set44* -
;44- .
}44/ 0
[66 	
HttpGet66	 
]66 
[77 	
AllowAnonymous77	 
]77 
[88 	
Route88	 
(88 
$str88 
)88  
]88  !
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' (
Login99) .
(99. /
string99/ 5
	returnUrl996 ?
=99@ A
null99B F
)99F G
{:: 	
await<< 
HttpContext<< 
.<< 
SignOutAsync<< *
(<<* +
IdentityConstants<<+ <
.<<< =
ExternalScheme<<= K
)<<K L
;<<L M
ViewData>> 
[>> 
$str>>  
]>>  !
=>>" #
	returnUrl>>$ -
;>>- .
return?? 
View?? 
(?? 
)?? 
;?? 
}@@ 	
[BB 	
HttpPostBB	 
]BB 
[CC 	
AllowAnonymousCC	 
]CC 
[DD 	$
ValidateAntiForgeryTokenDD	 !
]DD! "
publicEE 
asyncEE 
TaskEE 
<EE 
IActionResultEE '
>EE' (
LoginEE) .
(EE. /
LoginViewModelEE/ =
modelEE> C
,EEC D
stringEEE K
	returnUrlEEL U
=EEV W
nullEEX \
)EE\ ]
{FF 	
ViewDataGG 
[GG 
$strGG  
]GG  !
=GG" #
	returnUrlGG$ -
;GG- .
ifHH 
(HH 

ModelStateHH 
.HH 
IsValidHH "
)HH" #
{II 
	MicrosoftLL 
.LL 

AspNetCoreLL $
.LL$ %
IdentityLL% -
.LL- .
SignInResultLL. :
resultLL; A
=LLB C
awaitLLD I
_signInManagerLLJ X
.LLX Y
PasswordSignInAsyncLLY l
(LLl m
modelLLm r
.LLr s
UserNameLLs {
,LL{ |
model	LL} Ç
.
LLÇ É
Password
LLÉ ã
,
LLã å
model
LLç í
.
LLí ì

RememberMe
LLì ù
,
LLù û
lockoutOnFailure
LLü Ø
:
LLØ ∞
false
LL± ∂
)
LL∂ ∑
;
LL∑ ∏
ifMM 
(MM 
resultMM 
.MM 
	SucceededMM $
)MM$ %
{NN 
ifOO 
(OO 
!OO 
stringOO 
.OO  
IsNullOrWhiteSpaceOO  2
(OO2 3
modelOO3 8
.OO8 9
UserNameOO9 A
)OOA B
)OOB C
{PP 
ApplicationUserQQ '
userQQ( ,
=QQ- .
awaitQQ/ 4
_userManagerQQ5 A
.QQA B
FindByNameAsyncQQB Q
(QQQ R
modelQQR W
.QQW X
UserNameQQX `
)QQ` a
;QQa b
ifSS 
(SS 
userSS  
!=SS! #
nullSS$ (
&&SS) +
!SS, -
stringSS- 3
.SS3 4
IsNullOrWhiteSpaceSS4 F
(SSF G
userSSG K
.SSK L
UserNameSSL T
)SST U
)SSU V
{TT 
thisUU  
.UU  !
SetProfileSessionUU! 2
(UU2 3
userUU3 7
.UU7 8
IdUU8 :
,UU: ;
userUU< @
.UU@ A
UserNameUUA I
)UUI J
;UUJ K
awaitWW !
SetStaffRolesWW" /
(WW/ 0
userWW0 4
)WW4 5
;WW5 6
}XX 
}YY 
_logger[[ 
.[[ 
LogInformation[[ *
([[* +
$str[[+ <
)[[< =
;[[= >
return\\ 
RedirectToLocal\\ *
(\\* +
	returnUrl\\+ 4
)\\4 5
;\\5 6
}]] 
if__ 
(__ 
result__ 
.__ 
RequiresTwoFactor__ ,
)__, -
{`` 
returnaa 
RedirectToActionaa +
(aa+ ,
nameofaa, 2
(aa2 3
LoginWith2faaa3 ?
)aa? @
,aa@ A
newaaB E
{aaF G
	returnUrlaaH Q
,aaQ R
modelaaS X
.aaX Y

RememberMeaaY c
}aad e
)aae f
;aaf g
}bb 
ifdd 
(dd 
resultdd 
.dd 
IsLockedOutdd &
)dd& '
{ee 
_loggerff 
.ff 

LogWarningff &
(ff& '
$strff' A
)ffA B
;ffB C
returngg 
RedirectToActiongg +
(gg+ ,
nameofgg, 2
(gg2 3
Lockoutgg3 :
)gg: ;
)gg; <
;gg< =
}hh 
elseii 
{jj 

ModelStatekk 
.kk 
AddModelErrorkk ,
(kk, -
stringkk- 3
.kk3 4
Emptykk4 9
,kk9 :
$strkk; S
)kkS T
;kkT U
returnll 
Viewll 
(ll  
modelll  %
)ll% &
;ll& '
}mm 
}nn 
returnqq 
Viewqq 
(qq 
modelqq 
)qq 
;qq 
}rr 	
[tt 	
HttpGettt	 
]tt 
[uu 	
AllowAnonymousuu	 
]uu 
publicvv 
asyncvv 
Taskvv 
<vv 
IActionResultvv '
>vv' (
LoginWith2favv) 5
(vv5 6
boolvv6 :

rememberMevv; E
,vvE F
stringvvG M
	returnUrlvvN W
=vvX Y
nullvvZ ^
)vv^ _
{ww 	
ApplicationUseryy 
useryy  
=yy! "
awaityy# (
_signInManageryy) 7
.yy7 8/
#GetTwoFactorAuthenticationUserAsyncyy8 [
(yy[ \
)yy\ ]
;yy] ^
if{{ 
({{ 
user{{ 
=={{ 
null{{ 
){{ 
{|| 
throw}} 
new}}  
ApplicationException}} .
(}}. /
$"}}/ 1:
.Unable to load two-factor authentication user.}}1 _
"}}_ `
)}}` a
;}}a b
}~~ #
LoginWith2faViewModel
ÄÄ !
model
ÄÄ" '
=
ÄÄ( )
new
ÄÄ* -#
LoginWith2faViewModel
ÄÄ. C
{
ÄÄD E

RememberMe
ÄÄF P
=
ÄÄQ R

rememberMe
ÄÄS ]
}
ÄÄ^ _
;
ÄÄ_ `
ViewData
ÅÅ 
[
ÅÅ 
$str
ÅÅ  
]
ÅÅ  !
=
ÅÅ" #
	returnUrl
ÅÅ$ -
;
ÅÅ- .
return
ÉÉ 
View
ÉÉ 
(
ÉÉ 
model
ÉÉ 
)
ÉÉ 
;
ÉÉ 
}
ÑÑ 	
[
ÜÜ 	
HttpPost
ÜÜ	 
]
ÜÜ 
[
áá 	
AllowAnonymous
áá	 
]
áá 
[
àà 	&
ValidateAntiForgeryToken
àà	 !
]
àà! "
public
ââ 
async
ââ 
Task
ââ 
<
ââ 
IActionResult
ââ '
>
ââ' (
LoginWith2fa
ââ) 5
(
ââ5 6#
LoginWith2faViewModel
ââ6 K
model
ââL Q
,
ââQ R
bool
ââS W

rememberMe
ââX b
,
ââb c
string
ââd j
	returnUrl
ââk t
=
ââu v
null
ââw {
)
ââ{ |
{
ää 	
if
ãã 
(
ãã 
!
ãã 

ModelState
ãã 
.
ãã 
IsValid
ãã #
)
ãã# $
{
åå 
return
çç 
View
çç 
(
çç 
model
çç !
)
çç! "
;
çç" #
}
éé 
ApplicationUser
êê 
user
êê  
=
êê! "
await
êê# (
_signInManager
êê) 7
.
êê7 81
#GetTwoFactorAuthenticationUserAsync
êê8 [
(
êê[ \
)
êê\ ]
;
êê] ^
if
ëë 
(
ëë 
user
ëë 
==
ëë 
null
ëë 
)
ëë 
{
íí 
throw
ìì 
new
ìì "
ApplicationException
ìì .
(
ìì. /
$"
ìì/ 1+
Unable to load user with ID '
ìì1 N
{
ììN O
_userManager
ììO [
.
ìì[ \
	GetUserId
ìì\ e
(
ììe f
User
ììf j
)
ììj k
}
ììk l
'.
ììl n
"
ììn o
)
ììo p
;
ììp q
}
îî 
string
ññ 
authenticatorCode
ññ $
=
ññ% &
model
ññ' ,
.
ññ, -
TwoFactorCode
ññ- :
.
ññ: ;
Replace
ññ; B
(
ññB C
$str
ññC F
,
ññF G
string
ññH N
.
ññN O
Empty
ññO T
)
ññT U
.
ññU V
Replace
ññV ]
(
ññ] ^
$str
ññ^ a
,
ñña b
string
ññc i
.
ññi j
Empty
ññj o
)
ñño p
;
ññp q
	Microsoft
òò 
.
òò 

AspNetCore
òò  
.
òò  !
Identity
òò! )
.
òò) *
SignInResult
òò* 6
result
òò7 =
=
òò> ?
await
òò@ E
_signInManager
òòF T
.
òòT U/
!TwoFactorAuthenticatorSignInAsync
òòU v
(
òòv w 
authenticatorCodeòòw à
,òòà â

rememberMeòòä î
,òòî ï
modelòòñ õ
.òòõ ú
RememberMachineòòú ´
)òò´ ¨
;òò¨ ≠
if
öö 
(
öö 
result
öö 
.
öö 
	Succeeded
öö  
)
öö  !
{
õõ 
_logger
úú 
.
úú 
LogInformation
úú &
(
úú& '
$str
úú' R
,
úúR S
user
úúT X
.
úúX Y
Id
úúY [
)
úú[ \
;
úú\ ]
return
ùù 
RedirectToLocal
ùù &
(
ùù& '
	returnUrl
ùù' 0
)
ùù0 1
;
ùù1 2
}
ûû 
else
üü 
if
üü 
(
üü 
result
üü 
.
üü 
IsLockedOut
üü '
)
üü' (
{
†† 
_logger
°° 
.
°° 

LogWarning
°° "
(
°°" #
$str
°°# N
,
°°N O
user
°°P T
.
°°T U
Id
°°U W
)
°°W X
;
°°X Y
return
¢¢ 
RedirectToAction
¢¢ '
(
¢¢' (
nameof
¢¢( .
(
¢¢. /
Lockout
¢¢/ 6
)
¢¢6 7
)
¢¢7 8
;
¢¢8 9
}
££ 
else
§§ 
{
•• 
_logger
¶¶ 
.
¶¶ 

LogWarning
¶¶ "
(
¶¶" #
$str
¶¶# b
,
¶¶b c
user
¶¶d h
.
¶¶h i
Id
¶¶i k
)
¶¶k l
;
¶¶l m

ModelState
ßß 
.
ßß 
AddModelError
ßß (
(
ßß( )
string
ßß) /
.
ßß/ 0
Empty
ßß0 5
,
ßß5 6
$str
ßß7 T
)
ßßT U
;
ßßU V
return
®® 
View
®® 
(
®® 
)
®® 
;
®® 
}
©© 
}
™™ 	
[
¨¨ 	
HttpGet
¨¨	 
]
¨¨ 
[
≠≠ 	
AllowAnonymous
≠≠	 
]
≠≠ 
public
ÆÆ 
async
ÆÆ 
Task
ÆÆ 
<
ÆÆ 
IActionResult
ÆÆ '
>
ÆÆ' (#
LoginWithRecoveryCode
ÆÆ) >
(
ÆÆ> ?
string
ÆÆ? E
	returnUrl
ÆÆF O
=
ÆÆP Q
null
ÆÆR V
)
ÆÆV W
{
ØØ 	
ApplicationUser
±± 
user
±±  
=
±±! "
await
±±# (
_signInManager
±±) 7
.
±±7 81
#GetTwoFactorAuthenticationUserAsync
±±8 [
(
±±[ \
)
±±\ ]
;
±±] ^
if
≤≤ 
(
≤≤ 
user
≤≤ 
==
≤≤ 
null
≤≤ 
)
≤≤ 
{
≥≥ 
throw
¥¥ 
new
¥¥ "
ApplicationException
¥¥ .
(
¥¥. /
$"
¥¥/ 1<
.Unable to load two-factor authentication user.
¥¥1 _
"
¥¥_ `
)
¥¥` a
;
¥¥a b
}
µµ 
ViewData
∑∑ 
[
∑∑ 
$str
∑∑  
]
∑∑  !
=
∑∑" #
	returnUrl
∑∑$ -
;
∑∑- .
return
ππ 
View
ππ 
(
ππ 
)
ππ 
;
ππ 
}
∫∫ 	
[
ºº 	
HttpPost
ºº	 
]
ºº 
[
ΩΩ 	
AllowAnonymous
ΩΩ	 
]
ΩΩ 
[
ææ 	&
ValidateAntiForgeryToken
ææ	 !
]
ææ! "
public
øø 
async
øø 
Task
øø 
<
øø 
IActionResult
øø '
>
øø' (#
LoginWithRecoveryCode
øø) >
(
øø> ?,
LoginWithRecoveryCodeViewModel
øø? ]
model
øø^ c
,
øøc d
string
øøe k
	returnUrl
øøl u
=
øøv w
null
øøx |
)
øø| }
{
¿¿ 	
if
¡¡ 
(
¡¡ 
!
¡¡ 

ModelState
¡¡ 
.
¡¡ 
IsValid
¡¡ #
)
¡¡# $
{
¬¬ 
return
√√ 
View
√√ 
(
√√ 
model
√√ !
)
√√! "
;
√√" #
}
ƒƒ 
ApplicationUser
∆∆ 
user
∆∆  
=
∆∆! "
await
∆∆# (
_signInManager
∆∆) 7
.
∆∆7 81
#GetTwoFactorAuthenticationUserAsync
∆∆8 [
(
∆∆[ \
)
∆∆\ ]
;
∆∆] ^
if
«« 
(
«« 
user
«« 
==
«« 
null
«« 
)
«« 
{
»» 
throw
…… 
new
…… "
ApplicationException
…… .
(
……. /
$"
……/ 1<
.Unable to load two-factor authentication user.
……1 _
"
……_ `
)
……` a
;
……a b
}
   
string
ÃÃ 
recoveryCode
ÃÃ 
=
ÃÃ  !
model
ÃÃ" '
.
ÃÃ' (
RecoveryCode
ÃÃ( 4
.
ÃÃ4 5
Replace
ÃÃ5 <
(
ÃÃ< =
$str
ÃÃ= @
,
ÃÃ@ A
string
ÃÃB H
.
ÃÃH I
Empty
ÃÃI N
)
ÃÃN O
;
ÃÃO P
	Microsoft
ŒŒ 
.
ŒŒ 

AspNetCore
ŒŒ  
.
ŒŒ  !
Identity
ŒŒ! )
.
ŒŒ) *
SignInResult
ŒŒ* 6
result
ŒŒ7 =
=
ŒŒ> ?
await
ŒŒ@ E
_signInManager
ŒŒF T
.
ŒŒT U.
 TwoFactorRecoveryCodeSignInAsync
ŒŒU u
(
ŒŒu v
recoveryCodeŒŒv Ç
)ŒŒÇ É
;ŒŒÉ Ñ
if
–– 
(
–– 
result
–– 
.
–– 
	Succeeded
––  
)
––  !
{
—— 
_logger
““ 
.
““ 
LogInformation
““ &
(
““& '
$str
““' ^
,
““^ _
user
““` d
.
““d e
Id
““e g
)
““g h
;
““h i
return
”” 
RedirectToLocal
”” &
(
””& '
	returnUrl
””' 0
)
””0 1
;
””1 2
}
‘‘ 
if
’’ 
(
’’ 
result
’’ 
.
’’ 
IsLockedOut
’’ "
)
’’" #
{
÷÷ 
_logger
◊◊ 
.
◊◊ 

LogWarning
◊◊ "
(
◊◊" #
$str
◊◊# N
,
◊◊N O
user
◊◊P T
.
◊◊T U
Id
◊◊U W
)
◊◊W X
;
◊◊X Y
return
ÿÿ 
RedirectToAction
ÿÿ '
(
ÿÿ' (
nameof
ÿÿ( .
(
ÿÿ. /
Lockout
ÿÿ/ 6
)
ÿÿ6 7
)
ÿÿ7 8
;
ÿÿ8 9
}
ŸŸ 
else
⁄⁄ 
{
€€ 
_logger
‹‹ 
.
‹‹ 

LogWarning
‹‹ "
(
‹‹" #
$str
‹‹# \
,
‹‹\ ]
user
‹‹^ b
.
‹‹b c
Id
‹‹c e
)
‹‹e f
;
‹‹f g

ModelState
›› 
.
›› 
AddModelError
›› (
(
››( )
string
››) /
.
››/ 0
Empty
››0 5
,
››5 6
$str
››7 W
)
››W X
;
››X Y
return
ﬁﬁ 
View
ﬁﬁ 
(
ﬁﬁ 
)
ﬁﬁ 
;
ﬁﬁ 
}
ﬂﬂ 
}
‡‡ 	
[
‚‚ 	
HttpGet
‚‚	 
]
‚‚ 
[
„„ 	
AllowAnonymous
„„	 
]
„„ 
public
‰‰ 
IActionResult
‰‰ 
Lockout
‰‰ $
(
‰‰$ %
)
‰‰% &
{
ÂÂ 	
return
ÊÊ 
View
ÊÊ 
(
ÊÊ 
)
ÊÊ 
;
ÊÊ 
}
ÁÁ 	
[
ÈÈ 	
HttpGet
ÈÈ	 
]
ÈÈ 
[
ÍÍ 	
AllowAnonymous
ÍÍ	 
]
ÍÍ 
[
ÎÎ 	
Route
ÎÎ	 
(
ÎÎ 
$str
ÎÎ "
)
ÎÎ" #
]
ÎÎ# $
public
ÏÏ 
IActionResult
ÏÏ 
Register
ÏÏ %
(
ÏÏ% &
string
ÏÏ& ,
	returnUrl
ÏÏ- 6
=
ÏÏ7 8
null
ÏÏ9 =
)
ÏÏ= >
{
ÌÌ 	
ViewData
ÓÓ 
[
ÓÓ 
$str
ÓÓ  
]
ÓÓ  !
=
ÓÓ" #
	returnUrl
ÓÓ$ -
;
ÓÓ- .
var
 
model
 
=
 
new
 "
MvcRegisterViewModel
 0
(
0 1
)
1 2
;
2 3
return
ÚÚ 
View
ÚÚ 
(
ÚÚ 
model
ÚÚ 
)
ÚÚ 
;
ÚÚ 
}
ÛÛ 	
[
ıı 	
HttpPost
ıı	 
]
ıı 
[
ˆˆ 	
AllowAnonymous
ˆˆ	 
]
ˆˆ 
[
˜˜ 	&
ValidateAntiForgeryToken
˜˜	 !
]
˜˜! "
public
¯¯ 
async
¯¯ 
Task
¯¯ 
<
¯¯ 
IActionResult
¯¯ '
>
¯¯' (
Register
¯¯) 1
(
¯¯1 2"
MvcRegisterViewModel
¯¯2 F
model
¯¯G L
,
¯¯L M
string
¯¯N T
	returnUrl
¯¯U ^
=
¯¯_ `
null
¯¯a e
)
¯¯e f
{
˘˘ 	
ViewData
˙˙ 
[
˙˙ 
$str
˙˙  
]
˙˙  !
=
˙˙" #
	returnUrl
˙˙$ -
;
˙˙- .
if
˚˚ 
(
˚˚ 

ModelState
˚˚ 
.
˚˚ 
IsValid
˚˚ "
)
˚˚" #
{
¸¸ 
ApplicationUser
˝˝ 
user
˝˝  $
=
˝˝% &
new
˝˝' *
ApplicationUser
˝˝+ :
{
˝˝; <
UserName
˝˝= E
=
˝˝F G
model
˝˝H M
.
˝˝M N
UserName
˝˝N V
,
˝˝V W
Email
˝˝X ]
=
˝˝^ _
model
˝˝` e
.
˝˝e f
Email
˝˝f k
}
˝˝l m
;
˝˝m n
user
˛˛ 
.
˛˛ 
UserName
˛˛ 
=
˛˛ 
model
˛˛  %
.
˛˛% &
UserName
˛˛& .
;
˛˛. /
IdentityResult
ÄÄ 
result
ÄÄ %
=
ÄÄ& '
await
ÄÄ( -
_userManager
ÄÄ. :
.
ÄÄ: ;
CreateAsync
ÄÄ; F
(
ÄÄF G
user
ÄÄG K
,
ÄÄK L
model
ÄÄM R
.
ÄÄR S
Password
ÄÄS [
)
ÄÄ[ \
;
ÄÄ\ ]
if
ÅÅ 
(
ÅÅ 
result
ÅÅ 
.
ÅÅ 
	Succeeded
ÅÅ $
)
ÅÅ$ %
{
ÇÇ 
ProfileViewModel
ÉÉ $
profile
ÉÉ% ,
=
ÉÉ- . 
_profileAppService
ÉÉ/ A
.
ÉÉA B
GenerateNewOne
ÉÉB P
(
ÉÉP Q
ProfileType
ÉÉQ \
.
ÉÉ\ ]
Personal
ÉÉ] e
)
ÉÉe f
;
ÉÉf g
profile
ÑÑ 
.
ÑÑ 
UserId
ÑÑ "
=
ÑÑ# $
new
ÑÑ% (
Guid
ÑÑ) -
(
ÑÑ- .
user
ÑÑ. 2
.
ÑÑ2 3
Id
ÑÑ3 5
)
ÑÑ5 6
;
ÑÑ6 7 
_profileAppService
ÖÖ &
.
ÖÖ& '
Save
ÖÖ' +
(
ÖÖ+ ,
profile
ÖÖ, 3
)
ÖÖ3 4
;
ÖÖ4 5
await
áá 
SetStaffRoles
áá '
(
áá' (
user
áá( ,
)
áá, -
;
áá- .
_logger
ââ 
.
ââ 
LogInformation
ââ *
(
ââ* +
$str
ââ+ V
)
ââV W
;
ââW X
string
ãã 
code
ãã 
=
ãã  !
await
ãã" '
_userManager
ãã( 4
.
ãã4 51
#GenerateEmailConfirmationTokenAsync
ãã5 X
(
ããX Y
user
ããY ]
)
ãã] ^
;
ãã^ _
string
åå 
callbackUrl
åå &
=
åå' (
Url
åå) ,
.
åå, -#
EmailConfirmationLink
åå- B
(
ååB C
user
ååC G
.
ååG H
Id
ååH J
,
ååJ K
code
ååL P
,
ååP Q
Request
ååR Y
.
ååY Z
Scheme
ååZ `
)
åå` a
;
ååa b
await
çç 
_emailSender
çç &
.
çç& '(
SendEmailConfirmationAsync
çç' A
(
ççA B
model
ççB G
.
ççG H
Email
ççH M
,
ççM N
callbackUrl
ççO Z
)
ççZ [
;
çç[ \
await
èè 
_signInManager
èè (
.
èè( )
SignInAsync
èè) 4
(
èè4 5
user
èè5 9
,
èè9 :
isPersistent
èè; G
:
èèG H
false
èèI N
)
èèN O
;
èèO P
_logger
êê 
.
êê 
LogInformation
êê *
(
êê* +
$str
êê+ V
)
êêV W
;
êêW X
return
ëë 
RedirectToLocal
ëë *
(
ëë* +
	returnUrl
ëë+ 4
)
ëë4 5
;
ëë5 6
}
íí 
	AddErrors
ìì 
(
ìì 
result
ìì  
)
ìì  !
;
ìì! "
}
îî 
return
óó 
View
óó 
(
óó 
model
óó 
)
óó 
;
óó 
}
òò 	
[
öö 	
HttpPost
öö	 
]
öö 
[
õõ 	&
ValidateAntiForgeryToken
õõ	 !
]
õõ! "
public
úú 
async
úú 
Task
úú 
<
úú 
IActionResult
úú '
>
úú' (
Logout
úú) /
(
úú/ 0
)
úú0 1
{
ùù 	
await
ûû 
_signInManager
ûû  
.
ûû  !
SignOutAsync
ûû! -
(
ûû- .
)
ûû. /
;
ûû/ 0
_logger
üü 
.
üü 
LogInformation
üü "
(
üü" #
$str
üü# 5
)
üü5 6
;
üü6 7
return
†† 
RedirectToAction
†† #
(
††# $
nameof
††$ *
(
††* +
HomeController
††+ 9
.
††9 :
Index
††: ?
)
††? @
,
††@ A
$str
††B H
)
††H I
;
††I J
}
°° 	
[
££ 	
HttpPost
££	 
]
££ 
[
§§ 	
AllowAnonymous
§§	 
]
§§ 
[
•• 	&
ValidateAntiForgeryToken
••	 !
]
••! "
public
¶¶ 
IActionResult
¶¶ 
ExternalLogin
¶¶ *
(
¶¶* +
string
¶¶+ 1
provider
¶¶2 :
,
¶¶: ;
string
¶¶< B
	returnUrl
¶¶C L
=
¶¶M N
null
¶¶O S
)
¶¶S T
{
ßß 	
string
©© 
redirectUrl
©© 
=
©©  
Url
©©! $
.
©©$ %
Action
©©% +
(
©©+ ,
nameof
©©, 2
(
©©2 3#
ExternalLoginCallback
©©3 H
)
©©H I
,
©©I J
$str
©©K T
,
©©T U
new
©©V Y
{
©©Z [
	returnUrl
©©\ e
}
©©f g
)
©©g h
;
©©h i&
AuthenticationProperties
™™ $

properties
™™% /
=
™™0 1
_signInManager
™™2 @
.
™™@ A7
)ConfigureExternalAuthenticationProperties
™™A j
(
™™j k
provider
™™k s
,
™™s t
redirectUrl™™u Ä
)™™Ä Å
;™™Å Ç
return
´´ 
	Challenge
´´ 
(
´´ 

properties
´´ '
,
´´' (
provider
´´) 1
)
´´1 2
;
´´2 3
}
¨¨ 	
[
ÆÆ 	
HttpGet
ÆÆ	 
]
ÆÆ 
[
ØØ 	
AllowAnonymous
ØØ	 
]
ØØ 
public
∞∞ 
async
∞∞ 
Task
∞∞ 
<
∞∞ 
IActionResult
∞∞ '
>
∞∞' (#
ExternalLoginCallback
∞∞) >
(
∞∞> ?
string
∞∞? E
	returnUrl
∞∞F O
=
∞∞P Q
null
∞∞R V
,
∞∞V W
string
∞∞X ^
remoteError
∞∞_ j
=
∞∞k l
null
∞∞m q
)
∞∞q r
{
±± 	
if
≤≤ 
(
≤≤ 
remoteError
≤≤ 
!=
≤≤ 
null
≤≤ #
)
≤≤# $
{
≥≥ 
ErrorMessage
¥¥ 
=
¥¥ 
$"
¥¥ !,
Error from external provider: 
¥¥! ?
{
¥¥? @
remoteError
¥¥@ K
}
¥¥K L
"
¥¥L M
;
¥¥M N
return
µµ 
RedirectToAction
µµ '
(
µµ' (
nameof
µµ( .
(
µµ. /
Login
µµ/ 4
)
µµ4 5
)
µµ5 6
;
µµ6 7
}
∂∂ 
ExternalLoginInfo
∑∑ 
info
∑∑ "
=
∑∑# $
await
∑∑% *
_signInManager
∑∑+ 9
.
∑∑9 :'
GetExternalLoginInfoAsync
∑∑: S
(
∑∑S T
)
∑∑T U
;
∑∑U V
if
∏∏ 
(
∏∏ 
info
∏∏ 
==
∏∏ 
null
∏∏ 
)
∏∏ 
{
ππ 
return
∫∫ 
RedirectToAction
∫∫ '
(
∫∫' (
nameof
∫∫( .
(
∫∫. /
Login
∫∫/ 4
)
∫∫4 5
)
∫∫5 6
;
∫∫6 7
}
ªª 
	Microsoft
ææ 
.
ææ 

AspNetCore
ææ  
.
ææ  !
Identity
ææ! )
.
ææ) *
SignInResult
ææ* 6
result
ææ7 =
=
ææ> ?
await
ææ@ E
_signInManager
ææF T
.
ææT U&
ExternalLoginSignInAsync
ææU m
(
ææm n
info
ææn r
.
æær s
LoginProviderææs Ä
,ææÄ Å
infoææÇ Ü
.ææÜ á
ProviderKeyææá í
,ææí ì
isPersistentææî †
:ææ† °
falseææ¢ ß
,ææß ®
bypassTwoFactorææ© ∏
:ææ∏ π
trueææ∫ æ
)æææ ø
;ææø ¿
if
øø 
(
øø 
result
øø 
.
øø 
	Succeeded
øø  
)
øø  !
{
¿¿ 
_logger
¡¡ 
.
¡¡ 
LogInformation
¡¡ &
(
¡¡& '
$str
¡¡' M
,
¡¡M N
info
¡¡O S
.
¡¡S T
LoginProvider
¡¡T a
)
¡¡a b
;
¡¡b c
string
√√ 
email
√√ 
=
√√ 
info
√√ #
.
√√# $
	Principal
√√$ -
.
√√- .
FindFirstValue
√√. <
(
√√< =

ClaimTypes
√√= G
.
√√G H
Email
√√H M
)
√√M N
;
√√N O
ApplicationUser
ƒƒ 
existingUser
ƒƒ  ,
=
ƒƒ- .
await
ƒƒ/ 4
_userManager
ƒƒ5 A
.
ƒƒA B
FindByEmailAsync
ƒƒB R
(
ƒƒR S
email
ƒƒS X
)
ƒƒX Y
;
ƒƒY Z
if
∆∆ 
(
∆∆ 
existingUser
∆∆  
!=
∆∆! #
null
∆∆$ (
)
∆∆( )
{
«« 
this
»» 
.
»» 
SetProfileSession
»» *
(
»»* +
existingUser
»»+ 7
.
»»7 8
Id
»»8 :
.
»»: ;
ToString
»»; C
(
»»C D
)
»»D E
,
»»E F
existingUser
»»G S
.
»»S T
UserName
»»T \
)
»»\ ]
;
»»] ^
await
   
SetStaffRoles
   '
(
  ' (
existingUser
  ( 4
)
  4 5
;
  5 6
}
ÀÀ 
return
ÕÕ 
RedirectToLocal
ÕÕ &
(
ÕÕ& '
	returnUrl
ÕÕ' 0
)
ÕÕ0 1
;
ÕÕ1 2
}
ŒŒ 
if
œœ 
(
œœ 
result
œœ 
.
œœ 
IsLockedOut
œœ "
)
œœ" #
{
–– 
return
—— 
RedirectToAction
—— '
(
——' (
nameof
——( .
(
——. /
Lockout
——/ 6
)
——6 7
)
——7 8
;
——8 9
}
““ 
else
”” 
{
‘‘ 
ViewData
÷÷ 
[
÷÷ 
$str
÷÷ $
]
÷÷$ %
=
÷÷& '
	returnUrl
÷÷( 1
;
÷÷1 2
ViewData
◊◊ 
[
◊◊ 
$str
◊◊ (
]
◊◊( )
=
◊◊* +
info
◊◊, 0
.
◊◊0 1
LoginProvider
◊◊1 >
;
◊◊> ?
ViewData
ÿÿ 
[
ÿÿ 
$str
ÿÿ %
]
ÿÿ% &
=
ÿÿ' (
SharedLocalizer
ÿÿ) 8
[
ÿÿ8 9
$str
ÿÿ9 C
]
ÿÿC D
;
ÿÿD E
string
ŸŸ 
text
ŸŸ 
=
ŸŸ 
$strŸŸ ±
;ŸŸ± ≤
string
€€ 
email
€€ 
=
€€ 
info
€€ #
.
€€# $
	Principal
€€$ -
.
€€- .
FindFirstValue
€€. <
(
€€< =

ClaimTypes
€€= G
.
€€G H
Email
€€H M
)
€€M N
;
€€N O'
MvcExternalLoginViewModel
›› )
model
››* /
=
››0 1
new
››2 5'
MvcExternalLoginViewModel
››6 O
{
››P Q
Email
››R W
=
››X Y
email
››Z _
}
››` a
;
››a b
ApplicationUser
ﬂﬂ 
existingUser
ﬂﬂ  ,
=
ﬂﬂ- .
await
ﬂﬂ/ 4
_userManager
ﬂﬂ5 A
.
ﬂﬂA B
FindByEmailAsync
ﬂﬂB R
(
ﬂﬂR S
email
ﬂﬂS X
)
ﬂﬂX Y
;
ﬂﬂY Z
if
‡‡ 
(
‡‡ 
existingUser
‡‡  
!=
‡‡! #
null
‡‡$ (
)
‡‡( )
{
·· 
model
‚‚ 
.
‚‚ 

UserExists
‚‚ $
=
‚‚% &
true
‚‚' +
;
‚‚+ ,
model
„„ 
.
„„ 
Username
„„ "
=
„„# $
existingUser
„„% 1
.
„„1 2
UserName
„„2 :
;
„„: ;
text
‰‰ 
=
‰‰ 
$str‰‰ ∞
;‰‰∞ ±
ViewData
ÊÊ 
[
ÊÊ 
$str
ÊÊ )
]
ÊÊ) *
=
ÊÊ+ ,
SharedLocalizer
ÊÊ- <
[
ÊÊ< =
$str
ÊÊ= K
]
ÊÊK L
;
ÊÊL M
}
ÁÁ 
ViewData
ÈÈ 
[
ÈÈ 
$str
ÈÈ '
]
ÈÈ' (
=
ÈÈ) *
SharedLocalizer
ÈÈ+ :
[
ÈÈ: ;
text
ÈÈ; ?
]
ÈÈ? @
;
ÈÈ@ A
return
ÎÎ 
View
ÎÎ 
(
ÎÎ 
$str
ÎÎ +
,
ÎÎ+ ,
model
ÎÎ- 2
)
ÎÎ2 3
;
ÎÎ3 4
}
ÏÏ 
}
ÌÌ 	
[
ÔÔ 	
HttpPost
ÔÔ	 
]
ÔÔ 
[
 	
AllowAnonymous
	 
]
 
[
ÒÒ 	&
ValidateAntiForgeryToken
ÒÒ	 !
]
ÒÒ! "
public
ÚÚ 
async
ÚÚ 
Task
ÚÚ 
<
ÚÚ 
IActionResult
ÚÚ '
>
ÚÚ' ('
ExternalLoginConfirmation
ÚÚ) B
(
ÚÚB C'
MvcExternalLoginViewModel
ÚÚC \
model
ÚÚ] b
,
ÚÚb c
string
ÚÚd j
	returnUrl
ÚÚk t
=
ÚÚu v
null
ÚÚw {
)
ÚÚ{ |
{
ÛÛ 	
if
ÙÙ 
(
ÙÙ 

ModelState
ÙÙ 
.
ÙÙ 
IsValid
ÙÙ "
)
ÙÙ" #
{
ıı 
IdentityResult
ˆˆ 
result
ˆˆ %
=
ˆˆ& '
new
ˆˆ( +
IdentityResult
ˆˆ, :
(
ˆˆ: ;
)
ˆˆ; <
;
ˆˆ< =
ExternalLoginInfo
˘˘ !
info
˘˘" &
=
˘˘' (
await
˘˘) .
_signInManager
˘˘/ =
.
˘˘= >'
GetExternalLoginInfoAsync
˘˘> W
(
˘˘W X
)
˘˘X Y
;
˘˘Y Z
if
˙˙ 
(
˙˙ 
info
˙˙ 
==
˙˙ 
null
˙˙  
)
˙˙  !
{
˚˚ 
throw
¸¸ 
new
¸¸ "
ApplicationException
¸¸ 2
(
¸¸2 3
$str
¸¸3 r
)
¸¸r s
;
¸¸s t
}
˝˝ 
ApplicationUser
ˇˇ 
user
ˇˇ  $
=
ˇˇ% &
new
ˇˇ' *
ApplicationUser
ˇˇ+ :
{
ˇˇ; <
UserName
ˇˇ= E
=
ˇˇF G
model
ˇˇH M
.
ˇˇM N
Username
ˇˇN V
,
ˇˇV W
Email
ˇˇX ]
=
ˇˇ^ _
model
ˇˇ` e
.
ˇˇe f
Email
ˇˇf k
}
ˇˇl m
;
ˇˇm n
ApplicationUser
ÄÄ 
existingUser
ÄÄ  ,
=
ÄÄ- .
await
ÄÄ/ 4
_userManager
ÄÄ5 A
.
ÄÄA B
FindByEmailAsync
ÄÄB R
(
ÄÄR S
model
ÄÄS X
.
ÄÄX Y
Email
ÄÄY ^
)
ÄÄ^ _
;
ÄÄ_ `
if
ÇÇ 
(
ÇÇ 
existingUser
ÇÇ  
!=
ÇÇ! #
null
ÇÇ$ (
)
ÇÇ( )
{
ÉÉ 
user
ÑÑ 
=
ÑÑ 
existingUser
ÑÑ '
;
ÑÑ' (
}
ÖÖ 
else
ÜÜ 
{
áá 
result
àà 
=
àà 
await
àà "
_userManager
àà# /
.
àà/ 0
CreateAsync
àà0 ;
(
àà; <
user
àà< @
)
àà@ A
;
ààA B
}
ââ 
result
ãã 
=
ãã 
await
ãã 
_userManager
ãã +
.
ãã+ ,
AddLoginAsync
ãã, 9
(
ãã9 :
user
ãã: >
,
ãã> ?
info
ãã@ D
)
ããD E
;
ããE F
if
çç 
(
çç 
result
çç 
.
çç 
	Succeeded
çç $
)
çç$ %
{
éé 
await
èè 
SetStaffRoles
èè '
(
èè' (
user
èè( ,
)
èè, -
;
èè- .
Guid
ëë 
userGuid
ëë !
=
ëë" #
new
ëë$ '
Guid
ëë( ,
(
ëë, -
user
ëë- 1
.
ëë1 2
Id
ëë2 4
)
ëë4 5
;
ëë5 6
ProfileViewModel
íí $
profile
íí% ,
=
íí- . 
_profileAppService
íí/ A
.
ííA B
GetByUserId
ííB M
(
ííM N
userGuid
ííN V
,
ííV W
ProfileType
ííX c
.
ííc d
Personal
ííd l
)
ííl m
;
íím n
if
ìì 
(
ìì 
profile
ìì 
==
ìì  "
null
ìì# '
)
ìì' (
{
îî 
profile
ïï 
=
ïï  ! 
_profileAppService
ïï" 4
.
ïï4 5
GenerateNewOne
ïï5 C
(
ïïC D
ProfileType
ïïD O
.
ïïO P
Personal
ïïP X
)
ïïX Y
;
ïïY Z
profile
ññ 
.
ññ  
UserId
ññ  &
=
ññ' (
userGuid
ññ) 1
;
ññ1 2
}
óó 
profile
ôô 
.
ôô 
Name
ôô  
=
ôô! "
info
ôô# '
.
ôô' (
	Principal
ôô( 1
.
ôô1 2
FindFirstValue
ôô2 @
(
ôô@ A

ClaimTypes
ôôA K
.
ôôK L
Name
ôôL P
)
ôôP Q
;
ôôQ R
if
õõ 
(
õõ 
string
õõ 
.
õõ  
IsNullOrWhiteSpace
õõ 1
(
õõ1 2
profile
õõ2 9
.
õõ9 :
ProfileImageUrl
õõ: I
)
õõI J
||
õõK M
profile
õõN U
.
õõU V
ProfileImageUrl
õõV e
.
õõe f
Equals
õõf l
(
õõl m
	Constants
õõm v
.
õõv w
DefaultAvatarõõw Ñ
)õõÑ Ö
)õõÖ Ü
{
úú 
string
ùù 
imageFileName
ùù ,
=
ùù- .
await
ùù/ 4'
GetExternalProfilePicture
ùù5 N
(
ùùN O
info
ùùO S
,
ùùS T
user
ùùU Y
,
ùùY Z
profile
ùù[ b
)
ùùb c
;
ùùc d
profile
üü 
.
üü  
ProfileImageUrl
üü  /
=
üü0 1
imageFileName
üü2 ?
.
üü? @
Equals
üü@ F
(
üüF G
	Constants
üüG P
.
üüP Q
DefaultAvatar
üüQ ^
)
üü^ _
?
üü` a
imageFileName
üüb o
:
üüp q
	Constants
üür {
.
üü{ |
DefaultImagePathüü| å
+üüç é
imageFileNameüüè ú
;üüú ù
}
††  
_profileAppService
¢¢ &
.
¢¢& '
Save
¢¢' +
(
¢¢+ ,
profile
¢¢, 3
)
¢¢3 4
;
¢¢4 5
this
§§ 
.
§§ 
SetProfileSession
§§ *
(
§§* +
user
§§+ /
.
§§/ 0
Id
§§0 2
,
§§2 3
user
§§4 8
.
§§8 9
UserName
§§9 A
)
§§A B
;
§§B C
await
¶¶ 
_signInManager
¶¶ (
.
¶¶( )
SignInAsync
¶¶) 4
(
¶¶4 5
user
¶¶5 9
,
¶¶9 :
isPersistent
¶¶; G
:
¶¶G H
false
¶¶I N
)
¶¶N O
;
¶¶O P
_logger
®® 
.
®® 
LogInformation
®® *
(
®®* +
$str
®®+ [
,
®®[ \
info
®®] a
.
®®a b
LoginProvider
®®b o
)
®®o p
;
®®p q
return
™™ 
RedirectToLocal
™™ *
(
™™* +
	returnUrl
™™+ 4
)
™™4 5
;
™™5 6
}
´´ 
	AddErrors
≠≠ 
(
≠≠ 
result
≠≠  
)
≠≠  !
;
≠≠! "
}
ÆÆ 
ViewData
∞∞ 
[
∞∞ 
$str
∞∞  
]
∞∞  !
=
∞∞" #
	returnUrl
∞∞$ -
;
∞∞- .
return
±± 
View
±± 
(
±± 
nameof
±± 
(
±± 
ExternalLogin
±± ,
)
±±, -
,
±±- .
model
±±/ 4
)
±±4 5
;
±±5 6
}
≤≤ 	
[
¥¥ 	
HttpGet
¥¥	 
]
¥¥ 
[
µµ 	
AllowAnonymous
µµ	 
]
µµ 
public
∂∂ 
async
∂∂ 
Task
∂∂ 
<
∂∂ 
IActionResult
∂∂ '
>
∂∂' (
ConfirmEmail
∂∂) 5
(
∂∂5 6
string
∂∂6 <
userId
∂∂= C
,
∂∂C D
string
∂∂E K
code
∂∂L P
)
∂∂P Q
{
∑∑ 	
if
∏∏ 
(
∏∏ 
userId
∏∏ 
==
∏∏ 
null
∏∏ 
||
∏∏ !
code
∏∏" &
==
∏∏' )
null
∏∏* .
)
∏∏. /
{
ππ 
return
∫∫ 
RedirectToAction
∫∫ '
(
∫∫' (
nameof
∫∫( .
(
∫∫. /
HomeController
∫∫/ =
.
∫∫= >
Index
∫∫> C
)
∫∫C D
,
∫∫D E
$str
∫∫F L
)
∫∫L M
;
∫∫M N
}
ªª 
ApplicationUser
ºº 
user
ºº  
=
ºº! "
await
ºº# (
_userManager
ºº) 5
.
ºº5 6
FindByIdAsync
ºº6 C
(
ººC D
userId
ººD J
)
ººJ K
;
ººK L
if
ΩΩ 
(
ΩΩ 
user
ΩΩ 
==
ΩΩ 
null
ΩΩ 
)
ΩΩ 
{
ææ 
throw
øø 
new
øø "
ApplicationException
øø .
(
øø. /
$"
øø/ 1+
Unable to load user with ID '
øø1 N
{
øøN O
userId
øøO U
}
øøU V
'.
øøV X
"
øøX Y
)
øøY Z
;
øøZ [
}
¿¿ 
IdentityResult
¡¡ 
result
¡¡ !
=
¡¡" #
await
¡¡$ )
_userManager
¡¡* 6
.
¡¡6 7
ConfirmEmailAsync
¡¡7 H
(
¡¡H I
user
¡¡I M
,
¡¡M N
code
¡¡O S
)
¡¡S T
;
¡¡T U
return
¬¬ 
View
¬¬ 
(
¬¬ 
result
¬¬ 
.
¬¬ 
	Succeeded
¬¬ (
?
¬¬) *
$str
¬¬+ 9
:
¬¬: ;
$str
¬¬< C
)
¬¬C D
;
¬¬D E
}
√√ 	
[
≈≈ 	
HttpGet
≈≈	 
]
≈≈ 
[
∆∆ 	
AllowAnonymous
∆∆	 
]
∆∆ 
public
«« 
IActionResult
«« 
ForgotPassword
«« +
(
««+ ,
)
««, -
{
»» 	
return
…… 
View
…… 
(
…… 
)
…… 
;
…… 
}
   	
[
ÃÃ 	
HttpPost
ÃÃ	 
]
ÃÃ 
[
ÕÕ 	
AllowAnonymous
ÕÕ	 
]
ÕÕ 
[
ŒŒ 	&
ValidateAntiForgeryToken
ŒŒ	 !
]
ŒŒ! "
public
œœ 
async
œœ 
Task
œœ 
<
œœ 
IActionResult
œœ '
>
œœ' (
ForgotPassword
œœ) 7
(
œœ7 8%
ForgotPasswordViewModel
œœ8 O
model
œœP U
)
œœU V
{
–– 	
if
—— 
(
—— 

ModelState
—— 
.
—— 
IsValid
—— "
)
——" #
{
““ 
ApplicationUser
”” 
user
””  $
=
””% &
await
””' ,
_userManager
””- 9
.
””9 :
FindByEmailAsync
””: J
(
””J K
model
””K P
.
””P Q
Email
””Q V
)
””V W
;
””W X
var
‘‘ #
emailAlreadyConfirmed
‘‘ )
=
‘‘* +
await
‘‘, 1
_userManager
‘‘2 >
.
‘‘> ?#
IsEmailConfirmedAsync
‘‘? T
(
‘‘T U
user
‘‘U Y
)
‘‘Y Z
;
‘‘Z [
if
’’ 
(
’’ 
user
’’ 
==
’’ 
null
’’  
||
’’! #
!
’’$ %#
emailAlreadyConfirmed
’’% :
)
’’: ;
{
÷÷ 
return
ÿÿ 
RedirectToAction
ÿÿ +
(
ÿÿ+ ,
nameof
ÿÿ, 2
(
ÿÿ2 3(
ForgotPasswordConfirmation
ÿÿ3 M
)
ÿÿM N
)
ÿÿN O
;
ÿÿO P
}
ŸŸ 
string
›› 
code
›› 
=
›› 
await
›› #
_userManager
››$ 0
.
››0 1-
GeneratePasswordResetTokenAsync
››1 P
(
››P Q
user
››Q U
)
››U V
;
››V W
string
ﬁﬁ 
callbackUrl
ﬁﬁ "
=
ﬁﬁ# $
Url
ﬁﬁ% (
.
ﬁﬁ( )'
ResetPasswordCallbackLink
ﬁﬁ) B
(
ﬁﬁB C
user
ﬁﬁC G
.
ﬁﬁG H
Id
ﬁﬁH J
,
ﬁﬁJ K
code
ﬁﬁL P
,
ﬁﬁP Q
Request
ﬁﬁR Y
.
ﬁﬁY Z
Scheme
ﬁﬁZ `
)
ﬁﬁ` a
;
ﬁﬁa b
await
ﬂﬂ 
_emailSender
ﬂﬂ "
.
ﬂﬂ" #
SendEmailAsync
ﬂﬂ# 1
(
ﬂﬂ1 2
model
ﬂﬂ2 7
.
ﬂﬂ7 8
Email
ﬂﬂ8 =
,
ﬂﬂ= >
$str
ﬂﬂ? O
,
ﬂﬂO P
$"
‡‡ D
6Please reset your password by clicking here: <a href='
‡‡ K
{
‡‡K L
callbackUrl
‡‡L W
}
‡‡W X

'>link</a>
‡‡X b
"
‡‡b c
)
‡‡c d
;
‡‡d e
return
·· 
RedirectToAction
·· '
(
··' (
nameof
··( .
(
··. /(
ForgotPasswordConfirmation
··/ I
)
··I J
)
··J K
;
··K L
}
‚‚ 
return
ÂÂ 
View
ÂÂ 
(
ÂÂ 
model
ÂÂ 
)
ÂÂ 
;
ÂÂ 
}
ÊÊ 	
[
ËË 	
HttpGet
ËË	 
]
ËË 
[
ÈÈ 	
AllowAnonymous
ÈÈ	 
]
ÈÈ 
public
ÍÍ 
IActionResult
ÍÍ (
ForgotPasswordConfirmation
ÍÍ 7
(
ÍÍ7 8
)
ÍÍ8 9
{
ÎÎ 	
return
ÏÏ 
View
ÏÏ 
(
ÏÏ 
)
ÏÏ 
;
ÏÏ 
}
ÌÌ 	
[
ÔÔ 	
HttpGet
ÔÔ	 
]
ÔÔ 
[
 	
AllowAnonymous
	 
]
 
public
ÒÒ 
IActionResult
ÒÒ 
ResetPassword
ÒÒ *
(
ÒÒ* +
string
ÒÒ+ 1
code
ÒÒ2 6
=
ÒÒ7 8
null
ÒÒ9 =
)
ÒÒ= >
{
ÚÚ 	
if
ÛÛ 
(
ÛÛ 
code
ÛÛ 
==
ÛÛ 
null
ÛÛ 
)
ÛÛ 
{
ÙÙ 
throw
ıı 
new
ıı "
ApplicationException
ıı .
(
ıı. /
$str
ıı/ \
)
ıı\ ]
;
ıı] ^
}
ˆˆ $
ResetPasswordViewModel
˜˜ "
model
˜˜# (
=
˜˜) *
new
˜˜+ .$
ResetPasswordViewModel
˜˜/ E
{
˜˜F G
Code
˜˜H L
=
˜˜M N
code
˜˜O S
}
˜˜T U
;
˜˜U V
return
¯¯ 
View
¯¯ 
(
¯¯ 
model
¯¯ 
)
¯¯ 
;
¯¯ 
}
˘˘ 	
[
˚˚ 	
HttpPost
˚˚	 
]
˚˚ 
[
¸¸ 	
AllowAnonymous
¸¸	 
]
¸¸ 
[
˝˝ 	&
ValidateAntiForgeryToken
˝˝	 !
]
˝˝! "
public
˛˛ 
async
˛˛ 
Task
˛˛ 
<
˛˛ 
IActionResult
˛˛ '
>
˛˛' (
ResetPassword
˛˛) 6
(
˛˛6 7$
ResetPasswordViewModel
˛˛7 M
model
˛˛N S
)
˛˛S T
{
ˇˇ 	
if
ÄÄ 
(
ÄÄ 
!
ÄÄ 

ModelState
ÄÄ 
.
ÄÄ 
IsValid
ÄÄ #
)
ÄÄ# $
{
ÅÅ 
return
ÇÇ 
View
ÇÇ 
(
ÇÇ 
model
ÇÇ !
)
ÇÇ! "
;
ÇÇ" #
}
ÉÉ 
ApplicationUser
ÑÑ 
user
ÑÑ  
=
ÑÑ! "
await
ÑÑ# (
_userManager
ÑÑ) 5
.
ÑÑ5 6
FindByNameAsync
ÑÑ6 E
(
ÑÑE F
model
ÑÑF K
.
ÑÑK L
UserName
ÑÑL T
)
ÑÑT U
;
ÑÑU V
if
ÖÖ 
(
ÖÖ 
user
ÖÖ 
==
ÖÖ 
null
ÖÖ 
)
ÖÖ 
{
ÜÜ 
return
àà 
RedirectToAction
àà '
(
àà' (
nameof
àà( .
(
àà. /'
ResetPasswordConfirmation
àà/ H
)
ààH I
)
ààI J
;
ààJ K
}
ââ 
IdentityResult
ää 
result
ää !
=
ää" #
await
ää$ )
_userManager
ää* 6
.
ää6 7 
ResetPasswordAsync
ää7 I
(
ääI J
user
ääJ N
,
ääN O
model
ääP U
.
ääU V
Code
ääV Z
,
ääZ [
model
ää\ a
.
ääa b
Password
ääb j
)
ääj k
;
ääk l
if
ãã 
(
ãã 
result
ãã 
.
ãã 
	Succeeded
ãã  
)
ãã  !
{
åå 
return
çç 
RedirectToAction
çç '
(
çç' (
nameof
çç( .
(
çç. /'
ResetPasswordConfirmation
çç/ H
)
ççH I
)
ççI J
;
ççJ K
}
éé 
	AddErrors
èè 
(
èè 
result
èè 
)
èè 
;
èè 
return
êê 
View
êê 
(
êê 
)
êê 
;
êê 
}
ëë 	
[
ìì 	
HttpGet
ìì	 
]
ìì 
[
îî 	
AllowAnonymous
îî	 
]
îî 
public
ïï 
IActionResult
ïï '
ResetPasswordConfirmation
ïï 6
(
ïï6 7
)
ïï7 8
{
ññ 	
return
óó 
View
óó 
(
óó 
)
óó 
;
óó 
}
òò 	
[
õõ 	
HttpGet
õõ	 
]
õõ 
public
úú 
IActionResult
úú 
AccessDenied
úú )
(
úú) *
)
úú* +
{
ùù 	
return
ûû 
View
ûû 
(
ûû 
)
ûû 
;
ûû 
}
üü 	
[
°° 	
HttpPost
°°	 
]
°° 
[
¢¢ 	
AllowAnonymous
¢¢	 
]
¢¢ 
public
££ 
async
££ 
Task
££ 
<
££ 
IActionResult
££ '
>
££' (
ValidateUserName
££) 9
(
££9 :
string
££: @
UserName
££A I
)
££I J
{
§§ 	
OperationResultVo
•• 
result
•• $
;
••$ %
try
ßß 
{
®® 
var
©© 
user
©© 
=
©© 
await
©©  
UserManager
©©! ,
.
©©, -
FindByNameAsync
©©- <
(
©©< =
UserName
©©= E
)
©©E F
;
©©F G
if
´´ 
(
´´ 
user
´´ 
==
´´ 
null
´´  
)
´´  !
{
¨¨ 
return
≠≠ 
Json
≠≠ 
(
≠≠  
true
≠≠  $
)
≠≠$ %
;
≠≠% &
}
ÆÆ 
else
ØØ 
{
∞∞ 
return
±± 
Json
±± 
(
±±  
false
±±  %
)
±±% &
;
±±& '
}
≤≤ 
}
≥≥ 
catch
¥¥ 
(
¥¥ 
	Exception
¥¥ 
ex
¥¥ 
)
¥¥  
{
µµ 
result
∂∂ 
=
∂∂ 
new
∂∂ 
OperationResultVo
∂∂ .
(
∂∂. /
false
∂∂/ 4
)
∂∂4 5
;
∂∂5 6
_logger
∑∑ 
.
∑∑ 
Log
∑∑ 
(
∑∑ 
LogLevel
∑∑ $
.
∑∑$ %
Error
∑∑% *
,
∑∑* +
ex
∑∑, .
,
∑∑. /
ex
∑∑0 2
.
∑∑2 3
Message
∑∑3 :
)
∑∑: ;
;
∑∑; <
}
∏∏ 
return
∫∫ 
Json
∫∫ 
(
∫∫ 
result
∫∫ 
)
∫∫ 
;
∫∫  
}
ªª 	
private
¿¿ 
async
¿¿ 
Task
¿¿ 
SetStaffRoles
¿¿ (
(
¿¿( )
ApplicationUser
¿¿) 8
user
¿¿9 =
)
¿¿= >
{
¡¡ 	
await
¬¬ 
_userManager
¬¬ 
.
¬¬ 
AddToRoleAsync
¬¬ -
(
¬¬- .
user
¬¬. 2
,
¬¬2 3
Roles
¬¬4 9
.
¬¬9 :
Member
¬¬: @
.
¬¬@ A
ToString
¬¬A I
(
¬¬I J
)
¬¬J K
)
¬¬K L
;
¬¬L M
if
ƒƒ 
(
ƒƒ 
user
ƒƒ 
.
ƒƒ 
UserName
ƒƒ 
.
ƒƒ 
Equals
ƒƒ $
(
ƒƒ$ %
$str
ƒƒ% 0
)
ƒƒ0 1
||
ƒƒ2 4
user
ƒƒ5 9
.
ƒƒ9 :
UserName
ƒƒ: B
.
ƒƒB C
Equals
ƒƒC I
(
ƒƒI J
$str
ƒƒJ Q
)
ƒƒQ R
)
ƒƒR S
{
≈≈ 
await
∆∆ 
_userManager
∆∆ "
.
∆∆" #
AddToRoleAsync
∆∆# 1
(
∆∆1 2
user
∆∆2 6
,
∆∆6 7
Roles
∆∆8 =
.
∆∆= >
Administrator
∆∆> K
.
∆∆K L
ToString
∆∆L T
(
∆∆T U
)
∆∆U V
)
∆∆V W
;
∆∆W X
}
«« 
}
»» 	
private
   
void
   
	AddErrors
   
(
   
IdentityResult
   -
result
  . 4
)
  4 5
{
ÀÀ 	
foreach
ÃÃ 
(
ÃÃ 
IdentityError
ÃÃ "
error
ÃÃ# (
in
ÃÃ) +
result
ÃÃ, 2
.
ÃÃ2 3
Errors
ÃÃ3 9
)
ÃÃ9 :
{
ÕÕ 

ModelState
ŒŒ 
.
ŒŒ 
AddModelError
ŒŒ (
(
ŒŒ( )
string
ŒŒ) /
.
ŒŒ/ 0
Empty
ŒŒ0 5
,
ŒŒ5 6
error
ŒŒ7 <
.
ŒŒ< =
Description
ŒŒ= H
)
ŒŒH I
;
ŒŒI J
}
œœ 
}
–– 	
private
““ 
IActionResult
““ 
RedirectToLocal
““ -
(
““- .
string
““. 4
	returnUrl
““5 >
)
““> ?
{
”” 	
if
‘‘ 
(
‘‘ 
Url
‘‘ 
.
‘‘ 

IsLocalUrl
‘‘ 
(
‘‘ 
	returnUrl
‘‘ (
)
‘‘( )
)
‘‘) *
{
’’ 
return
÷÷ 
Redirect
÷÷ 
(
÷÷  
	returnUrl
÷÷  )
)
÷÷) *
;
÷÷* +
}
◊◊ 
else
ÿÿ 
{
ŸŸ 
return
⁄⁄ 
RedirectToAction
⁄⁄ '
(
⁄⁄' (
nameof
⁄⁄( .
(
⁄⁄. /
HomeController
⁄⁄/ =
.
⁄⁄= >
Index
⁄⁄> C
)
⁄⁄C D
,
⁄⁄D E
$str
⁄⁄F L
)
⁄⁄L M
;
⁄⁄M N
}
€€ 
}
‹‹ 	
private
ﬁﬁ 
void
ﬁﬁ 
SetProfileSession
ﬁﬁ &
(
ﬁﬁ& '
string
ﬁﬁ' -
userId
ﬁﬁ. 4
,
ﬁﬁ4 5
string
ﬁﬁ6 <
userName
ﬁﬁ= E
)
ﬁﬁE F
{
ﬂﬂ 	
SetSessionValue
·· 
(
·· 
SessionValues
·· )
.
··) *
Username
··* 2
,
··2 3
userName
··4 <
)
··< =
;
··= >
Guid
„„ 
userGuid
„„ 
=
„„ 
new
„„ 
Guid
„„  $
(
„„$ %
userId
„„% +
)
„„+ ,
;
„„, -
ProfileViewModel
‰‰ 
profile
‰‰ $
=
‰‰% & 
_profileAppService
‰‰' 9
.
‰‰9 :
GetByUserId
‰‰: E
(
‰‰E F
userGuid
‰‰F N
,
‰‰N O
ProfileType
‰‰P [
.
‰‰[ \
Personal
‰‰\ d
)
‰‰d e
;
‰‰e f
if
ÂÂ 
(
ÂÂ 
profile
ÂÂ 
!=
ÂÂ 
null
ÂÂ 
)
ÂÂ  
{
ÊÊ 
SetSessionValue
ÁÁ 
(
ÁÁ  
SessionValues
ÁÁ  -
.
ÁÁ- .
FullName
ÁÁ. 6
,
ÁÁ6 7
profile
ÁÁ8 ?
.
ÁÁ? @
Name
ÁÁ@ D
)
ÁÁD E
;
ÁÁE F
}
ËË 
}
ÈÈ 	
private
ÎÎ 
async
ÎÎ 
Task
ÎÎ 
<
ÎÎ 
string
ÎÎ !
>
ÎÎ! "'
GetExternalProfilePicture
ÎÎ# <
(
ÎÎ< =
ExternalLoginInfo
ÎÎ= N
info
ÎÎO S
,
ÎÎS T
ApplicationUser
ÎÎU d
user
ÎÎe i
,
ÎÎi j
ProfileViewModel
ÎÎk {
profileÎÎ| É
)ÎÎÉ Ñ
{
ÏÏ 	
string
ÌÌ 
imageUrl
ÌÌ 
=
ÌÌ 
	Constants
ÌÌ '
.
ÌÌ' (
DefaultAvatar
ÌÌ( 5
;
ÌÌ5 6
byte
ÔÔ 
[
ÔÔ 
]
ÔÔ 
thumbnailBytes
ÔÔ !
=
ÔÔ" #
null
ÔÔ$ (
;
ÔÔ( )
if
 
(
 
info
 
.
 
LoginProvider
 "
==
# %
$str
& 0
)
0 1
{
ÒÒ 
string
ÚÚ 
nameIdentifier
ÚÚ %
=
ÚÚ& '
info
ÚÚ( ,
.
ÚÚ, -
	Principal
ÚÚ- 6
.
ÚÚ6 7
FindFirstValue
ÚÚ7 E
(
ÚÚE F

ClaimTypes
ÚÚF P
.
ÚÚP Q
NameIdentifier
ÚÚQ _
)
ÚÚ_ `
;
ÚÚ` a
string
ÛÛ 
thumbnailUrl
ÛÛ #
=
ÛÛ$ %
$"
ÛÛ& ()
https://graph.facebook.com/
ÛÛ( C
{
ÛÛC D
nameIdentifier
ÛÛD R
}
ÛÛR S!
/picture?type=large
ÛÛS f
"
ÛÛf g
;
ÛÛg h
using
ıı 
(
ıı 

HttpClient
ıı !

httpClient
ıı" ,
=
ıı- .
new
ıı/ 2

HttpClient
ıı3 =
(
ıı= >
)
ıı> ?
)
ıı? @
{
ˆˆ 
string
˜˜ 
filename
˜˜ #
=
˜˜$ %
user
˜˜& *
.
˜˜* +
Id
˜˜+ -
+
˜˜. /
$str
˜˜0 3
+
˜˜4 5
ProfileType
˜˜6 A
.
˜˜A B
Personal
˜˜B J
.
˜˜J K
ToString
˜˜K S
(
˜˜S T
)
˜˜T U
;
˜˜U V
thumbnailBytes
¯¯ "
=
¯¯# $
await
¯¯% *

httpClient
¯¯+ 5
.
¯¯5 6
GetByteArrayAsync
¯¯6 G
(
¯¯G H
thumbnailUrl
¯¯H T
)
¯¯T U
;
¯¯U V
imageUrl
˙˙ 
=
˙˙ 
base
˙˙ #
.
˙˙# $
UploadImage
˙˙$ /
(
˙˙/ 0
new
˙˙0 3
Guid
˙˙4 8
(
˙˙8 9
user
˙˙9 =
.
˙˙= >
Id
˙˙> @
)
˙˙@ A
,
˙˙A B
BlobType
˙˙C K
.
˙˙K L
ProfileImage
˙˙L X
,
˙˙X Y
filename
˙˙Z b
,
˙˙b c
thumbnailBytes
˙˙d r
)
˙˙r s
;
˙˙s t
}
˚˚ 
}
¸¸ 
return
˛˛ 
imageUrl
˛˛ 
;
˛˛ 
}
ˇˇ 	
}
ÇÇ 
}ÉÉ è
kC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\Base\BaseController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
.& '
Base' +
{ 
public 

class 
BaseController 
:  !

Controller" ,
{ 
private 
IStringLocalizer  
<  !
SharedResources! 0
>0 1
_sharedLocalizer2 B
;B C
public 
IStringLocalizer 
<  
SharedResources  /
>/ 0
SharedLocalizer1 @
=>A C
_sharedLocalizerD T
??U W
(X Y
_sharedLocalizerY i
=j k
(l m
IStringLocalizerm }
<} ~
SharedResources	~ ç
>
ç é
)
é è
HttpContext
è ö
?
ö õ
.
õ ú
RequestServices
ú ´
.
´ ¨

GetService
¨ ∂
(
∂ ∑
typeof
∑ Ω
(
Ω æ
IStringLocalizer
æ Œ
<
Œ œ
SharedResources
œ ﬁ
>
ﬁ ﬂ
)
ﬂ ‡
)
‡ ·
)
· ‚
;
‚ „
public 
BaseController 
( 
) 
{ 	
} 	
	protected 
string 

GetBaseUrl #
(# $
)$ %
{ 	
return 

WebUtility 
. 
	UrlDecode '
(' (
$"( *
{* +
this+ /
./ 0
Request0 7
.7 8
Scheme8 >
}> ?
://? B
{B C
thisC G
.G H
RequestH O
.O P
HostP T
}T U
{U V
thisV Z
.Z [
Request[ b
.b c
PathBasec k
}k l
"l m
)m n
;n o
} 	
	protected 
string 
GetSessionValue (
(( )
SessionValues) 6
key7 :
): ;
{   	
string!! 
value!! 
=!! 
HttpContext!! &
.!!& '
Session!!' .
.!!. /
	GetString!!/ 8
(!!8 9
key!!9 <
.!!< =
ToString!!= E
(!!E F
)!!F G
)!!G H
;!!H I
return## 
value## 
;## 
}$$ 	
	protected%% 
void%% 
SetSessionValue%% &
(%%& '
SessionValues%%' 4
key%%5 8
,%%8 9
string%%: @
value%%A F
)%%F G
{&& 	
HttpContext'' 
.'' 
Session'' 
.''  
	SetString''  )
('') *
key''* -
.''- .
ToString''. 6
(''6 7
)''7 8
,''8 9
value'': ?
)''? @
;''@ A
}(( 	
})) 
}** «ê
qC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\Base\SecureBaseController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
.& '
Base' +
{ 
public 

class  
SecureBaseController %
:& '
BaseController( 6
{ 
private 
UserManager 
< 
ApplicationUser +
>+ ,
_userManager- 9
;9 :
public 
UserManager 
< 
ApplicationUser *
>* +
UserManager, 7
=>8 :
_userManager; G
??H J
(K L
_userManagerL X
=Y Z
HttpContext[ f
?f g
.g h
RequestServicesh w
.w x

GetService	x Ç
<
Ç É
UserManager
É é
<
é è
ApplicationUser
è û
>
û ü
>
ü †
(
† °
)
° ¢
)
¢ £
;
£ §
private  
IImageStorageService $ 
_imageStorageService% 9
;9 :
public  
IImageStorageService #
ImageStorageService$ 7
=>8 : 
_imageStorageService; O
??P R
(S T 
_imageStorageServiceT h
=i j
HttpContextk v
?v w
.w x
RequestServices	x á
.
á à

GetService
à í
<
í ì"
IImageStorageService
ì ß
>
ß ®
(
® ©
)
© ™
)
™ ´
;
´ ¨
private 
ICookieMgrService !
_cookieMgrService" 3
;3 4
public 
ICookieMgrService  
CookieMgrService! 1
=>2 4
_cookieMgrService5 F
??G I
(J K
_cookieMgrServiceK \
=] ^
HttpContext_ j
?j k
.k l
RequestServicesl {
.{ |

GetService	| Ü
<
Ü á
ICookieMgrService
á ò
>
ò ô
(
ô ö
)
ö õ
)
õ ú
;
ú ù
private!! 
IProfileAppService!! "
_profileAppService!!# 5
;!!5 6
public"" 
IProfileAppService"" !
ProfileAppService""" 3
=>""4 6
_profileAppService""7 I
??""J L
(""M N
_profileAppService""N `
=""a b
HttpContext""c n
?""n o
.""o p
RequestServices""p 
.	"" Ä

GetService
""Ä ä
<
""ä ã 
IProfileAppService
""ã ù
>
""ù û
(
""û ü
)
""ü †
)
""† °
;
""° ¢
public%% 
Guid%% 
CurrentUserId%% !
{%%" #
get%%$ '
;%%' (
set%%) ,
;%%, -
}%%. /
public'' 
override'' 
void'' 
OnActionExecuting'' .
(''. /"
ActionExecutingContext''/ E
context''F M
)''M N
{(( 	
base)) 
.)) 
OnActionExecuting)) "
())" #
context))# *
)))* +
;))+ ,
if++ 
(++ 
ViewBag++ 
.++ 
Username++  
==++! #
null++$ (
)++( )
{,, 
string-- 
username-- 
=--  !
	Constants--" +
.--+ ,
DefaultUsername--, ;
;--; <
if// 
(// 
User// 
!=// 
null//  
&&//! #
User//$ (
.//( )
Identity//) 1
.//1 2
IsAuthenticated//2 A
)//A B
{00 
string11 
userId11 !
=11" #
this11$ (
.11( )
User11) -
.11- .
FindFirstValue11. <
(11< =

ClaimTypes11= G
.11G H
NameIdentifier11H V
)11V W
;11W X
CurrentUserId22 !
=22" #
new22$ '
Guid22( ,
(22, -
userId22- 3
)223 4
;224 5
username44 
=44 
this44 #
.44# $
User44$ (
.44( )
FindFirstValue44) 7
(447 8

ClaimTypes448 B
.44B C
Name44C G
)44G H
;44H I
string66 
sessionUserName66 *
=66+ ,
GetSessionValue66- <
(66< =
SessionValues66= J
.66J K
Username66K S
)66S T
;66T U
if88 
(88 
sessionUserName88 '
!=88( *
null88+ /
&&880 2
!883 4
sessionUserName884 C
.88C D
Equals88D J
(88J K
username88K S
)88S T
)88T U
{99 
SetSessionValue:: '
(::' (
SessionValues::( 5
.::5 6
Username::6 >
,::> ?
username::@ H
)::H I
;::I J
};; 
ViewBag== 
.== 
Username== $
===% &
username==' /
??==0 2
	Constants==3 <
.==< =
DefaultUsername=== L
;==L M
ViewBag>> 
.>> 
ProfileImage>> (
=>>) *
UrlFormatter>>+ 7
.>>7 8
ProfileImage>>8 D
(>>D E
CurrentUserId>>E R
)>>R S
;>>S T
}?? 
}@@ 
ViewBagBB 
.BB 
BaseUrlBB 
=BB 
baseBB "
.BB" #

GetBaseUrlBB# -
(BB- .
)BB. /
;BB/ 0
}CC 	
	protectedEE 
stringEE 
	GetAvatarEE "
(EE" #
)EE# $
{FF 	
returnHH 
GetCookieValueHH !
(HH! "
SessionValuesHH" /
.HH/ 0
UserProfileImageUrlHH0 C
)HHC D
;HHD E
}II 	
	protectedKK 
voidKK 
	SetAvatarKK  
(KK  !
stringKK! '
profileImageUrlKK( 7
)KK7 8
{LL 	
SetCookieValueNN 
(NN 
SessionValuesNN (
.NN( )
UserProfileImageUrlNN) <
,NN< =
profileImageUrlNN> M
,NNM N
$numNNO P
)NNP Q
;NNQ R
}OO 	
	protectedRR 
ProfileViewModelRR "
SetAuthorDetailsRR# 3
(RR3 4&
UserGeneratedBaseViewModelRR4 N
vmRRO Q
)RRQ R
{SS 	
ifTT 
(TT 
vmTT 
.TT 
IdTT 
==TT 
GuidTT 
.TT 
EmptyTT #
||TT$ &
vmTT' )
.TT) *
UserIdTT* 0
==TT1 3
GuidTT4 8
.TT8 9
EmptyTT9 >
)TT> ?
{UU 
vmVV 
.VV 
UserIdVV 
=VV 
CurrentUserIdVV )
;VV) *
}WW 
ProfileViewModelYY 
profileYY $
=YY% &
ProfileAppServiceYY' 8
.YY8 9
GetByUserIdYY9 D
(YYD E
thisYYE I
.YYI J
CurrentUserIdYYJ W
,YYW X
vmYYY [
.YY[ \
UserIdYY\ b
,YYb c
ProfileTypeYYd o
.YYo p
PersonalYYp x
)YYx y
;YYy z
if[[ 
([[ 
profile[[ 
!=[[ 
null[[ 
)[[  
{\\ 
vm]] 
.]] 

AuthorName]] 
=]] 
profile]]  '
.]]' (
Name]]( ,
;]], -
vm^^ 
.^^ 
AuthorPicture^^  
=^^! "
UrlFormatter^^# /
.^^/ 0
ProfileImage^^0 <
(^^< =
vm^^= ?
.^^? @
UserId^^@ F
)^^F G
;^^G H
}__ 
returnaa 
profileaa 
;aa 
}bb 	
privategg 
stringgg 
UploadImagegg "
(gg" #
Guidgg# '
userIdgg( .
,gg. /
stringgg0 6
	imageTypegg7 @
,gg@ A
stringggB H
filenameggI Q
,ggQ R
byteggS W
[ggW X
]ggX Y
	fileBytesggZ c
)ggc d
{hh 	
Taskii 
<ii 
stringii 
>ii 
opii 
=ii 
ImageStorageServiceii 1
.ii1 2
StoreImageAsyncii2 A
(iiA B
userIdiiB H
.iiH I
ToStringiiI Q
(iiQ R
)iiR S
,iiS T
	imageTypeiiU ^
.ii^ _
ToLowerii_ f
(iif g
)iig h
+iii j
$striik n
+iio p
filenameiiq y
,iiy z
	fileBytes	ii{ Ñ
)
iiÑ Ö
;
iiÖ Ü
opjj 
.jj 
Waitjj 
(jj 
)jj 
;jj 
ifll 
(ll 
!ll 
opll 
.ll #
IsCompletedSuccessfullyll +
)ll+ ,
{mm 
thrownn 
opnn 
.nn 
	Exceptionnn "
;nn" #
}oo 
stringqq 
urlqq 
=qq 
opqq 
.qq 
Resultqq "
;qq" #
returnss 
urlss 
;ss 
}tt 	
privateuu 
stringuu 
DeleteImageuu "
(uu" #
Guiduu# '
userIduu( .
,uu. /
stringuu0 6
filenameuu7 ?
)uu? @
{vv 	
Taskww 
<ww 
stringww 
>ww 
opww 
=ww 
ImageStorageServiceww 1
.ww1 2
DeleteImageAsyncww2 B
(wwB C
userIdwwC I
.wwI J
ToStringwwJ R
(wwR S
)wwS T
,wwT U
filenamewwV ^
)ww^ _
;ww_ `
opxx 
.xx 
Waitxx 
(xx 
)xx 
;xx 
ifzz 
(zz 
!zz 
opzz 
.zz #
IsCompletedSuccessfullyzz +
)zz+ ,
{{{ 
throw|| 
op|| 
.|| 
	Exception|| "
;||" #
}}} 
string 
url 
= 
op 
. 
Result "
;" #
return
ÅÅ 
url
ÅÅ 
;
ÅÅ 
}
ÇÇ 	
private
ÑÑ 
string
ÑÑ 
DeleteImage
ÑÑ "
(
ÑÑ" #
Guid
ÑÑ# '
userId
ÑÑ( .
,
ÑÑ. /
string
ÑÑ0 6
	imageType
ÑÑ7 @
,
ÑÑ@ A
string
ÑÑB H
filename
ÑÑI Q
)
ÑÑQ R
{
ÖÖ 	
Task
ÜÜ 
<
ÜÜ 
string
ÜÜ 
>
ÜÜ 
op
ÜÜ 
=
ÜÜ !
ImageStorageService
ÜÜ 1
.
ÜÜ1 2
DeleteImageAsync
ÜÜ2 B
(
ÜÜB C
userId
ÜÜC I
.
ÜÜI J
ToString
ÜÜJ R
(
ÜÜR S
)
ÜÜS T
,
ÜÜT U
	imageType
ÜÜV _
.
ÜÜ_ `
ToLower
ÜÜ` g
(
ÜÜg h
)
ÜÜh i
+
ÜÜj k
$str
ÜÜl o
+
ÜÜp q
filename
ÜÜr z
)
ÜÜz {
;
ÜÜ{ |
op
áá 
.
áá 
Wait
áá 
(
áá 
)
áá 
;
áá 
if
ââ 
(
ââ 
!
ââ 
op
ââ 
.
ââ %
IsCompletedSuccessfully
ââ +
)
ââ+ ,
{
ää 
throw
ãã 
op
ãã 
.
ãã 
	Exception
ãã "
;
ãã" #
}
åå 
string
éé 
url
éé 
=
éé 
op
éé 
.
éé 
Result
éé "
;
éé" #
return
êê 
url
êê 
;
êê 
}
ëë 	
	protected
ïï 
string
ïï 
UploadImage
ïï $
(
ïï$ %
Guid
ïï% )
userId
ïï* 0
,
ïï0 1
BlobType
ïï2 :
	container
ïï; D
,
ïïD E
string
ïïF L
filename
ïïM U
,
ïïU V
byte
ïïW [
[
ïï[ \
]
ïï\ ]
	fileBytes
ïï^ g
)
ïïg h
{
ññ 	
string
óó 
containerName
óó  
=
óó! "
	container
óó# ,
.
óó, -
ToString
óó- 5
(
óó5 6
)
óó6 7
.
óó7 8
ToLower
óó8 ?
(
óó? @
)
óó@ A
;
óóA B
return
ôô 
this
ôô 
.
ôô 
UploadImage
ôô #
(
ôô# $
userId
ôô$ *
,
ôô* +
containerName
ôô, 9
,
ôô9 :
filename
ôô; C
,
ôôC D
	fileBytes
ôôE N
)
ôôN O
;
ôôO P
}
öö 	
	protected
úú 
string
úú 
UploadGameImage
úú (
(
úú( )
Guid
úú) -
userId
úú. 4
,
úú4 5
BlobType
úú6 >
type
úú? C
,
úúC D
string
úúE K
filename
úúL T
,
úúT U
byte
úúV Z
[
úúZ [
]
úú[ \
	fileBytes
úú] f
)
úúf g
{
ùù 	
var
ûû 
result
ûû 
=
ûû 
this
ûû 
.
ûû 
UploadImage
ûû )
(
ûû) *
userId
ûû* 0
,
ûû0 1
type
ûû2 6
.
ûû6 7
ToString
ûû7 ?
(
ûû? @
)
ûû@ A
.
ûûA B
ToLower
ûûB I
(
ûûI J
)
ûûJ K
,
ûûK L
filename
ûûM U
,
ûûU V
	fileBytes
ûûW `
)
ûû` a
;
ûûa b
return
†† 
result
†† 
;
†† 
}
°° 	
	protected
££ 
string
££  
UploadContentImage
££ +
(
££+ ,
Guid
££, 0
userId
££1 7
,
££7 8
string
££9 ?
filename
££@ H
,
££H I
byte
££J N
[
££N O
]
££O P
	fileBytes
££Q Z
)
££Z [
{
§§ 	
var
•• 
type
•• 
=
•• 
BlobType
•• 
.
••  
ContentImage
••  ,
.
••, -
ToString
••- 5
(
••5 6
)
••6 7
.
••7 8
ToLower
••8 ?
(
••? @
)
••@ A
;
••A B
var
¶¶ 
result
¶¶ 
=
¶¶ 
this
¶¶ 
.
¶¶ 
UploadImage
¶¶ )
(
¶¶) *
userId
¶¶* 0
,
¶¶0 1
type
¶¶2 6
,
¶¶6 7
filename
¶¶8 @
,
¶¶@ A
	fileBytes
¶¶B K
)
¶¶K L
;
¶¶L M
return
®® 
result
®® 
;
®® 
}
©© 	
	protected
´´ 
string
´´ !
UploadFeaturedImage
´´ ,
(
´´, -
Guid
´´- 1
userId
´´2 8
,
´´8 9
string
´´: @
filename
´´A I
,
´´I J
byte
´´K O
[
´´O P
]
´´P Q
	fileBytes
´´R [
)
´´[ \
{
¨¨ 	
var
≠≠ 
type
≠≠ 
=
≠≠ 
BlobType
≠≠ 
.
≠≠  
FeaturedImage
≠≠  -
.
≠≠- .
ToString
≠≠. 6
(
≠≠6 7
)
≠≠7 8
.
≠≠8 9
ToLower
≠≠9 @
(
≠≠@ A
)
≠≠A B
;
≠≠B C
var
ÆÆ 
result
ÆÆ 
=
ÆÆ 
this
ÆÆ 
.
ÆÆ 
UploadImage
ÆÆ )
(
ÆÆ) *
userId
ÆÆ* 0
,
ÆÆ0 1
type
ÆÆ2 6
,
ÆÆ6 7
filename
ÆÆ8 @
,
ÆÆ@ A
	fileBytes
ÆÆB K
)
ÆÆK L
;
ÆÆL M
return
∞∞ 
result
∞∞ 
;
∞∞ 
}
±± 	
	protected
≥≥ 
string
≥≥ 
DeleteGameImage
≥≥ (
(
≥≥( )
Guid
≥≥) -
userId
≥≥. 4
,
≥≥4 5
BlobType
≥≥6 >
type
≥≥? C
,
≥≥C D
string
≥≥E K
filename
≥≥L T
)
≥≥T U
{
¥¥ 	
var
µµ 
result
µµ 
=
µµ 
this
µµ 
.
µµ 
DeleteImage
µµ )
(
µµ) *
userId
µµ* 0
,
µµ0 1
filename
µµ2 :
)
µµ: ;
;
µµ; <
return
∑∑ 
result
∑∑ 
;
∑∑ 
}
∏∏ 	
	protected
∫∫ 
string
∫∫ !
DeleteFeaturedImage
∫∫ ,
(
∫∫, -
Guid
∫∫- 1
userId
∫∫2 8
,
∫∫8 9
string
∫∫: @
filename
∫∫A I
)
∫∫I J
{
ªª 	
var
ºº 
type
ºº 
=
ºº 
BlobType
ºº 
.
ºº  
FeaturedImage
ºº  -
.
ºº- .
ToString
ºº. 6
(
ºº6 7
)
ºº7 8
.
ºº8 9
ToLower
ºº9 @
(
ºº@ A
)
ººA B
;
ººB C
var
ΩΩ 
result
ΩΩ 
=
ΩΩ 
this
ΩΩ 
.
ΩΩ 
DeleteImage
ΩΩ )
(
ΩΩ) *
userId
ΩΩ* 0
,
ΩΩ0 1
filename
ΩΩ2 :
)
ΩΩ: ;
;
ΩΩ; <
return
øø 
result
øø 
;
øø 
}
¿¿ 	
	protected
≈≈ 
string
≈≈ 
GetCookieValue
≈≈ '
(
≈≈' (
SessionValues
≈≈( 5
key
≈≈6 9
)
≈≈9 :
{
∆∆ 	
string
«« 
value
«« 
=
«« 
CookieMgrService
«« +
.
««+ ,
Get
««, /
(
««/ 0
key
««0 3
.
««3 4
ToString
««4 <
(
««< =
)
««= >
)
««> ?
;
««? @
return
…… 
value
…… 
;
…… 
}
   	
	protected
ÃÃ 
void
ÃÃ 
SetCookieValue
ÃÃ %
(
ÃÃ% &
SessionValues
ÃÃ& 3
key
ÃÃ4 7
,
ÃÃ7 8
string
ÃÃ9 ?
value
ÃÃ@ E
,
ÃÃE F
int
ÃÃG J
?
ÃÃJ K

expireTime
ÃÃL V
)
ÃÃV W
{
ÕÕ 	
CookieMgrService
ŒŒ 
.
ŒŒ 
Set
ŒŒ  
(
ŒŒ  !
key
ŒŒ! $
.
ŒŒ$ %
ToString
ŒŒ% -
(
ŒŒ- .
)
ŒŒ. /
,
ŒŒ/ 0
value
ŒŒ1 6
,
ŒŒ6 7

expireTime
ŒŒ8 B
)
ŒŒB C
;
ŒŒC D
}
œœ 	
}
—— 
}““ …R
lC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\BrainstormController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
public 

class  
BrainstormController %
:& ' 
SecureBaseController( <
{ 
private !
IBrainstormAppService % 
brainstormAppService& :
;: ;
public  
BrainstormController #
(# $!
IBrainstormAppService$ 9 
brainstormAppService: N
)N O
{ 	
this 
.  
brainstormAppService %
=& ' 
brainstormAppService( <
;< =
} 	
[ 	
Route	 
( 
$str %
)% &
]& '
[ 	
Route	 
( 
$str 
) 
] 
public 
IActionResult 
Index "
(" #
Guid# '
?' (
id) +
)+ ,
{ 	&
BrainstormSessionViewModel &
currentSession' 5
;5 6!
OperationResultListVo !
<! "&
BrainstormSessionViewModel" <
>< =
sessions> F
=G H 
brainstormAppServiceI ]
.] ^
GetSessions^ i
(i j
thisj n
.n o
CurrentUserIdo |
)| }
;} ~
ViewData 
[ 
$str 
]  
=! "
sessions# +
.+ ,
Value, 1
;1 2
if   
(   
id   
.   
HasValue   
)   
{!! 
currentSession"" 
=""  
sessions""! )
."") *
Value""* /
.""/ 0
FirstOrDefault""0 >
(""> ?
x""? @
=>""A C
x""D E
.""E F
Id""F H
==""I K
id""L N
.""N O
Value""O T
)""T U
;""U V
}## 
else$$ 
{%% 
currentSession&& 
=&&  
sessions&&! )
.&&) *
Value&&* /
.&&/ 0
FirstOrDefault&&0 >
(&&> ?
x&&? @
=>&&A C
x&&D E
.&&E F
Type&&F J
==&&K M!
BrainstormSessionType&&N c
.&&c d
Main&&d h
)&&h i
;&&i j
}(( 
return** 
View** 
(** 
currentSession** &
)**& '
;**' (
}++ 	
public-- 
PartialViewResult--  
NewIdea--! (
(--( )
Guid--) -
	sessionId--. 7
)--7 8
{.. 	#
BrainstormIdeaViewModel// #
vm//$ &
=//' (
new//) ,#
BrainstormIdeaViewModel//- D
(//D E
)//E F
;//F G
vm00 
.00 
	SessionId00 
=00 
	sessionId00 $
;00$ %
return22 
PartialView22 
(22 
$str22 ,
,22, -
vm22. 0
)220 1
;221 2
}33 	
public55 
PartialViewResult55  

NewSession55! +
(55+ ,
)55, -
{66 	&
BrainstormSessionViewModel77 &
vm77' )
=77* +
new77, /&
BrainstormSessionViewModel770 J
(77J K
)77K L
;77L M
return99 
PartialView99 
(99 
$str99 3
,993 4
vm995 7
)997 8
;998 9
}:: 	
public<< 
IActionResult<< 
Details<< $
(<<$ %
Guid<<% )
id<<* ,
)<<, -
{== 	
OperationResultVo>> 
<>> #
BrainstormIdeaViewModel>> 5
>>>5 6
op>>7 9
=>>: ;
this>>< @
.>>@ A 
brainstormAppService>>A U
.>>U V
GetById>>V ]
(>>] ^
this>>^ b
.>>b c
CurrentUserId>>c p
,>>p q
id>>r t
)>>t u
;>>u v#
BrainstormIdeaViewModel@@ #
vm@@$ &
=@@' (
op@@) +
.@@+ ,
Value@@, 1
;@@1 2
thisBB 
.BB 
SetAuthorDetailsBB !
(BB! "
vmBB" $
)BB$ %
;BB% &
returnDD 
ViewDD 
(DD 
$strDD "
,DD" #
vmDD$ &
)DD& '
;DD' (
}EE 	
[GG 	
RouteGG	 
(GG 
$strGG 1
)GG1 2
]GG2 3
[HH 	
RouteHH	 
(HH 
$strHH  
)HH  !
]HH! "
publicII 
PartialViewResultII  
ListII! %
(II% &
GuidII& *
	sessionIdII+ 4
)II4 5
{JJ 	!
OperationResultListVoKK !
<KK! "#
BrainstormIdeaViewModelKK" 9
>KK9 :
serviceResultKK; H
=KKI J 
brainstormAppServiceKKK _
.KK_ `
GetAllBySessionIdKK` q
(KKq r
thisKKr v
.KKv w
CurrentUserId	KKw Ñ
,
KKÑ Ö
	sessionId
KKÜ è
)
KKè ê
;
KKê ë
IEnumerableMM 
<MM #
BrainstormIdeaViewModelMM /
>MM/ 0
itemsMM1 6
=MM7 8
serviceResultMM9 F
.MMF G
ValueMMG L
;MML M
returnOO 
PartialViewOO 
(OO 
$strOO &
,OO& '
itemsOO( -
)OO- .
;OO. /
}PP 	
[SS 	
HttpPostSS	 
]SS 
publicTT 
IActionResultTT 
SaveTT !
(TT! "#
BrainstormIdeaViewModelTT" 9
vmTT: <
)TT< =
{UU 	
tryVV 
{WW 
vmXX 
.XX 
UserIdXX 
=XX 
thisXX  
.XX  !
CurrentUserIdXX! .
;XX. / 
brainstormAppServiceZZ $
.ZZ$ %
SaveZZ% )
(ZZ) *
vmZZ* ,
)ZZ, -
;ZZ- .
string\\ 
url\\ 
=\\ 
Url\\  
.\\  !
Action\\! '
(\\' (
$str\\( /
,\\/ 0
$str\\1 =
,\\= >
new\\? B
{\\C D
area\\E I
=\\J K
string\\L R
.\\R S
Empty\\S X
,\\X Y
id\\Z \
=\\] ^
vm\\_ a
.\\a b
	SessionId\\b k
.\\k l
ToString\\l t
(\\t u
)\\u v
}\\w x
)\\x y
;\\y z
return^^ 
Json^^ 
(^^ 
new^^ %
OperationResultRedirectVo^^  9
(^^9 :
url^^: =
)^^= >
)^^> ?
;^^? @
}__ 
catch`` 
(`` 
	Exception`` 
ex`` 
)``  
{aa 
returnbb 
Jsonbb 
(bb 
newbb 
OperationResultVobb  1
(bb1 2
exbb2 4
.bb4 5
Messagebb5 <
)bb< =
)bb= >
;bb> ?
}cc 
}dd 	
[gg 	
HttpPostgg	 
]gg 
publichh 
IActionResulthh 
SaveSessionhh (
(hh( )&
BrainstormSessionViewModelhh) C
vmhhD F
)hhF G
{ii 	
tryjj 
{kk 
vmll 
.ll 
UserIdll 
=ll 
thisll  
.ll  !
CurrentUserIdll! .
;ll. / 
brainstormAppServicenn $
.nn$ %
SaveSessionnn% 0
(nn0 1
vmnn1 3
)nn3 4
;nn4 5
stringpp 
urlpp 
=pp 
Urlpp  
.pp  !
Actionpp! '
(pp' (
$strpp( /
,pp/ 0
$strpp1 =
,pp= >
newpp? B
{ppC D
areappE I
=ppJ K
stringppL R
.ppR S
EmptyppS X
,ppX Y
idppZ \
=pp] ^
vmpp_ a
.ppa b
Idppb d
.ppd e
ToStringppe m
(ppm n
)ppn o
}ppp q
)ppq r
;ppr s
returnrr 
Jsonrr 
(rr 
newrr %
OperationResultRedirectVorr  9
(rr9 :
urlrr: =
)rr= >
)rr> ?
;rr? @
}ss 
catchtt 
(tt 
	Exceptiontt 
extt 
)tt  
{uu 
returnvv 
Jsonvv 
(vv 
newvv 
OperationResultVovv  1
(vv1 2
exvv2 4
.vv4 5
Messagevv5 <
)vv< =
)vv= >
;vv> ?
}ww 
}xx 	
[zz 	
HttpPostzz	 
]zz 
public{{ 
IActionResult{{ 
Vote{{ !
({{! "#
BrainstormVoteViewModel{{" 9
vm{{: <
){{< =
{|| 	
try}} 
{~~ 
OperationResultVo !
operationResult" 1
=2 3 
brainstormAppService4 H
.H I
VoteI M
(M N
thisN R
.R S
CurrentUserIdS `
,` a
vmb d
.d e
VotingItemIde q
,q r
vms u
.u v
	VoteValuev 
)	 Ä
;
Ä Å
string
ÅÅ 
url
ÅÅ 
=
ÅÅ 
Url
ÅÅ  
.
ÅÅ  !
Action
ÅÅ! '
(
ÅÅ' (
$str
ÅÅ( /
,
ÅÅ/ 0
$str
ÅÅ1 =
,
ÅÅ= >
new
ÅÅ? B
{
ÅÅC D
area
ÅÅE I
=
ÅÅJ K
string
ÅÅL R
.
ÅÅR S
Empty
ÅÅS X
}
ÅÅY Z
)
ÅÅZ [
;
ÅÅ[ \
return
ÉÉ 
Json
ÉÉ 
(
ÉÉ 
new
ÉÉ '
OperationResultRedirectVo
ÉÉ  9
(
ÉÉ9 :
url
ÉÉ: =
)
ÉÉ= >
)
ÉÉ> ?
;
ÉÉ? @
}
ÑÑ 
catch
ÖÖ 
(
ÖÖ 
	Exception
ÖÖ 
ex
ÖÖ 
)
ÖÖ  
{
ÜÜ 
return
áá 
Json
áá 
(
áá 
new
áá 
OperationResultVo
áá  1
(
áá1 2
ex
áá2 4
.
áá4 5
Message
áá5 <
)
áá< =
)
áá= >
;
áá> ?
}
àà 
}
ââ 	
}
ää 
}ãã ›»
iC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\ContentController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
public 

class 
ContentController "
:# $ 
SecureBaseController% 9
{ 
private 
readonly "
IUserContentAppService /
service0 7
;7 8
private 
readonly 
IGameAppService (
gameAppService) 7
;7 8
private 
readonly !
IGameFollowAppService . 
gameFollowAppService/ C
;C D
private 
readonly !
IUserFollowAppService . 
userFollowAppService/ C
;C D
private 
readonly #
INotificationAppService 0"
notificationAppService1 G
;G H
public 
ContentController  
(  !"
IUserContentAppService! 7
service8 ?
, 
IGameAppService 
gameAppService ,
, !
IGameFollowAppService # 
gameFollowAppService$ 8
, !
IUserFollowAppService # 
userFollowAppService$ 8
,   #
INotificationAppService   %"
notificationAppService  & <
)  < =
{!! 	
this"" 
."" 
service"" 
="" 
service"" "
;""" #
this## 
.## 
gameAppService## 
=##  !
gameAppService##" 0
;##0 1
this$$ 
.$$  
gameFollowAppService$$ %
=$$& ' 
gameFollowAppService$$( <
;$$< =
this%% 
.%%  
userFollowAppService%% %
=%%& ' 
userFollowAppService%%( <
;%%< =
this&& 
.&& "
notificationAppService&& '
=&&( )"
notificationAppService&&* @
;&&@ A
}'' 	
[)) 	
Route))	 
()) 
$str)) "
)))" #
]))# $
public** 
async** 
Task** 
<** 
IActionResult** '
>**' (
Details**) 0
(**0 1
Guid**1 5
id**6 8
,**8 9
Guid**: >
notificationclicked**? R
)**R S
{++ 	
OperationResultVo,, 
<,,  
UserContentViewModel,, 2
>,,2 3
serviceResult,,4 A
=,,B C
service,,D K
.,,K L
GetById,,L S
(,,S T
id,,T V
),,V W
;,,W X 
UserContentViewModel..  
vm..! #
=..$ %
serviceResult..& 3
...3 4
Value..4 9
;..9 :
this00 
.00 
SetAuthorDetails00 !
(00! "
vm00" $
)00$ %
;00% &
if22 
(22 
vm22 
.22 
GameId22 
.22 
HasValue22 "
&&22# %
vm22& (
.22( )
GameId22) /
.22/ 0
Value220 5
!=226 8
Guid229 =
.22= >
Empty22> C
)22C D
{33 
OperationResultVo44 !
<44! "
Application44" -
.44- .

ViewModels44. 8
.448 9
Game449 =
.44= >
GameViewModel44> K
>44K L
gameServiceResult44M ^
=44_ `
gameAppService44a o
.44o p
GetById44p w
(44w x
vm44x z
.44z {
GameId	44{ Å
.
44Å Ç
Value
44Ç á
)
44á à
;
44à â
Application66 
.66 

ViewModels66 &
.66& '
Game66' +
.66+ ,
GameViewModel66, 9
game66: >
=66? @
gameServiceResult66A R
.66R S
Value66S X
;66X Y
vm88 
.88 
	GameTitle88 
=88 
game88 #
.88# $
Title88$ )
;88) *
vm99 
.99 
GameThumbnail99  
=99! "
UrlFormatter99# /
.99/ 0
Image990 5
(995 6
game996 :
.99: ;
UserId99; A
,99A B
BlobType99C K
.99K L
GameThumbnail99L Y
,99Y Z
game99[ _
.99_ `
ThumbnailUrl99` l
)99l m
;99m n
}:: 
vm<< 
.<< 
Content<< 
=<< 
vm<< 
.<< 
Content<< #
.<<# $
Replace<<$ +
(<<+ ,
$str<<, E
,<<E F
$str<<G q
)<<q r
;<<r s
vm== 
.== 
Content== 
=== 
vm== 
.== 
Content== #
.==# $
Replace==$ +
(==+ ,
$str==, D
,==D E
$str==F n
)==n o
;==o p
vm>> 
.>> 
Content>> 
=>> 
vm>> 
.>> 
Content>> #
.>># $
Replace>>$ +
(>>+ ,
$str>>, 7
,>>7 8
$str>>9 Y
)>>Y Z
;>>Z [
if@@ 
(@@ 
string@@ 
.@@ 
IsNullOrEmpty@@ $
(@@$ %
vm@@% '
.@@' (
Title@@( -
)@@- .
)@@. /
{AA 
vmBB 
.BB 
TitleBB 
=BB 
SharedLocalizerBB *
[BB* +
$strBB+ >
]BB> ?
+BB@ A
$strBBB E
+BBF G
vmBBH J
.BBJ K

CreateDateBBK U
.BBU V
ToStringBBV ^
(BB^ _
)BB_ `
;BB` a
}CC 
ifEE 
(EE 
stringEE 
.EE 
IsNullOrWhiteSpaceEE )
(EE) *
vmEE* ,
.EE, -
IntroductionEE- 9
)EE9 :
)EE: ;
{FF 
vmGG 
.GG 
IntroductionGG 
=GG  !
SharedLocalizerGG" 1
[GG1 2
$strGG2 E
]GGE F
+GGG H
$strGGI L
+GGM N
vmGGO Q
.GGQ R

CreateDateGGR \
.GG\ ]
ToShortDateStringGG] n
(GGn o
)GGo p
;GGp q
}HH 
ApplicationUserKK 
userKK  
=KK! "
awaitKK# (
UserManagerKK) 4
.KK4 5
FindByIdAsyncKK5 B
(KKB C
CurrentUserIdKKC P
.KKP Q
ToStringKKQ Y
(KKY Z
)KKZ [
)KK[ \
;KK\ ]
boolLL 
userIsAdminLL 
=LL 
userLL #
==LL$ &
nullLL' +
?LL, -
falseLL. 3
:LL4 5
awaitLL6 ;
UserManagerLL< G
.LLG H
IsInRoleAsyncLLH U
(LLU V
userLLV Z
,LLZ [
RolesLL\ a
.LLa b
AdministratorLLb o
.LLo p
ToStringLLp x
(LLx y
)LLy z
)LLz {
;LL{ |
vmMM 
.MM 
PermissionsMM 
.MM 
CanEditMM "
=MM# $
vmMM% '
.MM' (
UserIdMM( .
==MM/ 1
CurrentUserIdMM2 ?
||MM@ B
userIsAdminMMC N
;MMN O
thisOO 
.OO "
notificationAppServiceOO '
.OO' (

MarkAsReadOO( 2
(OO2 3
notificationclickedOO3 F
)OOF G
;OOG H
returnQQ 
ViewQQ 
(QQ 
vmQQ 
)QQ 
;QQ 
}RR 	
[TT 	
RouteTT	 
(TT 
$strTT '
)TT' (
]TT( )
publicUU 
IActionResultUU 
EditUU !
(UU! "
GuidUU" &
idUU' )
)UU) *
{VV 	
OperationResultVoWW 
<WW  
UserContentViewModelWW 2
>WW2 3
serviceResultWW4 A
=WWB C
serviceWWD K
.WWK L
GetByIdWWL S
(WWS T
idWWT V
)WWV W
;WWW X 
UserContentViewModelYY  
vmYY! #
=YY$ %
serviceResultYY& 3
.YY3 4
ValueYY4 9
;YY9 :
IEnumerable[[ 
<[[ 
SelectListItemVo[[ (
>[[( )
games[[* /
=[[0 1
gameAppService[[2 @
.[[@ A
	GetByUser[[A J
([[J K
vm[[K M
.[[M N
UserId[[N T
)[[T U
;[[U V
List\\ 
<\\ 
SelectListItem\\ 
>\\  
gamesDropDown\\! .
=\\/ 0
games\\1 6
.\\6 7
ToSelectList\\7 C
(\\C D
)\\D E
;\\E F
ViewBag]] 
.]] 
	UserGames]] 
=]] 
gamesDropDown]]  -
;]]- .
return__ 
View__ 
(__ 
$str__ $
,__$ %
vm__& (
)__( )
;__) *
}`` 	
publicbb 
IActionResultbb 
Addbb  
(bb  !
Guidbb! %
?bb% &
gameIdbb' -
)bb- .
{cc 	 
UserContentViewModeldd  
vmdd! #
=dd$ %
newdd& ) 
UserContentViewModeldd* >
(dd> ?
)dd? @
;dd@ A
vmee 
.ee 
UserIdee 
=ee 
CurrentUserIdee %
;ee% &
vmff 
.ff 
FeaturedImageff 
=ff 
	Constantsff (
.ff( ) 
DefaultFeaturedImageff) =
;ff= >
IEnumerablehh 
<hh 
SelectListItemVohh (
>hh( )
gameshh* /
=hh0 1
gameAppServicehh2 @
.hh@ A
	GetByUserhhA J
(hhJ K
vmhhK M
.hhM N
UserIdhhN T
)hhT U
;hhU V
Listii 
<ii 
SelectListItemii 
>ii  
gamesDropDownii! .
=ii/ 0
gamesii1 6
.ii6 7
ToSelectListii7 C
(iiC D
)iiD E
;iiE F
ViewBagjj 
.jj 
	UserGamesjj 
=jj 
gamesDropDownjj  -
;jj- .
ifll 
(ll 
gameIdll 
.ll 
HasValuell 
)ll  
{mm 
vmnn 
.nn 
GameIdnn 
=nn 
gameIdnn "
;nn" #
}oo 
returnqq 
Viewqq 
(qq 
$strqq $
,qq$ %
vmqq& (
)qq( )
;qq) *
}rr 	
[tt 	
HttpPosttt	 
]tt 
publicuu 
IActionResultuu 
Saveuu !
(uu! " 
UserContentViewModeluu" 6
vmuu7 9
)uu9 :
{vv 	
tryww 
{xx 
ProfileViewModelyy  
profileyy! (
=yy) *
thisyy+ /
.yy/ 0
SetAuthorDetailsyy0 @
(yy@ A
vmyyA C
)yyC D
;yyD E
OperationResultVo{{ !
<{{! "
Guid{{" &
>{{& '
result{{( .
={{/ 0
service{{1 8
.{{8 9
Save{{9 =
({{= >
vm{{> @
){{@ A
;{{A B
if}} 
(}} 
!}} 
result}} 
.}} 
Success}} #
)}}# $
{~~ 
return
ÄÄ 
Json
ÄÄ 
(
ÄÄ  
result
ÄÄ  &
)
ÄÄ& '
;
ÄÄ' (
}
ÅÅ 
else
ÇÇ 
{
ÉÉ 
this
ÑÑ 
.
ÑÑ 
NotifyFollowers
ÑÑ (
(
ÑÑ( )
this
ÑÑ) -
.
ÑÑ- .
CurrentUserId
ÑÑ. ;
,
ÑÑ; <
profile
ÑÑ= D
,
ÑÑD E
vm
ÑÑF H
.
ÑÑH I
GameId
ÑÑI O
.
ÑÑO P
Value
ÑÑP U
,
ÑÑU V
vm
ÑÑW Y
.
ÑÑY Z
Id
ÑÑZ \
)
ÑÑ\ ]
;
ÑÑ] ^
string
ÜÜ 
url
ÜÜ 
=
ÜÜ  
Url
ÜÜ! $
.
ÜÜ$ %
Action
ÜÜ% +
(
ÜÜ+ ,
$str
ÜÜ, 3
,
ÜÜ3 4
$str
ÜÜ5 ;
,
ÜÜ; <
new
ÜÜ= @
{
ÜÜA B
area
ÜÜC G
=
ÜÜH I
string
ÜÜJ P
.
ÜÜP Q
Empty
ÜÜQ V
,
ÜÜV W
id
ÜÜX Z
=
ÜÜ[ \
vm
ÜÜ] _
.
ÜÜ_ `
Id
ÜÜ` b
}
ÜÜc d
)
ÜÜd e
;
ÜÜe f
return
àà 
Json
àà 
(
àà  
new
àà  #'
OperationResultRedirectVo
àà$ =
(
àà= >
url
àà> A
)
ààA B
)
ààB C
;
ààC D
}
ââ 
}
ãã 
catch
åå 
(
åå 
	Exception
åå 
ex
åå 
)
åå  
{
çç 
return
éé 
Json
éé 
(
éé 
new
éé 
OperationResultVo
éé  1
(
éé1 2
ex
éé2 4
.
éé4 5
Message
éé5 <
)
éé< =
)
éé= >
;
éé> ?
}
èè 
}
êê 	
[
íí 	
HttpPost
íí	 
]
íí 
[
ìì 	
Route
ìì	 
(
ìì 
$str
ìì 
)
ìì 
]
ìì 
public
îî 
IActionResult
îî 

SimplePost
îî '
(
îî' (
string
îî( .
text
îî/ 3
,
îî3 4
string
îî5 ;
images
îî< B
)
îîB C
{
ïï 	"
UserContentViewModel
óó  
vm
óó! #
=
óó$ %
new
óó& )"
UserContentViewModel
óó* >
(
óó> ?
)
óó? @
;
óó@ A
vm
òò 
.
òò 
Language
òò 
=
òò 
SupportedLanguage
òò +
.
òò+ ,
English
òò, 3
;
òò3 4
vm
ôô 
.
ôô 
Content
ôô 
=
ôô 
text
ôô 
;
ôô 
ProfileViewModel
õõ 
profile
õõ $
=
õõ% &
this
õõ' +
.
õõ+ ,
SetAuthorDetails
õõ, <
(
õõ< =
vm
õõ= ?
)
õõ? @
;
õõ@ A
this
ùù 
.
ùù 
SetContentImages
ùù !
(
ùù! "
vm
ùù" $
,
ùù$ %
images
ùù& ,
)
ùù, -
;
ùù- .
OperationResultVo
üü 
<
üü 
Guid
üü "
>
üü" #
result
üü$ *
=
üü+ ,
service
üü- 4
.
üü4 5
Save
üü5 9
(
üü9 :
vm
üü: <
)
üü< =
;
üü= >
this
°° 
.
°° 
NotifyFollowers
°°  
(
°°  !
this
°°! %
.
°°% &
CurrentUserId
°°& 3
,
°°3 4
profile
°°5 <
,
°°< =
vm
°°> @
.
°°@ A
GameId
°°A G
,
°°G H
vm
°°I K
.
°°K L
Id
°°L N
)
°°N O
;
°°O P
return
££ 
Json
££ 
(
££ 
result
££ 
)
££ 
;
££  
}
§§ 	
public
¶¶ 
IActionResult
¶¶ 
Feed
¶¶ !
(
¶¶! "
Guid
¶¶" &
gameId
¶¶' -
,
¶¶- .
Guid
¶¶/ 3
userId
¶¶4 :
)
¶¶: ;
{
ßß 	
return
®® 
ViewComponent
®®  
(
®®  !
$str
®®! .
,
®®. /
new
®®0 3
{
®®4 5
count
®®6 ;
=
®®< =
$num
®®> @
,
®®@ A
gameId
®®B H
=
®®I J
gameId
®®K Q
,
®®Q R
userId
®®S Y
=
®®Z [
userId
®®\ b
}
®®c d
)
®®d e
;
®®e f
}
©© 	
private
´´ 
void
´´ 
SetContentImages
´´ %
(
´´% &"
UserContentViewModel
´´& :
vm
´´; =
,
´´= >
string
´´? E
images
´´F L
)
´´L M
{
¨¨ 	
if
≠≠ 
(
≠≠ 
images
≠≠ 
!=
≠≠ 
null
≠≠ 
)
≠≠ 
{
ÆÆ 
string
ØØ 
[
ØØ 
]
ØØ 
imgSplit
ØØ !
=
ØØ" #
images
ØØ$ *
.
ØØ* +
Split
ØØ+ 0
(
ØØ0 1
$char
ØØ1 4
)
ØØ4 5
;
ØØ5 6
vm
∞∞ 
.
∞∞ 
Images
∞∞ 
=
∞∞ 
new
∞∞ 
List
∞∞  $
<
∞∞$ %
string
∞∞% +
>
∞∞+ ,
(
∞∞, -
)
∞∞- .
;
∞∞. /
for
≤≤ 
(
≤≤ 
int
≤≤ 
i
≤≤ 
=
≤≤ 
$num
≤≤ 
;
≤≤ 
i
≤≤  !
<
≤≤" #
imgSplit
≤≤$ ,
.
≤≤, -
Length
≤≤- 3
;
≤≤3 4
i
≤≤5 6
++
≤≤6 8
)
≤≤8 9
{
≥≥ 
if
¥¥ 
(
¥¥ 
!
¥¥ 
string
¥¥ 
.
¥¥   
IsNullOrWhiteSpace
¥¥  2
(
¥¥2 3
imgSplit
¥¥3 ;
[
¥¥; <
i
¥¥< =
]
¥¥= >
)
¥¥> ?
)
¥¥? @
{
µµ 
if
∂∂ 
(
∂∂ 
string
∂∂ "
.
∂∂" # 
IsNullOrWhiteSpace
∂∂# 5
(
∂∂5 6
vm
∂∂6 8
.
∂∂8 9
FeaturedImage
∂∂9 F
)
∂∂F G
)
∂∂G H
{
∑∑ 
vm
∏∏ 
.
∏∏ 
FeaturedImage
∏∏ ,
=
∏∏- .
imgSplit
∏∏/ 7
[
∏∏7 8
i
∏∏8 9
]
∏∏9 :
;
∏∏: ;
}
ππ 
else
∫∫ 
{
ªª 
vm
ºº 
.
ºº 
Images
ºº %
.
ºº% &
Add
ºº& )
(
ºº) *
imgSplit
ºº* 2
[
ºº2 3
i
ºº3 4
]
ºº4 5
)
ºº5 6
;
ºº6 7
}
ΩΩ 
}
ææ 
}
øø 
}
¿¿ 
}
¡¡ 	
private
√√ 
void
√√ 
NotifyFollowers
√√ $
(
√√$ %
Guid
√√% )
userId
√√* 0
,
√√0 1
ProfileViewModel
√√2 B
profile
√√C J
,
√√J K
Guid
√√L P
?
√√P Q
gameId
√√R X
,
√√X Y
Guid
√√Z ^
	contentId
√√_ h
)
√√h i
{
ƒƒ 	

Dictionary
≈≈ 
<
≈≈ 
Guid
≈≈ 
,
≈≈ 

FollowType
≈≈ '
>
≈≈' (
	followers
≈≈) 2
=
≈≈3 4
new
≈≈5 8

Dictionary
≈≈9 C
<
≈≈C D
Guid
≈≈D H
,
≈≈H I

FollowType
≈≈J T
>
≈≈T U
(
≈≈U V
)
≈≈V W
;
≈≈W X
string
«« 
notificationText
«« #
=
««$ %
SharedLocalizer
««& 5
[
««5 6
$str
««6 U
]
««U V
;
««V W
string
»» 
notificationUrl
»» "
=
»»# $
Url
»»% (
.
»»( )
Action
»») /
(
»»/ 0
$str
»»0 9
,
»»9 :
$str
»»; D
,
»»D E
new
»»F I
{
»»J K
id
»»L N
=
»»O P
	contentId
»»Q Z
}
»»[ \
)
»»\ ]
;
»»] ^
string
   
gameName
   
=
   
string
   $
.
  $ %
Empty
  % *
;
  * +
Guid
ÃÃ 
targetId
ÃÃ 
=
ÃÃ 
Guid
ÃÃ  
.
ÃÃ  !
Empty
ÃÃ! &
;
ÃÃ& '#
OperationResultListVo
ŒŒ !
<
ŒŒ! "!
UserFollowViewModel
ŒŒ" 5
>
ŒŒ5 6
userFollowers
ŒŒ7 D
=
ŒŒE F
this
ŒŒG K
.
ŒŒK L"
userFollowAppService
ŒŒL `
.
ŒŒ` a
GetByFollowedId
ŒŒa p
(
ŒŒp q
userId
ŒŒq w
)
ŒŒw x
;
ŒŒx y
if
–– 
(
–– 
userFollowers
–– 
.
–– 
Success
–– %
)
––% &
{
—— 
foreach
““ 
(
““ !
UserFollowViewModel
““ ,
userFollower
““- 9
in
““: <
userFollowers
““= J
.
““J K
Value
““K P
)
““P Q
{
”” 
	followers
‘‘ 
.
‘‘ 
Add
‘‘ !
(
‘‘! "
userFollower
‘‘" .
.
‘‘. /
UserId
‘‘/ 5
,
‘‘5 6

FollowType
‘‘7 A
.
‘‘A B
Content
‘‘B I
)
‘‘I J
;
‘‘J K
}
’’ 
}
÷÷ 
if
ÿÿ 
(
ÿÿ 
gameId
ÿÿ 
.
ÿÿ 
HasValue
ÿÿ 
)
ÿÿ  
{
ŸŸ #
OperationResultListVo
⁄⁄ %
<
⁄⁄% &!
GameFollowViewModel
⁄⁄& 9
>
⁄⁄9 :
gameFollowResult
⁄⁄; K
=
⁄⁄L M
this
⁄⁄N R
.
⁄⁄R S"
gameFollowAppService
⁄⁄S g
.
⁄⁄g h
GetByGameId
⁄⁄h s
(
⁄⁄s t
gameId
⁄⁄t z
.
⁄⁄z {
Value⁄⁄{ Ä
)⁄⁄Ä Å
;⁄⁄Å Ç
OperationResultVo
‹‹ !
<
‹‹! "
GameViewModel
‹‹" /
>
‹‹/ 0

gameResult
‹‹1 ;
=
‹‹< =
gameAppService
‹‹> L
.
‹‹L M
GetById
‹‹M T
(
‹‹T U
gameId
‹‹U [
.
‹‹[ \
Value
‹‹\ a
)
‹‹a b
;
‹‹b c
if
ﬁﬁ 
(
ﬁﬁ 

gameResult
ﬁﬁ 
.
ﬁﬁ 
Success
ﬁﬁ &
)
ﬁﬁ& '
{
ﬂﬂ 
gameName
‡‡ 
=
‡‡ 

gameResult
‡‡ )
.
‡‡) *
Value
‡‡* /
.
‡‡/ 0
Title
‡‡0 5
;
‡‡5 6
}
·· 
if
„„ 
(
„„ 
gameFollowResult
„„ $
.
„„$ %
Success
„„% ,
)
„„, -
{
‰‰ 
foreach
ÂÂ 
(
ÂÂ !
GameFollowViewModel
ÂÂ 0
gameFollower
ÂÂ1 =
in
ÂÂ> @
gameFollowResult
ÂÂA Q
.
ÂÂQ R
Value
ÂÂR W
)
ÂÂW X
{
ÊÊ 
if
ÁÁ 
(
ÁÁ 
	followers
ÁÁ %
.
ÁÁ% &
ContainsKey
ÁÁ& 1
(
ÁÁ1 2
gameFollower
ÁÁ2 >
.
ÁÁ> ?
UserId
ÁÁ? E
)
ÁÁE F
)
ÁÁF G
{
ËË 
	followers
ÈÈ %
[
ÈÈ% &
gameFollower
ÈÈ& 2
.
ÈÈ2 3
UserId
ÈÈ3 9
]
ÈÈ9 :
=
ÈÈ; <

FollowType
ÈÈ= G
.
ÈÈG H
Game
ÈÈH L
;
ÈÈL M
}
ÍÍ 
else
ÎÎ 
{
ÏÏ 
	followers
ÌÌ %
.
ÌÌ% &
Add
ÌÌ& )
(
ÌÌ) *
gameFollower
ÌÌ* 6
.
ÌÌ6 7
UserId
ÌÌ7 =
,
ÌÌ= >

FollowType
ÌÌ? I
.
ÌÌI J
Game
ÌÌJ N
)
ÌÌN O
;
ÌÌO P
}
ÓÓ 
}
ÔÔ 
}
 
}
ÒÒ 
foreach
ÛÛ 
(
ÛÛ 
KeyValuePair
ÛÛ !
<
ÛÛ! "
Guid
ÛÛ" &
,
ÛÛ& '

FollowType
ÛÛ( 2
>
ÛÛ2 3
follower
ÛÛ4 <
in
ÛÛ= ?
	followers
ÛÛ@ I
)
ÛÛI J
{
ÙÙ 
switch
ıı 
(
ıı 
follower
ıı  
.
ıı  !
Value
ıı! &
)
ıı& '
{
ˆˆ 
case
˜˜ 

FollowType
˜˜ #
.
˜˜# $
Content
˜˜$ +
:
˜˜+ ,
this
¯¯ 
.
¯¯ $
notificationAppService
¯¯ 3
.
¯¯3 4
Notify
¯¯4 :
(
¯¯: ;
follower
¯¯; C
.
¯¯C D
Key
¯¯D G
,
¯¯G H
NotificationType
¯¯I Y
.
¯¯Y Z
ContentPosted
¯¯Z g
,
¯¯g h
targetId
¯¯i q
,
¯¯q r
String
¯¯s y
.
¯¯y z
Format¯¯z Ä
(¯¯Ä Å 
notificationText¯¯Å ë
,¯¯ë í
profile¯¯ì ö
.¯¯ö õ
Name¯¯õ ü
)¯¯ü †
,¯¯† °
notificationUrl¯¯¢ ±
)¯¯± ≤
;¯¯≤ ≥
break
˘˘ 
;
˘˘ 
case
˙˙ 

FollowType
˙˙ #
.
˙˙# $
Game
˙˙$ (
:
˙˙( )
this
˚˚ 
.
˚˚ $
notificationAppService
˚˚ 3
.
˚˚3 4
Notify
˚˚4 :
(
˚˚: ;
follower
˚˚; C
.
˚˚C D
Key
˚˚D G
,
˚˚G H
NotificationType
˚˚I Y
.
˚˚Y Z
ContentPosted
˚˚Z g
,
˚˚g h
targetId
˚˚i q
,
˚˚q r
String
˚˚s y
.
˚˚y z
Format˚˚z Ä
(˚˚Ä Å 
notificationText˚˚Å ë
,˚˚ë í
gameName˚˚ì õ
)˚˚õ ú
,˚˚ú ù
notificationUrl˚˚û ≠
)˚˚≠ Æ
;˚˚Æ Ø
break
¸¸ 
;
¸¸ 
default
˝˝ 
:
˝˝ 
this
˛˛ 
.
˛˛ $
notificationAppService
˛˛ 3
.
˛˛3 4
Notify
˛˛4 :
(
˛˛: ;
follower
˛˛; C
.
˛˛C D
Key
˛˛D G
,
˛˛G H
NotificationType
˛˛I Y
.
˛˛Y Z
ContentPosted
˛˛Z g
,
˛˛g h
targetId
˛˛i q
,
˛˛q r
String
˛˛s y
.
˛˛y z
Format˛˛z Ä
(˛˛Ä Å 
notificationText˛˛Å ë
,˛˛ë í
profile˛˛ì ö
.˛˛ö õ
Name˛˛õ ü
)˛˛ü †
,˛˛† °
notificationUrl˛˛¢ ±
)˛˛± ≤
;˛˛≤ ≥
break
ˇˇ 
;
ˇˇ 
}
ÄÄ 
}
ÅÅ 
}
ÇÇ 	
}
ÉÉ 
}ÑÑ Ωq
fC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\GameController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
public 

class 
GameController 
:  ! 
SecureBaseController" 6
{ 
private 
readonly 
IGameAppService (
_gameAppService) 8
;8 9
private 
readonly #
INotificationAppService 0"
notificationAppService1 G
;G H
public 
GameController 
( 
IGameAppService -
gameAppService. <
, #
INotificationAppService %"
notificationAppService& <
)< =
:> ?
base@ D
(D E
)E F
{ 	
_gameAppService 
= 
gameAppService ,
;, -
this 
. "
notificationAppService '
=( )"
notificationAppService* @
;@ A
} 	
[ 	
Route	 
( 
$str 
)  
]  !
public 
async 
Task 
< 
IActionResult '
>' (
Details) 0
(0 1
Guid1 5
id6 8
,8 9
Guid: >
notificationclicked? R
)R S
{   	
_gameAppService!! 
.!! 
CurrentUserId!! )
=!!* +
this!!, 0
.!!0 1
CurrentUserId!!1 >
;!!> ?
OperationResultVo"" 
<"" 
GameViewModel"" +
>""+ ,
serviceResult""- :
=""; <
_gameAppService""= L
.""L M
GetById""M T
(""T U
id""U W
)""W X
;""X Y
GameViewModel$$ 
vm$$ 
=$$ 
serviceResult$$ ,
.$$, -
Value$$- 2
;$$2 3
this%% 
.%% 
	SetImages%% 
(%% 
vm%% 
)%% 
;%% 
ApplicationUser'' 
user''  
=''! "
await''# (
UserManager'') 4
.''4 5
FindByIdAsync''5 B
(''B C
CurrentUserId''C P
.''P Q
ToString''Q Y
(''Y Z
)''Z [
)''[ \
;''\ ]
bool(( 
userIsAdmin(( 
=(( 
user(( #
==(($ &
null((' +
?((, -
false((. 3
:((4 5
await((6 ;
UserManager((< G
.((G H
IsInRoleAsync((H U
(((U V
user((V Z
,((Z [
Roles((\ a
.((a b
Administrator((b o
.((o p
ToString((p x
(((x y
)((y z
)((z {
;(({ |
vm)) 
.)) 
Permissions)) 
.)) 
CanEdit)) "
=))# $
vm))% '
.))' (
UserId))( .
==))/ 1
CurrentUserId))2 ?
||))@ B
userIsAdmin))C N
;))N O
vm** 
.** 
Permissions** 
.** 
CanPostActivity** *
=**+ ,
vm**- /
.**/ 0
UserId**0 6
==**7 9
CurrentUserId**: G
;**G H
this,, 
.,, "
notificationAppService,, '
.,,' (

MarkAsRead,,( 2
(,,2 3
notificationclicked,,3 F
),,F G
;,,G H
return.. 
View.. 
(.. 
vm.. 
).. 
;.. 
}// 	
[11 	
Route11	 
(11 
$str11 %
)11% &
]11& '
public22 
IActionResult22 
List22 !
(22! "
	GameGenre22" +
genre22, 1
)221 2
{33 	
IEnumerable44 
<44 !
GameListItemViewModel44 -
>44- .
latest44/ 5
=446 7
_gameAppService448 G
.44G H
	GetLatest44H Q
(44Q R
CurrentUserId44R _
,44_ `
$num44a c
,44c d
Guid44e i
.44i j
Empty44j o
,44o p
genre44q v
)44v w
;44w x
ViewBag66 
.66 
Games66 
=66 
latest66 "
;66" #
ViewData77 
[77 
$str77 
]77 
=77 
genre77  %
;77% &
ViewData88 
[88 
$str88 
]88 
=88 
genre88  %
==88& (
$num88) *
?88+ ,
SharedLocalizer88- <
[88< =
$str88= D
]88D E
:88F G
SharedLocalizer88H W
[88W X
genre88X ]
.88] ^
ToString88^ f
(88f g
)88g h
+88i j
$str88k s
]88s t
;88t u
ViewData99 
[99 
$str99 "
]99" #
=99$ %
SharedLocalizer99& 5
[995 6
$str996 F
+99G H
genre99I N
.99N O
ToString99O W
(99W X
)99X Y
+99Z [
$str99\ d
]99d e
;99e f
return;; 
View;; 
(;; 
);; 
;;; 
}<< 	
public>> 
IActionResult>> 
Add>>  
(>>  !
)>>! "
{?? 	
GameViewModel@@ 
vm@@ 
=@@ 
new@@ "
GameViewModel@@# 0
(@@0 1
)@@1 2
;@@2 3
vmAA 
.AA 
UserIdAA 
=AA 
CurrentUserIdAA %
;AA% &
vmBB 
.BB 
CoverImageUrlBB 
=BB 
	ConstantsBB (
.BB( )!
DefaultGameCoverImageBB) >
;BB> ?
vmCC 
.CC 
ThumbnailUrlCC 
=CC 
	ConstantsCC '
.CC' ( 
DefaultGameThumbnailCC( <
;CC< =
returnEE 
ViewEE 
(EE 
$strEE $
,EE$ %
vmEE& (
)EE( )
;EE) *
}FF 	
publicHH 
IActionResultHH 
EditHH !
(HH! "
GuidHH" &
idHH' )
)HH) *
{II 	
OperationResultVoJJ 
<JJ 
GameViewModelJJ +
>JJ+ ,
serviceResultJJ- :
=JJ; <
_gameAppServiceJJ= L
.JJL M
GetByIdJJM T
(JJT U
idJJU W
)JJW X
;JJX Y
GameViewModelLL 
vmLL 
=LL 
serviceResultLL ,
.LL, -
ValueLL- 2
;LL2 3
thisMM 
.MM 
	SetImagesMM 
(MM 
vmMM 
)MM 
;MM 
returnOO 
ViewOO 
(OO 
$strOO $
,OO$ %
vmOO& (
)OO( )
;OO) *
}PP 	
[RR 	
HttpPostRR	 
]RR 
publicSS 
IActionResultSS 
SaveSS !
(SS! "
GameViewModelSS" /
vmSS0 2
,SS2 3
	IFormFileSS4 =
	thumbnailSS> G
)SSG H
{TT 	
tryUU 
{VV 
thisWW 
.WW 
SetAuthorDetailsWW %
(WW% &
vmWW& (
)WW( )
;WW) *
thisXX 
.XX 
ClearImagesUrlXX #
(XX# $
vmXX$ &
)XX& '
;XX' (
_gameAppServiceZZ 
.ZZ  
SaveZZ  $
(ZZ$ %
vmZZ% '
)ZZ' (
;ZZ( )
string\\ 
url\\ 
=\\ 
Url\\  
.\\  !
Action\\! '
(\\' (
$str\\( 1
,\\1 2
$str\\3 9
,\\9 :
new\\; >
{\\? @
area\\A E
=\\F G
string\\H N
.\\N O
Empty\\O T
,\\T U
id\\V X
=\\Y Z
vm\\[ ]
.\\] ^
Id\\^ `
.\\` a
ToString\\a i
(\\i j
)\\j k
}\\l m
)\\m n
;\\n o
return^^ 
Json^^ 
(^^ 
new^^ %
OperationResultRedirectVo^^  9
(^^9 :
url^^: =
)^^= >
)^^> ?
;^^? @
}__ 
catch`` 
(`` 
	Exception`` 
ex`` 
)``  
{aa 
returnbb 
Jsonbb 
(bb 
newbb 
OperationResultVobb  1
(bb1 2
exbb2 4
.bb4 5
Messagebb5 <
)bb< =
)bb= >
;bb> ?
}cc 
}dd 	
publicff 
IActionResultff 
Latestff #
(ff# $
intff$ '
qtdff( +
,ff+ ,
Guidff- 1
userIdff2 8
)ff8 9
{gg 	
returnhh 
ViewComponenthh  
(hh  !
$strhh! .
,hh. /
newhh0 3
{hh4 5
qtdhh6 9
=hh: ;
qtdhh< ?
,hh? @
userIdhhA G
=hhH I
userIdhhJ P
}hhQ R
)hhR S
;hhS T
}ii 	
privatekk 
voidkk 
	SetImageskk 
(kk 
GameViewModelkk ,
vmkk- /
)kk/ 0
{ll 	
vmmm 
.mm 
ThumbnailUrlmm 
=mm 
stringmm $
.mm$ %
IsNullOrWhiteSpacemm% 7
(mm7 8
vmmm8 :
.mm: ;
ThumbnailUrlmm; G
)mmG H
||mmI K
	ConstantsmmL U
.mmU V 
DefaultGameThumbnailmmV j
.mmj k
Containsmmk s
(mms t
vmmmt v
.mmv w
ThumbnailUrl	mmw É
)
mmÉ Ñ
?
mmÖ Ü
	Constants
mmá ê
.
mmê ë"
DefaultGameThumbnail
mmë •
:
mm¶ ß
UrlFormatter
mm® ¥
.
mm¥ µ
Image
mmµ ∫
(
mm∫ ª
vm
mmª Ω
.
mmΩ æ
UserId
mmæ ƒ
,
mmƒ ≈
BlobType
mm∆ Œ
.
mmŒ œ
GameThumbnail
mmœ ‹
,
mm‹ ›
vm
mmﬁ ‡
.
mm‡ ·
ThumbnailUrl
mm· Ì
)
mmÌ Ó
;
mmÓ Ô
vmoo 
.oo 
CoverImageUrloo 
=oo 
stringoo %
.oo% &
IsNullOrWhiteSpaceoo& 8
(oo8 9
vmoo9 ;
.oo; <
CoverImageUrloo< I
)ooI J
||ooK M
	ConstantsooN W
.ooW X!
DefaultGameCoverImageooX m
.oom n
Containsoon v
(oov w
vmoow y
.ooy z
CoverImageUrl	ooz á
)
ooá à
?
ooâ ä
	Constants
ooã î
.
ooî ï#
DefaultGameCoverImage
ooï ™
:
oo´ ¨
UrlFormatter
oo≠ π
.
ooπ ∫
Image
oo∫ ø
(
ooø ¿
vm
oo¿ ¬
.
oo¬ √
UserId
oo√ …
,
oo…  
BlobType
ooÀ ”
.
oo” ‘
	GameCover
oo‘ ›
,
oo› ﬁ
vm
ooﬂ ·
.
oo· ‚
CoverImageUrl
oo‚ Ô
)
ooÔ 
;
oo Ò
vmqq 
.qq 
AuthorPictureqq 
=qq 
UrlFormatterqq +
.qq+ ,
ProfileImageqq, 8
(qq8 9
vmqq9 ;
.qq; <
UserIdqq< B
)qqB C
;qqC D
}rr 	
privatett 
voidtt 
SetAuthorDetailstt %
(tt% &
GameViewModeltt& 3
vmtt4 6
)tt6 7
{uu 	
ifvv 
(vv 
vmvv 
.vv 
Idvv 
==vv 
Guidvv 
.vv 
Emptyvv #
||vv$ &
vmvv' )
.vv) *
UserIdvv* 0
==vv1 3
Guidvv4 8
.vv8 9
Emptyvv9 >
||vv? A
vmvvB D
.vvD E
UserIdvvE K
==vvL N
CurrentUserIdvvO \
)vv\ ]
{ww 
vmxx 
.xx 
UserIdxx 
=xx 
CurrentUserIdxx )
;xx) *
ProfileViewModelyy  
profileyy! (
=yy) *
ProfileAppServiceyy+ <
.yy< =
GetByUserIdyy= H
(yyH I
CurrentUserIdyyI V
,yyV W
ProfileTypeyyX c
.yyc d
Personalyyd l
)yyl m
;yym n
if{{ 
({{ 
profile{{ 
!={{ 
null{{ #
){{# $
{|| 
vm}} 
.}} 

AuthorName}} !
=}}" #
profile}}$ +
.}}+ ,
Name}}, 0
;}}0 1
vm~~ 
.~~ 
AuthorPicture~~ $
=~~% &
profile~~' .
.~~. /
ProfileImageUrl~~/ >
;~~> ?
} 
}
ÄÄ 
}
ÅÅ 	
private
ÉÉ 
void
ÉÉ 
ClearImagesUrl
ÉÉ #
(
ÉÉ# $
GameViewModel
ÉÉ$ 1
vm
ÉÉ2 4
)
ÉÉ4 5
{
ÑÑ 	
vm
ÖÖ 
.
ÖÖ 
ThumbnailUrl
ÖÖ 
=
ÖÖ 
GetUrlLastPart
ÖÖ ,
(
ÖÖ, -
vm
ÖÖ- /
.
ÖÖ/ 0
ThumbnailUrl
ÖÖ0 <
)
ÖÖ< =
;
ÖÖ= >
vm
ÜÜ 
.
ÜÜ 
CoverImageUrl
ÜÜ 
=
ÜÜ 
GetUrlLastPart
ÜÜ -
(
ÜÜ- .
vm
ÜÜ. 0
.
ÜÜ0 1
CoverImageUrl
ÜÜ1 >
)
ÜÜ> ?
;
ÜÜ? @
}
áá 	
private
ââ 
static
ââ 
string
ââ 
GetUrlLastPart
ââ ,
(
ââ, -
string
ââ- 3
url
ââ4 7
)
ââ7 8
{
ää 	
if
ãã 
(
ãã 
string
ãã 
.
ãã  
IsNullOrWhiteSpace
ãã )
(
ãã) *
url
ãã* -
)
ãã- .
)
ãã. /
{
åå 
return
çç 
url
çç 
;
çç 
}
éé 
else
èè 
{
êê 
string
ëë 
[
ëë 
]
ëë 
split
ëë 
=
ëë  
url
ëë! $
.
ëë$ %
Split
ëë% *
(
ëë* +
$char
ëë+ .
)
ëë. /
;
ëë/ 0
return
íí 
split
íí 
[
íí 
split
íí "
.
íí" #
Length
íí# )
-
íí* +
$num
íí, -
]
íí- .
;
íí. /
}
ìì 
}
îî 	
}
ïï 
}ññ ¡Æ
fC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\HomeController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
public 

class 
HomeController 
:  ! 
SecureBaseController" 6
{ 
private 
readonly &
IFeaturedContentAppService 3
_service4 <
;< =
private 
readonly 
IHostingEnvironment ,

hostingEnv- 7
;7 8
public 
HomeController 
( &
IFeaturedContentAppService 8
service9 @
,@ A
IHostingEnvironmentB U

hostingEnvV `
)` a
:b c
based h
(h i
)i j
{ 	
_service 
= 
service 
; 
this 
. 

hostingEnv 
= 

hostingEnv (
;( )
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
CarouselViewModel   
featured   &
=  ' (
_service  ) 1
.  1 2
GetFeaturedNow  2 @
(  @ A
)  A B
;  B C
ViewBag!! 
.!! 
Carousel!! 
=!! 
featured!! '
;!!' (

Dictionary## 
<## 
string## 
,## 
string## %
>##% &
	genreDict##' 0
=##1 2
SetGenreTags##3 ?
(##? @
)##@ A
;##A B
ViewData%% 
[%% 
$str%% 
]%% 
=%%  
	genreDict%%! *
;%%* +
return'' 
View'' 
('' 
)'' 
;'' 
}(( 	
public** 
IActionResult** 
About** "
(**" #
)**# $
{++ 	
return,, 
View,, 
(,, 
),, 
;,, 
}-- 	
[// 	
Route//	 
(// 
$str// $
)//$ %
]//% &
public00 
IActionResult00 
Terms00 "
(00" #
)00# $
{11 	
return22 
View22 
(22 
)22 
;22 
}33 	
[55 	
Route55	 
(55 
$str55 
)55 
]55 
public66 
IActionResult66 
Privacy66 $
(66$ %
)66% &
{77 	
return88 
View88 
(88 
)88 
;88 
}99 	
public;; 
IActionResult;; 
Error;; "
(;;" #
);;# $
{<< 	
return== 
View== 
(== 
new== 
ErrorViewModel== *
{==+ ,
	RequestId==- 6
===7 8
Activity==9 A
.==A B
Current==B I
?==I J
.==J K
Id==K M
??==N P
HttpContext==Q \
.==\ ]
TraceIdentifier==] l
}==m n
)==n o
;==o p
}>> 	
public@@ 
IActionResult@@ 
Counters@@ %
(@@% &
)@@& '
{AA 	
returnBB 
ViewComponentBB  
(BB  !
$strBB! +
,BB+ ,
newBB- 0
{BB1 2
qtdBB3 6
=BB7 8
$numBB9 :
}BB; <
)BB< =
;BB= >
}CC 	
publicEE 
IActionResultEE 
NotificationsEE *
(EE* +
)EE+ ,
{FF 	
returnGG 
ViewComponentGG  
(GG  !
$strGG! /
,GG/ 0
newGG1 4
{GG5 6
qtdGG7 :
=GG; <
$numGG= >
}GG? @
)GG@ A
;GGA B
}HH 	
[JJ 	
RouteJJ	 
(JJ 
$strJJ 
)JJ 
]JJ 
publicKK 
IActionResultKK 
TimelineKK %
(KK% &
)KK& '
{LL 	
TimeLineViewModelMM 
modelMM #
=MM$ %
GenerateTimelineMM& 6
(MM6 7
)MM7 8
;MM8 9
returnOO 
ViewOO 
(OO 
modelOO 
)OO 
;OO 
}PP 	
privateRR 
staticRR 
TimeLineViewModelRR (
GenerateTimelineRR) 9
(RR9 :
)RR: ;
{SS 	
varTT 
	startDateTT 
=TT 
newTT 
DateTimeTT  (
(TT( )
$numTT) -
,TT- .
$numTT/ 1
,TT1 2
$numTT3 5
)TT5 6
;TT6 7
TimeLineViewModelUU 
modelUU #
=UU$ %
newUU& )
TimeLineViewModelUU* ;
(UU; <
)UU< =
;UU= >
modelWW 
.WW 
ItemsWW 
.WW 
AddWW 
(WW 
newWW !
TimeLineItemViewModelWW  5
{XX 
StartYY 
=YY 
trueYY 
,YY 
DateZZ 
=ZZ 
	startDateZZ  
,ZZ  !
Icon[[ 
=[[ 
$str[[ (
,[[( )
Title\\ 
=\\ 
$str\\ "
,\\" #
Subtitle]] 
=]] 
	startDate]] $
.]]$ %
ToShortDateString]]% 6
(]]6 7
)]]7 8
,]]8 9
Description^^ 
=^^ 
$str	^^ í
}__ 
)__ 
;__ 
modelaa 
.aa 
Itemsaa 
.aa 
Addaa 
(aa 
newaa !
TimeLineItemViewModelaa  5
{bb 
Datecc 
=cc 
newcc 
DateTimecc #
(cc# $
$numcc$ (
,cc( )
$numcc* ,
,cc, -
$numcc. 0
)cc0 1
,cc1 2
Icondd 
=dd 
$strdd $
,dd$ %
Coloree 
=ee 
$stree !
,ee! "
Titleff 
=ff 
$strff *
,ff* +
Subtitlegg 
=gg 
$strgg D
,ggD E
Descriptionhh 
=hh 
$strhh S
}ii 
)ii 
;ii 
modelkk 
.kk 
Itemskk 
.kk 
Addkk 
(kk 
newkk !
TimeLineItemViewModelkk  5
{ll 
Datemm 
=mm 
newmm 
DateTimemm #
(mm# $
$nummm$ (
,mm( )
$nummm* ,
,mm, -
$nummm. 0
)mm0 1
,mm1 2
Iconnn 
=nn 
$strnn %
,nn% &
Coloroo 
=oo 
$stroo !
,oo! "
Titlepp 
=pp 
$strpp (
,pp( )
Subtitleqq 
=qq 
$strqq 2
,qq2 3
Descriptionrr 
=rr 
$strrr m
,rrm n
Itemsss 
=ss 
{ss 
$strtt )
,tt) *
$struu "
,uu" #
$strvv 6
,vv6 7
$strww -
,ww- .
$strxx 
}yy 
}zz 
)zz 
;zz 
model|| 
.|| 
Items|| 
.|| 
Add|| 
(|| 
new|| !
TimeLineItemViewModel||  5
{}} 
Date~~ 
=~~ 
new~~ 
DateTime~~ #
(~~# $
$num~~$ (
,~~( )
$num~~* ,
,~~, -
$num~~. 0
)~~0 1
,~~1 2
Icon 
= 
$str *
,* +
Color
ÄÄ 
=
ÄÄ 
$str
ÄÄ 
,
ÄÄ 
Title
ÅÅ 
=
ÅÅ 
$str
ÅÅ &
,
ÅÅ& '
Subtitle
ÇÇ 
=
ÇÇ 
$str
ÇÇ +
,
ÇÇ+ ,
Description
ÉÉ 
=
ÉÉ 
$strÉÉ ó
}
ÑÑ 
)
ÑÑ 
;
ÑÑ 
model
ÜÜ 
.
ÜÜ 
Items
ÜÜ 
.
ÜÜ 
Add
ÜÜ 
(
ÜÜ 
new
ÜÜ #
TimeLineItemViewModel
ÜÜ  5
{
áá 
Date
àà 
=
àà 
new
àà 
DateTime
àà #
(
àà# $
$num
àà$ (
,
àà( )
$num
àà* ,
,
àà, -
$num
àà. 0
)
àà0 1
,
àà1 2
Color
ââ 
=
ââ 
$str
ââ  
,
ââ  !
Title
ää 
=
ää 
$str
ää '
,
ää' (
Subtitle
ãã 
=
ãã 
$str
ãã 1
,
ãã1 2
Description
åå 
=
åå 
$stråå õ
,ååõ ú
Items
çç 
=
çç 
{
çç 
$str
éé I
,
ééI J
$str
èè -
,
èè- .
$str
êê C
,
êêC D
$str
ëë *
,
ëë* +
$str
íí ;
,
íí; <
$str
ìì "
,
ìì" #
$str
îî C
,
îîC D
$str
ïï %
,
ïï% &
$str
ññ ,
,
ññ, -
$str
óó (
,
óó( )
$str
òò +
,
òò+ ,
$str
ôô {
,
ôô{ |
$str
öö 7
,
öö7 8
$str
õõ /
,
õõ/ 0
$str
úú 5
,
úú5 6
$str
ùù -
,
ùù- .
$str
ûû (
,
ûû( )
$str
üü $
,
üü$ %
$str
†† 5
}
°° 
}
¢¢ 
)
¢¢ 
;
¢¢ 
model
§§ 
.
§§ 
Items
§§ 
.
§§ 
Add
§§ 
(
§§ 
new
§§ #
TimeLineItemViewModel
§§  5
{
•• 
Date
¶¶ 
=
¶¶ 
new
¶¶ 
DateTime
¶¶ #
(
¶¶# $
$num
¶¶$ (
,
¶¶( )
$num
¶¶* ,
,
¶¶, -
$num
¶¶. 0
)
¶¶0 1
,
¶¶1 2
Color
ßß 
=
ßß 
$str
ßß !
,
ßß! "
Title
®® 
=
®® 
$str
®® '
,
®®' (
Subtitle
©© 
=
©© 
$str
©© /
,
©©/ 0
Description
™™ 
=
™™ 
$str
™™ b
,
™™b c
Items
´´ 
=
´´ 
{
´´ 
$str
¨¨ (
,
¨¨( )
$str
≠≠ (
,
≠≠( )
$str
ÆÆ +
,
ÆÆ+ ,
$str
ØØ $
,
ØØ$ %
$str
∞∞ *
,
∞∞* +
$str
±± &
,
±±& '
$str
≤≤ 5
}
≥≥ 
}
¥¥ 
)
¥¥ 
;
¥¥ 
model
∂∂ 
.
∂∂ 
Items
∂∂ 
.
∂∂ 
Add
∂∂ 
(
∂∂ 
new
∂∂ #
TimeLineItemViewModel
∂∂  5
{
∑∑ 
Date
∏∏ 
=
∏∏ 
new
∏∏ 
DateTime
∏∏ #
(
∏∏# $
$num
∏∏$ (
,
∏∏( )
$num
∏∏* ,
,
∏∏, -
$num
∏∏. 0
)
∏∏0 1
,
∏∏1 2
Icon
ππ 
=
ππ 
$str
ππ %
,
ππ% &
Color
∫∫ 
=
∫∫ 
$str
∫∫ !
,
∫∫! "
Title
ªª 
=
ªª 
$str
ªª &
,
ªª& '
Subtitle
ºº 
=
ºº 
$str
ºº 8
,
ºº8 9
Description
ΩΩ 
=
ΩΩ 
$str
ΩΩ U
,
ΩΩU V
Items
ææ 
=
ææ 
{
ææ 
$str
øø -
,
øø- .
$str
¿¿ R
,
¿¿R S
$str
¡¡ [
,
¡¡[ \
$str
¬¬ 8
,
¬¬8 9
$str
√√ F
,
√√F G
$str
ƒƒ )
,
ƒƒ) *
$str
≈≈ &
}
∆∆ 
}
«« 
)
«« 
;
«« 
model
…… 
.
…… 
Items
…… 
.
…… 
Add
…… 
(
…… 
new
…… #
TimeLineItemViewModel
……  5
{
   
Date
ÀÀ 
=
ÀÀ 
new
ÀÀ 
DateTime
ÀÀ #
(
ÀÀ# $
$num
ÀÀ$ (
,
ÀÀ( )
$num
ÀÀ* ,
,
ÀÀ, -
$num
ÀÀ. 0
)
ÀÀ0 1
,
ÀÀ1 2
Icon
ÃÃ 
=
ÃÃ 
$str
ÃÃ %
,
ÃÃ% &
Color
ÕÕ 
=
ÕÕ 
$str
ÕÕ !
,
ÕÕ! "
Title
ŒŒ 
=
ŒŒ 
$str
ŒŒ &
,
ŒŒ& '
Subtitle
œœ 
=
œœ 
$str
œœ (
,
œœ( )
Description
–– 
=
–– 
$str
–– =
,
––= >
Items
—— 
=
—— 
{
—— 
$str
““ -
,
““- .
$str
”” 0
,
””0 1
$str
‘‘ #
}
’’ 
}
÷÷ 
)
÷÷ 
;
÷÷ 
model
ÿÿ 
.
ÿÿ 
Items
ÿÿ 
.
ÿÿ 
Add
ÿÿ 
(
ÿÿ 
new
ÿÿ #
TimeLineItemViewModel
ÿÿ  5
{
ŸŸ 
Date
⁄⁄ 
=
⁄⁄ 
new
⁄⁄ 
DateTime
⁄⁄ #
(
⁄⁄# $
$num
⁄⁄$ (
,
⁄⁄( )
$num
⁄⁄* ,
,
⁄⁄, -
$num
⁄⁄. 0
)
⁄⁄0 1
,
⁄⁄1 2
Icon
€€ 
=
€€ 
$str
€€ (
,
€€( )
Color
‹‹ 
=
‹‹ 
$str
‹‹ !
,
‹‹! "
Title
›› 
=
›› 
$str
›› $
,
››$ %
Subtitle
ﬁﬁ 
=
ﬁﬁ 
$str
ﬁﬁ &
,
ﬁﬁ& '
Description
ﬂﬂ 
=
ﬂﬂ 
$str
ﬂﬂ A
,
ﬂﬂA B
Items
‡‡ 
=
‡‡ 
{
‡‡ 
$str
·· #
,
··# $
$str
‚‚ 2
,
‚‚2 3
$str
„„ &
,
„„& '
$str
‰‰ 9
}
ÂÂ 
}
ÊÊ 
)
ÊÊ 
;
ÊÊ 
model
ËË 
.
ËË 
Items
ËË 
.
ËË 
Add
ËË 
(
ËË 
new
ËË #
TimeLineItemViewModel
ËË  5
{
ÈÈ 
Date
ÍÍ 
=
ÍÍ 
new
ÍÍ 
DateTime
ÍÍ #
(
ÍÍ# $
$num
ÍÍ$ (
,
ÍÍ( )
$num
ÍÍ* ,
,
ÍÍ, -
$num
ÍÍ. 0
)
ÍÍ0 1
,
ÍÍ1 2
Icon
ÎÎ 
=
ÎÎ 
$str
ÎÎ '
,
ÎÎ' (
Color
ÏÏ 
=
ÏÏ 
$str
ÏÏ !
,
ÏÏ! "
Title
ÌÌ 
=
ÌÌ 
$str
ÌÌ $
,
ÌÌ$ %
Subtitle
ÓÓ 
=
ÓÓ 
$str
ÓÓ )
,
ÓÓ) *
Description
ÔÔ 
=
ÔÔ 
$str
ÔÔ G
,
ÔÔG H
Items
 
=
 
{
 
$str
ÒÒ 7
,
ÒÒ7 8
$str
ÚÚ )
,
ÚÚ) *
$str
ÛÛ 0
,
ÛÛ0 1
$str
ÙÙ 
}
ıı 
}
ˆˆ 
)
ˆˆ 
;
ˆˆ 
model
¯¯ 
.
¯¯ 
Items
¯¯ 
.
¯¯ 
Add
¯¯ 
(
¯¯ 
new
¯¯ #
TimeLineItemViewModel
¯¯  5
{
˘˘ 
Date
˙˙ 
=
˙˙ 
new
˙˙ 
DateTime
˙˙ #
(
˙˙# $
$num
˙˙$ (
,
˙˙( )
$num
˙˙* ,
,
˙˙, -
$num
˙˙. 0
)
˙˙0 1
,
˙˙1 2
Icon
˚˚ 
=
˚˚ 
$str
˚˚ &
,
˚˚& '
Color
¸¸ 
=
¸¸ 
$str
¸¸ !
,
¸¸! "
Title
˝˝ 
=
˝˝ 
$str
˝˝ "
,
˝˝" #
Subtitle
˛˛ 
=
˛˛ 
$str
˛˛ %
,
˛˛% &
Description
ˇˇ 
=
ˇˇ 
$str
ˇˇ I
,
ˇˇI J
Items
ÄÄ 
=
ÄÄ 
{
ÄÄ 
$str
ÅÅ $
,
ÅÅ$ %
$str
ÇÇ '
,
ÇÇ' (
$str
ÉÉ 
,
ÉÉ 
}
ÑÑ 
}
ÖÖ 
)
ÖÖ 
;
ÖÖ 
model
áá 
.
áá 
Items
áá 
.
áá 
Add
áá 
(
áá 
new
áá #
TimeLineItemViewModel
áá  5
{
àà 
Date
ââ 
=
ââ 
new
ââ 
DateTime
ââ #
(
ââ# $
$num
ââ$ (
,
ââ( )
$num
ââ* ,
,
ââ, -
$num
ââ. 0
)
ââ0 1
,
ââ1 2
Icon
ää 
=
ää 
$str
ää .
,
ää. /
Color
ãã 
=
ãã 
$str
ãã 
,
ãã 
Title
åå 
=
åå 
$str
åå #
,
åå# $
Subtitle
çç 
=
çç 
$str
çç /
,
çç/ 0
Description
éé 
=
éé 
$str
éé l
,
éél m
Items
èè 
=
èè 
{
èè 
$str
êê $
,
êê$ %
$str
ëë !
,
ëë! "
$str
íí !
,
íí! "
$str
ìì ,
}
îî 
}
ïï 
)
ïï 
;
ïï 
model
òò 
.
òò 
Items
òò 
.
òò 
Add
òò 
(
òò 
new
òò #
TimeLineItemViewModel
òò  5
{
ôô 
Date
öö 
=
öö 
new
öö 
DateTime
öö #
(
öö# $
$num
öö$ (
,
öö( )
$num
öö* ,
,
öö, -
$num
öö. 0
)
öö0 1
,
öö1 2
Icon
õõ 
=
õõ 
$str
õõ #
,
õõ# $
Color
úú 
=
úú 
$str
úú  
,
úú  !
Title
ùù 
=
ùù 
$str
ùù #
,
ùù# $
Subtitle
ûû 
=
ûû 
$str
ûû &
,
ûû& '
Description
üü 
=
üü 
$strüü £
}
†† 
)
†† 
;
†† 
model
££ 
.
££ 
Items
££ 
.
££ 
Add
££ 
(
££ 
new
££ #
TimeLineItemViewModel
££  5
{
§§ 
End
•• 
=
•• 
true
•• 
,
•• 
Date
¶¶ 
=
¶¶ 
new
¶¶ 
DateTime
¶¶ #
(
¶¶# $
$num
¶¶$ (
,
¶¶( )
$num
¶¶* ,
,
¶¶, -
$num
¶¶. 0
)
¶¶0 1
,
¶¶1 2
Icon
ßß 
=
ßß 
$str
ßß $
,
ßß$ %
Color
®® 
=
®® 
$str
®® !
,
®®! "
Title
©© 
=
©© 
$str
©© &
,
©©& '
Subtitle
™™ 
=
™™ 
$str
™™ (
,
™™( )
Description
´´ 
=
´´ 
$str
´´ w
}
¨¨ 
)
¨¨ 
;
¨¨ 
model
ÆÆ 
.
ÆÆ 
Items
ÆÆ 
=
ÆÆ 
model
ÆÆ 
.
ÆÆ  
Items
ÆÆ  %
.
ÆÆ% &
OrderBy
ÆÆ& -
(
ÆÆ- .
x
ÆÆ. /
=>
ÆÆ0 2
x
ÆÆ3 4
.
ÆÆ4 5
Date
ÆÆ5 9
)
ÆÆ9 :
.
ÆÆ: ;
ToList
ÆÆ; A
(
ÆÆA B
)
ÆÆB C
;
ÆÆC D
return
ØØ 
model
ØØ 
;
ØØ 
}
∞∞ 	
private
≥≥ 
static
≥≥ 

Dictionary
≥≥ !
<
≥≥! "
string
≥≥" (
,
≥≥( )
string
≥≥* 0
>
≥≥0 1
SetGenreTags
≥≥2 >
(
≥≥> ?
)
≥≥? @
{
¥¥ 	
List
µµ 
<
µµ 
KeyValuePair
µµ 
<
µµ 
string
µµ $
,
µµ$ %
string
µµ& ,
>
µµ, -
>
µµ- .
	genreDict
µµ/ 8
=
µµ9 :
new
µµ; >
List
µµ? C
<
µµC D
KeyValuePair
µµD P
<
µµP Q
string
µµQ W
,
µµW X
string
µµY _
>
µµ_ `
>
µµ` a
(
µµa b
)
µµb c
;
µµc d
IEnumerable
∑∑ 
<
∑∑ 
	GameGenre
∑∑ !
>
∑∑! "
genres
∑∑# )
=
∑∑* +
Enum
∑∑, 0
.
∑∑0 1
	GetValues
∑∑1 :
(
∑∑: ;
typeof
∑∑; A
(
∑∑A B
	GameGenre
∑∑B K
)
∑∑K L
)
∑∑L M
.
∑∑M N
Cast
∑∑N R
<
∑∑R S
	GameGenre
∑∑S \
>
∑∑\ ]
(
∑∑] ^
)
∑∑^ _
;
∑∑_ `
genres
ππ 
.
ππ 
ToList
ππ 
(
ππ 
)
ππ 
.
ππ 
ForEach
ππ #
(
ππ# $
x
ππ$ %
=>
ππ& (
{
∫∫ 
string
ªª 
uiClass
ªª 
=
ªª  
x
ªª! "
.
ªª" # 
GetAttributeOfType
ªª# 5
<
ªª5 6
UiInfoAttribute
ªª6 E
>
ªªE F
(
ªªF G
)
ªªG H
.
ªªH I
Class
ªªI N
;
ªªN O
	genreDict
ΩΩ 
.
ΩΩ 
Add
ΩΩ 
(
ΩΩ 
new
ΩΩ !
KeyValuePair
ΩΩ" .
<
ΩΩ. /
string
ΩΩ/ 5
,
ΩΩ5 6
string
ΩΩ7 =
>
ΩΩ= >
(
ΩΩ> ?
x
ΩΩ? @
.
ΩΩ@ A
ToString
ΩΩA I
(
ΩΩI J
)
ΩΩJ K
,
ΩΩK L
uiClass
ΩΩM T
)
ΩΩT U
)
ΩΩU V
;
ΩΩV W
}
ææ 
)
ææ 
;
ææ 
Random
¿¿ 
r
¿¿ 
=
¿¿ 
new
¿¿ 
Random
¿¿ !
(
¿¿! "
)
¿¿" #
;
¿¿# $

Dictionary
¬¬ 
<
¬¬ 
string
¬¬ 
,
¬¬ 
string
¬¬ %
>
¬¬% &
dict
¬¬' +
=
¬¬, -
	genreDict
¬¬. 7
.
¬¬7 8
OrderBy
¬¬8 ?
(
¬¬? @
x
¬¬@ A
=>
¬¬B D
r
¬¬E F
.
¬¬F G
Next
¬¬G K
(
¬¬K L
)
¬¬L M
)
¬¬M N
.
¬¬N O
ToDictionary
¬¬O [
(
¬¬[ \
x
¬¬\ ]
=>
¬¬^ `
x
¬¬a b
.
¬¬b c
Key
¬¬c f
,
¬¬f g
x
¬¬h i
=>
¬¬j l
x
¬¬m n
.
¬¬n o
Value
¬¬o t
)
¬¬t u
;
¬¬u v
return
ƒƒ 
dict
ƒƒ 
;
ƒƒ 
}
≈≈ 	
}
«« 
}»» ‰…
mC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\InteractionController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
[ 
Route 

(
 
$str 
) 
] 
public 

class !
InteractionController &
:' ( 
SecureBaseController) =
{ 
private 
readonly 
ILikeAppService (
likeAppService) 7
;7 8
private 
readonly 
IProfileAppService +
profileAppService, =
;= >
private 
readonly "
IUserContentAppService /!
userContentAppService0 E
;E F
private 
readonly 
IGameAppService (
gameAppService) 7
;7 8
private 
readonly )
IUserContentCommentAppService 6(
userContentCommentAppService7 S
;S T
private 
readonly !
IBrainstormAppService . 
brainstormAppService/ C
;C D
private 
readonly #
INotificationAppService 0"
notificationAppService1 G
;G H
private 
readonly 
IFollowAppService *
followAppService+ ;
;; <
private 
readonly %
IUserConnectionAppService 2$
userConnectionAppService3 K
;K L
public !
InteractionController $
($ %
ILikeAppService% 4
likeAppService5 C
, 
IProfileAppService  
profileAppService! 2
, "
IUserContentAppService $!
userContentAppService% :
, 
IGameAppService 
gameAppService ,
, )
IUserContentCommentAppService +(
userContentCommentAppService, H
, !
IBrainstormAppService # 
brainstormAppService$ 8
,   #
INotificationAppService   %"
notificationAppService  & <
,!! 
IFollowAppService!! 
followAppService!!  0
,"" %
IUserConnectionAppService"" '$
userConnectionAppService""( @
)""@ A
{## 	
this$$ 
.$$ 
likeAppService$$ 
=$$  !
likeAppService$$" 0
;$$0 1
this%% 
.%% 
profileAppService%% "
=%%# $
profileAppService%%% 6
;%%6 7
this&& 
.&& !
userContentAppService&& &
=&&' (!
userContentAppService&&) >
;&&> ?
this'' 
.'' 
gameAppService'' 
=''  !
gameAppService''" 0
;''0 1
this(( 
.(( (
userContentCommentAppService(( -
=((. /(
userContentCommentAppService((0 L
;((L M
this)) 
.))  
brainstormAppService)) %
=))& ' 
brainstormAppService))( <
;))< =
this** 
.** "
notificationAppService** '
=**( )"
notificationAppService*** @
;**@ A
this++ 
.++ 
followAppService++ !
=++" #
followAppService++$ 4
;++4 5
this,, 
.,, $
userConnectionAppService,, )
=,,* +$
userConnectionAppService,,, D
;,,D E
}-- 	
[00 	
HttpPost00	 
]00 
[22 	
Route22	 
(22 
$str22 
)22 
]22 
public33 
IActionResult33 
LikeContent33 (
(33( )
Guid33) -
targetId33. 6
)336 7
{44 	
likeAppService55 
.55 
CurrentUserId55 (
=55) *
this55+ /
.55/ 0
CurrentUserId550 =
;55= >
OperationResultVo66 
response66 &
=66' (
likeAppService66) 7
.667 8
ContentLike668 C
(66C D
targetId66D L
)66L M
;66M N"
notificationAppService88 "
.88" #
CurrentUserId88# 0
=881 2
this883 7
.887 8
CurrentUserId888 E
;88E F
OperationResultVo99 
<99  
UserContentViewModel99 2
>992 3
content994 ;
=99< =!
userContentAppService99> S
.99S T
GetById99T [
(99[ \
targetId99\ d
)99d e
;99e f
ProfileViewModel;; 
	myProfile;; &
=;;' (
profileAppService;;) :
.;;: ;
GetByUserId;;; F
(;;F G
this;;G K
.;;K L
CurrentUserId;;L Y
,;;Y Z
this;;[ _
.;;_ `
CurrentUserId;;` m
,;;m n
ProfileType;;o z
.;;z {
Personal	;;{ É
)
;;É Ñ
;
;;Ñ Ö
string== 
text== 
=== 
String==  
.==  !
Format==! '
(==' (
SharedLocalizer==( 7
[==7 8
$str==8 M
]==M N
,==N O
	myProfile==P Y
.==Y Z
Name==Z ^
)==^ _
;==_ `
string?? 
url?? 
=?? 
Url?? 
.?? 
Action?? #
(??# $
$str??$ -
,??- .
$str??/ 8
,??8 9
new??: =
{??> ?
id??@ B
=??C D
targetId??E M
}??N O
)??O P
;??P Q
OperationResultVoAA 
notificationResultAA 0
=AA1 2"
notificationAppServiceAA3 I
.AAI J
NotifyAAJ P
(AAP Q
contentAAQ X
.AAX Y
ValueAAY ^
.AA^ _
UserIdAA_ e
,AAe f
NotificationTypeAAg w
.AAw x
ContentLike	AAx É
,
AAÉ Ñ
targetId
AAÖ ç
,
AAç é
text
AAè ì
,
AAì î
url
AAï ò
)
AAò ô
;
AAô ö
returnCC 
JsonCC 
(CC 
responseCC  
)CC  !
;CC! "
}DD 	
[FF 	
HttpPostFF	 
]FF 
[GG 	
RouteGG	 
(GG 
$strGG 
)GG  
]GG  !
publicHH 
IActionResultHH 
UnLikeContentHH *
(HH* +
GuidHH+ /
likedIdHH0 7
)HH7 8
{II 	
likeAppServiceJJ 
.JJ 
CurrentUserIdJJ (
=JJ) *
thisJJ+ /
.JJ/ 0
CurrentUserIdJJ0 =
;JJ= >
OperationResultVoKK 
responseKK &
=KK' (
likeAppServiceKK) 7
.KK7 8
ContentUnlikeKK8 E
(KKE F
likedIdKKF M
)KKM N
;KKN O
returnMM 
JsonMM 
(MM 
responseMM  
)MM  !
;MM! "
}NN 	
[QQ 	
HttpPostQQ	 
]QQ 
[RR 	
RouteRR	 
(RR 
$strRR  
)RR  !
]RR! "
publicSS 
IActionResultSS 
CommentSS $
(SS$ %'
UserContentCommentViewModelSS% @
vmSSA C
)SSC D
{TT 	
OperationResultVoUU 
responseUU &
;UU& '
thisWW 
.WW 
SetAuthorDetailsWW !
(WW! "
vmWW" $
)WW$ %
;WW% &
switchYY 
(YY 
vmYY 
.YY 
UserContentTypeYY &
)YY& '
{ZZ 
case[[ 
UserContentType[[ $
.[[$ %
Post[[% )
:[[) *
response\\ 
=\\ (
userContentCommentAppService\\ ;
.\\; <
Comment\\< C
(\\C D
vm\\D F
)\\F G
;\\G H
break]] 
;]] 
case^^ 
UserContentType^^ $
.^^$ %

VotingItem^^% /
:^^/ 0
response__ 
=__  
brainstormAppService__ 3
.__3 4
Comment__4 ;
(__; <
vm__< >
)__> ?
;__? @
break`` 
;`` 
defaultaa 
:aa 
responsebb 
=bb (
userContentCommentAppServicebb ;
.bb; <
Commentbb< C
(bbC D
vmbbD F
)bbF G
;bbG H
breakcc 
;cc 
}dd 
returnff 
Jsonff 
(ff 
responseff  
)ff  !
;ff! "
}gg 	
[mm 	
HttpPostmm	 
]mm 
[nn 	
Routenn	 
(nn 
$strnn 
)nn 
]nn 
publicoo 
IActionResultoo 
LikeGameoo %
(oo% &
Guidoo& *
likedIdoo+ 2
)oo2 3
{pp 	
likeAppServiceqq 
.qq 
CurrentUserIdqq (
=qq) *
thisqq+ /
.qq/ 0
CurrentUserIdqq0 =
;qq= >
OperationResultVorr 
responserr &
=rr' (
likeAppServicerr) 7
.rr7 8
GameLikerr8 @
(rr@ A
likedIdrrA H
)rrH I
;rrI J
OperationResultVott 
<tt 
GameViewModeltt +
>tt+ ,

gameResulttt- 7
=tt8 9
gameAppServicett: H
.ttH I
GetByIdttI P
(ttP Q
likedIdttQ X
)ttX Y
;ttY Z
ProfileViewModelvv 
	myProfilevv &
=vv' (
profileAppServicevv) :
.vv: ;
GetByUserIdvv; F
(vvF G
thisvvG K
.vvK L
CurrentUserIdvvL Y
,vvY Z
ProfileTypevv[ f
.vvf g
Personalvvg o
)vvo p
;vvp q
stringxx 
textxx 
=xx 
Stringxx  
.xx  !
Formatxx! '
(xx' (
SharedLocalizerxx( 7
[xx7 8
$strxx8 R
]xxR S
,xxS T
	myProfilexxU ^
.xx^ _
Namexx_ c
,xxc d

gameResultxxe o
.xxo p
Valuexxp u
.xxu v
Titlexxv {
)xx{ |
;xx| }
stringzz 
urlzz 
=zz 
Urlzz 
.zz 
Actionzz #
(zz# $
$strzz$ -
,zz- .
$strzz/ 5
,zz5 6
newzz7 :
{zz; <
idzz= ?
=zz@ A
likedIdzzB I
}zzJ K
)zzK L
;zzL M
OperationResultVo|| 
notificationResult|| 0
=||1 2"
notificationAppService||3 I
.||I J
Notify||J P
(||P Q

gameResult||Q [
.||[ \
Value||\ a
.||a b
UserId||b h
,||h i
NotificationType||j z
.||z {
ContentLike	||{ Ü
,
||Ü á
likedId
||à è
,
||è ê
text
||ë ï
,
||ï ñ
url
||ó ö
)
||ö õ
;
||õ ú
return 
Json 
( 
response  
)  !
;! "
}
ÄÄ 	
[
ÇÇ 	
HttpPost
ÇÇ	 
]
ÇÇ 
[
ÉÉ 	
Route
ÉÉ	 
(
ÉÉ 
$str
ÉÉ 
)
ÉÉ 
]
ÉÉ 
public
ÑÑ 
IActionResult
ÑÑ 

UnLikeGame
ÑÑ '
(
ÑÑ' (
Guid
ÑÑ( ,
likedId
ÑÑ- 4
)
ÑÑ4 5
{
ÖÖ 	
likeAppService
ÜÜ 
.
ÜÜ 
CurrentUserId
ÜÜ (
=
ÜÜ) *
this
ÜÜ+ /
.
ÜÜ/ 0
CurrentUserId
ÜÜ0 =
;
ÜÜ= >
OperationResultVo
áá 
response
áá &
=
áá' (
likeAppService
áá) 7
.
áá7 8

GameUnlike
áá8 B
(
ááB C
likedId
ááC J
)
ááJ K
;
ááK L
return
ââ 
Json
ââ 
(
ââ 
response
ââ  
)
ââ  !
;
ââ! "
}
ää 	
[
êê 	
HttpPost
êê	 
]
êê 
[
ëë 	
Route
ëë	 
(
ëë 
$str
ëë 
)
ëë 
]
ëë 
public
íí 
IActionResult
íí 

FollowGame
íí '
(
íí' (
Guid
íí( ,
gameId
íí- 3
)
íí3 4
{
ìì 	
OperationResultVo
îî 
response
îî &
=
îî' (
followAppService
îî) 9
.
îî9 :

GameFollow
îî: D
(
îîD E
this
îîE I
.
îîI J
CurrentUserId
îîJ W
,
îîW X
gameId
îîY _
)
îî_ `
;
îî` a
OperationResultVo
ññ 
<
ññ 
GameViewModel
ññ +
>
ññ+ ,

gameResult
ññ- 7
=
ññ8 9
gameAppService
ññ: H
.
ññH I
GetById
ññI P
(
ññP Q
gameId
ññQ W
)
ññW X
;
ññX Y
ProfileViewModel
òò 
	myProfile
òò &
=
òò' (
profileAppService
òò) :
.
òò: ;
GetByUserId
òò; F
(
òòF G
this
òòG K
.
òòK L
CurrentUserId
òòL Y
,
òòY Z
ProfileType
òò[ f
.
òòf g
Personal
òòg o
)
òòo p
;
òòp q
string
öö 
text
öö 
=
öö 
String
öö  
.
öö  !
Format
öö! '
(
öö' (
SharedLocalizer
öö( 7
[
öö7 8
$str
öö8 ]
]
öö] ^
,
öö^ _
	myProfile
öö` i
.
ööi j
Name
ööj n
,
öön o

gameResult
ööp z
.
ööz {
Valueöö{ Ä
.ööÄ Å
TitleööÅ Ü
)ööÜ á
;ööá à
string
úú 
url
úú 
=
úú 
Url
úú 
.
úú 
Action
úú #
(
úú# $
$str
úú$ -
,
úú- .
$str
úú/ 8
,
úú8 9
new
úú: =
{
úú> ?
id
úú@ B
=
úúC D
this
úúE I
.
úúI J
CurrentUserId
úúJ W
}
úúX Y
)
úúY Z
;
úúZ [
OperationResultVo
ûû  
notificationResult
ûû 0
=
ûû1 2$
notificationAppService
ûû3 I
.
ûûI J
Notify
ûûJ P
(
ûûP Q

gameResult
ûûQ [
.
ûû[ \
Value
ûû\ a
.
ûûa b
UserId
ûûb h
,
ûûh i
NotificationType
ûûj z
.
ûûz {
ContentLikeûû{ Ü
,ûûÜ á
gameIdûûà é
,ûûé è
textûûê î
,ûûî ï
urlûûñ ô
)ûûô ö
;ûûö õ
return
°° 
Json
°° 
(
°° 
response
°°  
)
°°  !
;
°°! "
}
¢¢ 	
[
§§ 	
HttpPost
§§	 
]
§§ 
[
•• 	
Route
••	 
(
•• 
$str
•• 
)
•• 
]
••  
public
¶¶ 
IActionResult
¶¶ 
UnFollowGame
¶¶ )
(
¶¶) *
Guid
¶¶* .
gameId
¶¶/ 5
)
¶¶5 6
{
ßß 	
OperationResultVo
®® 
response
®® &
=
®®' (
followAppService
®®) 9
.
®®9 :
GameUnfollow
®®: F
(
®®F G
this
®®G K
.
®®K L
CurrentUserId
®®L Y
,
®®Y Z
gameId
®®[ a
)
®®a b
;
®®b c
return
™™ 
Json
™™ 
(
™™ 
response
™™  
)
™™  !
;
™™! "
}
´´ 	
[
±± 	
HttpPost
±±	 
]
±± 
[
≤≤ 	
Route
≤≤	 
(
≤≤ 
$str
≤≤ 
)
≤≤ 
]
≤≤ 
public
≥≥ 
IActionResult
≥≥ 

FollowUser
≥≥ '
(
≥≥' (
Guid
≥≥( ,
userId
≥≥- 3
)
≥≥3 4
{
¥¥ 	
OperationResultVo
µµ 
response
µµ &
=
µµ' (
followAppService
µµ) 9
.
µµ9 :

UserFollow
µµ: D
(
µµD E
this
µµE I
.
µµI J
CurrentUserId
µµJ W
,
µµW X
userId
µµY _
)
µµ_ `
;
µµ` a
ProfileViewModel
∑∑ 
	myProfile
∑∑ &
=
∑∑' (
profileAppService
∑∑) :
.
∑∑: ;
GetByUserId
∑∑; F
(
∑∑F G
this
∑∑G K
.
∑∑K L
CurrentUserId
∑∑L Y
,
∑∑Y Z
ProfileType
∑∑[ f
.
∑∑f g
Personal
∑∑g o
)
∑∑o p
;
∑∑p q
string
ππ 
text
ππ 
=
ππ 
String
ππ  
.
ππ  !
Format
ππ! '
(
ππ' (
SharedLocalizer
ππ( 7
[
ππ7 8
$str
ππ8 S
]
ππS T
,
ππT U
	myProfile
ππV _
.
ππ_ `
Name
ππ` d
)
ππd e
;
ππe f
string
ªª 
url
ªª 
=
ªª 
Url
ªª 
.
ªª 
Action
ªª #
(
ªª# $
$str
ªª$ -
,
ªª- .
$str
ªª/ 8
,
ªª8 9
new
ªª: =
{
ªª> ?
id
ªª@ B
=
ªªC D
this
ªªE I
.
ªªI J
CurrentUserId
ªªJ W
}
ªªX Y
)
ªªY Z
;
ªªZ [
OperationResultVo
ΩΩ  
notificationResult
ΩΩ 0
=
ΩΩ1 2$
notificationAppService
ΩΩ3 I
.
ΩΩI J
Notify
ΩΩJ P
(
ΩΩP Q
userId
ΩΩQ W
,
ΩΩW X
NotificationType
ΩΩY i
.
ΩΩi j
ContentLike
ΩΩj u
,
ΩΩu v
userId
ΩΩw }
,
ΩΩ} ~
textΩΩ É
,ΩΩÉ Ñ
urlΩΩÖ à
)ΩΩà â
;ΩΩâ ä
return
øø 
Json
øø 
(
øø 
response
øø  
)
øø  !
;
øø! "
}
¿¿ 	
[
¬¬ 	
HttpPost
¬¬	 
]
¬¬ 
[
√√ 	
Route
√√	 
(
√√ 
$str
√√ 
)
√√ 
]
√√  
public
ƒƒ 
IActionResult
ƒƒ 
UnFollowUser
ƒƒ )
(
ƒƒ) *
Guid
ƒƒ* .
userId
ƒƒ/ 5
)
ƒƒ5 6
{
≈≈ 	
OperationResultVo
∆∆ 
response
∆∆ &
=
∆∆' (
followAppService
∆∆) 9
.
∆∆9 :
UserUnfollow
∆∆: F
(
∆∆F G
this
∆∆G K
.
∆∆K L
CurrentUserId
∆∆L Y
,
∆∆Y Z
userId
∆∆[ a
)
∆∆a b
;
∆∆b c
return
»» 
Json
»» 
(
»» 
response
»»  
)
»»  !
;
»»! "
}
…… 	
[
œœ 	
HttpPost
œœ	 
]
œœ 
[
–– 	
Route
––	 
(
–– 
$str
–– 
)
–– 
]
–– 
public
—— 
IActionResult
—— 
ConnectToUser
—— *
(
——* +
Guid
——+ /
userId
——0 6
)
——6 7
{
““ 	
OperationResultVo
”” 
response
”” &
=
””' (&
userConnectionAppService
””) A
.
””A B
Connect
””B I
(
””I J
this
””J N
.
””N O
CurrentUserId
””O \
,
””\ ]
userId
””^ d
)
””d e
;
””e f
ProfileViewModel
’’ 
	myProfile
’’ &
=
’’' (
profileAppService
’’) :
.
’’: ;
GetByUserId
’’; F
(
’’F G
this
’’G K
.
’’K L
CurrentUserId
’’L Y
,
’’Y Z
ProfileType
’’[ f
.
’’f g
Personal
’’g o
)
’’o p
;
’’p q
string
◊◊ 
text
◊◊ 
=
◊◊ 
String
◊◊  
.
◊◊  !
Format
◊◊! '
(
◊◊' (
SharedLocalizer
◊◊( 7
[
◊◊7 8
$str
◊◊8 O
]
◊◊O P
,
◊◊P Q
	myProfile
◊◊R [
.
◊◊[ \
Name
◊◊\ `
)
◊◊` a
;
◊◊a b
string
ŸŸ 
url
ŸŸ 
=
ŸŸ 
Url
ŸŸ 
.
ŸŸ 
Action
ŸŸ #
(
ŸŸ# $
$str
ŸŸ$ -
,
ŸŸ- .
$str
ŸŸ/ 8
,
ŸŸ8 9
new
ŸŸ: =
{
ŸŸ> ?
id
ŸŸ@ B
=
ŸŸC D
this
ŸŸE I
.
ŸŸI J
CurrentUserId
ŸŸJ W
}
ŸŸX Y
)
ŸŸY Z
;
ŸŸZ [
OperationResultVo
€€  
notificationResult
€€ 0
=
€€1 2$
notificationAppService
€€3 I
.
€€I J
Notify
€€J P
(
€€P Q
userId
€€Q W
,
€€W X
NotificationType
€€Y i
.
€€i j
ConnectionRequest
€€j {
,
€€{ |
userId€€} É
,€€É Ñ
text€€Ö â
,€€â ä
url€€ã é
)€€é è
;€€è ê
TranslateResponse
›› 
(
›› 
response
›› &
)
››& '
;
››' (
return
ﬂﬂ 
Json
ﬂﬂ 
(
ﬂﬂ 
response
ﬂﬂ  
)
ﬂﬂ  !
;
ﬂﬂ! "
}
‡‡ 	
[
‚‚ 	
HttpPost
‚‚	 
]
‚‚ 
[
„„ 	
Route
„„	 
(
„„ 
$str
„„  
)
„„  !
]
„„! "
public
‰‰ 
IActionResult
‰‰ 
DisconnectUser
‰‰ +
(
‰‰+ ,
Guid
‰‰, 0
userId
‰‰1 7
)
‰‰7 8
{
ÂÂ 	
OperationResultVo
ÊÊ 
response
ÊÊ &
=
ÊÊ' (&
userConnectionAppService
ÊÊ) A
.
ÊÊA B

Disconnect
ÊÊB L
(
ÊÊL M
this
ÊÊM Q
.
ÊÊQ R
CurrentUserId
ÊÊR _
,
ÊÊ_ `
userId
ÊÊa g
)
ÊÊg h
;
ÊÊh i
TranslateResponse
ËË 
(
ËË 
response
ËË &
)
ËË& '
;
ËË' (
return
ÍÍ 
Json
ÍÍ 
(
ÍÍ 
response
ÍÍ  
)
ÍÍ  !
;
ÍÍ! "
}
ÎÎ 	
[
ÓÓ 	
Route
ÓÓ	 
(
ÓÓ 
$str
ÓÓ %
)
ÓÓ% &
]
ÓÓ& '
public
ÔÔ 
IActionResult
ÔÔ 
	AllowUser
ÔÔ &
(
ÔÔ& '
Guid
ÔÔ' +
userId
ÔÔ, 2
)
ÔÔ2 3
{
 	
OperationResultVo
ÒÒ 
response
ÒÒ &
=
ÒÒ' (&
userConnectionAppService
ÒÒ) A
.
ÒÒA B
Allow
ÒÒB G
(
ÒÒG H
this
ÒÒH L
.
ÒÒL M
CurrentUserId
ÒÒM Z
,
ÒÒZ [
userId
ÒÒ\ b
)
ÒÒb c
;
ÒÒc d
TranslateResponse
ÛÛ 
(
ÛÛ 
response
ÛÛ &
)
ÛÛ& '
;
ÛÛ' (
return
ıı 
Json
ıı 
(
ıı 
response
ıı  
)
ıı  !
;
ıı! "
}
ˆˆ 	
[
˜˜ 	
Route
˜˜	 
(
˜˜ 
$str
˜˜ $
)
˜˜$ %
]
˜˜% &
public
¯¯ 
IActionResult
¯¯ 
DenyUser
¯¯ %
(
¯¯% &
Guid
¯¯& *
userId
¯¯+ 1
)
¯¯1 2
{
˘˘ 	
OperationResultVo
˙˙ 
response
˙˙ &
=
˙˙' (&
userConnectionAppService
˙˙) A
.
˙˙A B
Deny
˙˙B F
(
˙˙F G
this
˙˙G K
.
˙˙K L
CurrentUserId
˙˙L Y
,
˙˙Y Z
userId
˙˙[ a
)
˙˙a b
;
˙˙b c
TranslateResponse
¸¸ 
(
¸¸ 
response
¸¸ &
)
¸¸& '
;
¸¸' (
return
˛˛ 
Json
˛˛ 
(
˛˛ 
response
˛˛  
)
˛˛  !
;
˛˛! "
}
ˇˇ 	
private
ÑÑ 
void
ÑÑ 
SetAuthorDetails
ÑÑ %
(
ÑÑ% &)
UserContentCommentViewModel
ÑÑ& A
	viewModel
ÑÑB K
)
ÑÑK L
{
ÖÖ 	
ProfileViewModel
ÜÜ 
profile
ÜÜ $
=
ÜÜ% &
ProfileAppService
ÜÜ' 8
.
ÜÜ8 9
GetByUserId
ÜÜ9 D
(
ÜÜD E
CurrentUserId
ÜÜE R
,
ÜÜR S
ProfileType
ÜÜT _
.
ÜÜ_ `
Personal
ÜÜ` h
)
ÜÜh i
;
ÜÜi j
if
àà 
(
àà 
profile
àà 
!=
àà 
null
àà 
)
àà  
{
ââ 
	viewModel
ää 
.
ää 

AuthorName
ää $
=
ää% &
profile
ää' .
.
ää. /
Name
ää/ 3
;
ää3 4
	viewModel
ãã 
.
ãã 
AuthorPicture
ãã '
=
ãã( )
profile
ãã* 1
.
ãã1 2
ProfileImageUrl
ãã2 A
;
ããA B
}
åå 
	viewModel
éé 
.
éé 
UserId
éé 
=
éé 
CurrentUserId
éé ,
;
éé, -
}
èè 	
private
ëë 
void
ëë 
TranslateResponse
ëë &
(
ëë& '
OperationResultVo
ëë' 8
response
ëë9 A
)
ëëA B
{
íí 	
if
ìì 
(
ìì 
response
ìì 
!=
ìì 
null
ìì  
&&
ìì! #
!
ìì$ %
String
ìì% +
.
ìì+ , 
IsNullOrWhiteSpace
ìì, >
(
ìì> ?
response
ìì? G
.
ììG H
Message
ììH O
)
ììO P
)
ììP Q
{
îî 
response
ïï 
.
ïï 
Message
ïï  
=
ïï! "
SharedLocalizer
ïï# 2
[
ïï2 3
response
ïï3 ;
.
ïï; <
Message
ïï< C
]
ïïC D
;
ïïD E
}
ññ 
}
óó 	
}
ôô 
}öö ˝±
hC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\ManageController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
[ 
	Authorize 
] 
[ 
Route 

(
 
$str "
)" #
]# $
public 

class 
ManageController !
:" # 
SecureBaseController$ 8
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
SignInManager &
<& '
ApplicationUser' 6
>6 7
_signInManager8 F
;F G
private 
readonly 
IEmailSender %
_emailSender& 2
;2 3
private 
readonly 
ILogger  
_logger! (
;( )
private 
readonly 

UrlEncoder #
_urlEncoder$ /
;/ 0
private 
const 
string "
AuthenticatorUriFormat 3
=4 5
$str6 m
;m n
private 
const 
string 
RecoveryCodesKey -
=. /
nameof0 6
(6 7
RecoveryCodesKey7 G
)G H
;H I
public!! 
ManageController!! 
(!!  
UserManager""
 
<"" 
ApplicationUser"" %
>""% &
userManager""' 2
,""2 3
SignInManager##
 
<## 
ApplicationUser## '
>##' (
signInManager##) 6
,##6 7
IEmailSender$$
 
emailSender$$ "
,$$" #
ILogger%%
 
<%% 
ManageController%% "
>%%" #
logger%%$ *
,%%* +

UrlEncoder&&
 

urlEncoder&& 
,&&  
IMapper''
 
mapper'' 
)'' 
:'' 
base''  
(''  !
)''! "
{(( 	
_userManager)) 
=)) 
userManager)) &
;))& '
_signInManager** 
=** 
signInManager** *
;*** +
_emailSender++ 
=++ 
emailSender++ &
;++& '
_logger,, 
=,, 
logger,, 
;,, 
_urlEncoder-- 
=-- 

urlEncoder-- $
;--$ %
}.. 	
[00 	
TempData00	 
]00 
public11 
string11 
StatusMessage11 #
{11$ %
get11& )
;11) *
set11+ .
;11. /
}110 1
[33 	
HttpGet33	 
]33 
public44 
async44 
Task44 
<44 
IActionResult44 '
>44' (
Index44) .
(44. /
)44/ 0
{55 	
ApplicationUser66 
user66  
=66! "
await66# (
_userManager66) 5
.665 6
GetUserAsync666 B
(66B C
User66C G
)66G H
;66H I
if77 
(77 
user77 
==77 
null77 
)77 
{88 
throw99 
new99  
ApplicationException99 .
(99. /
$"99/ 1)
Unable to load user with ID '991 N
{99N O
_userManager99O [
.99[ \
	GetUserId99\ e
(99e f
User99f j
)99j k
}99k l
'.99l n
"99n o
)99o p
;99p q
}:: 
IndexViewModel<< 
model<<  
=<<! "
new<<# &
IndexViewModel<<' 5
{== 
Username>> 
=>> 
user>> 
.>>  
UserName>>  (
,>>( )
Email?? 
=?? 
user?? 
.?? 
Email?? "
,??" #
PhoneNumber@@ 
=@@ 
user@@ "
.@@" #
PhoneNumber@@# .
,@@. /
IsEmailConfirmedAA  
=AA! "
userAA# '
.AA' (
EmailConfirmedAA( 6
,AA6 7
StatusMessageBB 
=BB 
StatusMessageBB  -
}CC 
;CC 
returnEE 
ViewEE 
(EE 
modelEE 
)EE 
;EE 
}FF 	
[HH 	
HttpPostHH	 
]HH 
[II 	$
ValidateAntiForgeryTokenII	 !
]II! "
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
IActionResultJJ '
>JJ' (
IndexJJ) .
(JJ. /
IndexViewModelJJ/ =
modelJJ> C
)JJC D
{KK 	
ifLL 
(LL 
!LL 

ModelStateLL 
.LL 
IsValidLL #
)LL# $
{MM 
returnNN 
ViewNN 
(NN 
modelNN !
)NN! "
;NN" #
}OO 
ApplicationUserQQ 
userQQ  
=QQ! "
awaitQQ# (
_userManagerQQ) 5
.QQ5 6
GetUserAsyncQQ6 B
(QQB C
UserQQC G
)QQG H
;QQH I
ifRR 
(RR 
userRR 
==RR 
nullRR 
)RR 
{SS 
throwTT 
newTT  
ApplicationExceptionTT .
(TT. /
$"TT/ 1)
Unable to load user with ID 'TT1 N
{TTN O
_userManagerTTO [
.TT[ \
	GetUserIdTT\ e
(TTe f
UserTTf j
)TTj k
}TTk l
'.TTl n
"TTn o
)TTo p
;TTp q
}UU 
stringWW 
emailWW 
=WW 
userWW 
.WW  
EmailWW  %
;WW% &
ifXX 
(XX 
modelXX 
.XX 
EmailXX 
!=XX 
emailXX $
)XX$ %
{YY 
IdentityResultZZ 
setEmailResultZZ -
=ZZ. /
awaitZZ0 5
_userManagerZZ6 B
.ZZB C
SetEmailAsyncZZC P
(ZZP Q
userZZQ U
,ZZU V
modelZZW \
.ZZ\ ]
EmailZZ] b
)ZZb c
;ZZc d
if[[ 
([[ 
![[ 
setEmailResult[[ #
.[[# $
	Succeeded[[$ -
)[[- .
{\\ 
throw]] 
new]]  
ApplicationException]] 2
(]]2 3
$"]]3 5F
:Unexpected error occurred setting email for user with ID ']]5 o
{]]o p
user]]p t
.]]t u
Id]]u w
}]]w x
'.]]x z
"]]z {
)]]{ |
;]]| }
}^^ 
}__ 
stringaa 
phoneNumberaa 
=aa  
useraa! %
.aa% &
PhoneNumberaa& 1
;aa1 2
ifbb 
(bb 
modelbb 
.bb 
PhoneNumberbb !
!=bb" $
phoneNumberbb% 0
)bb0 1
{cc 
IdentityResultdd 
setPhoneResultdd -
=dd. /
awaitdd0 5
_userManagerdd6 B
.ddB C
SetPhoneNumberAsyncddC V
(ddV W
userddW [
,dd[ \
modeldd] b
.ddb c
PhoneNumberddc n
)ddn o
;ddo p
ifee 
(ee 
!ee 
setPhoneResultee #
.ee# $
	Succeededee$ -
)ee- .
{ff 
throwgg 
newgg  
ApplicationExceptiongg 2
(gg2 3
$"gg3 5M
AUnexpected error occurred setting phone number for user with ID 'gg5 v
{ggv w
userggw {
.gg{ |
Idgg| ~
}gg~ 
'.	gg Å
"
ggÅ Ç
)
ggÇ É
;
ggÉ Ñ
}hh 
}ii 
StatusMessagekk 
=kk 
$strkk ;
;kk; <
returnll 
RedirectToActionll #
(ll# $
nameofll$ *
(ll* +
Indexll+ 0
)ll0 1
)ll1 2
;ll2 3
}mm 	
[oo 	
HttpPostoo	 
]oo 
[pp 	$
ValidateAntiForgeryTokenpp	 !
]pp! "
publicqq 
asyncqq 
Taskqq 
<qq 
IActionResultqq '
>qq' (!
SendVerificationEmailqq) >
(qq> ?
IndexViewModelqq? M
modelqqN S
)qqS T
{rr 	
ifss 
(ss 
!ss 

ModelStatess 
.ss 
IsValidss #
)ss# $
{tt 
returnuu 
Viewuu 
(uu 
modeluu !
)uu! "
;uu" #
}vv 
ApplicationUserxx 
userxx  
=xx! "
awaitxx# (
_userManagerxx) 5
.xx5 6
GetUserAsyncxx6 B
(xxB C
UserxxC G
)xxG H
;xxH I
ifyy 
(yy 
useryy 
==yy 
nullyy 
)yy 
{zz 
throw{{ 
new{{  
ApplicationException{{ .
({{. /
$"{{/ 1)
Unable to load user with ID '{{1 N
{{{N O
_userManager{{O [
.{{[ \
	GetUserId{{\ e
({{e f
User{{f j
){{j k
}{{k l
'.{{l n
"{{n o
){{o p
;{{p q
}|| 
string~~ 
code~~ 
=~~ 
await~~ 
_userManager~~  ,
.~~, -/
#GenerateEmailConfirmationTokenAsync~~- P
(~~P Q
user~~Q U
)~~U V
;~~V W
string 
callbackUrl 
=  
Url! $
.$ %!
EmailConfirmationLink% :
(: ;
user; ?
.? @
Id@ B
,B C
codeD H
,H I
RequestJ Q
.Q R
SchemeR X
)X Y
;Y Z
string
ÄÄ 
email
ÄÄ 
=
ÄÄ 
user
ÄÄ 
.
ÄÄ  
Email
ÄÄ  %
;
ÄÄ% &
await
ÅÅ 
_emailSender
ÅÅ 
.
ÅÅ (
SendEmailConfirmationAsync
ÅÅ 9
(
ÅÅ9 :
email
ÅÅ: ?
,
ÅÅ? @
callbackUrl
ÅÅA L
)
ÅÅL M
;
ÅÅM N
StatusMessage
ÉÉ 
=
ÉÉ 
$str
ÉÉ O
;
ÉÉO P
return
ÑÑ 
RedirectToAction
ÑÑ #
(
ÑÑ# $
nameof
ÑÑ$ *
(
ÑÑ* +
Index
ÑÑ+ 0
)
ÑÑ0 1
)
ÑÑ1 2
;
ÑÑ2 3
}
ÖÖ 	
[
áá 	
HttpGet
áá	 
]
áá 
public
àà 
async
àà 
Task
àà 
<
àà 
IActionResult
àà '
>
àà' (
ChangePassword
àà) 7
(
àà7 8
)
àà8 9
{
ââ 	
ApplicationUser
ää 
user
ää  
=
ää! "
await
ää# (
_userManager
ää) 5
.
ää5 6
GetUserAsync
ää6 B
(
ääB C
User
ääC G
)
ääG H
;
ääH I
if
ãã 
(
ãã 
user
ãã 
==
ãã 
null
ãã 
)
ãã 
{
åå 
throw
çç 
new
çç "
ApplicationException
çç .
(
çç. /
$"
çç/ 1+
Unable to load user with ID '
çç1 N
{
ççN O
_userManager
ççO [
.
çç[ \
	GetUserId
çç\ e
(
ççe f
User
ççf j
)
ççj k
}
ççk l
'.
ççl n
"
ççn o
)
çço p
;
ççp q
}
éé 
bool
êê 
hasPassword
êê 
=
êê 
await
êê $
_userManager
êê% 1
.
êê1 2
HasPasswordAsync
êê2 B
(
êêB C
user
êêC G
)
êêG H
;
êêH I
if
ëë 
(
ëë 
!
ëë 
hasPassword
ëë 
)
ëë 
{
íí 
return
ìì 
RedirectToAction
ìì '
(
ìì' (
nameof
ìì( .
(
ìì. /
SetPassword
ìì/ :
)
ìì: ;
)
ìì; <
;
ìì< =
}
îî %
ChangePasswordViewModel
ññ #
model
ññ$ )
=
ññ* +
new
ññ, /%
ChangePasswordViewModel
ññ0 G
{
ññH I
StatusMessage
ññJ W
=
ññX Y
StatusMessage
ññZ g
}
ññh i
;
ññi j
return
óó 
View
óó 
(
óó 
model
óó 
)
óó 
;
óó 
}
òò 	
[
öö 	
HttpPost
öö	 
]
öö 
[
õõ 	&
ValidateAntiForgeryToken
õõ	 !
]
õõ! "
public
úú 
async
úú 
Task
úú 
<
úú 
IActionResult
úú '
>
úú' (
ChangePassword
úú) 7
(
úú7 8%
ChangePasswordViewModel
úú8 O
model
úúP U
)
úúU V
{
ùù 	
if
ûû 
(
ûû 
!
ûû 

ModelState
ûû 
.
ûû 
IsValid
ûû #
)
ûû# $
{
üü 
return
†† 
View
†† 
(
†† 
model
†† !
)
††! "
;
††" #
}
°° 
ApplicationUser
££ 
user
££  
=
££! "
await
££# (
_userManager
££) 5
.
££5 6
GetUserAsync
££6 B
(
££B C
User
££C G
)
££G H
;
££H I
if
§§ 
(
§§ 
user
§§ 
==
§§ 
null
§§ 
)
§§ 
{
•• 
throw
¶¶ 
new
¶¶ "
ApplicationException
¶¶ .
(
¶¶. /
$"
¶¶/ 1+
Unable to load user with ID '
¶¶1 N
{
¶¶N O
_userManager
¶¶O [
.
¶¶[ \
	GetUserId
¶¶\ e
(
¶¶e f
User
¶¶f j
)
¶¶j k
}
¶¶k l
'.
¶¶l n
"
¶¶n o
)
¶¶o p
;
¶¶p q
}
ßß 
IdentityResult
©© "
changePasswordResult
©© /
=
©©0 1
await
©©2 7
_userManager
©©8 D
.
©©D E!
ChangePasswordAsync
©©E X
(
©©X Y
user
©©Y ]
,
©©] ^
model
©©_ d
.
©©d e
OldPassword
©©e p
,
©©p q
model
©©r w
.
©©w x
NewPassword©©x É
)©©É Ñ
;©©Ñ Ö
if
™™ 
(
™™ 
!
™™ "
changePasswordResult
™™ %
.
™™% &
	Succeeded
™™& /
)
™™/ 0
{
´´ 
	AddErrors
¨¨ 
(
¨¨ "
changePasswordResult
¨¨ .
)
¨¨. /
;
¨¨/ 0
return
≠≠ 
View
≠≠ 
(
≠≠ 
model
≠≠ !
)
≠≠! "
;
≠≠" #
}
ÆÆ 
await
∞∞ 
_signInManager
∞∞  
.
∞∞  !
SignInAsync
∞∞! ,
(
∞∞, -
user
∞∞- 1
,
∞∞1 2
isPersistent
∞∞3 ?
:
∞∞? @
false
∞∞A F
)
∞∞F G
;
∞∞G H
_logger
±± 
.
±± 
LogInformation
±± "
(
±±" #
$str
±±# N
)
±±N O
;
±±O P
StatusMessage
≤≤ 
=
≤≤ 
$str
≤≤ =
;
≤≤= >
return
¥¥ 
RedirectToAction
¥¥ #
(
¥¥# $
nameof
¥¥$ *
(
¥¥* +
ChangePassword
¥¥+ 9
)
¥¥9 :
)
¥¥: ;
;
¥¥; <
}
µµ 	
[
∑∑ 	
HttpGet
∑∑	 
]
∑∑ 
public
∏∏ 
async
∏∏ 
Task
∏∏ 
<
∏∏ 
IActionResult
∏∏ '
>
∏∏' (
SetPassword
∏∏) 4
(
∏∏4 5
)
∏∏5 6
{
ππ 	
ApplicationUser
∫∫ 
user
∫∫  
=
∫∫! "
await
∫∫# (
_userManager
∫∫) 5
.
∫∫5 6
GetUserAsync
∫∫6 B
(
∫∫B C
User
∫∫C G
)
∫∫G H
;
∫∫H I
if
ªª 
(
ªª 
user
ªª 
==
ªª 
null
ªª 
)
ªª 
{
ºº 
throw
ΩΩ 
new
ΩΩ "
ApplicationException
ΩΩ .
(
ΩΩ. /
$"
ΩΩ/ 1+
Unable to load user with ID '
ΩΩ1 N
{
ΩΩN O
_userManager
ΩΩO [
.
ΩΩ[ \
	GetUserId
ΩΩ\ e
(
ΩΩe f
User
ΩΩf j
)
ΩΩj k
}
ΩΩk l
'.
ΩΩl n
"
ΩΩn o
)
ΩΩo p
;
ΩΩp q
}
ææ 
bool
¿¿ 
hasPassword
¿¿ 
=
¿¿ 
await
¿¿ $
_userManager
¿¿% 1
.
¿¿1 2
HasPasswordAsync
¿¿2 B
(
¿¿B C
user
¿¿C G
)
¿¿G H
;
¿¿H I
if
¬¬ 
(
¬¬ 
hasPassword
¬¬ 
)
¬¬ 
{
√√ 
return
ƒƒ 
RedirectToAction
ƒƒ '
(
ƒƒ' (
nameof
ƒƒ( .
(
ƒƒ. /
ChangePassword
ƒƒ/ =
)
ƒƒ= >
)
ƒƒ> ?
;
ƒƒ? @
}
≈≈ "
SetPasswordViewModel
««  
model
««! &
=
««' (
new
««) ,"
SetPasswordViewModel
««- A
{
««B C
StatusMessage
««D Q
=
««R S
StatusMessage
««T a
}
««b c
;
««c d
return
»» 
View
»» 
(
»» 
model
»» 
)
»» 
;
»» 
}
…… 	
[
ÀÀ 	
HttpPost
ÀÀ	 
]
ÀÀ 
[
ÃÃ 	&
ValidateAntiForgeryToken
ÃÃ	 !
]
ÃÃ! "
public
ÕÕ 
async
ÕÕ 
Task
ÕÕ 
<
ÕÕ 
IActionResult
ÕÕ '
>
ÕÕ' (
SetPassword
ÕÕ) 4
(
ÕÕ4 5"
SetPasswordViewModel
ÕÕ5 I
model
ÕÕJ O
)
ÕÕO P
{
ŒŒ 	
if
œœ 
(
œœ 
!
œœ 

ModelState
œœ 
.
œœ 
IsValid
œœ #
)
œœ# $
{
–– 
return
—— 
View
—— 
(
—— 
model
—— !
)
——! "
;
——" #
}
““ 
ApplicationUser
‘‘ 
user
‘‘  
=
‘‘! "
await
‘‘# (
_userManager
‘‘) 5
.
‘‘5 6
GetUserAsync
‘‘6 B
(
‘‘B C
User
‘‘C G
)
‘‘G H
;
‘‘H I
if
’’ 
(
’’ 
user
’’ 
==
’’ 
null
’’ 
)
’’ 
{
÷÷ 
throw
◊◊ 
new
◊◊ "
ApplicationException
◊◊ .
(
◊◊. /
$"
◊◊/ 1+
Unable to load user with ID '
◊◊1 N
{
◊◊N O
_userManager
◊◊O [
.
◊◊[ \
	GetUserId
◊◊\ e
(
◊◊e f
User
◊◊f j
)
◊◊j k
}
◊◊k l
'.
◊◊l n
"
◊◊n o
)
◊◊o p
;
◊◊p q
}
ÿÿ 
IdentityResult
⁄⁄ 
addPasswordResult
⁄⁄ ,
=
⁄⁄- .
await
⁄⁄/ 4
_userManager
⁄⁄5 A
.
⁄⁄A B
AddPasswordAsync
⁄⁄B R
(
⁄⁄R S
user
⁄⁄S W
,
⁄⁄W X
model
⁄⁄Y ^
.
⁄⁄^ _
NewPassword
⁄⁄_ j
)
⁄⁄j k
;
⁄⁄k l
if
€€ 
(
€€ 
!
€€ 
addPasswordResult
€€ "
.
€€" #
	Succeeded
€€# ,
)
€€, -
{
‹‹ 
	AddErrors
›› 
(
›› 
addPasswordResult
›› +
)
››+ ,
;
››, -
return
ﬁﬁ 
View
ﬁﬁ 
(
ﬁﬁ 
model
ﬁﬁ !
)
ﬁﬁ! "
;
ﬁﬁ" #
}
ﬂﬂ 
await
·· 
_signInManager
··  
.
··  !
SignInAsync
··! ,
(
··, -
user
··- 1
,
··1 2
isPersistent
··3 ?
:
··? @
false
··A F
)
··F G
;
··G H
StatusMessage
‚‚ 
=
‚‚ 
$str
‚‚ 9
;
‚‚9 :
return
‰‰ 
RedirectToAction
‰‰ #
(
‰‰# $
nameof
‰‰$ *
(
‰‰* +
SetPassword
‰‰+ 6
)
‰‰6 7
)
‰‰7 8
;
‰‰8 9
}
ÂÂ 	
[
ÁÁ 	
HttpGet
ÁÁ	 
]
ÁÁ 
public
ËË 
async
ËË 
Task
ËË 
<
ËË 
IActionResult
ËË '
>
ËË' (
ExternalLogins
ËË) 7
(
ËË7 8
)
ËË8 9
{
ÈÈ 	
ApplicationUser
ÍÍ 
user
ÍÍ  
=
ÍÍ! "
await
ÍÍ# (
_userManager
ÍÍ) 5
.
ÍÍ5 6
GetUserAsync
ÍÍ6 B
(
ÍÍB C
User
ÍÍC G
)
ÍÍG H
;
ÍÍH I
if
ÎÎ 
(
ÎÎ 
user
ÎÎ 
==
ÎÎ 
null
ÎÎ 
)
ÎÎ 
{
ÏÏ 
throw
ÌÌ 
new
ÌÌ "
ApplicationException
ÌÌ .
(
ÌÌ. /
$"
ÌÌ/ 1+
Unable to load user with ID '
ÌÌ1 N
{
ÌÌN O
_userManager
ÌÌO [
.
ÌÌ[ \
	GetUserId
ÌÌ\ e
(
ÌÌe f
User
ÌÌf j
)
ÌÌj k
}
ÌÌk l
'.
ÌÌl n
"
ÌÌn o
)
ÌÌo p
;
ÌÌp q
}
ÓÓ %
ExternalLoginsViewModel
 #
model
$ )
=
* +
new
, /%
ExternalLoginsViewModel
0 G
{
H I
CurrentLogins
J W
=
X Y
await
Z _
_userManager
` l
.
l m
GetLoginsAsync
m {
(
{ |
user| Ä
)Ä Å
}Ç É
;É Ñ
model
ÒÒ 
.
ÒÒ 
OtherLogins
ÒÒ 
=
ÒÒ 
(
ÒÒ  !
await
ÒÒ! &
_signInManager
ÒÒ' 5
.
ÒÒ5 63
%GetExternalAuthenticationSchemesAsync
ÒÒ6 [
(
ÒÒ[ \
)
ÒÒ\ ]
)
ÒÒ] ^
.
ÚÚ 
Where
ÚÚ 
(
ÚÚ 
auth
ÚÚ 
=>
ÚÚ 
model
ÚÚ $
.
ÚÚ$ %
CurrentLogins
ÚÚ% 2
.
ÚÚ2 3
All
ÚÚ3 6
(
ÚÚ6 7
ul
ÚÚ7 9
=>
ÚÚ: <
auth
ÚÚ= A
.
ÚÚA B
Name
ÚÚB F
!=
ÚÚG I
ul
ÚÚJ L
.
ÚÚL M
LoginProvider
ÚÚM Z
)
ÚÚZ [
)
ÚÚ[ \
.
ÛÛ 
ToList
ÛÛ 
(
ÛÛ 
)
ÛÛ 
;
ÛÛ 
model
ÙÙ 
.
ÙÙ 
ShowRemoveButton
ÙÙ "
=
ÙÙ# $
await
ÙÙ% *
_userManager
ÙÙ+ 7
.
ÙÙ7 8
HasPasswordAsync
ÙÙ8 H
(
ÙÙH I
user
ÙÙI M
)
ÙÙM N
||
ÙÙO Q
model
ÙÙR W
.
ÙÙW X
CurrentLogins
ÙÙX e
.
ÙÙe f
Count
ÙÙf k
>
ÙÙl m
$num
ÙÙn o
;
ÙÙo p
model
ıı 
.
ıı 
StatusMessage
ıı 
=
ıı  !
StatusMessage
ıı" /
;
ıı/ 0
return
˜˜ 
View
˜˜ 
(
˜˜ 
model
˜˜ 
)
˜˜ 
;
˜˜ 
}
¯¯ 	
[
˙˙ 	
HttpPost
˙˙	 
]
˙˙ 
[
˚˚ 	&
ValidateAntiForgeryToken
˚˚	 !
]
˚˚! "
public
¸¸ 
async
¸¸ 
Task
¸¸ 
<
¸¸ 
IActionResult
¸¸ '
>
¸¸' (
	LinkLogin
¸¸) 2
(
¸¸2 3
string
¸¸3 9
provider
¸¸: B
)
¸¸B C
{
˝˝ 	
await
ˇˇ 
HttpContext
ˇˇ 
.
ˇˇ 
SignOutAsync
ˇˇ *
(
ˇˇ* +
IdentityConstants
ˇˇ+ <
.
ˇˇ< =
ExternalScheme
ˇˇ= K
)
ˇˇK L
;
ˇˇL M
string
ÇÇ 
redirectUrl
ÇÇ 
=
ÇÇ  
Url
ÇÇ! $
.
ÇÇ$ %
Action
ÇÇ% +
(
ÇÇ+ ,
nameof
ÇÇ, 2
(
ÇÇ2 3
LinkLoginCallback
ÇÇ3 D
)
ÇÇD E
)
ÇÇE F
;
ÇÇF G&
AuthenticationProperties
ÉÉ $

properties
ÉÉ% /
=
ÉÉ0 1
_signInManager
ÉÉ2 @
.
ÉÉ@ A7
)ConfigureExternalAuthenticationProperties
ÉÉA j
(
ÉÉj k
provider
ÉÉk s
,
ÉÉs t
redirectUrlÉÉu Ä
,ÉÉÄ Å
_userManagerÉÉÇ é
.ÉÉé è
	GetUserIdÉÉè ò
(ÉÉò ô
UserÉÉô ù
)ÉÉù û
)ÉÉû ü
;ÉÉü †
return
ÑÑ 
new
ÑÑ 
ChallengeResult
ÑÑ &
(
ÑÑ& '
provider
ÑÑ' /
,
ÑÑ/ 0

properties
ÑÑ1 ;
)
ÑÑ; <
;
ÑÑ< =
}
ÖÖ 	
[
áá 	
HttpGet
áá	 
]
áá 
public
àà 
async
àà 
Task
àà 
<
àà 
IActionResult
àà '
>
àà' (
LinkLoginCallback
àà) :
(
àà: ;
)
àà; <
{
ââ 	
ApplicationUser
ää 
user
ää  
=
ää! "
await
ää# (
_userManager
ää) 5
.
ää5 6
GetUserAsync
ää6 B
(
ääB C
User
ääC G
)
ääG H
;
ääH I
if
ãã 
(
ãã 
user
ãã 
==
ãã 
null
ãã 
)
ãã 
{
åå 
throw
çç 
new
çç "
ApplicationException
çç .
(
çç. /
$"
çç/ 1+
Unable to load user with ID '
çç1 N
{
ççN O
_userManager
ççO [
.
çç[ \
	GetUserId
çç\ e
(
ççe f
User
ççf j
)
ççj k
}
ççk l
'.
ççl n
"
ççn o
)
çço p
;
ççp q
}
éé 
ExternalLoginInfo
êê 
info
êê "
=
êê# $
await
êê% *
_signInManager
êê+ 9
.
êê9 :'
GetExternalLoginInfoAsync
êê: S
(
êêS T
user
êêT X
.
êêX Y
Id
êêY [
)
êê[ \
;
êê\ ]
if
ëë 
(
ëë 
info
ëë 
==
ëë 
null
ëë 
)
ëë 
{
íí 
throw
ìì 
new
ìì "
ApplicationException
ìì .
(
ìì. /
$"
ìì/ 1V
HUnexpected error occurred loading external login info for user with ID '
ìì1 y
{
ììy z
user
ììz ~
.
ìì~ 
Idìì Å
}ììÅ Ç
'.ììÇ Ñ
"ììÑ Ö
)ììÖ Ü
;ììÜ á
}
îî 
IdentityResult
ññ 
result
ññ !
=
ññ" #
await
ññ$ )
_userManager
ññ* 6
.
ññ6 7
AddLoginAsync
ññ7 D
(
ññD E
user
ññE I
,
ññI J
info
ññK O
)
ññO P
;
ññP Q
if
óó 
(
óó 
!
óó 
result
óó 
.
óó 
	Succeeded
óó !
)
óó! "
{
òò 
throw
ôô 
new
ôô "
ApplicationException
ôô .
(
ôô. /
$"
ôô/ 1P
BUnexpected error occurred adding external login for user with ID '
ôô1 s
{
ôôs t
user
ôôt x
.
ôôx y
Id
ôôy {
}
ôô{ |
'.
ôô| ~
"
ôô~ 
)ôô Ä
;ôôÄ Å
}
öö 
await
ùù 
HttpContext
ùù 
.
ùù 
SignOutAsync
ùù *
(
ùù* +
IdentityConstants
ùù+ <
.
ùù< =
ExternalScheme
ùù= K
)
ùùK L
;
ùùL M
StatusMessage
üü 
=
üü 
$str
üü ;
;
üü; <
return
†† 
RedirectToAction
†† #
(
††# $
nameof
††$ *
(
††* +
ExternalLogins
††+ 9
)
††9 :
)
††: ;
;
††; <
}
°° 	
[
££ 	
HttpPost
££	 
]
££ 
[
§§ 	&
ValidateAntiForgeryToken
§§	 !
]
§§! "
public
•• 
async
•• 
Task
•• 
<
•• 
IActionResult
•• '
>
••' (
RemoveLogin
••) 4
(
••4 5"
RemoveLoginViewModel
••5 I
model
••J O
)
••O P
{
¶¶ 	
ApplicationUser
ßß 
user
ßß  
=
ßß! "
await
ßß# (
_userManager
ßß) 5
.
ßß5 6
GetUserAsync
ßß6 B
(
ßßB C
User
ßßC G
)
ßßG H
;
ßßH I
if
®® 
(
®® 
user
®® 
==
®® 
null
®® 
)
®® 
{
©© 
throw
™™ 
new
™™ "
ApplicationException
™™ .
(
™™. /
$"
™™/ 1+
Unable to load user with ID '
™™1 N
{
™™N O
_userManager
™™O [
.
™™[ \
	GetUserId
™™\ e
(
™™e f
User
™™f j
)
™™j k
}
™™k l
'.
™™l n
"
™™n o
)
™™o p
;
™™p q
}
´´ 
IdentityResult
≠≠ 
result
≠≠ !
=
≠≠" #
await
≠≠$ )
_userManager
≠≠* 6
.
≠≠6 7
RemoveLoginAsync
≠≠7 G
(
≠≠G H
user
≠≠H L
,
≠≠L M
model
≠≠N S
.
≠≠S T
LoginProvider
≠≠T a
,
≠≠a b
model
≠≠c h
.
≠≠h i
ProviderKey
≠≠i t
)
≠≠t u
;
≠≠u v
if
ÆÆ 
(
ÆÆ 
!
ÆÆ 
result
ÆÆ 
.
ÆÆ 
	Succeeded
ÆÆ !
)
ÆÆ! "
{
ØØ 
throw
∞∞ 
new
∞∞ "
ApplicationException
∞∞ .
(
∞∞. /
$"
∞∞/ 1R
DUnexpected error occurred removing external login for user with ID '
∞∞1 u
{
∞∞u v
user
∞∞v z
.
∞∞z {
Id
∞∞{ }
}
∞∞} ~
'.∞∞~ Ä
"∞∞Ä Å
)∞∞Å Ç
;∞∞Ç É
}
±± 
await
≥≥ 
_signInManager
≥≥  
.
≥≥  !
SignInAsync
≥≥! ,
(
≥≥, -
user
≥≥- 1
,
≥≥1 2
isPersistent
≥≥3 ?
:
≥≥? @
false
≥≥A F
)
≥≥F G
;
≥≥G H
StatusMessage
¥¥ 
=
¥¥ 
$str
¥¥ =
;
¥¥= >
return
µµ 
RedirectToAction
µµ #
(
µµ# $
nameof
µµ$ *
(
µµ* +
ExternalLogins
µµ+ 9
)
µµ9 :
)
µµ: ;
;
µµ; <
}
∂∂ 	
[
∏∏ 	
HttpGet
∏∏	 
]
∏∏ 
public
ππ 
async
ππ 
Task
ππ 
<
ππ 
IActionResult
ππ '
>
ππ' (%
TwoFactorAuthentication
ππ) @
(
ππ@ A
)
ππA B
{
∫∫ 	
ApplicationUser
ªª 
user
ªª  
=
ªª! "
await
ªª# (
_userManager
ªª) 5
.
ªª5 6
GetUserAsync
ªª6 B
(
ªªB C
User
ªªC G
)
ªªG H
;
ªªH I
if
ºº 
(
ºº 
user
ºº 
==
ºº 
null
ºº 
)
ºº 
{
ΩΩ 
throw
ææ 
new
ææ "
ApplicationException
ææ .
(
ææ. /
$"
ææ/ 1+
Unable to load user with ID '
ææ1 N
{
ææN O
_userManager
ææO [
.
ææ[ \
	GetUserId
ææ\ e
(
ææe f
User
ææf j
)
ææj k
}
ææk l
'.
ææl n
"
ææn o
)
ææo p
;
ææp q
}
øø .
 TwoFactorAuthenticationViewModel
¡¡ ,
model
¡¡- 2
=
¡¡3 4
new
¡¡5 8.
 TwoFactorAuthenticationViewModel
¡¡9 Y
{
¬¬ 
HasAuthenticator
√√  
=
√√! "
await
√√# (
_userManager
√√) 5
.
√√5 6&
GetAuthenticatorKeyAsync
√√6 N
(
√√N O
user
√√O S
)
√√S T
!=
√√U W
null
√√X \
,
√√\ ]
Is2faEnabled
ƒƒ 
=
ƒƒ 
user
ƒƒ #
.
ƒƒ# $
TwoFactorEnabled
ƒƒ$ 4
,
ƒƒ4 5
RecoveryCodesLeft
≈≈ !
=
≈≈" #
await
≈≈$ )
_userManager
≈≈* 6
.
≈≈6 7%
CountRecoveryCodesAsync
≈≈7 N
(
≈≈N O
user
≈≈O S
)
≈≈S T
,
≈≈T U
}
∆∆ 
;
∆∆ 
return
»» 
View
»» 
(
»» 
model
»» 
)
»» 
;
»» 
}
…… 	
[
ÀÀ 	
HttpGet
ÀÀ	 
]
ÀÀ 
public
ÃÃ 
async
ÃÃ 
Task
ÃÃ 
<
ÃÃ 
IActionResult
ÃÃ '
>
ÃÃ' (
Disable2faWarning
ÃÃ) :
(
ÃÃ: ;
)
ÃÃ; <
{
ÕÕ 	
ApplicationUser
ŒŒ 
user
ŒŒ  
=
ŒŒ! "
await
ŒŒ# (
_userManager
ŒŒ) 5
.
ŒŒ5 6
GetUserAsync
ŒŒ6 B
(
ŒŒB C
User
ŒŒC G
)
ŒŒG H
;
ŒŒH I
if
œœ 
(
œœ 
user
œœ 
==
œœ 
null
œœ 
)
œœ 
{
–– 
throw
—— 
new
—— "
ApplicationException
—— .
(
——. /
$"
——/ 1+
Unable to load user with ID '
——1 N
{
——N O
_userManager
——O [
.
——[ \
	GetUserId
——\ e
(
——e f
User
——f j
)
——j k
}
——k l
'.
——l n
"
——n o
)
——o p
;
——p q
}
““ 
if
‘‘ 
(
‘‘ 
!
‘‘ 
user
‘‘ 
.
‘‘ 
TwoFactorEnabled
‘‘ &
)
‘‘& '
{
’’ 
throw
÷÷ 
new
÷÷ "
ApplicationException
÷÷ .
(
÷÷. /
$"
÷÷/ 1G
9Unexpected error occured disabling 2FA for user with ID '
÷÷1 j
{
÷÷j k
user
÷÷k o
.
÷÷o p
Id
÷÷p r
}
÷÷r s
'.
÷÷s u
"
÷÷u v
)
÷÷v w
;
÷÷w x
}
◊◊ 
return
ŸŸ 
View
ŸŸ 
(
ŸŸ 
nameof
ŸŸ 
(
ŸŸ 

Disable2fa
ŸŸ )
)
ŸŸ) *
)
ŸŸ* +
;
ŸŸ+ ,
}
⁄⁄ 	
[
‹‹ 	
HttpPost
‹‹	 
]
‹‹ 
[
›› 	&
ValidateAntiForgeryToken
››	 !
]
››! "
public
ﬁﬁ 
async
ﬁﬁ 
Task
ﬁﬁ 
<
ﬁﬁ 
IActionResult
ﬁﬁ '
>
ﬁﬁ' (

Disable2fa
ﬁﬁ) 3
(
ﬁﬁ3 4
)
ﬁﬁ4 5
{
ﬂﬂ 	
ApplicationUser
‡‡ 
user
‡‡  
=
‡‡! "
await
‡‡# (
_userManager
‡‡) 5
.
‡‡5 6
GetUserAsync
‡‡6 B
(
‡‡B C
User
‡‡C G
)
‡‡G H
;
‡‡H I
if
·· 
(
·· 
user
·· 
==
·· 
null
·· 
)
·· 
{
‚‚ 
throw
„„ 
new
„„ "
ApplicationException
„„ .
(
„„. /
$"
„„/ 1+
Unable to load user with ID '
„„1 N
{
„„N O
_userManager
„„O [
.
„„[ \
	GetUserId
„„\ e
(
„„e f
User
„„f j
)
„„j k
}
„„k l
'.
„„l n
"
„„n o
)
„„o p
;
„„p q
}
‰‰ 
IdentityResult
ÊÊ 
disable2faResult
ÊÊ +
=
ÊÊ, -
await
ÊÊ. 3
_userManager
ÊÊ4 @
.
ÊÊ@ A&
SetTwoFactorEnabledAsync
ÊÊA Y
(
ÊÊY Z
user
ÊÊZ ^
,
ÊÊ^ _
false
ÊÊ` e
)
ÊÊe f
;
ÊÊf g
if
ÁÁ 
(
ÁÁ 
!
ÁÁ 
disable2faResult
ÁÁ !
.
ÁÁ! "
	Succeeded
ÁÁ" +
)
ÁÁ+ ,
{
ËË 
throw
ÈÈ 
new
ÈÈ "
ApplicationException
ÈÈ .
(
ÈÈ. /
$"
ÈÈ/ 1G
9Unexpected error occured disabling 2FA for user with ID '
ÈÈ1 j
{
ÈÈj k
user
ÈÈk o
.
ÈÈo p
Id
ÈÈp r
}
ÈÈr s
'.
ÈÈs u
"
ÈÈu v
)
ÈÈv w
;
ÈÈw x
}
ÍÍ 
_logger
ÏÏ 
.
ÏÏ 
LogInformation
ÏÏ "
(
ÏÏ" #
$str
ÏÏ# L
,
ÏÏL M
user
ÏÏN R
.
ÏÏR S
Id
ÏÏS U
)
ÏÏU V
;
ÏÏV W
return
ÌÌ 
RedirectToAction
ÌÌ #
(
ÌÌ# $
nameof
ÌÌ$ *
(
ÌÌ* +%
TwoFactorAuthentication
ÌÌ+ B
)
ÌÌB C
)
ÌÌC D
;
ÌÌD E
}
ÓÓ 	
[
 	
HttpGet
	 
]
 
public
ÒÒ 
async
ÒÒ 
Task
ÒÒ 
<
ÒÒ 
IActionResult
ÒÒ '
>
ÒÒ' (!
EnableAuthenticator
ÒÒ) <
(
ÒÒ< =
)
ÒÒ= >
{
ÚÚ 	
ApplicationUser
ÛÛ 
user
ÛÛ  
=
ÛÛ! "
await
ÛÛ# (
_userManager
ÛÛ) 5
.
ÛÛ5 6
GetUserAsync
ÛÛ6 B
(
ÛÛB C
User
ÛÛC G
)
ÛÛG H
;
ÛÛH I
if
ÙÙ 
(
ÙÙ 
user
ÙÙ 
==
ÙÙ 
null
ÙÙ 
)
ÙÙ 
{
ıı 
throw
ˆˆ 
new
ˆˆ "
ApplicationException
ˆˆ .
(
ˆˆ. /
$"
ˆˆ/ 1+
Unable to load user with ID '
ˆˆ1 N
{
ˆˆN O
_userManager
ˆˆO [
.
ˆˆ[ \
	GetUserId
ˆˆ\ e
(
ˆˆe f
User
ˆˆf j
)
ˆˆj k
}
ˆˆk l
'.
ˆˆl n
"
ˆˆn o
)
ˆˆo p
;
ˆˆp q
}
˜˜ *
EnableAuthenticatorViewModel
˘˘ (
model
˘˘) .
=
˘˘/ 0
new
˘˘1 4*
EnableAuthenticatorViewModel
˘˘5 Q
(
˘˘Q R
)
˘˘R S
;
˘˘S T
await
˙˙ ,
LoadSharedKeyAndQrCodeUriAsync
˙˙ 0
(
˙˙0 1
user
˙˙1 5
,
˙˙5 6
model
˙˙7 <
)
˙˙< =
;
˙˙= >
return
¸¸ 
View
¸¸ 
(
¸¸ 
model
¸¸ 
)
¸¸ 
;
¸¸ 
}
˝˝ 	
[
ˇˇ 	
HttpPost
ˇˇ	 
]
ˇˇ 
[
ÄÄ 	&
ValidateAntiForgeryToken
ÄÄ	 !
]
ÄÄ! "
public
ÅÅ 
async
ÅÅ 
Task
ÅÅ 
<
ÅÅ 
IActionResult
ÅÅ '
>
ÅÅ' (!
EnableAuthenticator
ÅÅ) <
(
ÅÅ< =*
EnableAuthenticatorViewModel
ÅÅ= Y
model
ÅÅZ _
)
ÅÅ_ `
{
ÇÇ 	
ApplicationUser
ÉÉ 
user
ÉÉ  
=
ÉÉ! "
await
ÉÉ# (
_userManager
ÉÉ) 5
.
ÉÉ5 6
GetUserAsync
ÉÉ6 B
(
ÉÉB C
User
ÉÉC G
)
ÉÉG H
;
ÉÉH I
if
ÑÑ 
(
ÑÑ 
user
ÑÑ 
==
ÑÑ 
null
ÑÑ 
)
ÑÑ 
{
ÖÖ 
throw
ÜÜ 
new
ÜÜ "
ApplicationException
ÜÜ .
(
ÜÜ. /
$"
ÜÜ/ 1+
Unable to load user with ID '
ÜÜ1 N
{
ÜÜN O
_userManager
ÜÜO [
.
ÜÜ[ \
	GetUserId
ÜÜ\ e
(
ÜÜe f
User
ÜÜf j
)
ÜÜj k
}
ÜÜk l
'.
ÜÜl n
"
ÜÜn o
)
ÜÜo p
;
ÜÜp q
}
áá 
if
ââ 
(
ââ 
!
ââ 

ModelState
ââ 
.
ââ 
IsValid
ââ #
)
ââ# $
{
ää 
await
ãã ,
LoadSharedKeyAndQrCodeUriAsync
ãã 4
(
ãã4 5
user
ãã5 9
,
ãã9 :
model
ãã; @
)
ãã@ A
;
ããA B
return
åå 
View
åå 
(
åå 
model
åå !
)
åå! "
;
åå" #
}
çç 
string
êê 
verificationCode
êê #
=
êê$ %
model
êê& +
.
êê+ ,
Code
êê, 0
.
êê0 1
Replace
êê1 8
(
êê8 9
$str
êê9 <
,
êê< =
string
êê> D
.
êêD E
Empty
êêE J
)
êêJ K
.
êêK L
Replace
êêL S
(
êêS T
$str
êêT W
,
êêW X
string
êêY _
.
êê_ `
Empty
êê` e
)
êêe f
;
êêf g
bool
íí 
is2faTokenValid
íí  
=
íí! "
await
íí# (
_userManager
íí) 5
.
íí5 6'
VerifyTwoFactorTokenAsync
íí6 O
(
ííO P
user
ìì 
,
ìì 
_userManager
ìì "
.
ìì" #
Options
ìì# *
.
ìì* +
Tokens
ìì+ 1
.
ìì1 2(
AuthenticatorTokenProvider
ìì2 L
,
ììL M
verificationCode
ììN ^
)
ìì^ _
;
ìì_ `
if
ïï 
(
ïï 
!
ïï 
is2faTokenValid
ïï  
)
ïï  !
{
ññ 

ModelState
óó 
.
óó 
AddModelError
óó (
(
óó( )
$str
óó) /
,
óó/ 0
$str
óó1 P
)
óóP Q
;
óóQ R
await
òò ,
LoadSharedKeyAndQrCodeUriAsync
òò 4
(
òò4 5
user
òò5 9
,
òò9 :
model
òò; @
)
òò@ A
;
òòA B
return
ôô 
View
ôô 
(
ôô 
model
ôô !
)
ôô! "
;
ôô" #
}
öö 
await
úú 
_userManager
úú 
.
úú &
SetTwoFactorEnabledAsync
úú 7
(
úú7 8
user
úú8 <
,
úú< =
true
úú> B
)
úúB C
;
úúC D
_logger
ùù 
.
ùù 
LogInformation
ùù "
(
ùù" #
$str
ùù# e
,
ùùe f
user
ùùg k
.
ùùk l
Id
ùùl n
)
ùùn o
;
ùùo p
IEnumerable
ûû 
<
ûû 
string
ûû 
>
ûû 
recoveryCodes
ûû  -
=
ûû. /
await
ûû0 5
_userManager
ûû6 B
.
ûûB C4
&GenerateNewTwoFactorRecoveryCodesAsync
ûûC i
(
ûûi j
user
ûûj n
,
ûûn o
$num
ûûp r
)
ûûr s
;
ûûs t
TempData
üü 
[
üü 
RecoveryCodesKey
üü %
]
üü% &
=
üü' (
recoveryCodes
üü) 6
.
üü6 7
ToArray
üü7 >
(
üü> ?
)
üü? @
;
üü@ A
return
°° 
RedirectToAction
°° #
(
°°# $
nameof
°°$ *
(
°°* +
ShowRecoveryCodes
°°+ <
)
°°< =
)
°°= >
;
°°> ?
}
¢¢ 	
[
§§ 	
HttpGet
§§	 
]
§§ 
public
•• 
IActionResult
•• 
ShowRecoveryCodes
•• .
(
••. /
)
••/ 0
{
¶¶ 	
string
ßß 
[
ßß 
]
ßß 
recoveryCodes
ßß "
=
ßß# $
(
ßß% &
string
ßß& ,
[
ßß, -
]
ßß- .
)
ßß. /
TempData
ßß/ 7
[
ßß7 8
RecoveryCodesKey
ßß8 H
]
ßßH I
;
ßßI J
if
®® 
(
®® 
recoveryCodes
®® 
==
®®  
null
®®! %
)
®®% &
{
©© 
return
™™ 
RedirectToAction
™™ '
(
™™' (
nameof
™™( .
(
™™. /%
TwoFactorAuthentication
™™/ F
)
™™F G
)
™™G H
;
™™H I
}
´´ (
ShowRecoveryCodesViewModel
≠≠ &
model
≠≠' ,
=
≠≠- .
new
≠≠/ 2(
ShowRecoveryCodesViewModel
≠≠3 M
{
≠≠N O
RecoveryCodes
≠≠P ]
=
≠≠^ _
recoveryCodes
≠≠` m
}
≠≠n o
;
≠≠o p
return
ÆÆ 
View
ÆÆ 
(
ÆÆ 
model
ÆÆ 
)
ÆÆ 
;
ÆÆ 
}
ØØ 	
[
±± 	
HttpGet
±±	 
]
±± 
public
≤≤ 
IActionResult
≤≤ '
ResetAuthenticatorWarning
≤≤ 6
(
≤≤6 7
)
≤≤7 8
{
≥≥ 	
return
¥¥ 
View
¥¥ 
(
¥¥ 
nameof
¥¥ 
(
¥¥  
ResetAuthenticator
¥¥ 1
)
¥¥1 2
)
¥¥2 3
;
¥¥3 4
}
µµ 	
[
∑∑ 	
HttpPost
∑∑	 
]
∑∑ 
[
∏∏ 	&
ValidateAntiForgeryToken
∏∏	 !
]
∏∏! "
public
ππ 
async
ππ 
Task
ππ 
<
ππ 
IActionResult
ππ '
>
ππ' ( 
ResetAuthenticator
ππ) ;
(
ππ; <
)
ππ< =
{
∫∫ 	
ApplicationUser
ªª 
user
ªª  
=
ªª! "
await
ªª# (
_userManager
ªª) 5
.
ªª5 6
GetUserAsync
ªª6 B
(
ªªB C
User
ªªC G
)
ªªG H
;
ªªH I
if
ºº 
(
ºº 
user
ºº 
==
ºº 
null
ºº 
)
ºº 
{
ΩΩ 
throw
ææ 
new
ææ "
ApplicationException
ææ .
(
ææ. /
$"
ææ/ 1+
Unable to load user with ID '
ææ1 N
{
ææN O
_userManager
ææO [
.
ææ[ \
	GetUserId
ææ\ e
(
ææe f
User
ææf j
)
ææj k
}
ææk l
'.
ææl n
"
ææn o
)
ææo p
;
ææp q
}
øø 
await
¡¡ 
_userManager
¡¡ 
.
¡¡ &
SetTwoFactorEnabledAsync
¡¡ 7
(
¡¡7 8
user
¡¡8 <
,
¡¡< =
false
¡¡> C
)
¡¡C D
;
¡¡D E
await
¬¬ 
_userManager
¬¬ 
.
¬¬ (
ResetAuthenticatorKeyAsync
¬¬ 9
(
¬¬9 :
user
¬¬: >
)
¬¬> ?
;
¬¬? @
_logger
√√ 
.
√√ 
LogInformation
√√ "
(
√√" #
$str
√√# d
,
√√d e
user
√√f j
.
√√j k
Id
√√k m
)
√√m n
;
√√n o
return
≈≈ 
RedirectToAction
≈≈ #
(
≈≈# $
nameof
≈≈$ *
(
≈≈* +!
EnableAuthenticator
≈≈+ >
)
≈≈> ?
)
≈≈? @
;
≈≈@ A
}
∆∆ 	
[
»» 	
HttpGet
»»	 
]
»» 
public
…… 
async
…… 
Task
…… 
<
…… 
IActionResult
…… '
>
……' (*
GenerateRecoveryCodesWarning
……) E
(
……E F
)
……F G
{
   	
ApplicationUser
ÀÀ 
user
ÀÀ  
=
ÀÀ! "
await
ÀÀ# (
_userManager
ÀÀ) 5
.
ÀÀ5 6
GetUserAsync
ÀÀ6 B
(
ÀÀB C
User
ÀÀC G
)
ÀÀG H
;
ÀÀH I
if
ÃÃ 
(
ÃÃ 
user
ÃÃ 
==
ÃÃ 
null
ÃÃ 
)
ÃÃ 
{
ÕÕ 
throw
ŒŒ 
new
ŒŒ "
ApplicationException
ŒŒ .
(
ŒŒ. /
$"
ŒŒ/ 1+
Unable to load user with ID '
ŒŒ1 N
{
ŒŒN O
_userManager
ŒŒO [
.
ŒŒ[ \
	GetUserId
ŒŒ\ e
(
ŒŒe f
User
ŒŒf j
)
ŒŒj k
}
ŒŒk l
'.
ŒŒl n
"
ŒŒn o
)
ŒŒo p
;
ŒŒp q
}
œœ 
if
—— 
(
—— 
!
—— 
user
—— 
.
—— 
TwoFactorEnabled
—— &
)
——& '
{
““ 
throw
”” 
new
”” "
ApplicationException
”” .
(
””. /
$"
””/ 1?
1Cannot generate recovery codes for user with ID '
””1 b
{
””b c
user
””c g
.
””g h
Id
””h j
}
””j k6
'' because they do not have 2FA enabled.””k í
"””í ì
)””ì î
;””î ï
}
‘‘ 
return
÷÷ 
View
÷÷ 
(
÷÷ 
nameof
÷÷ 
(
÷÷ #
GenerateRecoveryCodes
÷÷ 4
)
÷÷4 5
)
÷÷5 6
;
÷÷6 7
}
◊◊ 	
[
ŸŸ 	
HttpPost
ŸŸ	 
]
ŸŸ 
[
⁄⁄ 	&
ValidateAntiForgeryToken
⁄⁄	 !
]
⁄⁄! "
public
€€ 
async
€€ 
Task
€€ 
<
€€ 
IActionResult
€€ '
>
€€' (#
GenerateRecoveryCodes
€€) >
(
€€> ?
)
€€? @
{
‹‹ 	
ApplicationUser
›› 
user
››  
=
››! "
await
››# (
_userManager
››) 5
.
››5 6
GetUserAsync
››6 B
(
››B C
User
››C G
)
››G H
;
››H I
if
ﬁﬁ 
(
ﬁﬁ 
user
ﬁﬁ 
==
ﬁﬁ 
null
ﬁﬁ 
)
ﬁﬁ 
{
ﬂﬂ 
throw
‡‡ 
new
‡‡ "
ApplicationException
‡‡ .
(
‡‡. /
$"
‡‡/ 1+
Unable to load user with ID '
‡‡1 N
{
‡‡N O
_userManager
‡‡O [
.
‡‡[ \
	GetUserId
‡‡\ e
(
‡‡e f
User
‡‡f j
)
‡‡j k
}
‡‡k l
'.
‡‡l n
"
‡‡n o
)
‡‡o p
;
‡‡p q
}
·· 
if
„„ 
(
„„ 
!
„„ 
user
„„ 
.
„„ 
TwoFactorEnabled
„„ &
)
„„& '
{
‰‰ 
throw
ÂÂ 
new
ÂÂ "
ApplicationException
ÂÂ .
(
ÂÂ. /
$"
ÂÂ/ 1?
1Cannot generate recovery codes for user with ID '
ÂÂ1 b
{
ÂÂb c
user
ÂÂc g
.
ÂÂg h
Id
ÂÂh j
}
ÂÂj k1
"' as they do not have 2FA enabled.ÂÂk ç
"ÂÂç é
)ÂÂé è
;ÂÂè ê
}
ÊÊ 
IEnumerable
ËË 
<
ËË 
string
ËË 
>
ËË 
recoveryCodes
ËË  -
=
ËË. /
await
ËË0 5
_userManager
ËË6 B
.
ËËB C4
&GenerateNewTwoFactorRecoveryCodesAsync
ËËC i
(
ËËi j
user
ËËj n
,
ËËn o
$num
ËËp r
)
ËËr s
;
ËËs t
_logger
ÈÈ 
.
ÈÈ 
LogInformation
ÈÈ "
(
ÈÈ" #
$str
ÈÈ# `
,
ÈÈ` a
user
ÈÈb f
.
ÈÈf g
Id
ÈÈg i
)
ÈÈi j
;
ÈÈj k(
ShowRecoveryCodesViewModel
ÎÎ &
model
ÎÎ' ,
=
ÎÎ- .
new
ÎÎ/ 2(
ShowRecoveryCodesViewModel
ÎÎ3 M
{
ÎÎN O
RecoveryCodes
ÎÎP ]
=
ÎÎ^ _
recoveryCodes
ÎÎ` m
.
ÎÎm n
ToArray
ÎÎn u
(
ÎÎu v
)
ÎÎv w
}
ÎÎx y
;
ÎÎy z
return
ÌÌ 
View
ÌÌ 
(
ÌÌ 
nameof
ÌÌ 
(
ÌÌ 
ShowRecoveryCodes
ÌÌ 0
)
ÌÌ0 1
,
ÌÌ1 2
model
ÌÌ3 8
)
ÌÌ8 9
;
ÌÌ9 :
}
ÓÓ 	
private
ÚÚ 
void
ÚÚ 
	AddErrors
ÚÚ 
(
ÚÚ 
IdentityResult
ÚÚ -
result
ÚÚ. 4
)
ÚÚ4 5
{
ÛÛ 	
foreach
ÙÙ 
(
ÙÙ 
IdentityError
ÙÙ "
error
ÙÙ# (
in
ÙÙ) +
result
ÙÙ, 2
.
ÙÙ2 3
Errors
ÙÙ3 9
)
ÙÙ9 :
{
ıı 

ModelState
ˆˆ 
.
ˆˆ 
AddModelError
ˆˆ (
(
ˆˆ( )
string
ˆˆ) /
.
ˆˆ/ 0
Empty
ˆˆ0 5
,
ˆˆ5 6
error
ˆˆ7 <
.
ˆˆ< =
Description
ˆˆ= H
)
ˆˆH I
;
ˆˆI J
}
˜˜ 
}
¯¯ 	
private
˙˙ 
string
˙˙ 
	FormatKey
˙˙  
(
˙˙  !
string
˙˙! '
unformattedKey
˙˙( 6
)
˙˙6 7
{
˚˚ 	
StringBuilder
¸¸ 
result
¸¸  
=
¸¸! "
new
¸¸# &
StringBuilder
¸¸' 4
(
¸¸4 5
)
¸¸5 6
;
¸¸6 7
int
˝˝ 
currentPosition
˝˝ 
=
˝˝  !
$num
˝˝" #
;
˝˝# $
while
˛˛ 
(
˛˛ 
currentPosition
˛˛ "
+
˛˛# $
$num
˛˛% &
<
˛˛' (
unformattedKey
˛˛) 7
.
˛˛7 8
Length
˛˛8 >
)
˛˛> ?
{
ˇˇ 
result
ÄÄ 
.
ÄÄ 
Append
ÄÄ 
(
ÄÄ 
unformattedKey
ÄÄ ,
.
ÄÄ, -
	Substring
ÄÄ- 6
(
ÄÄ6 7
currentPosition
ÄÄ7 F
,
ÄÄF G
$num
ÄÄH I
)
ÄÄI J
)
ÄÄJ K
.
ÄÄK L
Append
ÄÄL R
(
ÄÄR S
$str
ÄÄS V
)
ÄÄV W
;
ÄÄW X
currentPosition
ÅÅ 
+=
ÅÅ  "
$num
ÅÅ# $
;
ÅÅ$ %
}
ÇÇ 
if
ÉÉ 
(
ÉÉ 
currentPosition
ÉÉ 
<
ÉÉ  !
unformattedKey
ÉÉ" 0
.
ÉÉ0 1
Length
ÉÉ1 7
)
ÉÉ7 8
{
ÑÑ 
result
ÖÖ 
.
ÖÖ 
Append
ÖÖ 
(
ÖÖ 
unformattedKey
ÖÖ ,
.
ÖÖ, -
	Substring
ÖÖ- 6
(
ÖÖ6 7
currentPosition
ÖÖ7 F
)
ÖÖF G
)
ÖÖG H
;
ÖÖH I
}
ÜÜ 
return
àà 
result
àà 
.
àà 
ToString
àà "
(
àà" #
)
àà# $
.
àà$ %
ToLowerInvariant
àà% 5
(
àà5 6
)
àà6 7
;
àà7 8
}
ââ 	
private
ãã 
string
ãã 
GenerateQrCodeUri
ãã (
(
ãã( )
string
ãã) /
email
ãã0 5
,
ãã5 6
string
ãã7 =
unformattedKey
ãã> L
)
ããL M
{
åå 	
return
çç 
string
çç 
.
çç 
Format
çç  
(
çç  !$
AuthenticatorUriFormat
éé &
,
éé& '
_urlEncoder
èè 
.
èè 
Encode
èè "
(
èè" #
$str
èè# 5
)
èè5 6
,
èè6 7
_urlEncoder
êê 
.
êê 
Encode
êê "
(
êê" #
email
êê# (
)
êê( )
,
êê) *
unformattedKey
ëë 
)
ëë 
;
ëë  
}
íí 	
private
îî 
async
îî 
Task
îî ,
LoadSharedKeyAndQrCodeUriAsync
îî 9
(
îî9 :
ApplicationUser
îî: I
user
îîJ N
,
îîN O*
EnableAuthenticatorViewModel
îîP l
model
îîm r
)
îîr s
{
ïï 	
string
ññ 
unformattedKey
ññ !
=
ññ" #
await
ññ$ )
_userManager
ññ* 6
.
ññ6 7&
GetAuthenticatorKeyAsync
ññ7 O
(
ññO P
user
ññP T
)
ññT U
;
ññU V
if
óó 
(
óó 
string
óó 
.
óó 
IsNullOrEmpty
óó $
(
óó$ %
unformattedKey
óó% 3
)
óó3 4
)
óó4 5
{
òò 
await
ôô 
_userManager
ôô "
.
ôô" #(
ResetAuthenticatorKeyAsync
ôô# =
(
ôô= >
user
ôô> B
)
ôôB C
;
ôôC D
unformattedKey
öö 
=
öö  
await
öö! &
_userManager
öö' 3
.
öö3 4&
GetAuthenticatorKeyAsync
öö4 L
(
ööL M
user
ööM Q
)
ööQ R
;
ööR S
}
õõ 
model
ùù 
.
ùù 
	SharedKey
ùù 
=
ùù 
	FormatKey
ùù '
(
ùù' (
unformattedKey
ùù( 6
)
ùù6 7
;
ùù7 8
model
ûû 
.
ûû 
AuthenticatorUri
ûû "
=
ûû# $
GenerateQrCodeUri
ûû% 6
(
ûû6 7
user
ûû7 ;
.
ûû; <
Email
ûû< A
,
ûûA B
unformattedKey
ûûC Q
)
ûûQ R
;
ûûR S
}
üü 	
}
¢¢ 
}££ ‘9
iC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\ProfileController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
public 

class 
ProfileController "
:# $ 
SecureBaseController% 9
{ 
private 
readonly 
IProfileAppService +
_profileAppService, >
;> ?
private 
readonly #
INotificationAppService 0"
notificationAppService1 G
;G H
public 
ProfileController  
(  !
IProfileAppService! 3
profileAppService4 E
, #
INotificationAppService %"
notificationAppService& <
)< =
:> ?
base@ D
(D E
)E F
{ 	
_profileAppService 
=  
profileAppService! 2
;2 3
this 
. "
notificationAppService '
=( )"
notificationAppService* @
;@ A
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
Details) 0
(0 1
Guid1 5
id6 8
,8 9
Guid: >
notificationclicked? R
)R S
{ 	
ProfileViewModel 
vm 
=  !
_profileAppService" 4
.4 5
GetByUserId5 @
(@ A
thisA E
.E F
CurrentUserIdF S
,S T
idU W
,W X
ProfileTypeY d
.d e
Personale m
)m n
;n o
if   
(   
vm   
==   
null   
)   
{!! 
ProfileViewModel""  
profile""! (
="") *
_profileAppService""+ =
.""= >
GenerateNewOne""> L
(""L M
ProfileType""M X
.""X Y
Personal""Y a
)""a b
;""b c
profile## 
.## 
UserId## 
=##  
id##! #
;### $
_profileAppService$$ "
.$$" #
Save$$# '
($$' (
profile$$( /
)$$/ 0
;$$0 1
vm&& 
=&& 
profile&& 
;&& 
}'' 
this)) 
.)) 
	SetImages)) 
()) 
vm)) 
))) 
;)) 
ApplicationUser++ 
user++  
=++! "
await++# (
UserManager++) 4
.++4 5
FindByIdAsync++5 B
(++B C
CurrentUserId++C P
.++P Q
ToString++Q Y
(++Y Z
)++Z [
)++[ \
;++\ ]
bool,, 
userIsAdmin,, 
=,, 
user,, #
==,,$ &
null,,' +
?,,, -
false,,. 3
:,,4 5
await,,6 ;
UserManager,,< G
.,,G H
IsInRoleAsync,,H U
(,,U V
user,,V Z
,,,Z [
Roles,,\ a
.,,a b
Administrator,,b o
.,,o p
ToString,,p x
(,,x y
),,y z
),,z {
;,,{ |
vm-- 
.-- 
Permissions-- 
.-- 
CanEdit-- "
=--# $
vm--% '
.--' (
UserId--( .
==--/ 1
CurrentUserId--2 ?
||--@ B
userIsAdmin--C N
;--N O
this// 
.// "
notificationAppService// '
.//' (

MarkAsRead//( 2
(//2 3
notificationclicked//3 F
)//F G
;//G H
return11 
View11 
(11 
vm11 
)11 
;11 
}22 	
[44 	
Route44	 
(44 
$str44 +
)44+ ,
]44, -
public55 
IActionResult55 
Edit55 !
(55! "
Guid55" &
userId55' -
)55- .
{66 	
ProfileViewModel77 
vm77 
=77  !
_profileAppService77" 4
.774 5
GetByUserId775 @
(77@ A
userId77A G
,77G H
ProfileType77I T
.77T U
Personal77U ]
)77] ^
;77^ _
this88 
.88 
	SetImages88 
(88 
vm88 
)88 
;88 
return:: 
View:: 
(:: 
vm:: 
):: 
;:: 
};; 	
[== 	
HttpPost==	 
]== 
public>> 
IActionResult>> 
Save>> !
(>>! "
ProfileViewModel>>" 2
vm>>3 5
,>>5 6
	IFormFile>>7 @
avatar>>A G
)>>G H
{?? 	
try@@ 
{AA 
ifBB 
(BB 
vmBB 
.BB 
BioBB 
.BB 
ContainsBB #
(BB# $
$strBB$ v
)BBv w
)BBw x
{CC 
vmDD 
.DD 
BioDD 
=DD 
vmDD 
.DD  
NameDD  $
+DD% &
$strDD' z
;DDz {
}EE 
_profileAppServiceGG "
.GG" #
SaveGG# '
(GG' (
vmGG( *
)GG* +
;GG+ ,
stringII 
urlII 
=II 
UrlII  
.II  !
ActionII! '
(II' (
$strII( 1
,II1 2
$strII3 <
,II< =
newII> A
{IIB C
areaIID H
=III J
stringIIK Q
.IIQ R
EmptyIIR W
,IIW X
idIIY [
=II\ ]
vmII^ `
.II` a
UserIdIIa g
.IIg h
ToStringIIh p
(IIp q
)IIq r
}IIs t
)IIt u
;IIu v
returnKK 
JsonKK 
(KK 
newKK %
OperationResultRedirectVoKK  9
(KK9 :
urlKK: =
)KK= >
)KK> ?
;KK? @
}LL 
catchMM 
(MM 
	ExceptionMM 
exMM 
)MM  
{NN 
returnOO 
JsonOO 
(OO 
newOO 
OperationResultVoOO  1
(OO1 2
exOO2 4
.OO4 5
MessageOO5 <
)OO< =
)OO= >
;OO> ?
}PP 
}QQ 	
privateSS 
voidSS 
	SetImagesSS 
(SS 
ProfileViewModelSS /
vmSS0 2
)SS2 3
{TT 	
vmUU 
.UU 
ProfileImageUrlUU 
=UU  
UrlFormatterUU! -
.UU- .
ProfileImageUU. :
(UU: ;
vmUU; =
.UU= >
UserIdUU> D
)UUD E
;UUE F
vmVV 
.VV 
CoverImageUrlVV 
=VV 
UrlFormatterVV +
.VV+ ,
ProfileCoverImageVV, =
(VV= >
vmVV> @
.VV@ A
UserIdVVA G
,VVG H
vmVVI K
.VVK L
IdVVL N
)VVN O
;VVO P
}WW 	
}XX 
}YY ˛#
hC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\RoutesController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
RoutesController

 !
:

" #

Controller

$ .
{ 
private 
readonly /
#IActionDescriptorCollectionProvider </
#_actionDescriptorCollectionProvider= `
;` a
public 
RoutesController 
(  /
#IActionDescriptorCollectionProvider  C.
"actionDescriptorCollectionProviderD f
)f g
{ 	
this 
. /
#_actionDescriptorCollectionProvider 4
=5 6.
"actionDescriptorCollectionProvider7 Y
;Y Z
} 	
[ 	
HttpGet	 
] 
[ 	
HttpPut	 
] 
public 
IActionResult 
Index "
(" #
)# $
{ 	
var 
items 
= /
#_actionDescriptorCollectionProvider ;
.; <
ActionDescriptors< M
.M N
ItemsN S
;S T
var 
routes 
= 
items 
. 
Select %
(% &
x& '
=>( *
new+ .
	RouteInfo/ 8
{ 
Action 
= 
x 
. 
RouteValues &
[& '
$str' /
]/ 0
,0 1

Controller 
= 
x 
. 
RouteValues *
[* +
$str+ 7
]7 8
,8 9
Name 
= 
x 
. 
AttributeRouteInfo +
?+ ,
., -
Name- 1
,1 2
Template 
= 
x 
. 
AttributeRouteInfo /
?/ 0
.0 1
Template1 9
,9 :

Constraint 
= 
x 
. 
ActionConstraints 0
==1 3
null4 8
?9 :
string; A
.A B
EmptyB G
:H I
stringJ P
.P Q
JoinQ U
(U V
$strV Z
,Z [
x\ ]
.] ^
ActionConstraints^ o
?o p
.p q
OfTypeq w
<w x'
HttpMethodActionConstraint	x í
>
í ì
(
ì î
)
î ï
.
ï ñ
SingleOrDefault
ñ •
(
• ¶
)
¶ ß
?
ß ®
.
® ©
HttpMethods
© ¥
??
µ ∑
new
∏ ª
string
º ¬
[
¬ √
]
√ ƒ
{
≈ ∆
$str
« Ã
}
Õ Œ
)
Œ œ
}   
)   
.   
ToList   
(   
)   
;   
return"" 
View"" 
("" 
new"" 
RoutesModel"" '
{""( )
Routes""* 0
=""1 2
routes""3 9
}"": ;
)""; <
;""< =
}## 	
}$$ 
public&& 

class&& 
RoutesModel&& 
{'' 
public(( 
List(( 
<(( 
	RouteInfo(( 
>(( 
Routes(( %
{((& '
get((( +
;((+ ,
set((- 0
;((0 1
}((2 3
})) 
public++ 

class++ 
	RouteInfo++ 
{,, 
public-- 
string-- 
Template-- 
{--  
get--! $
;--$ %
set--& )
;--) *
}--+ ,
public.. 
string.. 
Name.. 
{.. 
get..  
;..  !
set.." %
;..% &
}..' (
public// 
string// 

Controller//  
{//! "
get//# &
;//& '
set//( +
;//+ ,
}//- .
public00 
string00 
Action00 
{00 
get00 "
;00" #
set00$ '
;00' (
}00) *
public11 
string11 

Constraint11  
{11! "
get11# &
;11& '
set11( +
;11+ ,
}11- .
}22 
}33 Â√
iC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\StorageController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
StorageController "
:# $ 
SecureBaseController% 9
{ 
private 
readonly 
IHostingEnvironment ,
_hostingEnv- 8
;8 9
private 
static  
IHttpContextAccessor +
HttpContextAccessor, ?
;? @
public 
StorageController  
(  !
IHostingEnvironment! 4

hostingEnv5 ?
,? @ 
IHttpContextAccessorA U
httpContextAccessorV i
)i j
{ 	
_hostingEnv 
= 

hostingEnv $
;$ %
HttpContextAccessor 
=  !
httpContextAccessor" 5
;5 6
} 	
[ 	
ResponseCache	 
( 
CacheProfileName '
=( )
$str* 1
)1 2
]2 3
[ 	
Route	 
( 
$str =
)= >
]> ?
public 
IActionResult 
	UserImage &
(& '
BlobType' /
type0 4
,4 5
Guid6 :
userId; A
,A B
stringC I
nameJ N
)N O
{   	
if"" 
("" 
string"" 
."" 
IsNullOrWhiteSpace"" )
("") *
name""* .
)"". /
)""/ 0
{## 
name$$ 
=$$ 
userId$$ 
.$$ 
ToString$$ &
($$& '
)$$' (
;$$( )
}%% 
if'' 
('' 
type'' 
=='' 
BlobType''  
.''  !
ProfileImage''! -
)''- .
{(( 
name)) 
=)) 
String)) 
.)) 
Format)) $
())$ %
$str))% 3
,))3 4
userId))5 ;
))); <
;))< =
}** 
return.. 
GetImage.. 
(.. 
type..  
,..  !
userId.." (
,..( )
name..* .
)... /
;../ 0
}// 	
[11 	
ResponseCache11	 
(11 
CacheProfileName11 '
=11( )
$str11* 3
)113 4
]114 5
[22 	
Route22	 
(22 
$str22 8
)228 9
]229 :
[33 	
Route33	 
(33 
$str33 
)33 
]33 
[44 	
Route44	 
(44 
$str44 
)44 
]44 
public55 
IActionResult55 
Image55 "
(55" #
BlobType55# +
type55, 0
,550 1
Guid552 6
userId557 =
,55= >
string55? E
name55F J
)55J K
{66 	
return77 
GetImage77 
(77 
type77  
,77  !
userId77" (
,77( )
name77* .
)77. /
;77/ 0
}88 	
private:: 
IActionResult:: 
GetImage:: &
(::& '
BlobType::' /
type::0 4
,::4 5
Guid::6 :
userId::; A
,::A B
string::C I
name::J N
)::N O
{;; 	
string<< 
baseUrl<< 
=<< 
	Constants<< &
.<<& '
DefaultCdnPath<<' 5
;<<5 6
name== 
=== 
name== 
.== 
Replace== 
(==  
	Constants==  )
.==) *
DefaultImagePath==* :
,==: ;
string==< B
.==B C
Empty==C H
)==H I
;==I J
try?? 
{@@ 
stringAA 
storageBasePathAA &
=AA' (
stringAA) /
.AA/ 0
EmptyAA0 5
;AA5 6
storageBasePathCC 
=CC  !
FormatBasePathCC" 0
(CC0 1
typeCC1 5
,CC5 6
userIdCC7 =
,CC= >
baseUrlCC? F
,CCF G
storageBasePathCCH W
)CCW X
;CCX Y
stringEE 
urlEE 
=EE 
storageBasePathEE ,
+EE- .
nameEE/ 3
;EE3 4
byteGG 
[GG 
]GG 
dataGG 
;GG 
usingII 
(II 
	WebClientII  
	webClientII! *
=II+ ,
newII- 0
	WebClientII1 :
(II: ;
)II; <
)II< =
{JJ 
dataKK 
=KK 
	webClientKK $
.KK$ %
DownloadDataKK% 1
(KK1 2
urlKK2 5
)KK5 6
;KK6 7
}LL 
stringNN 
etagNN 
=NN 
ETagGeneratorNN +
.NN+ ,
GetETagNN, 3
(NN3 4
HttpContextAccessorNN4 G
.NNG H
HttpContextNNH S
.NNS T
RequestNNT [
.NN[ \
PathNN\ `
.NN` a
ToStringNNa i
(NNi j
)NNj k
,NNk l
dataNNm q
)NNq r
;NNr s
ifOO 
(OO 
HttpContextAccessorOO '
.OO' (
HttpContextOO( 3
.OO3 4
RequestOO4 ;
.OO; <
HeadersOO< C
.OOC D
KeysOOD H
.OOH I
ContainsOOI Q
(OOQ R
HeaderNamesOOR ]
.OO] ^
IfNoneMatchOO^ i
)OOi j
&&OOk m 
HttpContextAccessor	OOn Å
.
OOÅ Ç
HttpContext
OOÇ ç
.
OOç é
Request
OOé ï
.
OOï ñ
Headers
OOñ ù
[
OOù û
HeaderNames
OOû ©
.
OO© ™
IfNoneMatch
OO™ µ
]
OOµ ∂
.
OO∂ ∑
ToString
OO∑ ø
(
OOø ¿
)
OO¿ ¡
==
OO¬ ƒ
etag
OO≈ …
)
OO…  
{PP 
returnQQ 
newQQ 
StatusCodeResultQQ /
(QQ/ 0
StatusCodesQQ0 ;
.QQ; < 
Status304NotModifiedQQ< P
)QQP Q
;QQQ R
}RR 
HttpContextAccessorSS #
.SS# $
HttpContextSS$ /
.SS/ 0
ResponseSS0 8
.SS8 9
HeadersSS9 @
.SS@ A
AddSSA D
(SSD E
HeaderNamesSSE P
.SSP Q
ETagSSQ U
,SSU V
newSSW Z
[SSZ [
]SS[ \
{SS] ^
etagSS_ c
}SSd e
)SSe f
;SSf g
returnUU 
FileUU 
(UU 
newUU 
MemoryStreamUU  ,
(UU, -
dataUU- 1
)UU1 2
,UU2 3
$strUU4 @
)UU@ A
;UUA B
}VV 
catchWW 
(WW 
	ExceptionWW 
)WW 
{XX 
returnYY 
ReturnDefaultImageYY )
(YY) *
typeYY* .
)YY. /
;YY/ 0
}ZZ 
}[[ 	
[^^ 	
HttpPost^^	 
]^^ 
[__ 	
Route__	 
(__ 
$str__ 
)__ 
]__ 
public`` 
IActionResult`` 
UploadProfileAvatar`` 0
(``0 1
	IFormFile``1 :
image``; @
,``@ A
string``B H
currentImage``I U
,``U V
Guid``W [
userId``\ b
)``b c
{aa 	
trybb 
{cc 
stringdd 
imageUrldd 
=dd  !
stringdd" (
.dd( )
Emptydd) .
;dd. /
ifff 
(ff 
imageff 
!=ff 
nullff !
&&ff" $
imageff% *
.ff* +
Lengthff+ 1
>ff2 3
$numff4 5
)ff5 6
{gg 
usinghh 
(hh 
MemoryStreamhh '
mshh( *
=hh+ ,
newhh- 0
MemoryStreamhh1 =
(hh= >
)hh> ?
)hh? @
{ii 
imagejj 
.jj 
CopyTojj $
(jj$ %
msjj% '
)jj' (
;jj( )
OptimizeImagell %
(ll% &
msll& (
)ll( )
;ll) *
bytenn 
[nn 
]nn 
	fileBytesnn (
=nn) *
msnn+ -
.nn- .
ToArraynn. 5
(nn5 6
)nn6 7
;nn7 8
stringpp 
	extensionpp (
=pp) *
GetFileExtensionpp+ ;
(pp; <
imagepp< A
)ppA B
;ppB C
stringrr 
filenamerr '
=rr( )
userIdrr* 0
+rr1 2
$strrr3 >
;rr> ?
imageUrltt  
=tt! "
basett# '
.tt' (
UploadImagett( 3
(tt3 4
userIdtt4 :
,tt: ;
BlobTypett< D
.ttD E
ProfileImagettE Q
,ttQ R
filenamettS [
,tt[ \
	fileBytestt] f
)ttf g
;ttg h
}uu 
}vv 
varxx 
jsonxx 
=xx 
newxx 
{yy 
sizezz 
=zz 
imagezz  
?zz  !
.zz! "
Lengthzz" (
,zz( )
oldImage{{ 
={{ 
currentImage{{ +
,{{+ ,
imageUrl|| 
=|| 
imageUrl|| '
}}} 
;}} 
return 
Json 
( 
json  
)  !
;! "
}
ÄÄ 
catch
ÅÅ 
(
ÅÅ 
	Exception
ÅÅ 
ex
ÅÅ 
)
ÅÅ  
{
ÇÇ 
var
ÉÉ 
json
ÉÉ 
=
ÉÉ 
new
ÉÉ 
{
ÑÑ 
error
ÖÖ 
=
ÖÖ 
ex
ÖÖ 
.
ÖÖ 
Message
ÖÖ &
}
ÜÜ 
;
ÜÜ 
return
àà 
Json
àà 
(
àà 
json
àà  
)
àà  !
;
àà! "
}
ââ 
}
ää 	
[
ãã 	
HttpPost
ãã	 
]
ãã 
[
åå 	
Route
åå	 
(
åå 
$str
åå (
)
åå( )
]
åå) *
public
çç 
IActionResult
çç %
UploadProfileCoverImage
çç 4
(
çç4 5
	IFormFile
çç5 >
image
çç? D
,
ççD E
string
ççF L
currentImage
ççM Y
,
ççY Z
Guid
çç[ _
userId
çç` f
,
ççf g
Guid
ççh l
	profileId
ççm v
)
ççv w
{
éé 	
try
èè 
{
êê 
string
ëë 
imageUrl
ëë 
=
ëë  !
string
ëë" (
.
ëë( )
Empty
ëë) .
;
ëë. /
if
ìì 
(
ìì 
image
ìì 
!=
ìì 
null
ìì !
&&
ìì" $
image
ìì% *
.
ìì* +
Length
ìì+ 1
>
ìì2 3
$num
ìì4 5
)
ìì5 6
{
îî 
using
ïï 
(
ïï 
MemoryStream
ïï '
ms
ïï( *
=
ïï+ ,
new
ïï- 0
MemoryStream
ïï1 =
(
ïï= >
)
ïï> ?
)
ïï? @
{
ññ 
image
óó 
.
óó 
CopyTo
óó $
(
óó$ %
ms
óó% '
)
óó' (
;
óó( )
OptimizeImage
ôô %
(
ôô% &
ms
ôô& (
)
ôô( )
;
ôô) *
byte
õõ 
[
õõ 
]
õõ 
	fileBytes
õõ (
=
õõ) *
ms
õõ+ -
.
õõ- .
ToArray
õõ. 5
(
õõ5 6
)
õõ6 7
;
õõ7 8
string
ùù 
	extension
ùù (
=
ùù) *
GetFileExtension
ùù+ ;
(
ùù; <
image
ùù< A
)
ùùA B
;
ùùB C
string
üü 
filename
üü '
=
üü( )
	profileId
üü* 3
.
üü3 4
ToString
üü4 <
(
üü< =
)
üü= >
;
üü> ?
imageUrl
°°  
=
°°! "
base
°°# '
.
°°' (
UploadImage
°°( 3
(
°°3 4
userId
°°4 :
,
°°: ;
BlobType
°°< D
.
°°D E
ProfileCover
°°E Q
,
°°Q R
filename
°°S [
,
°°[ \
	fileBytes
°°] f
)
°°f g
;
°°g h
}
¢¢ 
}
££ 
var
•• 
json
•• 
=
•• 
new
•• 
{
¶¶ 
size
ßß 
=
ßß 
image
ßß  
?
ßß  !
.
ßß! "
Length
ßß" (
,
ßß( )
oldImage
®® 
=
®® 
currentImage
®® +
,
®®+ ,
imageUrl
©© 
=
©© 
imageUrl
©© '
}
™™ 
;
™™ 
return
¨¨ 
Json
¨¨ 
(
¨¨ 
json
¨¨  
)
¨¨  !
;
¨¨! "
}
≠≠ 
catch
ÆÆ 
(
ÆÆ 
	Exception
ÆÆ 
ex
ÆÆ 
)
ÆÆ  
{
ØØ 
var
∞∞ 
json
∞∞ 
=
∞∞ 
new
∞∞ 
{
±± 
error
≤≤ 
=
≤≤ 
ex
≤≤ 
.
≤≤ 
Message
≤≤ &
}
≥≥ 
;
≥≥ 
return
µµ 
Json
µµ 
(
µµ 
json
µµ  
)
µµ  !
;
µµ! "
}
∂∂ 
}
∑∑ 	
[
ªª 	
HttpPost
ªª	 
]
ªª 
[
ºº 	
Route
ºº	 
(
ºº 
$str
ºº $
)
ºº$ %
]
ºº% &
public
ΩΩ 
IActionResult
ΩΩ !
UploadGameThumbnail
ΩΩ 0
(
ΩΩ0 1
	IFormFile
ΩΩ1 :
image
ΩΩ; @
,
ΩΩ@ A
Guid
ΩΩB F
gameId
ΩΩG M
,
ΩΩM N
string
ΩΩO U
currentImage
ΩΩV b
,
ΩΩb c
Guid
ΩΩd h
userId
ΩΩi o
)
ΩΩo p
{
ææ 	
return
øø 
UploadGameImage
øø "
(
øø" #
image
øø# (
,
øø( )
BlobType
øø* 2
.
øø2 3
GameThumbnail
øø3 @
,
øø@ A
	Constants
øøB K
.
øøK L"
DefaultGameThumbnail
øøL `
,
øø` a
gameId
øøb h
,
øøh i
currentImage
øøj v
,
øøv w
userId
øøx ~
)
øø~ 
;øø Ä
}
¿¿ 	
[
¬¬ 	
HttpPost
¬¬	 
]
¬¬ 
[
√√ 	
Route
√√	 
(
√√ 
$str
√√ %
)
√√% &
]
√√& '
public
ƒƒ 
IActionResult
ƒƒ "
UploadGameCoverImage
ƒƒ 1
(
ƒƒ1 2
	IFormFile
ƒƒ2 ;
image
ƒƒ< A
,
ƒƒA B
Guid
ƒƒC G
gameId
ƒƒH N
,
ƒƒN O
string
ƒƒP V
currentImage
ƒƒW c
,
ƒƒc d
Guid
ƒƒe i
userId
ƒƒj p
)
ƒƒp q
{
≈≈ 	
return
∆∆ 
UploadGameImage
∆∆ "
(
∆∆" #
image
∆∆# (
,
∆∆( )
BlobType
∆∆* 2
.
∆∆2 3
	GameCover
∆∆3 <
,
∆∆< =
	Constants
∆∆> G
.
∆∆G H#
DefaultGameCoverImage
∆∆H ]
,
∆∆] ^
gameId
∆∆_ e
,
∆∆e f
currentImage
∆∆g s
,
∆∆s t
userId
∆∆u {
)
∆∆{ |
;
∆∆| }
}
«« 	
private
…… 
IActionResult
…… 
UploadGameImage
…… -
(
……- .
	IFormFile
……. 7
image
……8 =
,
……= >
BlobType
……? G
type
……H L
,
……L M
string
……N T
defaultImage
……U a
,
……a b
Guid
……c g
gameId
……h n
,
……n o
string
……p v
currentImage……w É
,……É Ñ
Guid……Ö â
userId……ä ê
)……ê ë
{
   	
try
ÀÀ 
{
ÃÃ 
string
ÕÕ 
imageUrl
ÕÕ 
=
ÕÕ  !
string
ÕÕ" (
.
ÕÕ( )
Empty
ÕÕ) .
;
ÕÕ. /
if
œœ 
(
œœ 
image
œœ 
!=
œœ 
null
œœ !
&&
œœ" $
image
œœ% *
.
œœ* +
Length
œœ+ 1
>
œœ2 3
$num
œœ4 5
)
œœ5 6
{
–– 
using
—— 
(
—— 
MemoryStream
—— '
ms
——( *
=
——+ ,
new
——- 0
MemoryStream
——1 =
(
——= >
)
——> ?
)
——? @
{
““ 
image
”” 
.
”” 
CopyTo
”” $
(
””$ %
ms
””% '
)
””' (
;
””( )
OptimizeImage
’’ %
(
’’% &
ms
’’& (
)
’’( )
;
’’) *
byte
◊◊ 
[
◊◊ 
]
◊◊ 
	fileBytes
◊◊ (
=
◊◊) *
ms
◊◊+ -
.
◊◊- .
ToArray
◊◊. 5
(
◊◊5 6
)
◊◊6 7
;
◊◊7 8
string
ŸŸ 
	extension
ŸŸ (
=
ŸŸ) *
GetFileExtension
ŸŸ+ ;
(
ŸŸ; <
image
ŸŸ< A
)
ŸŸA B
;
ŸŸB C
string
€€ 
filename
€€ '
=
€€( )
DateTime
€€* 2
.
€€2 3
Now
€€3 6
.
€€6 7
ToString
€€7 ?
(
€€? @
$str
€€@ P
)
€€P Q
+
€€R S
$str
€€T W
+
€€X Y
	extension
€€Z c
;
€€c d
imageUrl
››  
=
››! "
base
››# '
.
››' (
UploadGameImage
››( 7
(
››7 8
userId
››8 >
,
››> ?
type
››@ D
,
››D E
filename
››F N
,
››N O
	fileBytes
››P Y
)
››Y Z
;
››Z [
}
ﬁﬁ 
}
ﬂﬂ 
if
·· 
(
·· 
!
·· 
string
·· 
.
··  
IsNullOrWhiteSpace
·· .
(
··. /
currentImage
··/ ;
)
··; <
)
··< =
{
‚‚ 
if
„„ 
(
„„ 
!
„„ 
currentImage
„„ %
.
„„% &
Equals
„„& ,
(
„„, -
defaultImage
„„- 9
)
„„9 :
)
„„: ;
{
‰‰ 
string
ÂÂ 
currentParam
ÂÂ +
=
ÂÂ, -!
GetImageNameFromUrl
ÂÂ. A
(
ÂÂA B
currentImage
ÂÂB N
)
ÂÂN O
;
ÂÂO P
string
ÁÁ 
delete
ÁÁ %
=
ÁÁ& '
base
ÁÁ( ,
.
ÁÁ, -
DeleteGameImage
ÁÁ- <
(
ÁÁ< =
userId
ÁÁ= C
,
ÁÁC D
type
ÁÁE I
,
ÁÁI J
currentParam
ÁÁK W
)
ÁÁW X
;
ÁÁX Y
}
ËË 
}
ÈÈ 
var
ÎÎ 
json
ÎÎ 
=
ÎÎ 
new
ÎÎ 
{
ÏÏ 
size
ÌÌ 
=
ÌÌ 
image
ÌÌ  
?
ÌÌ  !
.
ÌÌ! "
Length
ÌÌ" (
,
ÌÌ( )
gameId
ÓÓ 
=
ÓÓ 
gameId
ÓÓ #
,
ÓÓ# $
oldImage
ÔÔ 
=
ÔÔ 
currentImage
ÔÔ +
,
ÔÔ+ ,
imageUrl
 
=
 
imageUrl
 '
}
ÒÒ 
;
ÒÒ 
return
ÛÛ 
Json
ÛÛ 
(
ÛÛ 
json
ÛÛ  
)
ÛÛ  !
;
ÛÛ! "
}
ÙÙ 
catch
ıı 
(
ıı 
	Exception
ıı 
ex
ıı 
)
ıı  
{
ˆˆ 
var
˜˜ 
json
˜˜ 
=
˜˜ 
new
˜˜ 
{
¯¯ 
error
˘˘ 
=
˘˘ 
ex
˘˘ 
.
˘˘ 
Message
˘˘ &
}
˙˙ 
;
˙˙ 
return
¸¸ 
Json
¸¸ 
(
¸¸ 
json
¸¸  
)
¸¸  !
;
¸¸! "
}
˝˝ 
}
˛˛ 	
[
ÇÇ 	
HttpPost
ÇÇ	 
]
ÇÇ 
[
ÉÉ 	
Route
ÉÉ	 
(
ÉÉ 
$str
ÉÉ #
)
ÉÉ# $
]
ÉÉ$ %
public
ÑÑ 
IActionResult
ÑÑ  
UploadContentImage
ÑÑ /
(
ÑÑ/ 0
	IFormFile
ÑÑ0 9
upload
ÑÑ: @
)
ÑÑ@ A
{
ÖÖ 	
try
ÜÜ 
{
áá 
string
àà 
imageUrl
àà 
=
àà  !
string
àà" (
.
àà( )
Empty
àà) .
;
àà. /
if
ää 
(
ää 
upload
ää 
!=
ää 
null
ää "
&&
ää# %
upload
ää& ,
.
ää, -
Length
ää- 3
>
ää4 5
$num
ää6 7
)
ää7 8
{
ãã 
using
åå 
(
åå 
MemoryStream
åå '
ms
åå( *
=
åå+ ,
new
åå- 0
MemoryStream
åå1 =
(
åå= >
)
åå> ?
)
åå? @
{
çç 
upload
éé 
.
éé 
CopyTo
éé %
(
éé% &
ms
éé& (
)
éé( )
;
éé) *
if
êê 
(
êê 
upload
êê "
.
êê" #
ContentType
êê# .
.
êê. /

StartsWith
êê/ 9
(
êê9 :
$str
êê: A
)
êêA B
)
êêB C
{
ëë 
OptimizeImage
íí )
(
íí) *
ms
íí* ,
)
íí, -
;
íí- .
}
ìì 
byte
ïï 
[
ïï 
]
ïï 
	fileBytes
ïï (
=
ïï) *
ms
ïï+ -
.
ïï- .
ToArray
ïï. 5
(
ïï5 6
)
ïï6 7
;
ïï7 8
string
óó 
	extension
óó (
=
óó) *
GetFileExtension
óó+ ;
(
óó; <
upload
óó< B
)
óóB C
;
óóC D
string
ôô 
filename
ôô '
=
ôô( )
DateTime
ôô* 2
.
ôô2 3
Now
ôô3 6
.
ôô6 7
ToString
ôô7 ?
(
ôô? @
$str
ôô@ P
)
ôôP Q
+
ôôR S
$str
ôôT W
+
ôôX Y
	extension
ôôZ c
;
ôôc d
imageUrl
úú  
=
úú! "
base
úú# '
.
úú' ( 
UploadContentImage
úú( :
(
úú: ;
CurrentUserId
úú; H
,
úúH I
filename
úúJ R
,
úúR S
	fileBytes
úúT ]
)
úú] ^
;
úú^ _
}
ùù 
}
ûû 
string
üü 
baseUrl
üü 
=
üü   
GetAbsoluteBaseUri
üü! 3
(
üü3 4
)
üü4 5
;
üü5 6
var
°° 
json
°° 
=
°° 
new
°° 
{
¢¢ 
uploaded
££ 
=
££ 
true
££ #
,
££# $
url
§§ 
=
§§ 
imageUrl
§§ "
}
•• 
;
•• 
return
ßß 
Json
ßß 
(
ßß 
json
ßß  
)
ßß  !
;
ßß! "
}
®® 
catch
©© 
(
©© 
	Exception
©© 
ex
©© 
)
©©  
{
™™ 
var
´´ 
json
´´ 
=
´´ 
new
´´ 
{
¨¨ 
error
≠≠ 
=
≠≠ 
ex
≠≠ 
.
≠≠ 
Message
≠≠ &
}
ÆÆ 
;
ÆÆ 
return
∞∞ 
Json
∞∞ 
(
∞∞ 
json
∞∞  
)
∞∞  !
;
∞∞! "
}
±± 
}
≤≤ 	
[
≥≥ 	
HttpPost
≥≥	 
]
≥≥ 
[
¥¥ 	
Route
¥¥	 
(
¥¥ 
$str
¥¥ #
)
¥¥# $
]
¥¥$ %
public
µµ 
IActionResult
µµ  
UploadArticleImage
µµ /
(
µµ/ 0
	IFormFile
µµ0 9
upload
µµ: @
)
µµ@ A
{
∂∂ 	
try
∑∑ 
{
∏∏ 
string
ππ 
imageUrl
ππ 
=
ππ  !
string
ππ" (
.
ππ( )
Empty
ππ) .
;
ππ. /
if
ªª 
(
ªª 
upload
ªª 
!=
ªª 
null
ªª "
&&
ªª# %
upload
ªª& ,
.
ªª, -
Length
ªª- 3
>
ªª4 5
$num
ªª6 7
)
ªª7 8
{
ºº 
using
ΩΩ 
(
ΩΩ 
MemoryStream
ΩΩ '
ms
ΩΩ( *
=
ΩΩ+ ,
new
ΩΩ- 0
MemoryStream
ΩΩ1 =
(
ΩΩ= >
)
ΩΩ> ?
)
ΩΩ? @
{
ææ 
upload
øø 
.
øø 
CopyTo
øø %
(
øø% &
ms
øø& (
)
øø( )
;
øø) *
if
¡¡ 
(
¡¡ 
upload
¡¡ "
.
¡¡" #
ContentType
¡¡# .
.
¡¡. /

StartsWith
¡¡/ 9
(
¡¡9 :
$str
¡¡: A
)
¡¡A B
)
¡¡B C
{
¬¬ 
OptimizeImage
√√ )
(
√√) *
ms
√√* ,
)
√√, -
;
√√- .
}
ƒƒ 
byte
∆∆ 
[
∆∆ 
]
∆∆ 
	fileBytes
∆∆ (
=
∆∆) *
ms
∆∆+ -
.
∆∆- .
ToArray
∆∆. 5
(
∆∆5 6
)
∆∆6 7
;
∆∆7 8
string
»» 
	extension
»» (
=
»») *
GetFileExtension
»»+ ;
(
»»; <
upload
»»< B
)
»»B C
;
»»C D
string
   
filename
   '
=
  ( )
DateTime
  * 2
.
  2 3
Now
  3 6
.
  6 7
ToString
  7 ?
(
  ? @
$str
  @ P
)
  P Q
+
  R S
$str
  T W
+
  X Y
	extension
  Z c
;
  c d
imageUrl
ÕÕ  
=
ÕÕ! "
base
ÕÕ# '
.
ÕÕ' ( 
UploadContentImage
ÕÕ( :
(
ÕÕ: ;
CurrentUserId
ÕÕ; H
,
ÕÕH I
filename
ÕÕJ R
,
ÕÕR S
	fileBytes
ÕÕT ]
)
ÕÕ] ^
;
ÕÕ^ _
}
ŒŒ 
}
œœ 
string
–– 
baseUrl
–– 
=
––   
GetAbsoluteBaseUri
––! 3
(
––3 4
)
––4 5
;
––5 6
var
““ 
json
““ 
=
““ 
new
““ 
{
”” 
uploaded
‘‘ 
=
‘‘ 
true
‘‘ #
,
‘‘# $
url
’’ 
=
’’ 
UrlFormatter
’’ &
.
’’& '
Image
’’' ,
(
’’, -
this
’’- 1
.
’’1 2
CurrentUserId
’’2 ?
,
’’? @
BlobType
’’A I
.
’’I J
ContentImage
’’J V
,
’’V W
imageUrl
’’X `
)
’’` a
}
÷÷ 
;
÷÷ 
return
ÿÿ 
Json
ÿÿ 
(
ÿÿ 
json
ÿÿ  
)
ÿÿ  !
;
ÿÿ! "
}
ŸŸ 
catch
⁄⁄ 
(
⁄⁄ 
	Exception
⁄⁄ 
ex
⁄⁄ 
)
⁄⁄  
{
€€ 
var
‹‹ 
json
‹‹ 
=
‹‹ 
new
‹‹ 
{
›› 
error
ﬁﬁ 
=
ﬁﬁ 
ex
ﬁﬁ 
.
ﬁﬁ 
Message
ﬁﬁ &
}
ﬂﬂ 
;
ﬂﬂ 
return
·· 
Json
·· 
(
·· 
json
··  
)
··  !
;
··! "
}
‚‚ 
}
„„ 	
[
ÊÊ 	
HttpPost
ÊÊ	 
]
ÊÊ 
[
ÁÁ 	
Route
ÁÁ	 
(
ÁÁ 
$str
ÁÁ $
)
ÁÁ$ %
]
ÁÁ% &
public
ËË 
IActionResult
ËË !
UploadFeaturedImage
ËË 0
(
ËË0 1
	IFormFile
ËË1 :
featuredimage
ËË; H
,
ËËH I
Guid
ËËJ N
id
ËËO Q
,
ËËQ R
string
ËËS Y
currentImage
ËËZ f
,
ËËf g
Guid
ËËh l
userId
ËËm s
)
ËËs t
{
ÈÈ 	
try
ÍÍ 
{
ÎÎ 
string
ÏÏ 
imageUrl
ÏÏ 
=
ÏÏ  !
string
ÏÏ" (
.
ÏÏ( )
Empty
ÏÏ) .
;
ÏÏ. /
if
ÓÓ 
(
ÓÓ 
featuredimage
ÓÓ !
!=
ÓÓ" $
null
ÓÓ% )
&&
ÓÓ* ,
featuredimage
ÓÓ- :
.
ÓÓ: ;
Length
ÓÓ; A
>
ÓÓB C
$num
ÓÓD E
)
ÓÓE F
{
ÔÔ 
using
 
(
 
MemoryStream
 '
ms
( *
=
+ ,
new
- 0
MemoryStream
1 =
(
= >
)
> ?
)
? @
{
ÒÒ 
featuredimage
ÚÚ %
.
ÚÚ% &
CopyTo
ÚÚ& ,
(
ÚÚ, -
ms
ÚÚ- /
)
ÚÚ/ 0
;
ÚÚ0 1
if
ÙÙ 
(
ÙÙ 
featuredimage
ÙÙ )
.
ÙÙ) *
ContentType
ÙÙ* 5
.
ÙÙ5 6

StartsWith
ÙÙ6 @
(
ÙÙ@ A
$str
ÙÙA H
)
ÙÙH I
)
ÙÙI J
{
ıı 
OptimizeImage
ˆˆ )
(
ˆˆ) *
ms
ˆˆ* ,
)
ˆˆ, -
;
ˆˆ- .
}
˜˜ 
byte
˘˘ 
[
˘˘ 
]
˘˘ 
	fileBytes
˘˘ (
=
˘˘) *
ms
˘˘+ -
.
˘˘- .
ToArray
˘˘. 5
(
˘˘5 6
)
˘˘6 7
;
˘˘7 8
string
˚˚ 
	extension
˚˚ (
=
˚˚) *
GetFileExtension
˚˚+ ;
(
˚˚; <
featuredimage
˚˚< I
)
˚˚I J
;
˚˚J K
string
˝˝ 
filename
˝˝ '
=
˝˝( )
DateTime
˝˝* 2
.
˝˝2 3
Now
˝˝3 6
.
˝˝6 7
ToString
˝˝7 ?
(
˝˝? @
$str
˝˝@ P
)
˝˝P Q
+
˝˝R S
$str
˝˝T W
+
˝˝X Y
	extension
˝˝Z c
;
˝˝c d
if
ˇˇ 
(
ˇˇ 
userId
ˇˇ "
==
ˇˇ# %
Guid
ˇˇ& *
.
ˇˇ* +
Empty
ˇˇ+ 0
)
ˇˇ0 1
{
ÄÄ 
userId
ÅÅ "
=
ÅÅ# $
CurrentUserId
ÅÅ% 2
;
ÅÅ2 3
}
ÇÇ 
imageUrl
ÑÑ  
=
ÑÑ! "
base
ÑÑ# '
.
ÑÑ' (!
UploadFeaturedImage
ÑÑ( ;
(
ÑÑ; <
userId
ÑÑ< B
,
ÑÑB C
filename
ÑÑD L
,
ÑÑL M
	fileBytes
ÑÑN W
)
ÑÑW X
;
ÑÑX Y
}
ÖÖ 
}
ÜÜ 
if
àà 
(
àà 
!
àà 
string
àà 
.
àà  
IsNullOrWhiteSpace
àà .
(
àà. /
currentImage
àà/ ;
)
àà; <
)
àà< =
{
ââ 
if
ää 
(
ää 
!
ää 
currentImage
ää %
.
ää% &
Equals
ää& ,
(
ää, -
	Constants
ää- 6
.
ää6 7"
DefaultFeaturedImage
ää7 K
)
ääK L
)
ääL M
{
ãã 
string
åå 
currentParam
åå +
=
åå, -!
GetImageNameFromUrl
åå. A
(
ååA B
currentImage
ååB N
)
ååN O
;
ååO P
string
éé 
delete
éé %
=
éé& '
base
éé( ,
.
éé, -!
DeleteFeaturedImage
éé- @
(
éé@ A
userId
ééA G
,
ééG H
currentParam
ééI U
)
ééU V
;
ééV W
}
èè 
}
êê 
var
íí 
json
íí 
=
íí 
new
íí 
{
ìì 
size
îî 
=
îî 
featuredimage
îî (
?
îî( )
.
îî) *
Length
îî* 0
,
îî0 1
id
ïï 
=
ïï 
id
ïï 
,
ïï 
oldImage
ññ 
=
ññ 
currentImage
ññ +
,
ññ+ ,
imageUrl
óó 
=
óó 
imageUrl
óó '
}
òò 
;
òò 
return
öö 
Json
öö 
(
öö 
json
öö  
)
öö  !
;
öö! "
}
õõ 
catch
úú 
(
úú 
	Exception
úú 
ex
úú 
)
úú  
{
ùù 
var
ûû 
json
ûû 
=
ûû 
new
ûû 
{
üü 
error
†† 
=
†† 
ex
†† 
.
†† 
Message
†† &
}
°° 
;
°° 
return
££ 
Json
££ 
(
££ 
json
££  
)
££  !
;
££! "
}
§§ 
}
•• 	
private
©© 
IActionResult
©©  
ReturnDefaultImage
©© 0
(
©©0 1
BlobType
©©1 9
type
©©: >
)
©©> ?
{
™™ 	
string
´´ #
defaultImageNotRooted
´´ (
=
´´) *
GetDefaultImage
´´+ :
(
´´: ;
type
´´; ?
)
´´? @
;
´´@ A
string
≠≠ 
retorno
≠≠ 
=
≠≠ 
Path
≠≠ !
.
≠≠! "
Combine
≠≠" )
(
≠≠) *
_hostingEnv
≠≠* 5
.
≠≠5 6
WebRootPath
≠≠6 A
,
≠≠A B#
defaultImageNotRooted
≠≠C X
)
≠≠X Y
;
≠≠Y Z
byte
ØØ 
[
ØØ 
]
ØØ 
bytes
ØØ 
=
ØØ 
System
ØØ !
.
ØØ! "
IO
ØØ" $
.
ØØ$ %
File
ØØ% )
.
ØØ) *
ReadAllBytes
ØØ* 6
(
ØØ6 7
retorno
ØØ7 >
)
ØØ> ?
;
ØØ? @
return
±± 
File
±± 
(
±± 
new
±± 
MemoryStream
±± (
(
±±( )
bytes
±±) .
)
±±. /
,
±±/ 0
$str
±±1 <
)
±±< =
;
±±= >
}
≤≤ 	
private
¥¥ 
static
¥¥ 
string
¥¥ 
GetFileExtension
¥¥ .
(
¥¥. /
	IFormFile
¥¥/ 8
uploadedFile
¥¥9 E
)
¥¥E F
{
µµ 	
string
∂∂ 
[
∂∂ 
]
∂∂ 
split
∂∂ 
=
∂∂ 
uploadedFile
∂∂ )
.
∂∂) *
FileName
∂∂* 2
.
∂∂2 3
Split
∂∂3 8
(
∂∂8 9
$char
∂∂9 <
)
∂∂< =
;
∂∂= >
string
∑∑ 
	extension
∑∑ 
=
∑∑ 
split
∑∑ $
.
∑∑$ %
Length
∑∑% +
>
∑∑, -
$num
∑∑. /
?
∑∑0 1
split
∑∑2 7
[
∑∑7 8
$num
∑∑8 9
]
∑∑9 :
:
∑∑; <
$str
∑∑= B
;
∑∑B C
return
∏∏ 
	extension
∏∏ 
;
∏∏ 
}
ππ 	
private
ªª 
static
ªª 
string
ªª !
GetImageNameFromUrl
ªª 1
(
ªª1 2
string
ªª2 8
currentImage
ªª9 E
)
ªªE F
{
ºº 	
string
ΩΩ 
[
ΩΩ 
]
ΩΩ 
urlSplit
ΩΩ 
=
ΩΩ 
currentImage
ΩΩ  ,
.
ΩΩ, -
Split
ΩΩ- 2
(
ΩΩ2 3
$char
ΩΩ3 6
)
ΩΩ6 7
;
ΩΩ7 8
string
ææ 
split
ææ 
=
ææ 
urlSplit
ææ #
[
ææ# $
urlSplit
ææ$ ,
.
ææ, -
Length
ææ- 3
-
ææ4 5
$num
ææ6 7
]
ææ7 8
;
ææ8 9
return
√√ 
split
√√ 
;
√√ 
}
ƒƒ 	
private
∆∆ 
string
∆∆  
GetAbsoluteBaseUri
∆∆ )
(
∆∆) *
)
∆∆* +
{
«« 	
return
»» 
$str
»» 
+
»» !
HttpContextAccessor
»»  3
.
»»3 4
HttpContext
»»4 ?
.
»»? @
Request
»»@ G
.
»»G H
Host
»»H L
.
»»L M
ToString
»»M U
(
»»U V
)
»»V W
;
»»W X
}
…… 	
private
ÀÀ 
static
ÀÀ 
string
ÀÀ 
FormatBasePath
ÀÀ ,
(
ÀÀ, -
BlobType
ÀÀ- 5
type
ÀÀ6 :
,
ÀÀ: ;
Guid
ÀÀ< @
userId
ÀÀA G
,
ÀÀG H
string
ÀÀI O
baseUrl
ÀÀP W
,
ÀÀW X
string
ÀÀY _
storageBasePath
ÀÀ` o
)
ÀÀo p
{
ÃÃ 	
switch
ÕÕ 
(
ÕÕ 
type
ÕÕ 
)
ÕÕ 
{
ŒŒ 
case
œœ 
BlobType
œœ 
.
œœ 
ProfileImage
œœ *
:
œœ* +
storageBasePath
–– #
=
––$ %
baseUrl
––& -
+
––. /
userId
––0 6
+
––7 8
$str
––9 <
+
––= >
type
––? C
.
––C D
ToString
––D L
(
––L M
)
––M N
.
––N O
ToLower
––O V
(
––V W
)
––W X
+
––Y Z
$str
––[ ^
;
––^ _
break
—— 
;
—— 
case
““ 
BlobType
““ 
.
““ 
ProfileCover
““ *
:
““* +
storageBasePath
”” #
=
””$ %
baseUrl
””& -
+
””. /
userId
””0 6
+
””7 8
$str
””9 <
+
””= >
type
””? C
.
””C D
ToString
””D L
(
””L M
)
””M N
.
””N O
ToLower
””O V
(
””V W
)
””W X
+
””Y Z
$str
””[ ^
;
””^ _
break
‘‘ 
;
‘‘ 
case
’’ 
BlobType
’’ 
.
’’ 
GameThumbnail
’’ +
:
’’+ ,
case
÷÷ 
BlobType
÷÷ 
.
÷÷ 
	GameCover
÷÷ '
:
÷÷' (
case
◊◊ 
BlobType
◊◊ 
.
◊◊ 
ContentImage
◊◊ *
:
◊◊* +
case
ÿÿ 
BlobType
ÿÿ 
.
ÿÿ 
FeaturedImage
ÿÿ +
:
ÿÿ+ ,
default
ŸŸ 
:
ŸŸ 
storageBasePath
⁄⁄ #
=
⁄⁄$ %
baseUrl
⁄⁄& -
+
⁄⁄. /
userId
⁄⁄0 6
+
⁄⁄7 8
$str
⁄⁄9 <
;
⁄⁄< =
break
€€ 
;
€€ 
}
‹‹ 
return
ﬁﬁ 
storageBasePath
ﬁﬁ "
;
ﬁﬁ" #
}
ﬂﬂ 	
private
·· 
static
·· 
string
·· 
GetDefaultImage
·· -
(
··- .
BlobType
··. 6
type
··7 ;
)
··; <
{
‚‚ 	
string
„„ #
defaultImageNotRooted
„„ (
=
„„) *
string
„„+ 1
.
„„1 2
Empty
„„2 7
;
„„7 8
switch
ÂÂ 
(
ÂÂ 
type
ÂÂ 
)
ÂÂ 
{
ÊÊ 
case
ÁÁ 
BlobType
ÁÁ 
.
ÁÁ 
ProfileImage
ÁÁ *
:
ÁÁ* +#
defaultImageNotRooted
ËË )
=
ËË* +
	Constants
ËË, 5
.
ËË5 6
DefaultAvatar
ËË6 C
;
ËËC D
break
ÈÈ 
;
ÈÈ 
case
ÍÍ 
BlobType
ÍÍ 
.
ÍÍ 
ProfileCover
ÍÍ *
:
ÍÍ* +#
defaultImageNotRooted
ÎÎ )
=
ÎÎ* +
	Constants
ÎÎ, 5
.
ÎÎ5 6&
DefaultProfileCoverImage
ÎÎ6 N
;
ÎÎN O
break
ÏÏ 
;
ÏÏ 
case
ÌÌ 
BlobType
ÌÌ 
.
ÌÌ 
GameThumbnail
ÌÌ +
:
ÌÌ+ ,#
defaultImageNotRooted
ÓÓ )
=
ÓÓ* +
	Constants
ÓÓ, 5
.
ÓÓ5 6"
DefaultGameThumbnail
ÓÓ6 J
;
ÓÓJ K
break
ÔÔ 
;
ÔÔ 
case
 
BlobType
 
.
 
	GameCover
 '
:
' (#
defaultImageNotRooted
ÒÒ )
=
ÒÒ* +
	Constants
ÒÒ, 5
.
ÒÒ5 6#
DefaultGameCoverImage
ÒÒ6 K
;
ÒÒK L
break
ÚÚ 
;
ÚÚ 
case
ÛÛ 
BlobType
ÛÛ 
.
ÛÛ 
ContentImage
ÛÛ *
:
ÛÛ* +#
defaultImageNotRooted
ÙÙ )
=
ÙÙ* +
	Constants
ÙÙ, 5
.
ÙÙ5 6"
DefaultGameThumbnail
ÙÙ6 J
;
ÙÙJ K
break
ıı 
;
ıı 
case
ˆˆ 
BlobType
ˆˆ 
.
ˆˆ 
FeaturedImage
ˆˆ +
:
ˆˆ+ ,#
defaultImageNotRooted
˜˜ )
=
˜˜* +
	Constants
˜˜, 5
.
˜˜5 6"
DefaultFeaturedImage
˜˜6 J
;
˜˜J K
break
¯¯ 
;
¯¯ 
default
˘˘ 
:
˘˘ #
defaultImageNotRooted
˙˙ )
=
˙˙* +
	Constants
˙˙, 5
.
˙˙5 6
DefaultAvatar
˙˙6 C
;
˙˙C D
break
˚˚ 
;
˚˚ 
}
¸¸ #
defaultImageNotRooted
˛˛ !
=
˛˛" ##
defaultImageNotRooted
˛˛$ 9
.
˛˛9 :
	Substring
˛˛: C
(
˛˛C D
$num
˛˛D E
)
˛˛E F
.
˛˛F G
Replace
˛˛G N
(
˛˛N O
$str
˛˛O S
,
˛˛S T
$str
˛˛U Y
)
˛˛Y Z
;
˛˛Z [
return
ÄÄ #
defaultImageNotRooted
ÄÄ (
;
ÄÄ( )
}
ÅÅ 	
private
ÉÉ 
static
ÉÉ 
void
ÉÉ 
OptimizeImage
ÉÉ )
(
ÉÉ) *
MemoryStream
ÉÉ* 6
ms
ÉÉ7 9
)
ÉÉ9 :
{
ÑÑ 	
ms
ÖÖ 
.
ÖÖ 
Position
ÖÖ 
=
ÖÖ 
$num
ÖÖ 
;
ÖÖ 
ImageOptimizer
áá 
	optimizer
áá $
=
áá% &
new
áá' *
ImageOptimizer
áá+ 9
(
áá9 :
)
áá: ;
;
áá; <
	optimizer
àà 
.
àà 
LosslessCompress
àà &
(
àà& '
ms
àà' )
)
àà) *
;
àà* +
}
íí 	
}
îî 
}ïï ≥
fC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Controllers\UserController.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Controllers &
{ 
public 

class 
UserController 
:  ! 
SecureBaseController" 6
{ 
private 
readonly 
IProfileAppService +
_profileAppService, >
;> ?
public 
UserController 
( 
IProfileAppService 0
profileAppService1 B
)B C
:D E
baseF J
(J K
)K L
{ 	
_profileAppService 
=  
profileAppService! 2
;2 3
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
ProfileViewModel 
model "
=# $
FakeData% -
.- .
FakeProfile. 9
(9 :
): ;
;; <
return 
View 
( 
model 
) 
; 
} 	
public   
IActionResult   
Edit   !
(  ! "
)  " #
{!! 	
return"" 
View"" 
("" 
)"" 
;"" 
}## 	
[%% 	
	Authorize%%	 
]%% 
public&& 
IActionResult&& 
List&& !
(&&! "
)&&" #
{'' 	!
OperationResultListVo(( !
<((! "
ProfileViewModel((" 2
>((2 3
serviceResult((4 A
=((B C
_profileAppService((D V
.((V W
GetAll((W ]
(((] ^
)((^ _
;((_ `
List** 
<** 
ProfileViewModel** !
>**! "
profiles**# +
=**, -
serviceResult**. ;
.**; <
Value**< A
.**A B
OrderByDescending**B S
(**S T
x**T U
=>**V X
x**Y Z
.**Z [

CreateDate**[ e
)**e f
.**f g
ToList**g m
(**m n
)**n o
;**o p
foreach,, 
(,, 
var,, 
profile,,  
in,,! #
profiles,,$ ,
),,, -
{-- 
profile.. 
... 
ProfileImageUrl.. '
=..( )
UrlFormatter..* 6
...6 7
ProfileImage..7 C
(..C D
profile..D K
...K L
UserId..L R
)..R S
;..S T
profile// 
.// 
CoverImageUrl// %
=//& '
UrlFormatter//( 4
.//4 5
ProfileCoverImage//5 F
(//F G
profile//G N
.//N O
UserId//O U
,//U V
profile//W ^
.//^ _
Id//_ a
)//a b
;//b c
}00 
return22 
View22 
(22 
profiles22  
)22  !
;22! "
}33 	
}44 
}55 ô
_C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Enums\SessionValues.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Enums  
{ 
public 

enum 
SessionValues 
{		 
Username

 
=

 
$num

 
,

 
UserProfileImageUrl 
= 
$num 
,  
FullName 
= 
$num 
} 
} Ú
gC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Extensions\AutoMapperConfig.cs
	namespace 	
IndieVisible
 
. 
Web 
. 

Extensions %
{ 
public 

static 
class 
AutoMapperSetup '
{		 
public

 
static

 
void

 
AddAutoMapperSetup

 -
(

- .
this

. 2
IServiceCollection

3 E
services

F N
)

N O
{ 	
if 
( 
services 
== 
null  
)  !
{ 
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7
services7 ?
)? @
)@ A
;A B
} 
services 
. 
AddAutoMapper "
(" #
)# $
;$ %
AutoMapperConfig 
. 
RegisterMappings -
(- .
). /
;/ 0
} 	
} 
} ƒ
lC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Extensions\IEnumerableExtensions.cs
	namespace 	
IndieVisible
 
. 
Web 
. 

Extensions %
{		 
public

 

static

 
class

 !
IEnumerableExtensions

 -
{ 
public 
static 
List 
< 
SelectListItem )
>) *
ToSelectList+ 7
(7 8
this8 <
IEnumerable= H
<H I
SelectListItemVoI Y
>Y Z
items[ `
)` a
{ 	
List 
< 
SelectListItem 
>  
	finalList! *
=+ ,
new- 0
List1 5
<5 6
SelectListItem6 D
>D E
(E F
)F G
;G H
foreach 
( 
var 
item 
in  
items! &
)& '
{ 
var 
sli 
= 
new 
SelectListItem ,
{ 
Value 
= 
item  
.  !
Value! &
,& '
Text 
= 
item 
.  
Text  $
} 
; 
	finalList 
. 
Add 
( 
sli !
)! "
;" #
} 
return 
	finalList 
; 
} 	
} 
} Ú
jC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Extensions\UrlHelperExtensions.cs
	namespace 	
	Microsoft
 
. 

AspNetCore 
. 
Mvc "
{ 
public		 

static		 
class		 
UrlHelperExtensions		 +
{

 
public 
static 
string !
EmailConfirmationLink 2
(2 3
this3 7

IUrlHelper8 B
	urlHelperC L
,L M
stringN T
userIdU [
,[ \
string] c
coded h
,h i
stringj p
schemeq w
)w x
{ 	
return 
	urlHelper 
. 
Action #
(# $
action 
: 
nameof 
( 
AccountController 0
.0 1
ConfirmEmail1 =
)= >
,> ?

controller 
: 
$str %
,% &
values 
: 
new 
{ 
userId $
,$ %
code& *
}+ ,
,, -
protocol 
: 
scheme  
)  !
;! "
} 	
public 
static 
string %
ResetPasswordCallbackLink 6
(6 7
this7 ;

IUrlHelper< F
	urlHelperG P
,P Q
stringR X
userIdY _
,_ `
stringa g
codeh l
,l m
stringn t
schemeu {
){ |
{ 	
return 
	urlHelper 
. 
Action #
(# $
action 
: 
nameof 
( 
AccountController 0
.0 1
ResetPassword1 >
)> ?
,? @

controller 
: 
$str %
,% &
values 
: 
new 
{ 
userId $
,$ %
code& *
}+ ,
,, -
protocol 
: 
scheme  
)  !
;! "
} 	
} 
} ‹,
äC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Extensions\ViewModelExtensions\NotificationViewModelExtensions.cs
	namespace 	
IndieVisible
 
. 
Web 
. 

Extensions %
.% &
ViewModelExtensions& 9
{ 
public		 

static		 
class		 +
NotificationViewModelExtensions		 7
{

 
public 
static 
void 
DefineVisuals (
(( )
this) -
List. 2
<2 3%
NotificationItemViewModel3 L
>L M
vmN P
)P Q
{ 	
foreach 
( 
var 
item 
in  
vm! #
)# $
{ 
switch 
( 
item 
. 
Type !
)! "
{ 
case 
Domain 
.  
Core  $
.$ %
Enums% *
.* +
NotificationType+ ;
.; <
ContentLike< G
:G H
item 
. 
Icon !
=" #
$str$ 2
;2 3
item 
. 
	IconColor &
=' (
$str) 3
;3 4
break 
; 
case 
Domain 
.  
Core  $
.$ %
Enums% *
.* +
NotificationType+ ;
.; <
GameLike< D
:D E
item 
. 
Icon !
=" #
$str$ 2
;2 3
item 
. 
	IconColor &
=' (
$str) 3
;3 4
break 
; 
case 
Domain 
.  
Core  $
.$ %
Enums% *
.* +
NotificationType+ ;
.; <
ContentComment< J
:J K
item 
. 
Icon !
=" #
$str$ 4
;4 5
item 
. 
	IconColor &
=' (
$str) 5
;5 6
break 
; 
case 
Domain 
.  
Core  $
.$ %
Enums% *
.* +
NotificationType+ ;
.; <
ConnectionRequest< M
:M N
item   
.   
Icon   !
=  " #
$str  $ 6
;  6 7
item!! 
.!! 
	IconColor!! &
=!!' (
$str!!) 6
;!!6 7
break"" 
;"" 
case## 
Domain## 
.##  
Core##  $
.##$ %
Enums##% *
.##* +
NotificationType##+ ;
.##; <
	FollowYou##< E
:##E F
item$$ 
.$$ 
Icon$$ !
=$$" #
$str$$$ 0
;$$0 1
item%% 
.%% 
	IconColor%% &
=%%' (
$str%%) 4
;%%4 5
break&& 
;&& 
case'' 
Domain'' 
.''  
Core''  $
.''$ %
Enums''% *
.''* +
NotificationType''+ ;
.''; <
FollowYourGame''< J
:''J K
item(( 
.(( 
Icon(( !
=((" #
$str(($ 0
;((0 1
item)) 
.)) 
	IconColor)) &
=))' (
$str))) 6
;))6 7
break** 
;** 
case++ 
Domain++ 
.++  
Core++  $
.++$ %
Enums++% *
.++* +
NotificationType+++ ;
.++; <
AchivementEarned++< L
:++L M
item,, 
.,, 
Icon,, !
=,," #
$str,,$ 7
;,,7 8
item-- 
.-- 
	IconColor-- &
=--' (
$str--) 5
;--5 6
break.. 
;.. 
case// 
Domain// 
.//  
Core//  $
.//$ %
Enums//% *
.//* +
NotificationType//+ ;
.//; <
LevelUp//< C
://C D
item00 
.00 
Icon00 !
=00" #
$str00$ 7
;007 8
item11 
.11 
	IconColor11 &
=11' (
$str11) 5
;115 6
break22 
;22 
case33 
Domain33 
.33  
Core33  $
.33$ %
Enums33% *
.33* +
NotificationType33+ ;
.33; < 
ArticleAboutYourGame33< P
:33P Q
item44 
.44 
Icon44 !
=44" #
$str44$ 7
;447 8
item55 
.55 
	IconColor55 &
=55' (
$str55) 5
;555 6
break66 
;66 
case77 
Domain77 
.77  
Core77  $
.77$ %
Enums77% *
.77* +
NotificationType77+ ;
.77; <
ContentPosted77< I
:77I J
item88 
.88 
Icon88 !
=88" #
$str88$ 5
;885 6
item99 
.99 
	IconColor99 &
=99' (
$str99) 5
;995 6
break:: 
;:: 
default;; 
:;; 
item<< 
.<< 
Icon<< !
=<<" #
$str<<$ 7
;<<7 8
item== 
.== 
	IconColor== &
===' (
$str==) 5
;==5 6
break>> 
;>> 
}?? 
}@@ 
}AA 	
}BB 
}CC ¬9
aC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Filters\EtagAttribute.cs
	namespace

 	
IndieVisible


 
.

 
Web

 
{ 
public 

class 
EtagAttribute 
:  
	Attribute! *
,* +
IActionFilter, 9
{ 
private 
readonly 
int 
[ 
] 
_statusCodes +
;+ ,
public 
EtagAttribute 
( 
params #
int$ '
[' (
]( )
statusCodes* 5
)5 6
{ 	
_statusCodes 
= 
statusCodes &
;& '
if 
( 
statusCodes 
. 
Length "
==# %
$num& '
)' (
{ 
_statusCodes 
= 
new "
[" #
]# $
{% &
$num' *
}+ ,
;, -
} 
} 	
public 
void 
OnActionExecuting %
(% &"
ActionExecutingContext& <
context= D
)D E
{ 	
} 	
public 
void 
OnActionExecuted $
($ %!
ActionExecutedContext% :
context; B
)B C
{ 	
if 
( 
context 
. 
HttpContext #
.# $
Request$ +
.+ ,
Method, 2
==3 5
$str6 ;
); <
{   
if!! 
(!! 
_statusCodes!!  
.!!  !
Contains!!! )
(!!) *
context!!* 1
.!!1 2
HttpContext!!2 =
.!!= >
Response!!> F
.!!F G

StatusCode!!G Q
)!!Q R
)!!R S
{"" 
var$$ 
test$$ 
=$$ 
context$$ &
.$$& '
Result$$' -
;$$- .
string&& 
content&& "
=&&# $
JsonConvert&&% 0
.&&0 1
SerializeObject&&1 @
(&&@ A
context&&A H
.&&H I
Result&&I O
)&&O P
;&&P Q
string(( 
etag(( 
=((  !
ETagGenerator((" /
.((/ 0
GetETag((0 7
(((7 8
context((8 ?
.((? @
HttpContext((@ K
.((K L
Request((L S
.((S T
Path((T X
.((X Y
ToString((Y a
(((a b
)((b c
,((c d
Encoding((e m
.((m n
UTF8((n r
.((r s
GetBytes((s {
((({ |
content	((| É
)
((É Ñ
)
((Ñ Ö
;
((Ö Ü
if** 
(** 
context** 
.**  
HttpContext**  +
.**+ ,
Request**, 3
.**3 4
Headers**4 ;
.**; <
Keys**< @
.**@ A
Contains**A I
(**I J
HeaderNames**J U
.**U V
IfNoneMatch**V a
)**a b
&&**c e
context**f m
.**m n
HttpContext**n y
.**y z
Request	**z Å
.
**Å Ç
Headers
**Ç â
[
**â ä
HeaderNames
**ä ï
.
**ï ñ
IfNoneMatch
**ñ °
]
**° ¢
.
**¢ £
ToString
**£ ´
(
**´ ¨
)
**¨ ≠
==
**Æ ∞
etag
**± µ
)
**µ ∂
{++ 
context,, 
.,,  
Result,,  &
=,,' (
new,,) ,
StatusCodeResult,,- =
(,,= >
$num,,> A
),,A B
;,,B C
}-- 
context.. 
... 
HttpContext.. '
...' (
Response..( 0
...0 1
Headers..1 8
...8 9
Add..9 <
(..< =
HeaderNames..= H
...H I
ETag..I M
,..M N
new..O R
[..R S
]..S T
{..U V
etag..W [
}..\ ]
)..] ^
;..^ _
}// 
}00 
}11 	
}22 
public55 

static55 
class55 
ETagGenerator55 %
{66 
public77 
static77 
string77 
GetETag77 $
(77$ %
string77% +
key77, /
,77/ 0
byte771 5
[775 6
]776 7
contentBytes778 D
)77D E
{88 	
byte99 
[99 
]99 
keyBytes99 
=99 
Encoding99 &
.99& '
UTF899' +
.99+ ,
GetBytes99, 4
(994 5
key995 8
)998 9
;999 :
byte:: 
[:: 
]:: 
combinedBytes::  
=::! "
Combine::# *
(::* +
keyBytes::+ 3
,::3 4
contentBytes::5 A
)::A B
;::B C
return<< 
GenerateETag<< 
(<<  
combinedBytes<<  -
)<<- .
;<<. /
}== 	
private?? 
static?? 
string?? 
GenerateETag?? *
(??* +
byte??+ /
[??/ 0
]??0 1
data??2 6
)??6 7
{@@ 	
usingAA 
(AA 
MD5AA 
md5AA 
=AA 
MD5AA  
.AA  !
CreateAA! '
(AA' (
)AA( )
)AA) *
{BB 
byteCC 
[CC 
]CC 
hashCC 
=CC 
md5CC !
.CC! "
ComputeHashCC" -
(CC- .
dataCC. 2
)CC2 3
;CC3 4
stringDD 
hexDD 
=DD 
BitConverterDD )
.DD) *
ToStringDD* 2
(DD2 3
hashDD3 7
)DD7 8
;DD8 9
returnEE 
hexEE 
.EE 
ReplaceEE "
(EE" #
$strEE# &
,EE& '
$strEE( *
)EE* +
;EE+ ,
}FF 
}GG 	
privateII 
staticII 
byteII 
[II 
]II 
CombineII %
(II% &
byteII& *
[II* +
]II+ ,
aII- .
,II. /
byteII0 4
[II4 5
]II5 6
bII7 8
)II8 9
{JJ 	
byteKK 
[KK 
]KK 
cKK 
=KK 
newKK 
byteKK 
[KK  
aKK  !
.KK! "
LengthKK" (
+KK) *
bKK+ ,
.KK, -
LengthKK- 3
]KK3 4
;KK4 5
BufferLL 
.LL 
	BlockCopyLL 
(LL 
aLL 
,LL 
$numLL  !
,LL! "
cLL# $
,LL$ %
$numLL& '
,LL' (
aLL) *
.LL* +
LengthLL+ 1
)LL1 2
;LL2 3
BufferMM 
.MM 
	BlockCopyMM 
(MM 
bMM 
,MM 
$numMM  !
,MM! "
cMM# $
,MM$ %
aMM& '
.MM' (
LengthMM( .
,MM. /
bMM0 1
.MM1 2
LengthMM2 8
)MM8 9
;MM9 :
returnNN 
cNN 
;NN 
}OO 	
}PP 
}QQ Â
ÇC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Middlewares\CanonicalUrl\CanonicalMiddlewareExtensions.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Middlewares &
.& '
CanonicalUrl' 3
{ 
public 

static 
class ,
 CanonicalUrlMiddlewareExtensions 8
{8 9
public 
static 
IApplicationBuilder )%
UseCanonicalUrlMiddleware* C
(C D
thisD H
IApplicationBuilderI \
builder] d
,d e*
CanonicalURLMiddlewareOptions	f É
options
Ñ ã
)
ã å
{ 	
return		 
builder		 
.		 
UseMiddleware		 (
<		( )"
CanonicalURLMiddleware		) ?
>		? @
(		@ A
options		A H
)		H I
;		I J
}

 	
} 
} ¨'
{C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Middlewares\CanonicalUrl\CanonicalUrlMiddleware.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Middlewares &
.& '
CanonicalUrl' 3
{ 
public 

class "
CanonicalURLMiddleware '
{ 
private 
readonly 
RequestDelegate (
_next) .
;. /
private		 
readonly		 )
CanonicalURLMiddlewareOptions		 6
_options		7 ?
;		? @
public "
CanonicalURLMiddleware %
(% &
RequestDelegate& 5
next6 :
,: ;)
CanonicalURLMiddlewareOptions< Y
optionsZ a
)a b
{b c
_next 
= 
next 
; 
_options 
= 
options 
; 
} 	
public 
async 
Task 
Invoke  
(  !
HttpContext! ,
context- 4
)4 5
{5 6
var 
canonicalUrl 
= 
context &
.& '
Request' .
.. /
Path/ 3
.3 4
ToString4 <
(< =
)= >
;> ?
if 
( 
_options 
. 
TrailingSlash %
)% &
{ 
if 
( 
canonicalUrl  
.  !
Length! '
>( )
$num* +
&&, .
!/ 0
string0 6
.6 7
Equals7 =
(= >
canonicalUrl> J
[J K
canonicalUrlK W
.W X
LengthX ^
-_ `
$numa b
]b c
,c d
$chare h
)h i
)i j
{ 
canonicalUrl  
=! "
canonicalUrl# /
+0 1
$str2 5
;5 6
} 
} 
else 
{ 
if 
( 
canonicalUrl  
.  !
Length! '
>( )
$num* +
&&, .
string/ 5
.5 6
Equals6 <
(< =
canonicalUrl= I
[I J
canonicalUrlJ V
.V W
LengthW ]
-^ _
$num` a
]a b
,b c
$chard g
)g h
)h i
{ 
canonicalUrl  
=! "
canonicalUrl# /
./ 0
	Substring0 9
(9 :
$num: ;
,; <
canonicalUrl= I
.I J
LengthJ P
-Q R
$numS T
)T U
;U V
} 
} 
var!! 
queryString!! 
=!! 
context!! %
.!!% &
Request!!& -
.!!- .
QueryString!!. 9
.!!9 :
ToString!!: B
(!!B C
)!!C D
;!!D E
if"" 
("" 
_options"" 
."" 
LowerCaseUrls"" %
)""% &
{## 
if%% 
(%% 
_options%% 
.%% $
QueryStringCaseSensitive%% 5
&&%%6 8
!%%9 :
string%%: @
.%%@ A
IsNullOrEmpty%%A N
(%%N O
queryString%%O Z
)%%Z [
)%%[ \
{&& 
canonicalUrl''  
=''! "
canonicalUrl''# /
.''/ 0
ToLower''0 7
(''7 8
)''8 9
+'': ;
queryString''< G
;''G H
}(( 
else)) 
{** 
canonicalUrl++  
=++! "
(++# $
canonicalUrl++$ 0
+++1 2
queryString++3 >
)++> ?
.++? @
ToLower++@ G
(++G H
)++H I
;++I J
;++K L
},, 
}-- 
var// 
oldPath// 
=// 
context// !
.//! "
Request//" )
.//) *
Path//* .
.//. /
ToString/// 7
(//7 8
)//8 9
+//: ;
context//< C
.//C D
Request//D K
.//K L
QueryString//L W
.//W X
ToString//X `
(//` a
)//a b
;//b c
if00 
(00 
!00 
string00 
.00 
Equals00 
(00 
canonicalUrl00 *
,00* +
oldPath00, 3
)003 4
)004 5
{11 
context22 
.22 
Response22  
.22  !
Redirect22! )
(22) *
canonicalUrl22* 6
)226 7
;227 8
}33 
await55 
_next55 
.55 
Invoke55 
(55 
context55 &
)55& '
;55' (
}66 	
}77 
}88 í
ÇC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Middlewares\CanonicalUrl\CanonicalUrlMiddlewareOptions.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Middlewares &
.& '
CanonicalUrl' 3
{ 
public

 

class

 )
CanonicalURLMiddlewareOptions

 .
{ 
public 
bool 
LowerCaseUrls !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
bool $
QueryStringCaseSensitive ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
bool 
TrailingSlash !
{" #
get$ '
;' (
set) ,
;, -
}. /
public )
CanonicalURLMiddlewareOptions ,
(, -
)- .
{. /
}/ 0
} 
}   ¬-
fC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Middlewares\ETagMiddleware.cs
	namespace		 	
IndieVisible		
 
.		 
Web		 
.		 
Middlewares		 &
{

 
public 

class 
ETagMiddleware 
{ 
private 
readonly 
RequestDelegate (
_next) .
;. /
public 
ETagMiddleware 
( 
RequestDelegate -
next. 2
)2 3
{ 	
_next 
= 
next 
; 
} 	
public 
async 
Task 
InvokeAsync %
(% &
HttpContext& 1
context2 9
)9 :
{ 	
HttpResponse 
response !
=" #
context$ +
.+ ,
Response, 4
;4 5
Stream 
originalStream !
=" #
response$ ,
., -
Body- 1
;1 2
using 
( 
MemoryStream 
ms  "
=# $
new% (
MemoryStream) 5
(5 6
)6 7
)7 8
{ 
response 
. 
Body 
= 
ms  "
;" #
await 
_next 
( 
context #
)# $
;$ %
if 
( 
IsEtagSupported #
(# $
response$ ,
), -
)- .
{   
string!! 
checksum!! #
=!!$ %
CalculateChecksum!!& 7
(!!7 8
ms!!8 :
)!!: ;
;!!; <
response## 
.## 
Headers## $
[##$ %
HeaderNames##% 0
.##0 1
ETag##1 5
]##5 6
=##7 8
checksum##9 A
;##A B
if%% 
(%% 
context%% 
.%%  
Request%%  '
.%%' (
Headers%%( /
.%%/ 0
TryGetValue%%0 ;
(%%; <
HeaderNames%%< G
.%%G H
IfNoneMatch%%H S
,%%S T
out%%U X
	Microsoft%%Y b
.%%b c

Extensions%%c m
.%%m n

Primitives%%n x
.%%x y
StringValues	%%y Ö
etag
%%Ü ä
)
%%ä ã
&&
%%å é
checksum
%%è ó
==
%%ò ö
etag
%%õ ü
)
%%ü †
{&& 
response''  
.''  !

StatusCode''! +
='', -
StatusCodes''. 9
.''9 : 
Status304NotModified'': N
;''N O
return(( 
;(( 
})) 
}** 
ms,, 
.,, 
Position,, 
=,, 
$num,, 
;,,  
await-- 
ms-- 
.-- 
CopyToAsync-- $
(--$ %
originalStream--% 3
)--3 4
;--4 5
}.. 
}// 	
private11 
static11 
bool11 
IsEtagSupported11 +
(11+ ,
HttpResponse11, 8
response119 A
)11A B
{22 	
if33 
(33 
response33 
.33 

StatusCode33 #
!=33$ &
StatusCodes33' 2
.332 3
Status200OK333 >
)33> ?
{44 
return55 
false55 
;55 
}66 
if99 
(99 
response99 
.99 
Body99 
.99 
Length99 $
>99% &
$num99' )
*99* +
$num99, 0
)990 1
{:: 
return;; 
false;; 
;;; 
}<< 
if>> 
(>> 
response>> 
.>> 
Headers>>  
.>>  !
ContainsKey>>! ,
(>>, -
HeaderNames>>- 8
.>>8 9
ETag>>9 =
)>>= >
)>>> ?
{?? 
return@@ 
false@@ 
;@@ 
}AA 
returnCC 
trueCC 
;CC 
}DD 	
privateFF 
staticFF 
stringFF 
CalculateChecksumFF /
(FF/ 0
MemoryStreamFF0 <
msFF= ?
)FF? @
{GG 	
stringHH 
checksumHH 
=HH 
$strHH  
;HH  !
usingJJ 
(JJ 
SHA1JJ 
algoJJ 
=JJ 
SHA1JJ #
.JJ# $
CreateJJ$ *
(JJ* +
)JJ+ ,
)JJ, -
{KK 
msLL 
.LL 
PositionLL 
=LL 
$numLL 
;LL  
byteMM 
[MM 
]MM 
bytesMM 
=MM 
algoMM #
.MM# $
ComputeHashMM$ /
(MM/ 0
msMM0 2
)MM2 3
;MM3 4
checksumNN 
=NN 
$"NN 
\"NN 
{NN  
WebEncodersNN  +
.NN+ ,
Base64UrlEncodeNN, ;
(NN; <
bytesNN< A
)NNA B
}NNB C
\"NNC E
"NNE F
;NNF G
}OO 
returnQQ 
checksumQQ 
;QQ 
}RR 	
}SS 
publicUU 

staticUU 
classUU (
ApplicationBuilderExtensionsUU 4
{VV 
publicWW 
staticWW 
voidWW 

UseETaggerWW %
(WW% &
thisWW& *
IApplicationBuilderWW+ >
appWW? B
)WWB C
{XX 	
appYY 
.YY 
UseMiddlewareYY 
<YY 
ETagMiddlewareYY ,
>YY, -
(YY- .
)YY. /
;YY/ 0
}ZZ 	
}[[ 
}\\ úÖ
iC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Middlewares\SitemapMiddleware.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Middlewares &
{ 
public 

class 
SitemapMiddleware "
{ 
private 
RequestDelegate 
_next  %
;% &
private 
string 
_rootUrl 
;  
private 
List 
< 
string 
> 
forbiddenAreas +
;+ ,
private 
List 
< 
KeyValuePair !
<! "
string" (
,( )
string* 0
>0 1
>1 2
	forbidden3 <
;< =
public 
SitemapMiddleware  
(  !
RequestDelegate! 0
next1 5
,5 6
string7 =
rootUrl> E
)E F
{ 	
_next 
= 
next 
; 
_rootUrl 
= 
rootUrl 
; 
forbiddenAreas 
= 
new  
List! %
<% &
string& ,
>, -
(- .
). /
;/ 0
forbiddenAreas 
. 
Add 
( 
$str '
)' (
;( )
forbiddenAreas 
. 
Add 
( 
$str &
)& '
;' (
	forbidden 
= 
new 
List  
<  !
KeyValuePair! -
<- .
string. 4
,4 5
string6 <
>< =
>= >
(> ?
)? @
;@ A
	forbidden   
.   
Add   
(   
$str   "
,  " #
$str  $ '
)  ' (
;  ( )
	forbidden!! 
.!! 
Add!! 
(!! 
$str!! #
,!!# $
$str!!% (
)!!( )
;!!) *
	forbidden"" 
."" 
Add"" 
("" 
$str""  
,""  !
$str""" %
)""% &
;""& '
	forbidden$$ 
.$$ 
Add$$ 
($$ 
$str$$ #
,$$# $
$str$$% .
)$$. /
;$$/ 0
	forbidden%% 
.%% 
Add%% 
(%% 
$str%% #
,%%# $
$str%%% 4
)%%4 5
;%%5 6
	forbidden&& 
.&& 
Add&& 
(&& 
$str&& #
,&&# $
$str&&% 4
)&&4 5
;&&5 6
	forbidden'' 
.'' 
Add'' 
('' 
$str'' #
,''# $
$str''% A
)''A B
;''B C
	forbidden(( 
.(( 
Add(( 
((( 
$str(( #
,((# $
$str((% @
)((@ A
;((A B
	forbidden)) 
.)) 
Add)) 
()) 
$str)) #
,))# $
$str))% 3
)))3 4
;))4 5
	forbidden** 
.** 
Add** 
(** 
$str**  
,**  !
$str**" 0
)**0 1
;**1 2
	forbidden++ 
.++ 
Add++ 
(++ 
$str++ "
,++" #
$str++$ ?
)++? @
;++@ A
	forbidden,, 
.,, 
Add,, 
(,, 
$str,, "
,,," #
$str,,$ 7
),,7 8
;,,8 9
	forbidden-- 
.-- 
Add-- 
(-- 
$str-- "
,--" #
$str--$ +
)--+ ,
;--, -
	forbidden.. 
... 
Add.. 
(.. 
$str.. "
,.." #
$str..$ 7
)..7 8
;..8 9
	forbidden// 
.// 
Add// 
(// 
$str//  
,//  !
$str//" *
)//* +
;//+ ,
	forbidden00 
.00 
Add00 
(00 
$str00  
,00  !
$str00" ,
)00, -
;00- .
	forbidden11 
.11 
Add11 
(11 
$str11 #
,11# $
$str11% +
)11+ ,
;11, -
	forbidden33 
.33 
Add33 
(33 
$str33 
,33 
$str33 %
)33% &
;33& '
}44 	
public66 
async66 
Task66 
Invoke66  
(66  !
HttpContext66! ,
context66- 4
)664 5
{77 	
if88 
(88 
context88 
.88 
Request88 
.88  
Path88  $
.88$ %
Value88% *
.88* +
Equals88+ 1
(881 2
$str882 @
,88@ A
StringComparison88B R
.88R S
OrdinalIgnoreCase88S d
)88d e
)88e f
{99 
Stream:: 
stream:: 
=:: 
context::  '
.::' (
Response::( 0
.::0 1
Body::1 5
;::5 6
context;; 
.;; 
Response;;  
.;;  !

StatusCode;;! +
=;;, -
$num;;. 1
;;;1 2
context<< 
.<< 
Response<<  
.<<  !
ContentType<<! ,
=<<- .
$str<</ @
;<<@ A
string== 
sitemapContent== %
===& '
$str==( h
;==h i
Assembly?? 
assembly?? !
=??" #
Assembly??$ ,
.??, - 
GetExecutingAssembly??- A
(??A B
)??B C
;??C D
ListAA 
<AA 
TypeAA 
>AA 
controllersAA &
=AA' (
assemblyAA) 1
.AA1 2
GetTypesAA2 :
(AA: ;
)AA; <
.BB 
WhereBB 
(BB 
typeBB 
=>BB  "
typeofBB# )
(BB) *

ControllerBB* 4
)BB4 5
.BB5 6
IsAssignableFromBB6 F
(BBF G
typeBBG K
)BBK L
||CC 
typeCC 
.CC 
NameCC  
.CC  !
EndsWithCC! )
(CC) *
$strCC* 6
)CC6 7
)CC7 8
.CC8 9
ToListCC9 ?
(CC? @
)CC@ A
;CCA B
foreachEE 
(EE 
TypeEE 

controllerEE (
inEE) +
controllersEE, 7
)EE7 8
{FF 
IEnumerableGG 
<GG  

MethodInfoGG  *
>GG* +
methodsGG, 3
=GG4 5

controllerGG6 @
.GG@ A

GetMethodsGGA K
(GGK L
BindingFlagsGGL X
.GGX Y
PublicGGY _
|GG` a
BindingFlagsGGb n
.GGn o
InstanceGGo w
|GGx y
BindingFlags	GGz Ü
.
GGÜ á
DeclaredOnly
GGá ì
)
GGì î
.HH 
WhereHH 
(HH 
methodHH %
=>HH& (
typeofHH) /
(HH/ 0
IActionResultHH0 =
)HH= >
.HH> ?
IsAssignableFromHH? O
(HHO P
methodHHP V
.HHV W

ReturnTypeHHW a
)HHa b
)HHb c
;HHc d
foreachII 
(II 

MethodInfoII '
methodII( .
inII/ 1
methodsII2 9
)II9 :
{JJ 
varKK 
controllerNameKK *
=KK+ ,

controllerKK- 7
.KK7 8
NameKK8 <
.KK< =
ToLowerKK= D
(KKD E
)KKE F
.KKF G
ReplaceKKG N
(KKN O
$strKKO [
,KK[ \
$strKK] _
)KK_ `
;KK` a
varLL 

actionNameLL &
=LL' (
methodLL) /
.LL/ 0
NameLL0 4
.LL4 5
ToLowerLL5 <
(LL< =
)LL= >
;LL> ?
varNN 
isForbiddenNN '
=NN( )
	forbiddenNN* 3
.NN3 4
ContainsNN4 <
(NN< =
newNN= @
KeyValuePairNNA M
<NNM N
stringNNN T
,NNT U
stringNNV \
>NN\ ]
(NN] ^
controllerNameNN^ l
,NNl m

actionNameNNn x
)NNx y
)NNy z
;NNz {
isForbiddenOO #
=OO$ %
isForbiddenOO& 1
||OO2 4
	forbiddenOO5 >
.OO> ?
ContainsOO? G
(OOG H
newOOH K
KeyValuePairOOL X
<OOX Y
stringOOY _
,OO_ `
stringOOa g
>OOg h
(OOh i
controllerNameOOi w
,OOw x
$strOOy |
)OO| }
)OO} ~
;OO~ 
isForbiddenPP #
=PP$ %
isForbiddenPP& 1
||PP2 4
	forbiddenPP5 >
.PP> ?
ContainsPP? G
(PPG H
newPPH K
KeyValuePairPPL X
<PPX Y
stringPPY _
,PP_ `
stringPPa g
>PPg h
(PPh i
$strPPi l
,PPl m

actionNamePPn x
)PPx y
)PPy z
;PPz {
boolRR 
isPostRR #
=RR$ %
methodRR& ,
.RR, -
CustomAttributesRR- =
.RR= >
AnyRR> A
(RRA B
xRRB C
=>RRD F
xRRG H
.RRH I
AttributeTypeRRI V
==RRW Y
typeofRRZ `
(RR` a
HttpPostAttributeRRa r
)RRr s
)RRs t
;RRt u
boolSS 
areaForbiddenSS *
=SS+ ,
forbiddenAreasSS- ;
.SS; <
AnySS< ?
(SS? @
xSS@ A
=>SSB D

controllerSSE O
.SSO P
	NamespaceSSP Y
.SSY Z
ToLowerSSZ a
(SSa b
)SSb c
.SSc d
ContainsSSd l
(SSl m
$strSSm v
+SSw x
xSSy z
)SSz {
)SS{ |
;SS| }
boolTT 
controllerForbiddenTT 0
=TT1 2
falseTT3 8
;TT8 9
boolUU 
methodForbiddenUU ,
=UU- .
falseUU/ 4
;UU4 5
ifWW 
(WW 
!WW 
isPostWW #
&&WW$ &
!WW' (
areaForbiddenWW( 5
&&WW6 8
!WW9 :
isForbiddenWW: E
&&WWF H
!WWI J
controllerForbiddenWWJ ]
&&WW^ `
!WWa b
methodForbiddenWWb q
)WWq r
{XX 
sitemapContentYY *
+=YY+ -
$strYY. 5
;YY5 6
RouteAttribute[[ *
routeAttribute[[+ 9
=[[: ;
method[[< B
.[[B C
GetCustomAttributes[[C V
<[[V W
RouteAttribute[[W e
>[[e f
([[f g
)[[g h
.[[h i
FirstOrDefault[[i w
([[w x
)[[x y
;[[y z
if]] 
(]]  
routeAttribute]]  .
!=]]/ 1
null]]2 6
&&]]7 9
!]]: ;
routeAttribute]]; I
.]]I J
Template]]J R
.]]R S
Contains]]S [
(]][ \
$str]]\ _
)]]_ `
)]]` a
{^^ 
sitemapContent__  .
+=__/ 1
string__2 8
.__8 9
Format__9 ?
(__? @
$str__@ U
,__U V
_rootUrl__W _
.___ `
Trim__` d
(__d e
$char__e h
)__h i
,__i j
routeAttribute__k y
.__y z
Template	__z Ç
.
__Ç É
Trim
__É á
(
__á à
$char
__à ã
)
__ã å
)
__å ç
;
__ç é
}`` 
elseaa  
{bb 
stringcc  &

methodNamecc' 1
=cc2 3
methodcc4 :
.cc: ;
Namecc; ?
.cc? @
ToLowercc@ G
(ccG H
)ccH I
.ccI J
EqualsccJ P
(ccP Q
$strccQ X
)ccX Y
?ccZ [
stringcc\ b
.ccb c
Emptyccc h
:cci j

actionNamecck u
;ccu v
ifdd  "
(dd# $
stringdd$ *
.dd* +
IsNullOrWhiteSpacedd+ =
(dd= >

methodNamedd> H
)ddH I
)ddI J
{ee  !
sitemapContentff$ 2
+=ff3 5
stringff6 <
.ff< =
Formatff= C
(ffC D
$strffD Y
,ffY Z
_rootUrlff[ c
.ffc d
Trimffd h
(ffh i
$charffi l
)ffl m
,ffm n
controllerNameffo }
.ff} ~
Trim	ff~ Ç
(
ffÇ É
$char
ffÉ Ü
)
ffÜ á
)
ffá à
;
ffà â
}gg  !
elsehh  $
{ii  !
sitemapContentjj$ 2
+=jj3 5
stringjj6 <
.jj< =
Formatjj= C
(jjC D
$strjjD ]
,jj] ^
_rootUrljj_ g
.jjg h
Trimjjh l
(jjl m
$charjjm p
)jjp q
,jjq r
controllerName	jjs Å
.
jjÅ Ç
Trim
jjÇ Ü
(
jjÜ á
$char
jjá ä
)
jjä ã
,
jjã å

methodName
jjç ó
.
jjó ò
Trim
jjò ú
(
jjú ù
$char
jjù †
)
jj† °
)
jj° ¢
;
jj¢ £
}kk  !
}ll 
sitemapContentnn *
+=nn+ -
stringnn. 4
.nn4 5
Formatnn5 ;
(nn; <
$strnn< T
,nnT U
DateTimennV ^
.nn^ _
UtcNownn_ e
.nne f
ToStringnnf n
(nnn o
$strnno {
)nn{ |
)nn| }
;nn} ~
sitemapContentoo *
+=oo+ -
$stroo. 6
;oo6 7
}pp 
}qq 
}rr 
sitemapContentss 
+=ss !
$strss" -
;ss- .
usingtt 
(tt 
MemoryStreamtt #
memoryStreamtt$ 0
=tt1 2
newtt3 6
MemoryStreamtt7 C
(ttC D
)ttD E
)ttE F
{uu 
bytevv 
[vv 
]vv 
bytesvv  
=vv! "
Encodingvv# +
.vv+ ,
UTF8vv, 0
.vv0 1
GetBytesvv1 9
(vv9 :
sitemapContentvv: H
)vvH I
;vvI J
memoryStreamww  
.ww  !
Writeww! &
(ww& '
bytesww' ,
,ww, -
$numww. /
,ww/ 0
bytesww1 6
.ww6 7
Lengthww7 =
)ww= >
;ww> ?
memoryStreamxx  
.xx  !
Seekxx! %
(xx% &
$numxx& '
,xx' (

SeekOriginxx) 3
.xx3 4
Beginxx4 9
)xx9 :
;xx: ;
awaityy 
memoryStreamyy &
.yy& '
CopyToAsyncyy' 2
(yy2 3
streamyy3 9
,yy9 :
bytesyy; @
.yy@ A
LengthyyA G
)yyG H
;yyH I
}zz 
}{{ 
else|| 
{}} 
await~~ 
_next~~ 
(~~ 
context~~ #
)~~# $
;~~$ %
} 
}
ÄÄ 	
}
ÅÅ 
public
ÉÉ 

static
ÉÉ 
class
ÉÉ 
BuilderExtensions
ÉÉ )
{
ÑÑ 
public
ÖÖ 
static
ÖÖ !
IApplicationBuilder
ÖÖ )"
UseSitemapMiddleware
ÖÖ* >
(
ÖÖ> ?
this
ÖÖ? C!
IApplicationBuilder
ÖÖD W
app
ÖÖX [
,
ÖÖ[ \
string
ÖÖ] c
rootUrl
ÖÖd k
=
ÖÖl m
$strÖÖn å
)ÖÖå ç
{
ÜÜ 	
return
áá 
app
áá 
.
áá 
UseMiddleware
áá $
<
áá$ %
SitemapMiddleware
áá% 6
>
áá6 7
(
áá7 8
new
áá8 ;
[
áá; <
]
áá< =
{
áá> ?
rootUrl
áá@ G
}
ááH I
)
ááI J
;
ááJ K
}
àà 	
}
ââ 
public
ãã 

static
ãã 
class
ãã 
ListExtension
ãã %
{
åå 
public
çç 
static
çç 
void
çç 
Add
çç 
(
çç 
this
çç #
List
çç$ (
<
çç( )
KeyValuePair
çç) 5
<
çç5 6
string
çç6 <
,
çç< =
string
çç> D
>
ççD E
>
ççE F
list
ççG K
,
ççK L
string
ççM S
key
ççT W
,
ççW X
string
ççY _
value
çç` e
)
ççe f
{
éé 	
list
èè 
.
èè 
Add
èè 
(
èè 
new
èè 
KeyValuePair
èè %
<
èè% &
string
èè& ,
,
èè, -
string
èè. 4
>
èè4 5
(
èè5 6
key
èè6 9
,
èè9 :
value
èè; @
)
èè@ A
)
èèA B
;
èèB C
}
êê 	
}
ëë 
}íí œ
aC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Models\ErrorViewModel.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Models !
{ 
public 

class 
ErrorViewModel 
{ 
public 
string 
	RequestId 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
bool		 
ShowRequestId		 !
=>		" $
!		% &
string		& ,
.		, -
IsNullOrEmpty		- :
(		: ;
	RequestId		; D
)		D E
;		E F
}

 
} €
lC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Models\MvcExternalLoginViewModel.cs
	namespace		 	
IndieVisible		
 
.		 
Web		 
.		 
Models		 !
{

 
public 

class %
MvcExternalLoginViewModel *
:+ ,"
ExternalLoginViewModel- C
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! ;
); <
]< =
[ 	
Remote	 
( 
$str "
," #
$str$ -
,- .

HttpMethod/ 9
=: ;
$str< B
,B C
ErrorMessageD P
=Q R
$strS ~
)~ 
]	 Ä
[ 	
Display	 
( 
Name 
= 
$str "
)" #
]# $
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage &
=' (
$str( V
)V W
]W X
[ 	
RegularExpression	 
( 
$str [
,[ \
ErrorMessage] i
=j k
$str	l ™
)
™ ´
]
´ ¨
public 
new 
string 
Username "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ﬁ
gC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Models\MvcRegisterViewModel.cs
	namespace		 	
IndieVisible		
 
.		 
Web		 
.		 
Models		 !
{

 
public 

class  
MvcRegisterViewModel %
:& '
RegisterViewModel( 9
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! ;
); <
]< =
[ 	
Remote	 
( 
$str "
," #
$str$ -
,- .

HttpMethod/ 9
=: ;
$str< B
,B C
ErrorMessageD P
=Q R
$strS ~
)~ 
]	 Ä
[ 	
Display	 
( 
Name 
= 
$str #
)# $
]$ %
public 
new 
string 
UserName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} …
dC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Models\TimeLineViewModel.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Models !
{ 
public 

class 
TimeLineViewModel "
{ 
public 
List 
< !
TimeLineItemViewModel )
>) *
Items+ 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public

 
TimeLineViewModel

  
(

  !
)

! "
{ 	
Items 
= 
new 
List 
< !
TimeLineItemViewModel 2
>2 3
(3 4
)4 5
;5 6
} 	
} 
public 

class !
TimeLineItemViewModel &
{ 
public 
bool 
Start 
{ 
get 
;  
set! $
;$ %
}& '
public 
bool 
End 
{ 
get 
; 
set "
;" #
}$ %
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Icon 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Color 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Subtitle 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public!! 
List!! 
<!! 
String!! 
>!! 
Items!! !
{!!" #
get!!$ '
;!!' (
set!!) ,
;!!, -
}!!. /
public## 
bool## 
Future## 
{## 
get##  
{##! "
return### )
this##* .
.##. /
Date##/ 3
>##4 5
DateTime##6 >
.##> ?
Today##? D
;##D E
}##F G
}##H I
public%% !
TimeLineItemViewModel%% $
(%%$ %
)%%% &
{&& 	
Items'' 
='' 
new'' 
List'' 
<'' 
string'' #
>''# $
(''$ %
)''% &
;''& '
Icon(( 
=(( 
$str(( $
;(($ %
})) 	
}** 
}++ ô	
SC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Program.cs
	namespace 	
IndieVisible
 
. 
Web 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	 
CreateWebHostBuilder  
(  !
args! %
)% &
.& '
Build' ,
(, -
)- .
.. /
Run/ 2
(2 3
)3 4
;4 5
} 	
public 
static 
IWebHostBuilder % 
CreateWebHostBuilder& :
(: ;
string; A
[A B
]B C
argsD H
)H I
=>J L
WebHost 
.  
CreateDefaultBuilder (
(( )
args) -
)- .
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
;& '
} 
} ≤
eC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Resources\SharedResources.cs
	namespace 	
IndieVisible
 
. 
Web 
{ 
public 

class 
SharedResources  
{		 
}

 
} ÷
eC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Services\CookieMgrService.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Services #
{		 
public

 

class

 
CookieMgrService

 !
:

" #
ICookieMgrService

$ 5
{ 
private 
readonly  
IHttpContextAccessor - 
_httpContextAccessor. B
;B C
public 
CookieMgrService 
(   
IHttpContextAccessor  4
httpContextAccessor5 H
)H I
{ 	 
_httpContextAccessor  
=! "
httpContextAccessor# 6
;6 7
} 	
public 
string 
Get 
( 
string  
key! $
)$ %
{ 	
string "
cookieValueFromContext )
=* + 
_httpContextAccessor, @
.@ A
HttpContextA L
.L M
RequestM T
.T U
CookiesU \
[\ ]
key] `
]` a
;a b
return "
cookieValueFromContext )
;) *
} 	
public 
void 
Set 
( 
string 
key "
," #
string$ *
value+ 0
,0 1
int2 5
?5 6

expireTime7 A
)A B
{ 	
CookieOptions 
option  
=! "
new# &
CookieOptions' 4
(4 5
)5 6
;6 7
if 
( 

expireTime 
. 
HasValue #
)# $
option 
. 
Expires 
=  
DateTime! )
.) *
Now* -
.- .
AddDays. 5
(5 6

expireTime6 @
.@ A
ValueA F
)F G
;G H
else   
option!! 
.!! 
Expires!! 
=!!  
DateTime!!! )
.!!) *
Now!!* -
.!!- .
AddDays!!. 5
(!!5 6
$num!!6 7
)!!7 8
;!!8 9
option## 
.## 
IsEssential## 
=##  
true##! %
;##% &
string%% "
cookieValueFromContext%% )
=%%* + 
_httpContextAccessor%%, @
.%%@ A
HttpContext%%A L
.%%L M
Request%%M T
.%%T U
Cookies%%U \
[%%\ ]
key%%] `
]%%` a
;%%a b
if'' 
('' "
cookieValueFromContext'' &
!=''' )
null''* .
)''. /
{((  
_httpContextAccessor)) $
.))$ %
HttpContext))% 0
.))0 1
Response))1 9
.))9 :
Cookies)): A
.))A B
Append))B H
())H I
key))I L
,))L M
value))N S
,))S T
option))U [
)))[ \
;))\ ]
}** 
else++ 
{,,  
_httpContextAccessor-- $
.--$ %
HttpContext--% 0
.--0 1
Response--1 9
.--9 :
Cookies--: A
.--A B
Append--B H
(--H I
key--I L
,--L M
value--N S
,--S T
option--U [
)--[ \
;--\ ]
}.. 
}// 	
}00 
}11 «
fC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Services\ICookieMgrService.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Services #
{ 
public 

	interface 
ICookieMgrService &
{ 
string		 
Get		 
(		 
string		 
key		 
)		 
;		 
void 
Set 
( 
string 
key 
, 
string #
value$ )
,) *
int+ .
?. /

expireTime0 :
): ;
;; <
} 
} ≤∫
SC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Startup.cs
	namespace!! 	
IndieVisible!!
 
.!! 
Web!! 
{"" 
public## 

class## 
Startup## 
{$$ 
public%% 
Startup%% 
(%% 
IConfiguration%% %
configuration%%& 3
)%%3 4
{&& 	
Configuration'' 
='' 
configuration'' )
;'') *
}(( 	
public** 
IConfiguration** 
Configuration** +
{**, -
get**. 1
;**1 2
}**3 4
public-- 
void-- 
ConfigureServices-- %
(--% &
IServiceCollection--& 8
services--9 A
)--A B
{.. 	
services// 
.// 
	Configure// 
<// 
CookiePolicyOptions// 2
>//2 3
(//3 4
options//4 ;
=>//< >
{00 
options22 
.22 
CheckConsentNeeded22 *
=22+ ,
context22- 4
=>225 7
true228 <
;22< =
options33 
.33 !
MinimumSameSitePolicy33 -
=33. /
	Microsoft330 9
.339 :

AspNetCore33: D
.33D E
Http33E I
.33I J
SameSiteMode33J V
.33V W
None33W [
;33[ \
options44 
.44 
ConsentCookie44 %
.44% &
Name44& *
=44+ ,
$str44- C
;44C D
}55 
)55 
;55 
var77 
cs77 
=77 
Configuration77 "
.77" #
GetConnectionString77# 6
(776 7
$str777 J
)77J K
;77K L
services99 
.99 
AddDbContext99 !
<99! "!
AspNetIdentityContext99" 7
>997 8
(998 9
o999 :
=>99; =
o99> ?
.99? @
UseSqlServer99@ L
(99L M
cs99M O
,99O P
b99Q R
=>99S U
b99V W
.99W X
MigrationsAssembly99X j
(99j k
$str	99k ï
)
99ï ñ
)
99ñ ó
)
99ó ò
;
99ò ô
services:: 
.:: 
AddDbContext:: !
<::! "
IndieVisibleContext::" 5
>::5 6
(::6 7
o::7 8
=>::9 ;
o::< =
.::= >
UseSqlServer::> J
(::J K
cs::K M
,::M N
b::O P
=>::Q S
b::T U
.::U V
MigrationsAssembly::V h
(::h i
$str	::i Ç
)
::Ç É
)
::É Ñ
)
::Ñ Ö
;
::Ö Ü
services<< 
.<< 
AddIdentity<<  
<<<  !
ApplicationUser<<! 0
,<<0 1
IdentityRole<<2 >
><<> ?
(<<? @
options<<@ G
=><<H J
{== 
options>> 
.>> 
Password>>  
.>>  !
RequireDigit>>! -
=>>. /
false>>0 5
;>>5 6
options?? 
.?? 
Password??  
.??  !
RequiredLength??! /
=??0 1
$num??2 3
;??3 4
options@@ 
.@@ 
Password@@  
.@@  !"
RequireNonAlphanumeric@@! 7
=@@8 9
false@@: ?
;@@? @
optionsAA 
.AA 
PasswordAA  
.AA  !
RequireUppercaseAA! 1
=AA2 3
falseAA4 9
;AA9 :
optionsBB 
.BB 
PasswordBB  
.BB  !
RequireLowercaseBB! 1
=BB2 3
falseBB4 9
;BB9 :
}CC 
)CC 
.DD $
AddEntityFrameworkStoresDD )
<DD) *!
AspNetIdentityContextDD* ?
>DD? @
(DD@ A
)DDA B
.EE $
AddDefaultTokenProvidersEE )
(EE) *
)EE* +
;EE+ ,
servicesGG 
.GG 
AddAuthenticationGG &
(GG& '(
CookieAuthenticationDefaultsGG' C
.GGC D 
AuthenticationSchemeGGD X
)GGX Y
.HH 
	AddCookieHH 
(HH 
oHH 
=>HH 
{II 
oJJ 
.JJ 
CookieJJ 
.JJ 
NameJJ !
=JJ" #
$strJJ$ H
;JJH I
oKK 
.KK 
	LoginPathKK 
=KK  !
newKK" %

PathStringKK& 0
(KK0 1
$strKK1 9
)KK9 :
;KK: ;
oLL 
.LL 
AccessDeniedPathLL &
=LL' (
newLL) ,

PathStringLL- 7
(LL7 8
$strLL8 M
)LLM N
;LLN O
}MM 
)MM 
.NN 
AddFacebookNN 
(NN 
oNN 
=>NN !
{OO 
oPP 
.PP 
AppIdPP 
=PP 
ConfigurationPP +
[PP+ ,
$strPP, K
]PPK L
;PPL M
oQQ 
.QQ 
	AppSecretQQ 
=QQ  !
ConfigurationQQ" /
[QQ/ 0
$strQQ0 S
]QQS T
;QQT U
oRR 
.RR 
FieldsRR 
.RR 
AddRR  
(RR  !
$strRR! *
)RR* +
;RR+ ,
oSS 
.SS 
EventsSS 
=SS 
newSS "
OAuthEventsSS# .
{TT 
OnCreatingTicketUU (
=UU) *
contextUU+ 2
=>UU3 5
{VV 
ClaimsIdentityWW *
identityWW+ 3
=WW4 5
(WW6 7
ClaimsIdentityWW7 E
)WWE F
contextWWF M
.WWM N
	PrincipalWWN W
.WWW X
IdentityWWX `
;WW` a
stringXX "

profileImgXX# -
=XX. /
contextXX0 7
.XX7 8
UserXX8 <
[XX< =
$strXX= F
]XXF G
[XXG H
$strXXH N
]XXN O
.XXO P
ValueXXP U
<XXU V
stringXXV \
>XX\ ]
(XX] ^
$strXX^ c
)XXc d
;XXd e
identityYY $
.YY$ %
AddClaimYY% -
(YY- .
newYY. 1
ClaimYY2 7
(YY7 8
$strYY8 J
,YYJ K

profileImgYYL V
)YYV W
)YYW X
;YYX Y
returnZZ "
TaskZZ# '
.ZZ' (
CompletedTaskZZ( 5
;ZZ5 6
}[[ 
}\\ 
;\\ 
}]] 
)]] 
.^^ 
	AddGoogle^^ 
(^^ 
googleOptions^^ (
=>^^) +
{__ 
googleOptions`` !
.``! "
ClientId``" *
=``+ ,
Configuration``- :
[``: ;
$str``; [
]``[ \
;``\ ]
googleOptionsaa !
.aa! "
ClientSecretaa" .
=aa/ 0
Configurationaa1 >
[aa> ?
$straa? c
]aac d
;aad e
}bb 
)bb 
.cc 
AddMicrosoftAccountcc $
(cc$ %
microsoftOptionscc% 5
=>cc6 8
{dd 
microsoftOptionsee $
.ee$ %
ClientIdee% -
=ee. /
Configurationee0 =
[ee= >
$stree> f
]eef g
;eeg h
microsoftOptionsff $
.ff$ %
ClientSecretff% 1
=ff2 3
Configurationff4 A
[ffA B
$strffB e
]ffe f
;fff g
}gg 
)gg 
;gg 
servicesjj 
.jj 
AddAutoMapperSetupjj '
(jj' (
)jj( )
;jj) *
servicesll 
.ll 

AddSessionll 
(ll  
optll  #
=>ll$ &
{mm 
optnn 
.nn 
Cookienn 
.nn 
Namenn 
=nn  !
$strnn" 9
;nn9 :
optoo 
.oo 
Cookieoo 
.oo 
IsEssentialoo &
=oo' (
trueoo) -
;oo- .
}pp 
)pp 
;pp 
servicesrr 
.rr 
AddLocalizationrr $
(rr$ %
optsrr% )
=>rr* ,
{rr- .
optsrr/ 3
.rr3 4
ResourcesPathrr4 A
=rrB C
$strrrD O
;rrO P
}rrQ R
)rrR S
;rrS T
servicestt 
.tt "
AddResponseCompressiontt +
(tt+ ,
)tt, -
;tt- .
servicesvv 
.vv 

AddRoutingvv 
(vv  
optionsvv  '
=>vv( *
{ww 
optionsxx 
.xx 
LowercaseUrlsxx %
=xx& '
truexx( ,
;xx, -
optionsyy 
.yy 
AppendTrailingSlashyy +
=yy, -
trueyy. 2
;yy2 3
}zz 
)zz 
;zz 
services|| 
.|| 
AddMvc|| 
(|| 
options|| #
=>||$ &
{}} 
options~~ 
.~~ 
CacheProfiles~~ %
.~~% &
Add~~& )
(~~) *
$str~~* 3
,~~3 4
new 
CacheProfile $
($ %
)% &
{
ÄÄ 
Duration
ÅÅ  
=
ÅÅ! "
$num
ÅÅ# *
,
ÅÅ* +
VaryByHeader
ÇÇ $
=
ÇÇ% &
HeaderNames
ÇÇ' 2
.
ÇÇ2 3
ETag
ÇÇ3 7
}
ÉÉ 
)
ÉÉ 
;
ÉÉ 
options
ÑÑ 
.
ÑÑ 
CacheProfiles
ÑÑ %
.
ÑÑ% &
Add
ÑÑ& )
(
ÑÑ) *
$str
ÑÑ* 1
,
ÑÑ1 2
new
ÖÖ 
CacheProfile
ÖÖ $
(
ÖÖ$ %
)
ÖÖ% &
{
ÜÜ 
Duration
áá  
=
áá! "
$num
áá# (
,
áá( )
VaryByHeader
àà $
=
àà% &
HeaderNames
àà' 2
.
àà2 3
ETag
àà3 7
}
ââ 
)
ââ 
;
ââ 
options
ää 
.
ää 
CacheProfiles
ää %
.
ää% &
Add
ää& )
(
ää) *
$str
ää* 1
,
ää1 2
new
ãã 
CacheProfile
ãã $
(
ãã$ %
)
ãã% &
{
åå 
Location
çç  
=
çç! "#
ResponseCacheLocation
çç# 8
.
çç8 9
None
çç9 =
,
çç= >
NoStore
éé 
=
éé  !
true
éé" &
}
èè 
)
èè 
;
èè 
}
êê 
)
êê 
.
ëë !
AddViewLocalization
ëë  
(
ëë  !0
"LanguageViewLocationExpanderFormat
ëë! C
.
ëëC D
Suffix
ëëD J
,
ëëJ K
opts
ëëL P
=>
ëëQ S
{
ëëT U
opts
ëëV Z
.
ëëZ [
ResourcesPath
ëë[ h
=
ëëi j
$str
ëëk v
;
ëëv w
}
ëëx y
)
ëëy z
.
íí ,
AddDataAnnotationsLocalization
íí +
(
íí+ ,
options
íí, 3
=>
íí4 6
{
ìì 
options
îî 
.
îî -
DataAnnotationLocalizerProvider
îî 7
=
îî8 9
(
îî: ;
type
îî; ?
,
îî? @
factory
îîA H
)
îîH I
=>
îîJ L
factory
ïï 
.
ïï 
Create
ïï "
(
ïï" #
typeof
ïï# )
(
ïï) *
SharedResources
ïï* 9
)
ïï9 :
)
ïï: ;
;
ïï; <
}
ññ 
)
ññ 
.
óó %
SetCompatibilityVersion
óó $
(
óó$ %"
CompatibilityVersion
óó% 9
.
óó9 :
Version_2_1
óó: E
)
óóE F
;
óóF G
services
ôô 
.
ôô "
AddProgressiveWebApp
ôô )
(
ôô) *
)
ôô* +
;
ôô+ ,
List
üü 
<
üü 
CultureInfo
üü 
>
üü 
supportedCultures
üü /
=
üü0 1
new
üü2 5
List
üü6 :
<
üü: ;
CultureInfo
üü; F
>
üüF G
{
†† 
new
°° 
CultureInfo
°° #
(
°°# $
$str
°°$ +
)
°°+ ,
,
°°, -
new
¢¢ 
CultureInfo
¢¢ #
(
¢¢# $
$str
¢¢$ (
)
¢¢( )
,
¢¢) *
new
££ 
CultureInfo
££ #
(
££# $
$str
££$ +
)
££+ ,
,
££, -
new
§§ 
CultureInfo
§§ #
(
§§# $
$str
§§$ (
)
§§( )
,
§§) *
new
•• 
CultureInfo
•• #
(
••# $
$str
••$ +
)
••+ ,
,
••, -
new
¶¶ 
CultureInfo
¶¶ #
(
¶¶# $
$str
¶¶$ (
)
¶¶( )
,
¶¶) *
new
ßß 
CultureInfo
ßß #
(
ßß# $
$str
ßß$ (
)
ßß( )
,
ßß) *
new
®® 
CultureInfo
®® #
(
®®# $
$str
®®$ (
)
®®( )
,
®®) *
new
©© 
CultureInfo
©© #
(
©©# $
$str
©©$ (
)
©©( )
,
©©) *
new
™™ 
CultureInfo
™™ #
(
™™# $
$str
™™$ (
)
™™( )
}
´´ 
;
´´ 
services
≠≠ 
.
≠≠ 
	Configure
≠≠ 
<
≠≠ (
RequestLocalizationOptions
≠≠ 9
>
≠≠9 :
(
≠≠: ;
opts
≠≠; ?
=>
≠≠@ B
{
ÆÆ 
opts
∞∞ 
.
∞∞ #
DefaultRequestCulture
∞∞ *
=
∞∞+ ,
new
∞∞- 0
RequestCulture
∞∞1 ?
(
∞∞? @
$str
∞∞@ G
)
∞∞G H
;
∞∞H I
opts
≤≤ 
.
≤≤ 
SupportedCultures
≤≤ &
=
≤≤' (
supportedCultures
≤≤) :
;
≤≤: ;
opts
¥¥ 
.
¥¥ !
SupportedUICultures
¥¥ (
=
¥¥) *
supportedCultures
¥¥+ <
;
¥¥< =
}
µµ 
)
µµ 
;
µµ 
services
∑∑ 
.
∑∑ 
AddTransient
∑∑ !
<
∑∑! "
ICookieMgrService
∑∑" 3
,
∑∑3 4
CookieMgrService
∑∑5 E
>
∑∑E F
(
∑∑F G
)
∑∑G H
;
∑∑H I
services
ππ 
.
ππ 
	Configure
ππ 
<
ππ 
ConfigOptions
ππ ,
>
ππ, -
(
ππ- .
	myOptions
ππ. 7
=>
ππ8 :
{
∫∫ 
	myOptions
ªª 
.
ªª 
FacebookAppId
ªª '
=
ªª( )
Configuration
ªª* 7
[
ªª7 8
$str
ªª8 W
]
ªªW X
;
ªªX Y
}
ºº 
)
ºº 
;
ºº 
RegisterServices
¡¡ 
(
¡¡ 
services
¡¡ %
)
¡¡% &
;
¡¡& '
}
¬¬ 	
public
≈≈ 
void
≈≈ 
	Configure
≈≈ 
(
≈≈ !
IApplicationBuilder
≈≈ 1
app
≈≈2 5
,
≈≈5 6!
IHostingEnvironment
≈≈7 J
env
≈≈K N
,
≈≈N O
IServiceProvider
≈≈P `
serviceProvider
≈≈a p
)
≈≈p q
{
∆∆ 	
using
«« 
(
«« 
IServiceScope
««  
scope
««! &
=
««' (
app
««) ,
.
««, -!
ApplicationServices
««- @
.
««@ A 
GetRequiredService
««A S
<
««S T"
IServiceScopeFactory
««T h
>
««h i
(
««i j
)
««j k
.
««k l
CreateScope
««l w
(
««w x
)
««x y
)
««y z
{
»» 
scope
…… 
.
…… 
ServiceProvider
…… %
.
……% &

GetService
……& 0
<
……0 1#
AspNetIdentityContext
……1 F
>
……F G
(
……G H
)
……H I
.
……I J
Database
……J R
.
……R S
Migrate
……S Z
(
……Z [
)
……[ \
;
……\ ]
scope
   
.
   
ServiceProvider
   %
.
  % &

GetService
  & 0
<
  0 1!
IndieVisibleContext
  1 D
>
  D E
(
  E F
)
  F G
.
  G H
Database
  H P
.
  P Q
Migrate
  Q X
(
  X Y
)
  Y Z
;
  Z [
}
ÀÀ 
if
ÕÕ 
(
ÕÕ 
env
ÕÕ 
.
ÕÕ 
IsDevelopment
ÕÕ !
(
ÕÕ! "
)
ÕÕ" #
)
ÕÕ# $
{
ŒŒ 
app
œœ 
.
œœ '
UseDeveloperExceptionPage
œœ -
(
œœ- .
)
œœ. /
;
œœ/ 0
app
–– 
.
–– "
UseDatabaseErrorPage
–– (
(
––( )
)
––) *
;
––* +
}
—— 
else
““ 
{
”” 
app
‘‘ 
.
‘‘ !
UseExceptionHandler
‘‘ '
(
‘‘' (
$str
‘‘( 5
)
‘‘5 6
;
‘‘6 7
}
’’ 
app
◊◊ 
.
◊◊ !
UseHttpsRedirection
◊◊ #
(
◊◊# $
)
◊◊$ %
;
◊◊% &.
 FileExtensionContentTypeProvider
ŸŸ ,
provider
ŸŸ- 5
=
ŸŸ6 7
new
ŸŸ8 ;.
 FileExtensionContentTypeProvider
ŸŸ< \
(
ŸŸ\ ]
)
ŸŸ] ^
;
ŸŸ^ _
provider
⁄⁄ 
.
⁄⁄ 
Mappings
⁄⁄ 
[
⁄⁄ 
$str
⁄⁄ ,
]
⁄⁄, -
=
⁄⁄. /
$str
⁄⁄0 K
;
⁄⁄K L
app
‹‹ 
.
‹‹ 
UseStaticFiles
‹‹ 
(
‹‹ 
new
‹‹ "
StaticFileOptions
‹‹# 4
(
‹‹4 5
)
‹‹5 6
{
›› !
ContentTypeProvider
ﬁﬁ #
=
ﬁﬁ$ %
provider
ﬁﬁ& .
,
ﬁﬁ. /
OnPrepareResponse
ﬂﬂ !
=
ﬂﬂ" #
ctx
ﬂﬂ$ '
=>
ﬂﬂ( *
{
‡‡ 
ctx
·· 
.
·· 
Context
·· 
.
··  
Response
··  (
.
··( )
Headers
··) 0
[
··0 1
HeaderNames
··1 <
.
··< =
CacheControl
··= I
]
··I J
=
··K L
$str
··M e
;
··e f
}
‚‚ 
}
„„ 
)
„„ 
;
„„ 
app
ÂÂ 
.
ÂÂ 

UseETagger
ÂÂ 
(
ÂÂ 
)
ÂÂ 
;
ÂÂ 
IOptions
ÁÁ 
<
ÁÁ (
RequestLocalizationOptions
ÁÁ /
>
ÁÁ/ 0
options
ÁÁ1 8
=
ÁÁ9 :
app
ÁÁ; >
.
ÁÁ> ?!
ApplicationServices
ÁÁ? R
.
ÁÁR S

GetService
ÁÁS ]
<
ÁÁ] ^
IOptions
ÁÁ^ f
<
ÁÁf g)
RequestLocalizationOptionsÁÁg Å
>ÁÁÅ Ç
>ÁÁÇ É
(ÁÁÉ Ñ
)ÁÁÑ Ö
;ÁÁÖ Ü
app
ËË 
.
ËË $
UseRequestLocalization
ËË &
(
ËË& '
options
ËË' .
.
ËË. /
Value
ËË/ 4
)
ËË4 5
;
ËË5 6
app
ÍÍ 
.
ÍÍ 
UseCookiePolicy
ÍÍ 
(
ÍÍ  
)
ÍÍ  !
;
ÍÍ! "
app
ÏÏ 
.
ÏÏ 
UseAuthentication
ÏÏ !
(
ÏÏ! "
)
ÏÏ" #
;
ÏÏ# $
app
ÓÓ 
.
ÓÓ 

UseSession
ÓÓ 
(
ÓÓ 
)
ÓÓ 
;
ÓÓ 
app
 
.
 "
UseSitemapMiddleware
 $
(
$ %
)
% &
;
& '
app
¯¯ 
.
¯¯ 
UseRewriter
¯¯ 
(
¯¯ 
new
¯¯ 
RewriteOptions
¯¯  .
(
¯¯. /
)
¯¯/ 0
.
˙˙  
AddRedirectToHttps
˙˙ "
(
˙˙" #
)
˙˙# $
)
˚˚ 
;
˚˚ 
app
˝˝ 
.
˝˝ 
UseMvc
˝˝ 
(
˝˝ 
routes
˝˝ 
=>
˝˝  
{
˛˛ 
routes
ˇˇ 
.
ˇˇ 
MapRoute
ˇˇ 
(
ˇˇ  
name
ÄÄ 
:
ÄÄ 
$str
ÄÄ (
,
ÄÄ( )
template
ÅÅ 
:
ÅÅ 
$str
ÅÅ H
)
ÇÇ 
;
ÇÇ 
routes
ÑÑ 
.
ÑÑ 
MapRoute
ÑÑ 
(
ÑÑ  
name
ÖÖ 
:
ÖÖ 
$str
ÖÖ 
,
ÖÖ  
template
ÜÜ 
:
ÜÜ 
$str
ÜÜ R
)
áá 
;
áá 
routes
ââ 
.
ââ 
MapRoute
ââ 
(
ââ  
name
ää 
:
ää 
$str
ää #
,
ää# $
template
ãã 
:
ãã 
$str
ãã F
)
ããF G
;
ããG H
}
åå 
)
åå 
;
åå 
CreateUserRoles
êê 
(
êê 
serviceProvider
êê +
)
êê+ ,
.
êê, -
Wait
êê- 1
(
êê1 2
)
êê2 3
;
êê3 4
}
ëë 	
private
ìì 
static
ìì 
void
ìì 
RegisterServices
ìì ,
(
ìì, - 
IServiceCollection
ìì- ?
services
ìì@ H
)
ììH I
{
îî 	(
NativeInjectorBootStrapper
ññ &
.
ññ& '
RegisterServices
ññ' 7
(
ññ7 8
services
ññ8 @
)
ññ@ A
;
ññA B
}
óó 	
private
ôô 
async
ôô 
Task
ôô 
CreateUserRoles
ôô *
(
ôô* +
IServiceProvider
ôô+ ;
serviceProvider
ôô< K
)
ôôK L
{
öö 	
RoleManager
õõ 
<
õõ 
IdentityRole
õõ $
>
õõ$ %
roleManager
õõ& 1
=
õõ2 3
serviceProvider
õõ4 C
.
õõC D 
GetRequiredService
õõD V
<
õõV W
RoleManager
õõW b
<
õõb c
IdentityRole
õõc o
>
õõo p
>
õõp q
(
õõq r
)
õõr s
;
õõs t
List
ùù 
<
ùù 
Roles
ùù 
>
ùù 
roles
ùù 
=
ùù 
Enum
ùù  $
.
ùù$ %
	GetValues
ùù% .
(
ùù. /
typeof
ùù/ 5
(
ùù5 6
Roles
ùù6 ;
)
ùù; <
)
ùù< =
.
ùù= >
Cast
ùù> B
<
ùùB C
Roles
ùùC H
>
ùùH I
(
ùùI J
)
ùùJ K
.
ùùK L
ToList
ùùL R
(
ùùR S
)
ùùS T
;
ùùT U
foreach
üü 
(
üü 
Roles
üü 
role
üü 
in
üü  "
roles
üü# (
)
üü( )
{
†† 
await
°° 
CreateIrNotExists
°° '
(
°°' (
roleManager
°°( 3
,
°°3 4
role
°°5 9
.
°°9 :
ToString
°°: B
(
°°B C
)
°°C D
)
°°D E
;
°°E F
}
¢¢ 
}
££ 	
private
•• 
static
•• 
async
•• 
Task
•• !
CreateIrNotExists
••" 3
(
••3 4
RoleManager
••4 ?
<
••? @
IdentityRole
••@ L
>
••L M
RoleManager
••N Y
,
••Y Z
string
••[ a
roleName
••b j
)
••j k
{
¶¶ 	
IdentityResult
ßß 

roleResult
ßß %
;
ßß% &
bool
®® 
	roleCheck
®® 
=
®® 
await
®® "
RoleManager
®®# .
.
®®. /
RoleExistsAsync
®®/ >
(
®®> ?
roleName
®®? G
)
®®G H
;
®®H I
if
©© 
(
©© 
!
©© 
	roleCheck
©© 
)
©© 
{
™™ 

roleResult
´´ 
=
´´ 
await
´´ "
RoleManager
´´# .
.
´´. /
CreateAsync
´´/ :
(
´´: ;
new
´´; >
IdentityRole
´´? K
(
´´K L
roleName
´´L T
)
´´T U
)
´´U V
;
´´V W
}
¨¨ 
}
≠≠ 	
}
ÆÆ 
}ØØ °
kC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\TagHelpers\CustomInputTagHelper.cs
	namespace		 	
IndieVisible		
 
.		 
Web		 
.		 

TagHelpers		 %
{

 
[ 
HtmlTargetElement 
( 
$str 
, 

Attributes  *
=+ ,
ForAttributeName- =
)= >
]> ?
public 

class  
CustomInputTagHelper %
:& '
InputTagHelper( 6
{ 
private 
const 
string 
ForAttributeName -
=. /
$str0 9
;9 :
[ 	
HtmlAttributeName	 
( 
$str ,
), -
]- .
public 
bool 

IsDisabled 
{  
set! $
;$ %
get& )
;) *
}+ ,
public  
CustomInputTagHelper #
(# $
IHtmlGenerator$ 2
	generator3 <
)< =
:> ?
base@ D
(D E
	generatorE N
)N O
{ 	
} 	
public 
override 
void 
Process $
($ %
TagHelperContext% 5
context6 =
,= >
TagHelperOutput? N
outputO U
)U V
{ 	
if 
( 

IsDisabled 
) 
{ 
output 
. 

Attributes !
.! "
SetAttribute" .
(. /
$str/ 9
,9 :
$str; E
)E F
;F G
} 
base 
. 
Process 
( 
context  
,  !
output" (
)( )
;) *
} 	
} 
}   ˇ
pC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\ViewComponents\CountersViewComponent.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
ViewComponents )
{ 
public 

class !
CountersViewComponent &
:' (
ViewComponent) 6
{ 
private 
readonly 
IGameAppService (
_gameAppService) 8
;8 9
private 
readonly 
IProfileAppService +
_profileAppService, >
;> ?
private 
readonly "
IUserContentAppService /
_contentService0 ?
;? @
public !
CountersViewComponent $
($ %
IGameAppService% 4
gameAppService5 C
,C D
IProfileAppServiceE W
profileAppServiceX i
,i j#
IUserContentAppService	k Å
contentService
Ç ê
)
ê ë
{ 	
_gameAppService 
= 
gameAppService ,
;, -
_profileAppService 
=  
profileAppService! 2
;2 3
_contentService 
= 
contentService ,
;, -
} 	
public 
async 
Task 
<  
IViewComponentResult .
>. /
InvokeAsync0 ;
(; <
int< ?
qtd@ C
)C D
{ 	
var 
model 
= 
new 
CountersViewModel -
(- .
). /
;/ 0
var 

gamesCount 
= 
_gameAppService ,
., -
Count- 2
(2 3
)3 4
;4 5
if   
(   

gamesCount   
.   
Success   "
)  " #
{!! 
model"" 
."" 

GamesCount""  
=""! "

gamesCount""# -
.""- .
Value"". 3
;""3 4
}## 
var%% 

usersCount%% 
=%% 
_profileAppService%% /
.%%/ 0
Count%%0 5
(%%5 6
)%%6 7
;%%7 8
if'' 
('' 

usersCount'' 
.'' 
Success'' "
)''" #
{(( 
model)) 
.)) 

UsersCount))  
=))! "

usersCount))# -
.))- .
Value)). 3
;))3 4
}** 
model,, 
.,, 
ArticlesCount,, 
=,,  !
_contentService,," 1
.,,1 2
CountArticles,,2 ?
(,,? @
),,@ A
;,,A B
return// 
View// 
(// 
model// 
)// 
;// 
}00 	
}11 
}22 “
sC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\ViewComponents\LatestGamesViewComponent.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
ViewComponents )
{ 
public 

class $
LatestGamesViewComponent )
:* +
ViewComponent, 9
{ 
private 
readonly  
IHttpContextAccessor - 
_httpContextAccessor. B
;B C
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
private 
readonly 
IGameAppService (
_gameAppService) 8
;8 9
public $
LatestGamesViewComponent '
(' (
IGameAppService( 7
gameAppService8 F
,F G 
IHttpContextAccessorH \
httpContextAccessor] p
)p q
{ 	
_gameAppService 
= 
gameAppService ,
;, - 
_httpContextAccessor  
=! "
httpContextAccessor# 6
;6 7
string 
id 
=  
_httpContextAccessor ,
., -
HttpContext- 8
.8 9
User9 =
.= >
FindFirstValue> L
(L M

ClaimTypesM W
.W X
NameIdentifierX f
)f g
;g h
if 
( 
! 
string 
. 
IsNullOrWhiteSpace *
(* +
id+ -
)- .
). /
{ 
UserId 
= 
new 
Guid !
(! "
id" $
)$ %
;% &
} 
}   	
public"" 
async"" 
Task"" 
<""  
IViewComponentResult"" .
>"". /
InvokeAsync""0 ;
(""; <
int""< ?
qtd""@ C
,""C D
Guid""E I
userId""J P
)""P Q
{## 	
if$$ 
($$ 
qtd$$ 
==$$ 
$num$$ 
)$$ 
{%% 
qtd&& 
=&& 
$num&& 
;&& 
}'' 
List)) 
<)) !
GameListItemViewModel)) &
>))& '
model))( -
=)). /
_gameAppService))0 ?
.))? @
	GetLatest))@ I
())I J
UserId))J P
,))P Q
qtd))R U
,))U V
userId))W ]
,))] ^
$num))_ `
)))` a
.))a b
ToList))b h
())h i
)))i j
;))j k
return++ 
View++ 
(++ 
model++ 
)++ 
;++ 
},, 	
}-- 
}.. £
tC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\ViewComponents\NotificationViewComponent.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
ViewComponents )
{ 
public 

class %
NotificationViewComponent *
:+ ,
ViewComponent- :
{ 
private 
readonly  
IHttpContextAccessor - 
_httpContextAccessor. B
;B C
private 
readonly #
INotificationAppService 0#
_notificationAppService1 H
;H I
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public %
NotificationViewComponent (
(( ) 
IHttpContextAccessor) =
httpContextAccessor> Q
,Q R#
INotificationAppServiceS j#
notificationAppService	k Å
)
Å Ç
{ 	 
_httpContextAccessor  
=! "
httpContextAccessor# 6
;6 7#
_notificationAppService #
=$ %"
notificationAppService& <
;< =
string 
id 
=  
_httpContextAccessor ,
., -
HttpContext- 8
.8 9
User9 =
.= >
FindFirstValue> L
(L M

ClaimTypesM W
.W X
NameIdentifierX f
)f g
;g h
if 
( 
! 
string 
. 
IsNullOrWhiteSpace *
(* +
id+ -
)- .
). /
{ 
UserId 
= 
new 
Guid !
(! "
id" $
)$ %
;% &
} 
}   	
public"" 
async"" 
Task"" 
<""  
IViewComponentResult"" .
>"". /
InvokeAsync""0 ;
(""; <
int""< ?
qtd""@ C
)""C D
{## 	
if$$ 
($$ 
qtd$$ 
==$$ 
$num$$ 
)$$ 
{%% 
qtd&& 
=&& 
$num&& 
;&& 
}'' #
_notificationAppService)) #
.))# $
CurrentUserId))$ 1
=))2 3
this))4 8
.))8 9
UserId))9 ?
;))? @
var** 
result** 
=** #
_notificationAppService** 0
.**0 1
GetByUserId**1 <
(**< =
this**= A
.**A B
UserId**B H
,**H I
qtd**J M
)**M N
;**N O
var,, 
model,, 
=,, 
result,, 
.,, 
Value,, $
.,,$ %
ToList,,% +
(,,+ ,
),,, -
;,,- .
foreach.. 
(.. 
var.. 
item.. 
in..  
model..! &
)..& '
{// 
item00 
.00 
Url00 
+=00 
String00 "
.00" #
Format00# )
(00) *
$str00* D
,00D E
item00F J
.00J K
Id00K M
)00M N
;00N O
}11 
model33 
.33 
DefineVisuals33 
(33  
)33  !
;33! "
ViewData55 
[55 
$str55 "
]55" #
=55$ %
model55& +
.55+ ,
Count55, 1
(551 2
x552 3
=>554 6
!557 8
x558 9
.559 :
IsRead55: @
)55@ A
;55A B
return77 
View77 
(77 
model77 
)77 
;77 
}88 	
}99 
}:: ª
sC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\ViewComponents\UserContentViewComponent.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
ViewComponents )
{ 
public 

class $
UserContentViewComponent )
:* +
ViewComponent, 9
{ 
private 
readonly  
IHttpContextAccessor - 
_httpContextAccessor. B
;B C
private 
readonly &
IUserPreferencesAppService 3&
_userPreferencesAppService4 N
;N O
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
private 
readonly "
IUserContentAppService /"
_userContentAppService0 F
;F G
public $
UserContentViewComponent '
(' ( 
IHttpContextAccessor( <
httpContextAccessor= P
,P Q"
IUserContentAppServiceR h!
userContentAppServicei ~
,~ (
IUserPreferencesAppService
Ä ö'
userPreferencesAppService
õ ¥
)
¥ µ
{ 	 
_httpContextAccessor  
=! "
httpContextAccessor# 6
;6 7"
_userContentAppService "
=# $!
userContentAppService% :
;: ;&
_userPreferencesAppService &
=' (%
userPreferencesAppService) B
;B C
string 
id 
=  
_httpContextAccessor ,
., -
HttpContext- 8
.8 9
User9 =
.= >
FindFirstValue> L
(L M

ClaimTypesM W
.W X
NameIdentifierX f
)f g
;g h
if!! 
(!! 
!!! 
string!! 
.!! 
IsNullOrWhiteSpace!! *
(!!* +
id!!+ -
)!!- .
)!!. /
{"" 
UserId## 
=## 
new## 
Guid## !
(##! "
id##" $
)##$ %
;##% &
}$$ 
}%% 	
public'' 
async'' 
Task'' 
<''  
IViewComponentResult'' .
>''. /
InvokeAsync''0 ;
(''; <
int''< ?
count''@ E
,''E F
Guid''G K
gameId''L R
,''R S
Guid''T X
userId''Y _
)''_ `
{(( 	$
UserPreferencesViewModel)) $
preferences))% 0
=))1 2&
_userPreferencesAppService))3 M
.))M N
GetByUserId))N Y
())Y Z
UserId))Z `
)))` a
;))a b
List++ 
<++ 
SupportedLanguage++ "
>++" #
	languages++$ -
=++. /
preferences++0 ;
.++; <
	Languages++< E
;++E F
List-- 
<-- (
UserContentListItemViewModel-- -
>--- .
model--/ 4
=--5 6"
_userContentAppService--7 M
.--M N
GetActivityFeed--N ]
(--] ^
UserId--^ d
,--d e
count--f k
,--k l
gameId--m s
,--s t
userId--u {
,--{ |
	languages	--} Ü
)
--Ü á
.
--á à
ToList
--à é
(
--é è
)
--è ê
;
--ê ë
return// 
View// 
(// 
model// 
)// 
;// 
}00 	
}11 
}22 ó
gC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Web\Views\Manage\ManageNavPages.cs
	namespace 	
IndieVisible
 
. 
Web 
. 
Views  
.  !
Manage! '
{		 
public

 

static

 
class

 
ManageNavPages

 &
{ 
public 
static 
string 
ActivePageKey *
=>+ -
$str. :
;: ;
public 
static 
string 
Index "
=># %
$str& -
;- .
public 
static 
string 
ChangePassword +
=>, .
$str/ ?
;? @
public 
static 
string 
ExternalLogins +
=>, .
$str/ ?
;? @
public 
static 
string #
TwoFactorAuthentication 4
=>5 7
$str8 Q
;Q R
public 
static 
string 
IndexNavClass *
(* +
ViewContext+ 6
viewContext7 B
)B C
=>D F
PageNavClassG S
(S T
viewContextT _
,_ `
Indexa f
)f g
;g h
public 
static 
string "
ChangePasswordNavClass 3
(3 4
ViewContext4 ?
viewContext@ K
)K L
=>M O
PageNavClassP \
(\ ]
viewContext] h
,h i
ChangePasswordj x
)x y
;y z
public 
static 
string "
ExternalLoginsNavClass 3
(3 4
ViewContext4 ?
viewContext@ K
)K L
=>M O
PageNavClassP \
(\ ]
viewContext] h
,h i
ExternalLoginsj x
)x y
;y z
public 
static 
string +
TwoFactorAuthenticationNavClass <
(< =
ViewContext= H
viewContextI T
)T U
=>V X
PageNavClassY e
(e f
viewContextf q
,q r$
TwoFactorAuthentication	s ä
)
ä ã
;
ã å
public 
static 
string 
PageNavClass )
() *
ViewContext* 5
viewContext6 A
,A B
stringC I
pageJ N
)N O
{ 	
var   

activePage   
=   
viewContext   (
.  ( )
ViewData  ) 1
[  1 2
$str  2 >
]  > ?
as  @ B
string  C I
;  I J
return!! 
string!! 
.!! 
Equals!!  
(!!  !

activePage!!! +
,!!+ ,
page!!- 1
,!!1 2
StringComparison!!3 C
.!!C D
OrdinalIgnoreCase!!D U
)!!U V
?!!W X
$str!!Y a
:!!b c
null!!d h
;!!h i
}"" 	
public$$ 
static$$ 
void$$ 
AddActivePage$$ (
($$( )
this$$) -
ViewDataDictionary$$. @
viewData$$A I
,$$I J
string$$K Q

activePage$$R \
)$$\ ]
=>$$^ `
viewData$$a i
[$$i j
ActivePageKey$$j w
]$$w x
=$$y z

activePage	$${ Ö
;
$$Ö Ü
}%% 
}&& 