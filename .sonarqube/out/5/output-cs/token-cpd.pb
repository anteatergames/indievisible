√
oC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\AutoMapper\AutoMapperConfig.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

AutoMapper# -
{ 
public 

class 
AutoMapperConfig !
{		 
public

 
static

 
MapperConfiguration

 )
RegisterMappings

* :
(

: ;
)

; <
{ 	
return 
new 
MapperConfiguration *
(* +
cfg+ .
=>/ 1
{ 
cfg 
. 

AddProfile 
( 
new "+
DomainToViewModelMappingProfile# B
(B C
)C D
)D E
;E F
cfg 
. 

AddProfile 
( 
new "+
ViewModelToDomainMappingProfile# B
(B C
)C D
)D E
;E F
} 
) 
; 
} 	
} 
} ¢4
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\AutoMapper\DomainToViewModelMappingProfile.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

AutoMapper# -
{ 
internal 
class +
DomainToViewModelMappingProfile 2
:3 4
Profile5 <
{ 
public +
DomainToViewModelMappingProfile .
(. /
)/ 0
{ 	
	CreateMap 
< 
Game 
, 
SelectListItemVo ,
>, -
(- .
). /
. 
	ForMember 
( 
x  
=>! #
x$ %
.% &
Value& +
,+ ,
opt- 0
=>1 3
opt4 7
.7 8
MapFrom8 ?
(? @
x@ A
=>B D
xE F
.F G
IdG I
.I J
ToStringJ R
(R S
)S T
)T U
)U V
. 
	ForMember 
( 
x  
=>! #
x$ %
.% &
Text& *
,* +
opt, /
=>0 2
opt3 6
.6 7
MapFrom7 >
(> ?
x? @
=>A C
xD E
.E F
TitleF K
)K L
)L M
;M N
	CreateMap 
< 
FeaturedContent %
,% &$
FeaturedContentViewModel' ?
>? @
(@ A
)A B
;B C
	CreateMap 
< 
UserPreferences %
,% &$
UserPreferencesViewModel' ?
>? @
(@ A
)A B
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
	Languages( 1
,1 2
opt3 6
=>7 9
opt: =
.= >
ResolveUsing> J
<J K+
UserLanguagesFromDomainResolverK j
>j k
(k l
)l m
)m n
;n o
	CreateMap   
<   
Game   
,   
GameViewModel   )
>  ) *
(  * +
)  + ,
.!! 
	ForMember!! 
(!! 
dest!! #
=>!!$ &
dest!!' +
.!!+ ,

AuthorName!!, 6
,!!6 7
opt!!8 ;
=>!!< >
opt!!? B
.!!B C
MapFrom!!C J
(!!J K
src!!K N
=>!!O Q
src!!R U
.!!U V
DeveloperName!!V c
)!!c d
)!!d e
."" 
	ForMember"" 
("" 
dest"" #
=>""$ &
dest""' +
.""+ ,
	Platforms"", 5
,""5 6
opt""7 :
=>""; =
opt""> A
.""A B
ResolveUsing""B N
<""N O*
GamePlatformFromDomainResolver""O m
>""m n
(""n o
)""o p
)""p q
;""q r
	CreateMap## 
<## 
Game## 
,## !
GameListItemViewModel## 1
>##1 2
(##2 3
)##3 4
;##4 5
	CreateMap'' 
<'' 
UserProfile'' !
,''! "
ProfileViewModel''# 3
>''3 4
(''4 5
)''5 6
.(( 
	ForMember(( 
((( 
x((  
=>((! #
x(($ %
.((% &
Counters((& .
,((. /
opt((0 3
=>((4 6
opt((7 :
.((: ;
Ignore((; A
(((A B
)((B C
)((C D
.)) 
	ForMember)) 
()) 
x))  
=>))! #
x))$ %
.))% &
IndieXp))& -
,))- .
opt))/ 2
=>))3 5
opt))6 9
.))9 :
Ignore)): @
())@ A
)))A B
)))B C
.** 
	ForMember** 
(** 
x**  
=>**! #
x**$ %
.**% &
ExternalLinks**& 3
,**3 4
opt**5 8
=>**9 ;
opt**< ?
.**? @
Ignore**@ F
(**F G
)**G H
)**H I
;**I J
	CreateMap.. 
<.. 
UserContent.. !
,..! " 
UserContentViewModel..# 7
>..7 8
(..8 9
)..9 :
;..: ;
	CreateMap// 
<// 
UserContent// !
,//! "(
UserContentListItemViewModel//# ?
>//? @
(//@ A
)//A B
.00 
	ForMember00 
(00 
x00 
=>00 
x00  !
.00! "
	LikeCount00" +
,00+ ,
opt00- 0
=>001 3
opt004 7
.007 8
MapFrom008 ?
(00? @
x00@ A
=>00B D
x00E F
.00F G
Likes00G L
.00L M
Count00M R
(00R S
)00S T
)00T U
)00U V
;00V W
	CreateMap22 
<22 
UserContent22 !
,22! ",
 UserContentToBeFeaturedViewModel22# C
>22C D
(22D E
)22E F
;22F G
	CreateMap66 
<66 
BrainstormSession66 '
,66' (&
BrainstormSessionViewModel66) C
>66C D
(66D E
)66E F
;66F G
	CreateMap77 
<77 
BrainstormIdea77 $
,77$ %#
BrainstormIdeaViewModel77& =
>77= >
(77> ?
)77? @
;77@ A
	CreateMap88 
<88 
BrainstormVote88 $
,88$ %#
BrainstormVoteViewModel88& =
>88= >
(88> ?
)88? @
;88@ A
	CreateMap99 
<99 
BrainstormComment99 '
,99' (&
BrainstormCommentViewModel99) C
>99C D
(99D E
)99E F
;99F G
	CreateMap== 
<== 
	UserBadge== 
,==  
UserBadgeViewModel==! 3
>==3 4
(==4 5
)==5 6
;==6 7
	CreateMapAA 
<AA 

GameFollowAA  
,AA  !
GameFollowViewModelAA" 5
>AA5 6
(AA6 7
)AA7 8
;AA8 9
	CreateMapBB 
<BB 

UserFollowBB  
,BB  !
UserFollowViewModelBB" 5
>BB5 6
(BB6 7
)BB7 8
;BB8 9
	CreateMapCC 
<CC 
UserConnectionCC $
,CC$ %#
UserConnectionViewModelCC& =
>CC= >
(CC> ?
)CC? @
;CC@ A
}EE 	
}FF 
}GG ç
}C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\AutoMapper\Resolvers\GamePlatformResolver.cs
	namespace		 	
IndieVisible		
 
.		 
Application		 "
.		" #

AutoMapper		# -
.		- .
	Resolvers		. 7
{

 
public 

class (
GamePlatformToDomainResolver -
:. /
IValueResolver0 >
<> ?
GameViewModel? L
,L M
GameN R
,R S
stringT Z
>Z [
{ 
public 
string 
Resolve 
( 
GameViewModel +
source, 2
,2 3
Game4 8
destination9 D
,D E
stringF L

destMemberM W
,W X
ResolutionContextY j
contextk r
)r s
{ 	
var 
result 
= 
string 
.  
Empty  %
;% &
if 
( 
source 
. 
	Platforms  
==! #
null$ (
||) +
!, -
source- 3
.3 4
	Platforms4 =
.= >
Any> A
(A B
)B C
)C D
{ 
return 
result 
; 
} 
result 
= 
string 
. 
Join  
(  !
$char! $
,$ %
source& ,
., -
	Platforms- 6
)6 7
;7 8
return 
result 
; 
} 	
} 
public 

class *
GamePlatformFromDomainResolver /
:0 1
IValueResolver2 @
<@ A
GameA E
,E F
GameViewModelG T
,T U
ListV Z
<Z [
GamePlatforms[ h
>h i
>i j
{ 
public 
List 
< 
GamePlatforms !
>! "
Resolve# *
(* +
Game+ /
source0 6
,6 7
GameViewModel8 E
destinationF Q
,Q R
ListS W
<W X
GamePlatformsX e
>e f

destMemberg q
,q r
ResolutionContext	s Ñ
context
Ö å
)
å ç
{ 	
var   
	platforms   
=   
(   
source   #
.  # $
	Platforms  $ -
??  . 0
string  1 7
.  7 8
Empty  8 =
)  = >
.!! 
Replace!! 
(!! 
$str!! "
,!!" #
$str!!$ *
)!!* +
."" 
Replace"" 
("" 
$str"" '
,""' (
$str"") 6
)""6 7
.## 
Split## 
(## 
new## 
Char## 
[##  
]##  !
{##" #
$char##$ '
}##( )
)##) *
;##* +
var%% 
platformsConverted%% "
=%%# $
	platforms%%% .
.%%. /
Where%%/ 4
(%%4 5
x%%5 6
=>%%7 9
!%%: ;
string%%; A
.%%A B
IsNullOrWhiteSpace%%B T
(%%T U
x%%U V
)%%V W
)%%W X
.%%X Y
Select%%Y _
(%%_ `
x%%` a
=>%%b d
(%%e f
GamePlatforms%%f s
)%%s t
Enum%%t x
.%%x y
Parse%%y ~
(%%~ 
typeof	%% Ö
(
%%Ö Ü
GamePlatforms
%%Ü ì
)
%%ì î
,
%%î ï
x
%%ñ ó
)
%%ó ò
)
%%ò ô
;
%%ô ö
return'' 
platformsConverted'' %
.''% &
ToList''& ,
('', -
)''- .
;''. /
}(( 	
})) 
}** Ø
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\AutoMapper\Resolvers\UserLanguagesResolver.cs
	namespace

 	
IndieVisible


 
.

 
Application

 "
.

" #

AutoMapper

# -
.

- .
	Resolvers

. 7
{ 
public 

class )
UserLanguagesToDomainResolver .
:/ 0
IValueResolver1 ?
<? @$
UserPreferencesViewModel@ X
,X Y
UserPreferencesZ i
,i j
stringk q
>q r
{ 
public 
string 
Resolve 
( $
UserPreferencesViewModel 6
source7 =
,= >
UserPreferences? N
destinationO Z
,Z [
string\ b

destMemberc m
,m n
ResolutionContext	o Ä
context
Å à
)
à â
{ 	
var 
result 
= 
string 
.  
Empty  %
;% &
if 
( 
source 
. 
	Languages  
==! #
null$ (
||) +
!, -
source- 3
.3 4
	Languages4 =
.= >
Any> A
(A B
)B C
)C D
{ 
return 
result 
; 
} 
result 
= 
string 
. 
Join  
(  !
$char! $
,$ %
source& ,
., -
	Languages- 6
)6 7
;7 8
return 
result 
; 
} 	
} 
public 

class +
UserLanguagesFromDomainResolver 0
:1 2
IValueResolver3 A
<A B
UserPreferencesB Q
,Q R$
UserPreferencesViewModelS k
,k l
Listm q
<q r
SupportedLanguage	r É
>
É Ñ
>
Ñ Ö
{ 
public 
List 
< 
SupportedLanguage %
>% &
Resolve' .
(. /
UserPreferences/ >
source? E
,E F$
UserPreferencesViewModelG _
destination` k
,k l
Listm q
<q r
SupportedLanguage	r É
>
É Ñ

destMember
Ö è
,
è ê
ResolutionContext
ë ¢
context
£ ™
)
™ ´
{   	
var!! 
	platforms!! 
=!! 
(!! 
source!! #
.!!# $
ContentLanguages!!$ 4
??!!5 7
string!!8 >
.!!> ?
Empty!!? D
)!!D E
."" 
Split"" 
("" 
new"" 
Char"" 
[""  
]""  !
{""" #
$char""$ '
}""( )
)"") *
;""* +
var$$ 
platformsConverted$$ "
=$$# $
	platforms$$% .
.$$. /
Where$$/ 4
($$4 5
x$$5 6
=>$$7 9
!$$: ;
string$$; A
.$$A B
IsNullOrWhiteSpace$$B T
($$T U
x$$U V
)$$V W
)$$W X
.$$X Y
Select$$Y _
($$_ `
x$$` a
=>$$b d
($$e f
SupportedLanguage$$f w
)$$w x
Enum$$x |
.$$| }
Parse	$$} Ç
(
$$Ç É
typeof
$$É â
(
$$â ä
SupportedLanguage
$$ä õ
)
$$õ ú
,
$$ú ù
x
$$û ü
)
$$ü †
)
$$† °
;
$$° ¢
return&& 
platformsConverted&& %
.&&% &
ToList&&& ,
(&&, -
)&&- .
;&&. /
}'' 	
}(( 
})) È)
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\AutoMapper\ViewModelToDomainMappingProfile.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

AutoMapper# -
{ 
public 

class +
ViewModelToDomainMappingProfile 0
:1 2
Profile3 :
{ 
public +
ViewModelToDomainMappingProfile .
(. /
)/ 0
{ 	
	CreateMap 
< $
FeaturedContentViewModel .
,. /
Domain0 6
.6 7
Models7 =
.= >
FeaturedContent> M
>M N
(N O
)O P
;P Q
	CreateMap 
< $
UserPreferencesViewModel .
,. /
Domain0 6
.6 7
Models7 =
.= >
UserPreferences> M
>M N
(N O
)O P
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
ContentLanguages( 8
,8 9
opt: =
=>> @
optA D
.D E
ResolveUsingE Q
<Q R)
UserLanguagesToDomainResolverR o
>o p
(p q
)q r
)r s
;s t
	CreateMap 
< %
NotificationItemViewModel /
,/ 0
Domain1 7
.7 8
Models8 >
.> ?
Notification? K
>K L
(L M
)M N
;N O
	CreateMap 
< 
GameViewModel #
,# $
Domain% +
.+ ,
Models, 2
.2 3
Game3 7
>7 8
(8 9
)9 :
. 
	ForMember 
( 
dest #
=>$ &
dest' +
.+ ,
DeveloperName, 9
,9 :
opt; >
=>? A
optB E
.E F
MapFromF M
(M N
srcN Q
=>R T
srcU X
.X Y

AuthorNameY c
)c d
)d e
. 
	ForMember 
( 
dest #
=>$ &
dest' +
.+ ,
	Platforms, 5
,5 6
opt7 :
=>; =
opt> A
.A B
ResolveUsingB N
<N O(
GamePlatformToDomainResolverO k
>k l
(l m
)m n
)n o
;o p
	CreateMap"" 
<"" 
ProfileViewModel"" &
,""& '
Domain""( .
."". /
Models""/ 5
.""5 6
UserProfile""6 A
>""A B
(""B C
)""C D
;""D E
	CreateMap&& 
<&&  
UserContentViewModel&& *
,&&* +
Domain&&, 2
.&&2 3
Models&&3 9
.&&9 :
UserContent&&: E
>&&E F
(&&F G
)&&G H
;&&H I
	CreateMap'' 
<'' (
UserContentListItemViewModel'' 2
,''2 3
Domain''4 :
.'': ;
Models''; A
.''A B
UserContent''B M
>''M N
(''N O
)''O P
;''P Q
	CreateMap++ 
<++ &
BrainstormSessionViewModel++ 0
,++0 1
Domain++2 8
.++8 9
Models++9 ?
.++? @
BrainstormSession++@ Q
>++Q R
(++R S
)++S T
;++T U
	CreateMap,, 
<,, #
BrainstormIdeaViewModel,, -
,,,- .
Domain,,/ 5
.,,5 6
Models,,6 <
.,,< =
BrainstormIdea,,= K
>,,K L
(,,L M
),,M N
;,,N O
	CreateMap-- 
<-- #
BrainstormVoteViewModel-- -
,--- .
Domain--/ 5
.--5 6
Models--6 <
.--< =
BrainstormVote--= K
>--K L
(--L M
)--M N
;--N O
	CreateMap.. 
<.. &
BrainstormCommentViewModel.. 0
,..0 1
Domain..2 8
...8 9
Models..9 ?
...? @
BrainstormComment..@ Q
>..Q R
(..R S
)..S T
;..T U
	CreateMap22 
<22 
UserBadgeViewModel22 (
,22( )
Domain22* 0
.220 1
Models221 7
.227 8
	UserBadge228 A
>22A B
(22B C
)22C D
;22D E
	CreateMap66 
<66 
GameFollowViewModel66 )
,66) *
Domain66+ 1
.661 2
Models662 8
.668 9

GameFollow669 C
>66C D
(66D E
)66E F
;66F G
	CreateMap88 
<88 
UserFollowViewModel88 )
,88) *
Domain88+ 1
.881 2
Models882 8
.888 9

UserFollow889 C
>88C D
(88D E
)88E F
;88F G
	CreateMap:: 
<:: #
UserConnectionViewModel:: -
,::- .
Domain::/ 5
.::5 6
Models::6 <
.::< =
UserConnection::= K
>::K L
(::L M
)::M N
;::N O
}<< 	
}== 
}>> Ú
]C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Constants.cs
	namespace 	
IndieVisible
 
. 
Application "
{ 
public 

static 
class 
	Constants !
{ 
public 
static 
string 
DefaultUsername ,
{ 	
get 
{ 
return		 
$str		  
;		  !
}

 
} 	
public 
static 
string 
DefaultAvatar *
{ 	
get 
{ 
return 
$str <
;< =
} 
} 	
public 
static 
string $
DefaultProfileCoverImage 5
{ 	
get 
{ 
return 
$str C
;C D
} 
} 	
public 
static 
string !
DefaultGameCoverImage 2
{ 	
get 
{ 
return   
$str   @
;  @ A
}!! 
}"" 	
public$$ 
static$$ 
string$$  
DefaultGameThumbnail$$ 1
{%% 	
get&& 
{'' 
return(( 
$str(( A
;((A B
})) 
}** 	
public,, 
static,, 
string,,  
DefaultFeaturedImage,, 1
{-- 	
get.. 
{// 
return00 
$str00 ?
;00? @
}11 
}22 	
public44 
static44 
string44 
DefaultImagePath44 -
{55 	
get66 
{77 
return88 
$str88 '
;88' (
}99 
}:: 	
public<< 
static<< 
string<<  
DefaultUserImagePath<< 1
{== 	
get>> 
{?? 
return@@ 
$str@@ +
;@@+ ,
}AA 
}BB 	
publicDD 
staticDD 
stringDD 
DefaultCdnPathDD +
{EE 	
getFF 
{GG 
returnHH 
$strHH ?
;HH? @
}II 
}JJ 	
publicLL 
staticLL 
stringLL #
DefaultAzureStoragePathLL 4
{MM 	
getNN 
{OO 
returnPP 
$strPP D
;PPD E
}QQ 
}RR 	
}SS 
}TT ÓV
\C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\FakeData.cs
	namespace 	
IndieVisible
 
. 
Application "
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
 
FakeData

  
{ 
public 
static 
CarouselViewModel '
FakeCarousel( 4
(4 5
)5 6
{ 	
CarouselViewModel 
carousel &
=' (
new) ,
CarouselViewModel- >
(> ?
)? @
;@ A
carousel 
. 
Items 
= 
new  
List! %
<% &$
FeaturedContentViewModel& >
>> ?
(? @
)@ A
;A B$
FeaturedContentViewModel $
item1% *
=+ ,
new- 0$
FeaturedContentViewModel1 I
{ 
Url 
= 
$str 
, 
ImageUrl 
= 
$str 5
,5 6
Title 
= 
$str 
, 
Introduction 
= 
$str <
} 
; 
carousel 
. 
Items 
. 
Add 
( 
item1 $
)$ %
;% &$
FeaturedContentViewModel $
item2% *
=+ ,
new- 0$
FeaturedContentViewModel1 I
{ 
Url 
= 
$str 
, 
ImageUrl 
= 
$str 8
,8 9
Title 
= 
$str $
,$ %
Introduction   
=   
$str   K
}!! 
;!! 
carousel"" 
."" 
Items"" 
."" 
Add"" 
("" 
item2"" $
)""$ %
;""% &$
FeaturedContentViewModel$$ $
item3$$% *
=$$+ ,
new$$- 0$
FeaturedContentViewModel$$1 I
{%% 
Url&& 
=&& 
$str&& 
,&& 
ImageUrl'' 
='' 
$str'' :
,'': ;
Title(( 
=(( 
$str(( 3
,((3 4
Introduction)) 
=)) 
$str)) X
}** 
;** 
carousel++ 
.++ 
Items++ 
.++ 
Add++ 
(++ 
item3++ $
)++$ %
;++% &$
FeaturedContentViewModel-- $
item4--% *
=--+ ,
new--- 0$
FeaturedContentViewModel--1 I
{.. 
Url// 
=// 
$str// 
,// 
ImageUrl00 
=00 
$str00 E
,00E F
Title11 
=11 
$str11 "
,11" #
Introduction22 
=22 
$str22 ;
}33 
;33 
carousel44 
.44 
Items44 
.44 
Add44 
(44 
item444 $
)44$ %
;44% &
return66 
carousel66 
;66 
}77 	
public99 
static99 
CountersViewModel99 '
FakeCounters99( 4
(994 5
)995 6
{:: 	
CountersViewModel;; 
counters;; &
=;;' (
new;;) ,
CountersViewModel;;- >
(;;> ?
);;? @
;;;@ A
counters== 
.== 

GamesCount== 
===  !
$num==" &
;==& '
counters>> 
.>> 

UsersCount>> 
=>>  !
$num>>" &
;>>& '
counters?? 
.?? 
ArticlesCount?? "
=??# $
$num??% (
;??( )
counters@@ 
.@@ 
	JamsCount@@ 
=@@  
$num@@! #
;@@# $
returnBB 
countersBB 
;BB 
}CC 	
publicEE 
staticEE 
ListEE 
<EE !
GameListItemViewModelEE 0
>EE0 1
FakeFeaturedGamesEE2 C
(EEC D
)EED E
{FF 	
ListGG 
<GG !
GameListItemViewModelGG &
>GG& '
gamesGG( -
=GG. /
newGG0 3
ListGG4 8
<GG8 9!
GameListItemViewModelGG9 N
>GGN O
(GGO P
)GGP Q
;GGQ R!
GameListItemViewModelII !
game2II" '
=II( )
newII* -!
GameListItemViewModelII. C
(IIC D
)IID E
;IIE F
game2JJ 
.JJ 
ThumbnailUrlJJ 
=JJ  
$strJJ! D
;JJD E
game2KK 
.KK 
DeveloperImageUrlKK #
=KK$ %
$strKK& P
;KKP Q
game2LL 
.LL 
TitleLL 
=LL 
$strLL %
;LL% &
game2MM 
.MM 
DeveloperNameMM 
=MM  !
$strMM" 4
;MM4 5
game2NN 
.NN 
PriceNN 
=NN 
$strNN  
;NN  !
gamesUU 
.UU 
AddUU 
(UU 
game2UU 
)UU 
;UU !
GameListItemViewModelWW !
game3WW" '
=WW( )
newWW* -!
GameListItemViewModelWW. C
(WWC D
)WWD E
;WWE F
game3XX 
.XX 
ThumbnailUrlXX 
=XX  
$strXX! D
;XXD E
game3YY 
.YY 
DeveloperImageUrlYY #
=YY$ %
$strYY& P
;YYP Q
game3ZZ 
.ZZ 
TitleZZ 
=ZZ 
$strZZ )
;ZZ) *
game3[[ 
.[[ 
DeveloperName[[ 
=[[  !
$str[[" 4
;[[4 5
game3\\ 
.\\ 
Price\\ 
=\\ 
$str\\  
;\\  !
gamesaa 
.aa 
Addaa 
(aa 
game3aa 
)aa 
;aa !
GameListItemViewModelcc !
game1cc" '
=cc( )
newcc* -!
GameListItemViewModelcc. C
(ccC D
)ccD E
;ccE F
game1dd 
.dd 
ThumbnailUrldd 
=dd  
$strdd! D
;ddD E
game1ee 
.ee 
DeveloperImageUrlee #
=ee$ %
$stree& P
;eeP Q
game1ff 
.ff 
Titleff 
=ff 
$strff #
;ff# $
game1gg 
.gg 
DeveloperNamegg 
=gg  !
$strgg" 0
;gg0 1
game1hh 
.hh 
Pricehh 
=hh 
$strhh  
;hh  !
gamesnn 
.nn 
Addnn 
(nn 
game1nn 
)nn 
;nn 
returnpp 
gamespp 
;pp 
}qq 	
publicss 
staticss 
ProfileViewModelss &
FakeProfiless' 2
(ss2 3
)ss3 4
{tt 	
ProfileViewModeluu 
profileuu $
=uu% &
newuu' *
ProfileViewModeluu+ ;
(uu; <
)uu< =
;uu= >
profileww 
.ww 
Typeww 
=ww 
ProfileTypeww &
.ww& '
Personalww' /
;ww/ 0
profileyy 
.yy 
Nameyy 
=yy 
$stryy $
;yy$ %
profilezz 
.zz 
Mottozz 
=zz 
$strzz (
;zz( )
profile{{ 
.{{ 
CoverImageUrl{{ !
={{" #
$str{{$ B
;{{B C
profile}} 
.}} 
Bio}} 
=}} 
$str}} i
;}}i j
profile 
. 

StudioName 
=  
$str! 6
;6 7
profile
ÄÄ 
.
ÄÄ 
Location
ÄÄ 
=
ÄÄ 
$str
ÄÄ )
;
ÄÄ) *
profile
ÇÇ 
.
ÇÇ 
GameJoltUrl
ÇÇ 
=
ÇÇ  !
string
ÇÇ" (
.
ÇÇ( )
Empty
ÇÇ) .
;
ÇÇ. /
profile
ÉÉ 
.
ÉÉ 
	ItchIoUrl
ÉÉ 
=
ÉÉ 
string
ÉÉ  &
.
ÉÉ& '
Empty
ÉÉ' ,
;
ÉÉ, -
profile
ÑÑ 
.
ÑÑ 

IndieDbUrl
ÑÑ 
=
ÑÑ  
string
ÑÑ! '
.
ÑÑ' (
Empty
ÑÑ( -
;
ÑÑ- .
profile
ÖÖ 
.
ÖÖ 
UnityConnectUrl
ÖÖ #
=
ÖÖ$ %
string
ÖÖ& ,
.
ÖÖ, -
Empty
ÖÖ- 2
;
ÖÖ2 3
profile
ÜÜ 
.
ÜÜ 
GameDevNetUrl
ÜÜ !
=
ÜÜ" #
string
ÜÜ$ *
.
ÜÜ* +
Empty
ÜÜ+ 0
;
ÜÜ0 1
profile
àà 
.
àà 
Counters
àà 
.
àà 
	Followers
àà &
=
àà' (
$num
àà) -
;
àà- .
profile
ââ 
.
ââ 
Counters
ââ 
.
ââ 
	Following
ââ &
=
ââ' (
$num
ââ) ,
;
ââ, -
profile
ää 
.
ää 
Counters
ää 
.
ää 
Connections
ää (
=
ää) *
$num
ää+ /
;
ää/ 0
profile
ãã 
.
ãã 
Counters
ãã 
.
ãã 
Games
ãã "
=
ãã# $
$num
ãã% '
;
ãã' (
profile
åå 
.
åå 
Counters
åå 
.
åå 
Posts
åå "
=
åå# $
$num
åå% &
;
åå& '
profile
çç 
.
çç 
Counters
çç 
.
çç 
Comments
çç %
=
çç& '
$num
çç( -
;
çç- .
profile
éé 
.
éé 
Counters
éé 
.
éé 
Jams
éé !
=
éé" #
$num
éé$ &
;
éé& '
profile
êê 
.
êê 
IndieXp
êê 
.
êê 
Level
êê !
=
êê" #
$num
êê$ %
;
êê% &
profile
ëë 
.
ëë 
IndieXp
ëë 
.
ëë 
LevelXp
ëë #
=
ëë$ %
$num
ëë& )
;
ëë) *
profile
íí 
.
íí 
IndieXp
íí 
.
íí 
NextLevelXp
íí '
=
íí( )
$num
íí* .
;
íí. /
profile
îî 
.
îî 
ExternalLinks
îî !
.
îî! "
Add
îî" %
(
îî% &
ExternalLinks
îî& 3
.
îî3 4
Website
îî4 ;
,
îî; <
$str
îî= Z
)
îîZ [
;
îî[ \
profile
ïï 
.
ïï 
ExternalLinks
ïï !
.
ïï! "
Add
ïï" %
(
ïï% &
ExternalLinks
ïï& 3
.
ïï3 4
Facebook
ïï4 <
,
ïï< =
$str
ïï> W
)
ïïW X
;
ïïX Y
return
óó 
profile
óó 
;
óó 
}
òò 	
}
ôô 
}öö ©
kC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Formatters\UrlFormatter.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Formatters# -
{ 
public 

static 
class 
UrlFormatter $
{ 
public 
static 
string 
ProfileImage )
() *
Guid* .
userId/ 5
)5 6
{		 	
return 
String 
. 
Format  
(  !
$str! .
,. /
	Constants0 9
.9 : 
DefaultUserImagePath: N
,N O
BlobTypeP X
.X Y
ProfileImageY e
,e f
userIdg m
,m n
userIdo u
)u v
;v w
} 	
public 
static 
string 
ProfileCoverImage .
(. /
Guid/ 3
userId4 :
,: ;
Guid< @
	profileIdA J
)J K
{ 	
return 
String 
. 
Format  
(  !
$str! ;
,; <
	Constants= F
.F G
DefaultCdnPathG U
,U V
userIdW ]
,] ^
	profileId_ h
)h i
;i j
} 	
public 
static 
string 
Image "
(" #
Guid# '
userId( .
,. /
BlobType0 8
type9 =
,= >
string? E
fileNameF N
)N O
{ 	
if 
( 
fileName 
. 

StartsWith #
(# $
	Constants$ -
.- .
DefaultCdnPath. <
)< =
)= >
{ 
return 
fileName 
;  
} 
else 
{ 
return 
String 
. 
Format $
($ %
$str% 2
,2 3
	Constants4 =
.= >
DefaultCdnPath> L
.L M
TrimEndM T
(T U
$charU X
)X Y
,Y Z
userId[ a
,a b
fileNamec k
)k l
;l m
} 
} 	
} 
}   Ç
tC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IBrainstormAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public		 

	interface		 !
IBrainstormAppService		 *
:		+ ,
ICrudAppService		- <
<		< =#
BrainstormIdeaViewModel		= T
>		T U
{

 !
OperationResultListVo 
< #
BrainstormIdeaViewModel 5
>5 6
GetAll7 =
(= >
Guid> B
userIdC I
)I J
;J K
OperationResultVo 
< #
BrainstormIdeaViewModel 1
>1 2
GetById3 :
(: ;
Guid; ?
userId@ F
,F G
GuidH L
idM O
)O P
;P Q
OperationResultVo 
Vote 
( 
Guid #
userId$ *
,* +
Guid, 0
ideaId1 7
,7 8
	VoteValue9 B
voteC G
)G H
;H I
OperationResultVo 
Comment !
(! "'
UserContentCommentViewModel" =
vm> @
)@ A
;A B
OperationResultVo 
< &
BrainstormSessionViewModel 4
>4 5

GetSession6 @
(@ A
GuidA E
userIdF L
,L M!
BrainstormSessionTypeN c
typed h
)h i
;i j!
OperationResultListVo 
< &
BrainstormSessionViewModel 8
>8 9
GetSessions: E
(E F
GuidF J
userIdK Q
)Q R
;R S
OperationResultVo 
< 
Guid 
> 
SaveSession  +
(+ ,&
BrainstormSessionViewModel, F
vmG I
)I J
;J K!
OperationResultListVo 
< #
BrainstormIdeaViewModel 5
>5 6
GetAllBySessionId7 H
(H I
GuidI M
userIdN T
,T U
GuidV Z
	sessionId[ d
)d e
;e f
} 
} ´

nC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\ICrudAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{		 
public

 

	interface

 
ICrudAppService

 $
<

$ %
T

% &
>

& '
{ 
Guid 
CurrentUserId 
{ 
get  
;  !
set" %
;% &
}' (
OperationResultVo 
< 
int 
> 
Count $
($ %
)% &
;& '!
OperationResultListVo 
< 
T 
>  
GetAll! '
(' (
)( )
;) *
OperationResultVo 
< 
T 
> 
GetById $
($ %
Guid% )
id* ,
), -
;- .
OperationResultVo 
< 
Guid 
> 
Save  $
($ %
T% &
	viewModel' 0
)0 1
;1 2
OperationResultVo 
Remove  
(  !
Guid! %
id& (
)( )
;) *
} 
} ı	
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IFeaturedContentAppService.cs
	namespace

 	
IndieVisible


 
.

 
Application

 "
.

" #

Interfaces

# -
{ 
public 

	interface &
IFeaturedContentAppService /
:0 1
ICrudAppService2 A
<A B$
FeaturedContentViewModelB Z
>Z [
{ 
CarouselViewModel 
GetFeaturedNow (
(( )
)) *
;* +
OperationResultVo 
< 
Guid 
> 
Add  #
(# $
Guid$ (
userId) /
,/ 0
Guid1 5
	contentId6 ?
,? @
stringA G
titleH M
,M N
stringO U
introductionV b
)b c
;c d
IEnumerable 
< ,
 UserContentToBeFeaturedViewModel 4
>4 5"
GetContentToBeFeatured6 L
(L M
)M N
;N O
OperationResultVo 
	Unfeature #
(# $
Guid$ (
id) +
)+ ,
;, -
} 
} ˛
pC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IFollowAppService.cs
	namespace		 	
IndieVisible		
 
.		 
Application		 "
.		" #

Interfaces		# -
{

 
public 

	interface 
IFollowAppService &
{ 
OperationResultVo 

GameFollow $
($ %
Guid% )
userId* 0
,0 1
Guid2 6
gameId7 =
)= >
;> ?
OperationResultVo 
GameUnfollow &
(& '
Guid' +
userId, 2
,2 3
Guid4 8
gameId9 ?
)? @
;@ A
OperationResultVo 

UserFollow $
($ %
Guid% )
userId* 0
,0 1
Guid2 6
followUserId7 C
)C D
;D E
OperationResultVo 
UserUnfollow &
(& '
Guid' +
userId, 2
,2 3
Guid4 8
followUserId9 E
)E F
;F G
} 
} ˛
nC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IGameAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{		 
public

 

	interface

 
IGameAppService

 $
:

% &
ICrudAppService

' 6
<

6 7
GameViewModel

7 D
>

D E
{ 
IEnumerable 
< !
GameListItemViewModel )
>) *
	GetLatest+ 4
(4 5
Guid5 9
currentUserId: G
,G H
intI L
countM R
,R S
GuidT X
userIdY _
,_ `
	GameGenrea j
genrek p
)p q
;q r
IEnumerable 
< 
SelectListItemVo $
>$ %
	GetByUser& /
(/ 0
Guid0 4
userId5 ;
); <
;< =
} 
} ≥
tC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IGameFollowAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public		 

	interface		 !
IGameFollowAppService		 *
:		+ ,
ICrudAppService		- <
<		< =
GameFollowViewModel		= P
>		P Q
{

 !
OperationResultListVo 
< 
GameFollowViewModel 1
>1 2
GetByGameId3 >
(> ?
Guid? C
gameIdD J
)J K
;K L
} 
} Ø
sC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IImageStorageService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public		 

	interface		  
IImageStorageService		 )
{

 
Task 
< 
string 
> 
StoreImageAsync $
($ %
string% +
	container, 5
,5 6
string7 =
filename> F
,F G
byteH L
[L M
]M N
imageO T
)T U
;U V
Task 
< 
string 
> 
DeleteImageAsync %
(% &
string& ,
	container- 6
,6 7
string8 >
filename? G
)G H
;H I
} 
} Ñ
nC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\ILikeAppService.cs
	namespace		 	
IndieVisible		
 
.		 
Application		 "
.		" #

Interfaces		# -
{

 
public 

	interface 
ILikeAppService $
:% &
ICrudAppService' 6
<6 7
UserLikeViewModel7 H
>H I
{ 
OperationResultVo 
ContentLike %
(% &
Guid& *
likedId+ 2
)2 3
;3 4
OperationResultVo 
ContentUnlike '
(' (
Guid( ,
likedId- 4
)4 5
;5 6
OperationResultVo 
GameLike "
(" #
Guid# '
userId( .
). /
;/ 0
OperationResultVo 

GameUnlike $
($ %
Guid% )
likedId* 1
)1 2
;2 3
} 
} Ó	
vC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\INotificationAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public 

	interface #
INotificationAppService ,
:- .
ICrudAppService/ >
<> ?%
NotificationItemViewModel? X
>X Y
{		 !
OperationResultListVo 
< %
NotificationItemViewModel 7
>7 8
GetByUserId9 D
(D E
GuidE I
userIdJ P
,P Q
intR U
countV [
)[ \
;\ ]
OperationResultVo 
Notify  
(  !
Guid! %
targetUserId& 2
,2 3
NotificationType4 D
contentLikeE P
,P Q
GuidR V
targetIdW _
,_ `
stringa g
texth l
,l m
stringn t
urlu x
)x y
;y z
OperationResultVo 

MarkAsRead $
($ %
Guid% )
id* ,
), -
;- .
} 
} ≤
qC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IProfileAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public		 

	interface		 
IProfileAppService		 '
:		( )
ICrudAppService		* 9
<		9 :
ProfileViewModel		: J
>		J K
{

 
ProfileViewModel 
GetByUserId $
($ %
Guid% )
userId* 0
,0 1
ProfileType2 =
type> B
)B C
;C D
ProfileViewModel 
GetByUserId $
($ %
Guid% )
currentUserId* 7
,7 8
Guid9 =
userId> D
,D E
ProfileTypeF Q
typeR V
)V W
;W X
ProfileViewModel 
GenerateNewOne '
(' (
ProfileType( 3
type4 8
)8 9
;9 :
} 
} ≠
sC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IUserBadgeAppService.cs
	namespace		 	
IndieVisible		
 
.		 
Application		 "
.		" #

Interfaces		# -
{

 
public 

	interface  
IUserBadgeAppService )
:* +
ICrudAppService, ;
<; <
UserBadgeViewModel< N
>N O
{ !
OperationResultListVo 
< 
UserBadgeViewModel 0
>0 1
	GetByUser2 ;
(; <
Guid< @
userIdA G
)G H
;H I
} 
} Ÿ
xC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IUserConnectionAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public		 

	interface		 %
IUserConnectionAppService		 .
:		/ 0
ICrudAppService		1 @
<		@ A#
UserConnectionViewModel		A X
>		X Y
{

 !
OperationResultListVo 
< #
UserConnectionViewModel 5
>5 6
GetByTargetUserId7 H
(H I
GuidI M
targetUserIdN Z
)Z [
;[ \
OperationResultVo 
Connect !
(! "
Guid" &
currentUserId' 4
,4 5
Guid6 :
userId; A
)A B
;B C
OperationResultVo 

Disconnect $
($ %
Guid% )
currentUserId* 7
,7 8
Guid9 =
userId> D
)D E
;E F
OperationResultVo 
Allow 
(  
Guid  $
currentUserId% 2
,2 3
Guid4 8
userId9 ?
)? @
;@ A
OperationResultVo 
Deny 
( 
Guid #
currentUserId$ 1
,1 2
Guid3 7
userId8 >
)> ?
;? @
} 
} ∂
uC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IUserContentAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public		 

	interface		 "
IUserContentAppService		 +
:		, -
ICrudAppService		. =
<		= > 
UserContentViewModel		> R
>		R S
{

 
IEnumerable 
< (
UserContentListItemViewModel 0
>0 1
GetActivityFeed2 A
(A B
GuidB F
currentUserIdG T
,T U
intV Y
countZ _
,_ `
Guida e
gameIdf l
,l m
Guidn r
userIds y
,y z
List{ 
<	 Ä
SupportedLanguage
Ä ë
>
ë í
	languages
ì ú
)
ú ù
;
ù û
int 
CountArticles 
( 
) 
; 
} 
} û
|C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IUserContentCommentAppService.cs
	namespace		 	
IndieVisible		
 
.		 
Application		 "
.		" #

Interfaces		# -
{

 
public 

	interface )
IUserContentCommentAppService 2
:3 4
ICrudAppService5 D
<D E'
UserContentCommentViewModelE `
>` a
{ 
OperationResultVo 
Comment !
(! "'
UserContentCommentViewModel" =
	viewModel> G
)G H
;H I
} 
} ã
tC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IUserFollowAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public		 

	interface		 !
IUserFollowAppService		 *
:		+ ,
ICrudAppService		- <
<		< =
UserFollowViewModel		= P
>		P Q
{

 !
OperationResultListVo 
< 
UserFollowViewModel 1
>1 2
GetByUserId3 >
(> ?
Guid? C
userIdD J
)J K
;K L!
OperationResultListVo 
< 
UserFollowViewModel 1
>1 2
GetByFollowedId3 B
(B C
GuidC G
followUserIdH T
)T U
;U V
} 
} Ü
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Interfaces\IUserPreferencesAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

Interfaces# -
{ 
public 

	interface &
IUserPreferencesAppService /
:0 1
ICrudAppService2 A
<A B$
UserPreferencesViewModelB Z
>Z [
{		 $
UserPreferencesViewModel  
GetByUserId! ,
(, -
Guid- 1
userId2 8
)8 9
;9 :
} 
} ì
pC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\Base\BaseAppService.cs
	namespace		 	
IndieVisible		
 
.		 
Application		 "
.		" #
Services		# +
{

 
public 

class 
BaseAppService 
{ 
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
	protected 
	MediaType 
GetMediaType (
(( )
string) /
featuredImage0 =
)= >
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
featuredImage* 7
)7 8
)8 9
{ 
return 
	MediaType  
.  !
None! %
;% &
} 
var 
youtubePattern 
=  
$str! U
;U V
var 
match 
= 
Regex 
. 
Match #
(# $
featuredImage$ 1
,1 2
youtubePattern3 A
)A B
;B C
if 
( 
match 
. 
Success 
) 
{ 
return 
	MediaType  
.  !
Youtube! (
;( )
} 
var   
imageExtensions   
=    !
new  " %
string  & ,
[  , -
]  - .
{  / 0
$str  1 6
,  6 7
$str  8 =
,  = >
$str  ? D
,  D E
$str  F L
,  L M
$str  N T
,  T U
$str  V [
,  [ \
$str  ] c
,  c d
$str  e k
,  k l
$str  m r
}  s t
;  t u
var!! 
videoExtensions!! 
=!!  !
new!!" %
string!!& ,
[!!, -
]!!- .
{!!/ 0
$str!!1 6
,!!6 7
$str!!8 =
,!!= >
$str!!? E
,!!E F
$str!!G L
,!!L M
$str!!N T
,!!T U
$str!!V [
,!![ \
$str!!] b
,!!b c
$str!!d i
,!!i j
$str!!k p
,!!p q
$str!!r w
,!!w x
$str!!y ~
,!!~ 
$str
!!Ä Ö
}
!!Ü á
;
!!á à
var## 
	extension## 
=## 
featuredImage## )
?##) *
.##* +
Split##+ 0
(##0 1
$char##1 4
)##4 5
.##5 6
Last##6 :
(##: ;
)##; <
;##< =
if&& 
(&& 
imageExtensions&& 
.&&  
Contains&&  (
(&&( )
	extension&&) 2
.&&2 3
ToLower&&3 :
(&&: ;
)&&; <
)&&< =
)&&= >
{'' 
return(( 
	MediaType((  
.((  !
Image((! &
;((& '
})) 
else** 
if** 
(** 
videoExtensions** $
.**$ %
Contains**% -
(**- .
	extension**. 7
.**7 8
ToLower**8 ?
(**? @
)**@ A
)**A B
)**B C
{++ 
return,, 
	MediaType,,  
.,,  !
Video,,! &
;,,& '
}-- 
return// 
	MediaType// 
.// 
Image// "
;//" #
}00 	
public22 
void22 
Dispose22 
(22 
)22 
{33 	
GC44 
.44 
SuppressFinalize44 
(44  
this44  $
)44$ %
;44% &
}55 	
}66 
}77 ¯Õ
qC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\BrainstormAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class  
BrainstormAppService %
:& '
BaseAppService( 6
,6 7!
IBrainstormAppService8 M
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly (
IBrainstormSessionRepository 5'
brainstormSessionRepository6 Q
;Q R
private 
readonly %
IBrainstormIdeaRepository 2$
brainstormIdeaRepository3 K
;K L
private 
readonly %
IBrainstormVoteRepository 2$
brainstormVoteRepository3 K
;K L
private 
readonly (
IBrainstormCommentRepository 5'
brainstormCommentRepository6 Q
;Q R
private 
readonly &
IGamificationDomainService 3%
gamificationDomainService4 M
;M N
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public  
BrainstormAppService #
(# $
IMapper$ +
mapper, 2
,2 3
IUnitOfWork4 ?

unitOfWork@ J
,   (
IBrainstormSessionRepository   *'
brainstormSessionRepository  + F
,  F G%
IBrainstormIdeaRepository  H a$
brainstormIdeaRepository  b z
,  z {&
IBrainstormVoteRepository	  | ï&
brainstormVoteRepository
  ñ Æ
,
  Æ Ø*
IBrainstormCommentRepository
  ∞ Ã)
brainstormCommentRepository
  Õ Ë
,!! &
IGamificationDomainService!! (%
gamificationDomainService!!) B
)!!B C
{"" 	
this## 
.## 
mapper## 
=## 
mapper##  
;##  !
this$$ 
.$$ 

unitOfWork$$ 
=$$ 

unitOfWork$$ (
;$$( )
this%% 
.%% $
brainstormIdeaRepository%% )
=%%* +$
brainstormIdeaRepository%%, D
;%%D E
this&& 
.&& '
brainstormSessionRepository&& ,
=&&- .'
brainstormSessionRepository&&/ J
;&&J K
this'' 
.'' $
brainstormVoteRepository'' )
=''* +$
brainstormVoteRepository'', D
;''D E
this(( 
.(( '
brainstormCommentRepository(( ,
=((- .'
brainstormCommentRepository((/ J
;((J K
this)) 
.)) %
gamificationDomainService)) *
=))+ ,%
gamificationDomainService))- F
;))F G
}** 	
public,, 
OperationResultVo,,  
<,,  !
int,,! $
>,,$ %
Count,,& +
(,,+ ,
),,, -
{-- 	
OperationResultVo.. 
<.. 
int.. !
>..! "
result..# )
;..) *
try00 
{11 
int22 
count22 
=22 $
brainstormIdeaRepository22 4
.224 5
GetAll225 ;
(22; <
)22< =
.22= >
Count22> C
(22C D
)22D E
;22E F
result44 
=44 
new44 
OperationResultVo44 .
<44. /
int44/ 2
>442 3
(443 4
count444 9
)449 :
;44: ;
}55 
catch66 
(66 
	Exception66 
ex66 
)66  
{77 
result88 
=88 
new88 
OperationResultVo88 .
<88. /
int88/ 2
>882 3
(883 4
ex884 6
.886 7
Message887 >
)88> ?
;88? @
}99 
return;; 
result;; 
;;; 
}<< 	
public>> !
OperationResultListVo>> $
<>>$ %#
BrainstormIdeaViewModel>>% <
>>>< =
GetAll>>> D
(>>D E
)>>E F
{?? 	!
OperationResultListVo@@ !
<@@! "#
BrainstormIdeaViewModel@@" 9
>@@9 :
result@@; A
;@@A B
tryBB 
{CC 

IQueryableDD 
<DD 
BrainstormIdeaDD )
>DD) *
	allModelsDD+ 4
=DD5 6$
brainstormIdeaRepositoryDD7 O
.DDO P
GetAllDDP V
(DDV W
)DDW X
;DDX Y
IEnumerableFF 
<FF #
BrainstormIdeaViewModelFF 3
>FF3 4
vmsFF5 8
=FF9 :
mapperFF; A
.FFA B
MapFFB E
<FFE F
IEnumerableFFF Q
<FFQ R
BrainstormIdeaFFR `
>FF` a
,FFa b
IEnumerableFFc n
<FFn o$
BrainstormIdeaViewModel	FFo Ü
>
FFÜ á
>
FFá à
(
FFà â
	allModels
FFâ í
)
FFí ì
;
FFì î
vmsHH 
=HH 
vmsHH 
.HH 
OrderByDescendingHH +
(HH+ ,
xHH, -
=>HH. 0
xHH1 2
.HH2 3
	VoteCountHH3 <
)HH< =
.HH= >
ThenByDescendingHH> N
(HHN O
xHHO P
=>HHQ S
xHHT U
.HHU V

CreateDateHHV `
)HH` a
;HHa b
resultJJ 
=JJ 
newJJ !
OperationResultListVoJJ 2
<JJ2 3#
BrainstormIdeaViewModelJJ3 J
>JJJ K
(JJK L
vmsJJL O
)JJO P
;JJP Q
}KK 
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL  
{MM 
resultNN 
=NN 
newNN !
OperationResultListVoNN 2
<NN2 3#
BrainstormIdeaViewModelNN3 J
>NNJ K
(NNK L
exNNL N
.NNN O
MessageNNO V
)NNV W
;NNW X
}OO 
returnQQ 
resultQQ 
;QQ 
}RR 	
publicTT 
OperationResultVoTT  
<TT  !#
BrainstormIdeaViewModelTT! 8
>TT8 9
GetByIdTT: A
(TTA B
GuidTTB F
idTTG I
)TTI J
{UU 	
OperationResultVoVV 
<VV #
BrainstormIdeaViewModelVV 5
>VV5 6
resultVV7 =
;VV= >
tryXX 
{YY 
BrainstormIdeaZZ 
modelZZ $
=ZZ% &$
brainstormIdeaRepositoryZZ' ?
.ZZ? @
GetByIdZZ@ G
(ZZG H
idZZH J
)ZZJ K
;ZZK L#
BrainstormIdeaViewModel\\ '
vm\\( *
=\\+ ,
mapper\\- 3
.\\3 4
Map\\4 7
<\\7 8#
BrainstormIdeaViewModel\\8 O
>\\O P
(\\P Q
model\\Q V
)\\V W
;\\W X
vm__ 
.__ 
	VoteCount__ 
=__ $
brainstormVoteRepository__ 7
.__7 8
Count__8 =
(__= >
x__> ?
=>__@ B
x__C D
.__D E
IdeaId__E K
==__L N
vm__O Q
.__Q R
Id__R T
)__T U
;__U V
vm`` 
.`` 
Score`` 
=`` $
brainstormVoteRepository`` 3
.``3 4
GetAll``4 :
(``: ;
)``; <
.``< =
Where``= B
(``B C
x``C D
=>``E G
x``H I
.``I J
IdeaId``J P
==``Q S
vm``T V
.``V W
Id``W Y
)``Y Z
.``Z [
Sum``[ ^
(``^ _
x``_ `
=>``a c
(``d e
int``e h
)``h i
x``i j
.``j k
	VoteValue``k t
)``t u
;``u v
resultbb 
=bb 
newbb 
OperationResultVobb .
<bb. /#
BrainstormIdeaViewModelbb/ F
>bbF G
(bbG H
vmbbH J
)bbJ K
;bbK L
}cc 
catchdd 
(dd 
	Exceptiondd 
exdd 
)dd  
{ee 
resultff 
=ff 
newff 
OperationResultVoff .
<ff. /#
BrainstormIdeaViewModelff/ F
>ffF G
(ffG H
exffH J
.ffJ K
MessageffK R
)ffR S
;ffS T
}gg 
returnii 
resultii 
;ii 
}jj 	
publicll 
OperationResultVoll  
Removell! '
(ll' (
Guidll( ,
idll- /
)ll/ 0
{mm 	
OperationResultVonn 
resultnn $
;nn$ %
trypp 
{qq $
brainstormIdeaRepositorytt (
.tt( )
Removett) /
(tt/ 0
idtt0 2
)tt2 3
;tt3 4

unitOfWorkvv 
.vv 
Commitvv !
(vv! "
)vv" #
;vv# $
resultxx 
=xx 
newxx 
OperationResultVoxx .
(xx. /
truexx/ 3
)xx3 4
;xx4 5
}yy 
catchzz 
(zz 
	Exceptionzz 
exzz 
)zz  
{{{ 
result|| 
=|| 
new|| 
OperationResultVo|| .
(||. /
ex||/ 1
.||1 2
Message||2 9
)||9 :
;||: ;
}}} 
return 
result 
; 
}
ÄÄ 	
public
ÇÇ 
OperationResultVo
ÇÇ  
<
ÇÇ  !
Guid
ÇÇ! %
>
ÇÇ% &
Save
ÇÇ' +
(
ÇÇ+ ,%
BrainstormIdeaViewModel
ÇÇ, C
	viewModel
ÇÇD M
)
ÇÇM N
{
ÉÉ 	
OperationResultVo
ÑÑ 
<
ÑÑ 
Guid
ÑÑ "
>
ÑÑ" #
result
ÑÑ$ *
;
ÑÑ* +
try
ÜÜ 
{
áá 
BrainstormIdea
àà 
model
àà $
;
àà$ %
BrainstormIdea
åå 
existing
åå '
=
åå( )&
brainstormIdeaRepository
åå* B
.
ååB C
GetById
ååC J
(
ååJ K
	viewModel
ååK T
.
ååT U
Id
ååU W
)
ååW X
;
ååX Y
if
çç 
(
çç 
existing
çç 
!=
çç 
null
çç  $
)
çç$ %
{
éé 
model
èè 
=
èè 
mapper
èè "
.
èè" #
Map
èè# &
(
èè& '
	viewModel
èè' 0
,
èè0 1
existing
èè2 :
)
èè: ;
;
èè; <
}
êê 
else
ëë 
{
íí 
model
ìì 
=
ìì 
mapper
ìì "
.
ìì" #
Map
ìì# &
<
ìì& '
BrainstormIdea
ìì' 5
>
ìì5 6
(
ìì6 7
	viewModel
ìì7 @
)
ìì@ A
;
ììA B
}
îî 
if
ññ 
(
ññ 
	viewModel
ññ 
.
ññ 
Id
ññ  
==
ññ! #
Guid
ññ$ (
.
ññ( )
Empty
ññ) .
)
ññ. /
{
óó 
BrainstormSession
òò %
session
òò& -
=
òò. /)
brainstormSessionRepository
òò0 K
.
òòK L
GetAll
òòL R
(
òòR S
)
òòS T
.
òòT U
FirstOrDefault
òòU c
(
òòc d
x
òòd e
=>
òòf h
x
òòi j
.
òòj k
Type
òòk o
==
òòp r$
BrainstormSessionTypeòòs à
.òòà â
Mainòòâ ç
)òòç é
;òòé è
model
öö 
.
öö 
	SessionId
öö #
=
öö$ %
session
öö& -
.
öö- .
Id
öö. 0
;
öö0 1&
brainstormIdeaRepository
úú ,
.
úú, -
Add
úú- 0
(
úú0 1
model
úú1 6
)
úú6 7
;
úú7 8
	viewModel
ùù 
.
ùù 
Id
ùù  
=
ùù! "
model
ùù# (
.
ùù( )
Id
ùù) +
;
ùù+ ,
this
üü 
.
üü '
gamificationDomainService
üü 2
.
üü2 3
ProcessAction
üü3 @
(
üü@ A
	viewModel
üüA J
.
üüJ K
UserId
üüK Q
,
üüQ R
PlatformAction
üüS a
.
üüa b
IdeaSuggested
üüb o
)
üüo p
;
üüp q
}
†† 
else
°° 
{
¢¢ &
brainstormIdeaRepository
££ ,
.
££, -
Update
££- 3
(
££3 4
model
££4 9
)
££9 :
;
££: ;
}
§§ 

unitOfWork
¶¶ 
.
¶¶ 
Commit
¶¶ !
(
¶¶! "
)
¶¶" #
;
¶¶# $
result
®® 
=
®® 
new
®® 
OperationResultVo
®® .
<
®®. /
Guid
®®/ 3
>
®®3 4
(
®®4 5
model
®®5 :
.
®®: ;
Id
®®; =
)
®®= >
;
®®> ?
}
©© 
catch
™™ 
(
™™ 
	Exception
™™ 
ex
™™ 
)
™™  
{
´´ 
result
¨¨ 
=
¨¨ 
new
¨¨ 
OperationResultVo
¨¨ .
<
¨¨. /
Guid
¨¨/ 3
>
¨¨3 4
(
¨¨4 5
ex
¨¨5 7
.
¨¨7 8
Message
¨¨8 ?
)
¨¨? @
;
¨¨@ A
}
≠≠ 
return
ØØ 
result
ØØ 
;
ØØ 
}
∞∞ 	
public
≥≥ #
OperationResultListVo
≥≥ $
<
≥≥$ %%
BrainstormIdeaViewModel
≥≥% <
>
≥≥< =
GetAll
≥≥> D
(
≥≥D E
Guid
≥≥E I
userId
≥≥J P
)
≥≥P Q
{
¥¥ 	#
OperationResultListVo
µµ !
<
µµ! "%
BrainstormIdeaViewModel
µµ" 9
>
µµ9 :
result
µµ; A
;
µµA B
try
∑∑ 
{
∏∏ 

IQueryable
ππ 
<
ππ 
BrainstormIdea
ππ )
>
ππ) *
	allModels
ππ+ 4
=
ππ5 6&
brainstormIdeaRepository
ππ7 O
.
ππO P
GetAll
ππP V
(
ππV W
)
ππW X
;
ππX Y

IQueryable
ªª 
<
ªª 
BrainstormVote
ªª )
>
ªª) *
currentUserVotes
ªª+ ;
=
ªª< =&
brainstormVoteRepository
ªª> V
.
ªªV W
GetByUserId
ªªW b
(
ªªb c
userId
ªªc i
)
ªªi j
;
ªªj k
IEnumerable
ΩΩ 
<
ΩΩ %
BrainstormIdeaViewModel
ΩΩ 3
>
ΩΩ3 4
vms
ΩΩ5 8
=
ΩΩ9 :
mapper
ΩΩ; A
.
ΩΩA B
Map
ΩΩB E
<
ΩΩE F
IEnumerable
ΩΩF Q
<
ΩΩQ R
BrainstormIdea
ΩΩR `
>
ΩΩ` a
,
ΩΩa b
IEnumerable
ΩΩc n
<
ΩΩn o&
BrainstormIdeaViewModelΩΩo Ü
>ΩΩÜ á
>ΩΩá à
(ΩΩà â
	allModelsΩΩâ í
)ΩΩí ì
;ΩΩì î
foreach
øø 
(
øø %
BrainstormIdeaViewModel
øø 0
item
øø1 5
in
øø6 8
vms
øø9 <
)
øø< =
{
¿¿ 
item
¡¡ 
.
¡¡ 
UserContentType
¡¡ (
=
¡¡) *
UserContentType
¡¡+ :
.
¡¡: ;

VotingItem
¡¡; E
;
¡¡E F
item
¬¬ 
.
¬¬ 
	VoteCount
¬¬ "
=
¬¬# $&
brainstormVoteRepository
¬¬% =
.
¬¬= >
Count
¬¬> C
(
¬¬C D
x
¬¬D E
=>
¬¬F H
x
¬¬I J
.
¬¬J K
IdeaId
¬¬K Q
==
¬¬R T
item
¬¬U Y
.
¬¬Y Z
Id
¬¬Z \
)
¬¬\ ]
;
¬¬] ^
item
√√ 
.
√√ 
Score
√√ 
=
√√  &
brainstormVoteRepository
√√! 9
.
√√9 :
GetAll
√√: @
(
√√@ A
)
√√A B
.
√√B C
Where
√√C H
(
√√H I
x
√√I J
=>
√√K M
x
√√N O
.
√√O P
IdeaId
√√P V
==
√√W Y
item
√√Z ^
.
√√^ _
Id
√√_ a
)
√√a b
.
√√b c
Sum
√√c f
(
√√f g
x
√√g h
=>
√√i k
(
√√l m
int
√√m p
)
√√p q
x
√√q r
.
√√r s
	VoteValue
√√s |
)
√√| }
;
√√} ~
item
ƒƒ 
.
ƒƒ 
CurrentUserVote
ƒƒ (
=
ƒƒ) *
currentUserVotes
ƒƒ+ ;
.
ƒƒ; <
FirstOrDefault
ƒƒ< J
(
ƒƒJ K
x
ƒƒK L
=>
ƒƒM O
x
ƒƒP Q
.
ƒƒQ R
IdeaId
ƒƒR X
==
ƒƒY [
item
ƒƒ\ `
.
ƒƒ` a
Id
ƒƒa c
)
ƒƒc d
?
ƒƒd e
.
ƒƒe f
	VoteValue
ƒƒf o
??
ƒƒp r
	VoteValue
ƒƒs |
.
ƒƒ| }
Neutralƒƒ} Ñ
;ƒƒÑ Ö
item
∆∆ 
.
∆∆ 
CommentCount
∆∆ %
=
∆∆& ')
brainstormCommentRepository
∆∆( C
.
∆∆C D
Count
∆∆D I
(
∆∆I J
x
∆∆J K
=>
∆∆L N
x
∆∆O P
.
∆∆P Q
IdeaId
∆∆Q W
==
∆∆X Z
item
∆∆[ _
.
∆∆_ `
Id
∆∆` b
)
∆∆b c
;
∆∆c d
}
«« 
vms
…… 
=
…… 
vms
…… 
.
…… 
OrderByDescending
…… +
(
……+ ,
x
……, -
=>
……. 0
x
……1 2
.
……2 3
Score
……3 8
)
……8 9
.
……9 :
ThenByDescending
……: J
(
……J K
x
……K L
=>
……M O
x
……P Q
.
……Q R

CreateDate
……R \
)
……\ ]
;
……] ^
result
ÀÀ 
=
ÀÀ 
new
ÀÀ #
OperationResultListVo
ÀÀ 2
<
ÀÀ2 3%
BrainstormIdeaViewModel
ÀÀ3 J
>
ÀÀJ K
(
ÀÀK L
vms
ÀÀL O
)
ÀÀO P
;
ÀÀP Q
}
ÃÃ 
catch
ÕÕ 
(
ÕÕ 
	Exception
ÕÕ 
ex
ÕÕ 
)
ÕÕ  
{
ŒŒ 
result
œœ 
=
œœ 
new
œœ #
OperationResultListVo
œœ 2
<
œœ2 3%
BrainstormIdeaViewModel
œœ3 J
>
œœJ K
(
œœK L
ex
œœL N
.
œœN O
Message
œœO V
)
œœV W
;
œœW X
}
–– 
return
““ 
result
““ 
;
““ 
}
”” 	
public
’’ 
OperationResultVo
’’  
<
’’  !%
BrainstormIdeaViewModel
’’! 8
>
’’8 9
GetById
’’: A
(
’’A B
Guid
’’B F
userId
’’G M
,
’’M N
Guid
’’O S
id
’’T V
)
’’V W
{
÷÷ 	
OperationResultVo
◊◊ 
<
◊◊ %
BrainstormIdeaViewModel
◊◊ 5
>
◊◊5 6
result
◊◊7 =
;
◊◊= >
try
ŸŸ 
{
⁄⁄ 
BrainstormIdea
€€ 
model
€€ $
=
€€% &&
brainstormIdeaRepository
€€' ?
.
€€? @
GetById
€€@ G
(
€€G H
id
€€H J
)
€€J K
;
€€K L%
BrainstormIdeaViewModel
›› '
vm
››( *
=
››+ ,
mapper
››- 3
.
››3 4
Map
››4 7
<
››7 8%
BrainstormIdeaViewModel
››8 O
>
››O P
(
››P Q
model
››Q V
)
››V W
;
››W X
vm
ﬂﬂ 
.
ﬂﬂ 
UserContentType
ﬂﬂ "
=
ﬂﬂ# $
UserContentType
ﬂﬂ% 4
.
ﬂﬂ4 5

VotingItem
ﬂﬂ5 ?
;
ﬂﬂ? @
vm
‡‡ 
.
‡‡ 
	VoteCount
‡‡ 
=
‡‡ &
brainstormVoteRepository
‡‡ 7
.
‡‡7 8
Count
‡‡8 =
(
‡‡= >
x
‡‡> ?
=>
‡‡@ B
x
‡‡C D
.
‡‡D E
IdeaId
‡‡E K
==
‡‡L N
vm
‡‡O Q
.
‡‡Q R
Id
‡‡R T
)
‡‡T U
;
‡‡U V
vm
·· 
.
·· 
Score
·· 
=
·· &
brainstormVoteRepository
·· 3
.
··3 4
GetAll
··4 :
(
··: ;
)
··; <
.
··< =
Where
··= B
(
··B C
x
··C D
=>
··E G
x
··H I
.
··I J
IdeaId
··J P
==
··Q S
vm
··T V
.
··V W
Id
··W Y
)
··Y Z
.
··Z [
Sum
··[ ^
(
··^ _
x
··_ `
=>
··a c
(
··d e
int
··e h
)
··h i
x
··i j
.
··j k
	VoteValue
··k t
)
··t u
;
··u v
vm
‚‚ 
.
‚‚ 
CurrentUserVote
‚‚ "
=
‚‚# $&
brainstormVoteRepository
‚‚% =
.
‚‚= >
GetAll
‚‚> D
(
‚‚D E
)
‚‚E F
.
‚‚F G
FirstOrDefault
‚‚G U
(
‚‚U V
x
‚‚V W
=>
‚‚X Z
x
‚‚[ \
.
‚‚\ ]
UserId
‚‚] c
==
‚‚d f
userId
‚‚g m
&&
‚‚n p
x
‚‚q r
.
‚‚r s
IdeaId
‚‚s y
==
‚‚z |
id
‚‚} 
)‚‚ Ä
?‚‚Ä Å
.‚‚Å Ç
	VoteValue‚‚Ç ã
??‚‚å é
	VoteValue‚‚è ò
.‚‚ò ô
Neutral‚‚ô †
;‚‚† °
vm
ÂÂ 
.
ÂÂ 
CommentCount
ÂÂ 
=
ÂÂ  !)
brainstormCommentRepository
ÂÂ" =
.
ÂÂ= >
GetAll
ÂÂ> D
(
ÂÂD E
)
ÂÂE F
.
ÂÂF G
Count
ÂÂG L
(
ÂÂL M
x
ÂÂM N
=>
ÂÂO Q
x
ÂÂR S
.
ÂÂS T
IdeaId
ÂÂT Z
==
ÂÂ[ ]
vm
ÂÂ^ `
.
ÂÂ` a
Id
ÂÂa c
)
ÂÂc d
;
ÂÂd e
IOrderedQueryable
ÁÁ !
<
ÁÁ! "
BrainstormComment
ÁÁ" 3
>
ÁÁ3 4
comments
ÁÁ5 =
=
ÁÁ> ?)
brainstormCommentRepository
ÁÁ@ [
.
ÁÁ[ \
GetAll
ÁÁ\ b
(
ÁÁb c
)
ÁÁc d
.
ÁÁd e
Where
ÁÁe j
(
ÁÁj k
x
ÁÁk l
=>
ÁÁm o
x
ÁÁp q
.
ÁÁq r
IdeaId
ÁÁr x
==
ÁÁy {
vm
ÁÁ| ~
.
ÁÁ~ 
IdÁÁ Å
)ÁÁÅ Ç
.ÁÁÇ É
OrderByÁÁÉ ä
(ÁÁä ã
xÁÁã å
=>ÁÁç è
xÁÁê ë
.ÁÁë í

CreateDateÁÁí ú
)ÁÁú ù
;ÁÁù û

IQueryable
ÈÈ 
<
ÈÈ (
BrainstormCommentViewModel
ÈÈ 5
>
ÈÈ5 6

commentsVm
ÈÈ7 A
=
ÈÈB C
comments
ÈÈD L
.
ÈÈL M
	ProjectTo
ÈÈM V
<
ÈÈV W(
BrainstormCommentViewModel
ÈÈW q
>
ÈÈq r
(
ÈÈr s
mapper
ÈÈs y
.
ÈÈy z$
ConfigurationProviderÈÈz è
)ÈÈè ê
;ÈÈê ë
vm
ÎÎ 
.
ÎÎ 
Comments
ÎÎ 
=
ÎÎ 

commentsVm
ÎÎ (
.
ÎÎ( )
ToList
ÎÎ) /
(
ÎÎ/ 0
)
ÎÎ0 1
;
ÎÎ1 2
foreach
ÓÓ 
(
ÓÓ (
BrainstormCommentViewModel
ÓÓ 3
comment
ÓÓ4 ;
in
ÓÓ< >
vm
ÓÓ? A
.
ÓÓA B
Comments
ÓÓB J
)
ÓÓJ K
{
ÔÔ 
comment
 
.
 

AuthorName
 &
=
' (
string
) /
.
/ 0 
IsNullOrWhiteSpace
0 B
(
B C
comment
C J
.
J K

AuthorName
K U
)
U V
?
W X
$str
Y g
:
h i
comment
j q
.
q r

AuthorName
r |
;
| }
comment
ÒÒ 
.
ÒÒ 
AuthorPicture
ÒÒ )
=
ÒÒ* +
UrlFormatter
ÒÒ, 8
.
ÒÒ8 9
ProfileImage
ÒÒ9 E
(
ÒÒE F
comment
ÒÒF M
.
ÒÒM N
UserId
ÒÒN T
)
ÒÒT U
;
ÒÒU V
comment
ÚÚ 
.
ÚÚ 
Text
ÚÚ  
=
ÚÚ! "
string
ÚÚ# )
.
ÚÚ) * 
IsNullOrWhiteSpace
ÚÚ* <
(
ÚÚ< =
comment
ÚÚ= D
.
ÚÚD E
Text
ÚÚE I
)
ÚÚI J
?
ÚÚK L
$str
ÚÚM q
:
ÚÚr s
comment
ÚÚt {
.
ÚÚ{ |
TextÚÚ| Ä
;ÚÚÄ Å
}
ÛÛ 
result
ıı 
=
ıı 
new
ıı 
OperationResultVo
ıı .
<
ıı. /%
BrainstormIdeaViewModel
ıı/ F
>
ııF G
(
ııG H
vm
ııH J
)
ııJ K
;
ııK L
}
ˆˆ 
catch
˜˜ 
(
˜˜ 
	Exception
˜˜ 
ex
˜˜ 
)
˜˜  
{
¯¯ 
result
˘˘ 
=
˘˘ 
new
˘˘ 
OperationResultVo
˘˘ .
<
˘˘. /%
BrainstormIdeaViewModel
˘˘/ F
>
˘˘F G
(
˘˘G H
ex
˘˘H J
.
˘˘J K
Message
˘˘K R
)
˘˘R S
;
˘˘S T
}
˙˙ 
return
¸¸ 
result
¸¸ 
;
¸¸ 
}
˝˝ 	
public
ÄÄ 
OperationResultVo
ÄÄ  
Vote
ÄÄ! %
(
ÄÄ% &
Guid
ÄÄ& *
userId
ÄÄ+ 1
,
ÄÄ1 2
Guid
ÄÄ3 7
ideaId
ÄÄ8 >
,
ÄÄ> ?
	VoteValue
ÄÄ@ I
vote
ÄÄJ N
)
ÄÄN O
{
ÅÅ 	
OperationResultVo
ÇÇ 
result
ÇÇ $
;
ÇÇ$ %
try
ÑÑ 
{
ÖÖ 
BrainstormVote
ÜÜ 
model
ÜÜ $
;
ÜÜ$ %
BrainstormVote
àà 
existing
àà '
=
àà( )&
brainstormVoteRepository
àà* B
.
ààB C
Get
ààC F
(
ààF G
ideaId
ààG M
,
ààM N
userId
ààO U
)
ààU V
;
ààV W
if
ââ 
(
ââ 
existing
ââ 
!=
ââ 
null
ââ  $
)
ââ$ %
{
ää 
model
ãã 
=
ãã 
existing
ãã $
;
ãã$ %
model
åå 
.
åå 
	VoteValue
åå #
=
åå$ %
vote
åå& *
;
åå* +
}
çç 
else
éé 
{
èè 
model
êê 
=
êê 
new
êê 
BrainstormVote
êê  .
{
ëë 
UserId
íí 
=
íí  
userId
íí! '
,
íí' (
IdeaId
ìì 
=
ìì  
ideaId
ìì! '
,
ìì' (
	VoteValue
îî !
=
îî" #
vote
îî$ (
}
ïï 
;
ïï 
}
ññ 
if
òò 
(
òò 
model
òò 
.
òò 
Id
òò 
==
òò 
Guid
òò  $
.
òò$ %
Empty
òò% *
)
òò* +
{
ôô &
brainstormVoteRepository
öö ,
.
öö, -
Add
öö- 0
(
öö0 1
model
öö1 6
)
öö6 7
;
öö7 8
}
õõ 
else
úú 
{
ùù &
brainstormVoteRepository
ûû ,
.
ûû, -
Update
ûû- 3
(
ûû3 4
model
ûû4 9
)
ûû9 :
;
ûû: ;
}
üü 

unitOfWork
°° 
.
°° 
Commit
°° !
(
°°! "
)
°°" #
;
°°# $
result
££ 
=
££ 
new
££ 
OperationResultVo
££ .
<
££. /
Guid
££/ 3
>
££3 4
(
££4 5
model
££5 :
.
££: ;
Id
££; =
)
££= >
;
££> ?
}
§§ 
catch
•• 
(
•• 
	Exception
•• 
ex
•• 
)
••  
{
¶¶ 
result
ßß 
=
ßß 
new
ßß 
OperationResultVo
ßß .
<
ßß. /
Guid
ßß/ 3
>
ßß3 4
(
ßß4 5
ex
ßß5 7
.
ßß7 8
Message
ßß8 ?
)
ßß? @
;
ßß@ A
}
®® 
return
™™ 
result
™™ 
;
™™ 
}
´´ 	
public
≠≠ 
OperationResultVo
≠≠  
Comment
≠≠! (
(
≠≠( ))
UserContentCommentViewModel
≠≠) D
vm
≠≠E G
)
≠≠G H
{
ÆÆ 	
OperationResultVo
ØØ 
result
ØØ $
;
ØØ$ %
try
±± 
{
≤≤ 
BrainstormComment
≥≥ !
model
≥≥" '
=
≥≥( )
new
≥≥* -
BrainstormComment
≥≥. ?
{
¥¥ 
UserId
µµ 
=
µµ 
vm
µµ 
.
µµ  
UserId
µµ  &
,
µµ& '
IdeaId
∂∂ 
=
∂∂ 
vm
∂∂ 
.
∂∂  
UserContentId
∂∂  -
,
∂∂- .
Text
∑∑ 
=
∑∑ 
vm
∑∑ 
.
∑∑ 
Text
∑∑ "
,
∑∑" #

AuthorName
∏∏ 
=
∏∏  
vm
∏∏! #
.
∏∏# $

AuthorName
∏∏$ .
,
∏∏. /
AuthorPicture
ππ !
=
ππ" #
vm
ππ$ &
.
ππ& '
AuthorPicture
ππ' 4
}
∫∫ 
;
∫∫ )
brainstormCommentRepository
ºº +
.
ºº+ ,
Add
ºº, /
(
ºº/ 0
model
ºº0 5
)
ºº5 6
;
ºº6 7

unitOfWork
ææ 
.
ææ 
Commit
ææ !
(
ææ! "
)
ææ" #
;
ææ# $
result
¿¿ 
=
¿¿ 
new
¿¿ 
OperationResultVo
¿¿ .
<
¿¿. /
Guid
¿¿/ 3
>
¿¿3 4
(
¿¿4 5
model
¿¿5 :
.
¿¿: ;
Id
¿¿; =
)
¿¿= >
;
¿¿> ?
}
¡¡ 
catch
¬¬ 
(
¬¬ 
	Exception
¬¬ 
ex
¬¬ 
)
¬¬  
{
√√ 
result
ƒƒ 
=
ƒƒ 
new
ƒƒ 
OperationResultVo
ƒƒ .
<
ƒƒ. /
Guid
ƒƒ/ 3
>
ƒƒ3 4
(
ƒƒ4 5
ex
ƒƒ5 7
.
ƒƒ7 8
Message
ƒƒ8 ?
)
ƒƒ? @
;
ƒƒ@ A
}
≈≈ 
return
«« 
result
«« 
;
«« 
}
»» 	
public
—— 
OperationResultVo
——  
<
——  !(
BrainstormSessionViewModel
——! ;
>
——; <

GetSession
——= G
(
——G H
Guid
——H L
userId
——M S
,
——S T#
BrainstormSessionType
——U j
type
——k o
)
——o p
{
““ 	
OperationResultVo
”” 
<
”” (
BrainstormSessionViewModel
”” 8
>
””8 9
result
””: @
;
””@ A
try
’’ 
{
÷÷ 
BrainstormSession
◊◊ !
model
◊◊" '
=
◊◊( ))
brainstormSessionRepository
◊◊* E
.
◊◊E F
GetAll
◊◊F L
(
◊◊L M
)
◊◊M N
.
◊◊N O
LastOrDefault
◊◊O \
(
◊◊\ ]
x
◊◊] ^
=>
◊◊_ a
x
◊◊b c
.
◊◊c d
Type
◊◊d h
==
◊◊i k
type
◊◊l p
)
◊◊p q
;
◊◊q r(
BrainstormSessionViewModel
ŸŸ *
vm
ŸŸ+ -
=
ŸŸ. /
mapper
ŸŸ0 6
.
ŸŸ6 7
Map
ŸŸ7 :
<
ŸŸ: ;(
BrainstormSessionViewModel
ŸŸ; U
>
ŸŸU V
(
ŸŸV W
model
ŸŸW \
)
ŸŸ\ ]
;
ŸŸ] ^
result
€€ 
=
€€ 
new
€€ 
OperationResultVo
€€ .
<
€€. /(
BrainstormSessionViewModel
€€/ I
>
€€I J
(
€€J K
vm
€€K M
)
€€M N
;
€€N O
}
‹‹ 
catch
›› 
(
›› 
	Exception
›› 
ex
›› 
)
››  
{
ﬁﬁ 
result
ﬂﬂ 
=
ﬂﬂ 
new
ﬂﬂ 
OperationResultVo
ﬂﬂ .
<
ﬂﬂ. /(
BrainstormSessionViewModel
ﬂﬂ/ I
>
ﬂﬂI J
(
ﬂﬂJ K
ex
ﬂﬂK M
.
ﬂﬂM N
Message
ﬂﬂN U
)
ﬂﬂU V
;
ﬂﬂV W
}
‡‡ 
return
‚‚ 
result
‚‚ 
;
‚‚ 
}
„„ 	
public
ÂÂ #
OperationResultListVo
ÂÂ $
<
ÂÂ$ %(
BrainstormSessionViewModel
ÂÂ% ?
>
ÂÂ? @
GetSessions
ÂÂA L
(
ÂÂL M
Guid
ÂÂM Q
userId
ÂÂR X
)
ÂÂX Y
{
ÊÊ 	#
OperationResultListVo
ÁÁ !
<
ÁÁ! "(
BrainstormSessionViewModel
ÁÁ" <
>
ÁÁ< =
result
ÁÁ> D
;
ÁÁD E
try
ÈÈ 
{
ÍÍ 

IQueryable
ÎÎ 
<
ÎÎ 
BrainstormSession
ÎÎ ,
>
ÎÎ, -
model
ÎÎ. 3
=
ÎÎ4 5)
brainstormSessionRepository
ÎÎ6 Q
.
ÎÎQ R
GetAll
ÎÎR X
(
ÎÎX Y
)
ÎÎY Z
;
ÎÎZ [

IQueryable
ÌÌ 
<
ÌÌ (
BrainstormSessionViewModel
ÌÌ 5
>
ÌÌ5 6
vms
ÌÌ7 :
=
ÌÌ; <
model
ÌÌ= B
.
ÌÌB C
	ProjectTo
ÌÌC L
<
ÌÌL M(
BrainstormSessionViewModel
ÌÌM g
>
ÌÌg h
(
ÌÌh i
mapper
ÌÌi o
.
ÌÌo p$
ConfigurationProviderÌÌp Ö
)ÌÌÖ Ü
;ÌÌÜ á
vms
ÔÔ 
=
ÔÔ 
vms
ÔÔ 
.
ÔÔ 
OrderBy
ÔÔ !
(
ÔÔ! "
x
ÔÔ" #
=>
ÔÔ$ &
x
ÔÔ' (
.
ÔÔ( )
Type
ÔÔ) -
)
ÔÔ- .
.
ÔÔ. /
ThenBy
ÔÔ/ 5
(
ÔÔ5 6
x
ÔÔ6 7
=>
ÔÔ8 :
x
ÔÔ; <
.
ÔÔ< =

CreateDate
ÔÔ= G
)
ÔÔG H
;
ÔÔH I
result
ÒÒ 
=
ÒÒ 
new
ÒÒ #
OperationResultListVo
ÒÒ 2
<
ÒÒ2 3(
BrainstormSessionViewModel
ÒÒ3 M
>
ÒÒM N
(
ÒÒN O
vms
ÒÒO R
)
ÒÒR S
;
ÒÒS T
}
ÚÚ 
catch
ÛÛ 
(
ÛÛ 
	Exception
ÛÛ 
ex
ÛÛ 
)
ÛÛ  
{
ÙÙ 
result
ıı 
=
ıı 
new
ıı #
OperationResultListVo
ıı 2
<
ıı2 3(
BrainstormSessionViewModel
ıı3 M
>
ııM N
(
ııN O
ex
ııO Q
.
ııQ R
Message
ııR Y
)
ııY Z
;
ııZ [
}
ˆˆ 
return
¯¯ 
result
¯¯ 
;
¯¯ 
}
˘˘ 	
public
˚˚ 
OperationResultVo
˚˚  
<
˚˚  !
Guid
˚˚! %
>
˚˚% &
SaveSession
˚˚' 2
(
˚˚2 3(
BrainstormSessionViewModel
˚˚3 M
vm
˚˚N P
)
˚˚P Q
{
¸¸ 	
OperationResultVo
˝˝ 
<
˝˝ 
Guid
˝˝ "
>
˝˝" #
result
˝˝$ *
;
˝˝* +
try
ˇˇ 
{
ÄÄ 
BrainstormSession
ÅÅ !
model
ÅÅ" '
;
ÅÅ' (
BrainstormSession
ÖÖ !
existing
ÖÖ" *
=
ÖÖ+ ,)
brainstormSessionRepository
ÖÖ- H
.
ÖÖH I
GetById
ÖÖI P
(
ÖÖP Q
vm
ÖÖQ S
.
ÖÖS T
Id
ÖÖT V
)
ÖÖV W
;
ÖÖW X
if
ÜÜ 
(
ÜÜ 
existing
ÜÜ 
!=
ÜÜ 
null
ÜÜ  $
)
ÜÜ$ %
{
áá 
model
àà 
=
àà 
mapper
àà "
.
àà" #
Map
àà# &
(
àà& '
vm
àà' )
,
àà) *
existing
àà+ 3
)
àà3 4
;
àà4 5
}
ââ 
else
ää 
{
ãã 
model
åå 
=
åå 
mapper
åå "
.
åå" #
Map
åå# &
<
åå& '
BrainstormSession
åå' 8
>
åå8 9
(
åå9 :
vm
åå: <
)
åå< =
;
åå= >
}
çç 
if
èè 
(
èè 
vm
èè 
.
èè 
Id
èè 
==
èè 
Guid
èè !
.
èè! "
Empty
èè" '
)
èè' (
{
êê )
brainstormSessionRepository
ëë /
.
ëë/ 0
Add
ëë0 3
(
ëë3 4
model
ëë4 9
)
ëë9 :
;
ëë: ;
vm
íí 
.
íí 
Id
íí 
=
íí 
model
íí !
.
íí! "
Id
íí" $
;
íí$ %
}
ìì 
else
îî 
{
ïï )
brainstormSessionRepository
ññ /
.
ññ/ 0
Update
ññ0 6
(
ññ6 7
model
ññ7 <
)
ññ< =
;
ññ= >
}
óó 

unitOfWork
ôô 
.
ôô 
Commit
ôô !
(
ôô! "
)
ôô" #
;
ôô# $
result
õõ 
=
õõ 
new
õõ 
OperationResultVo
õõ .
<
õõ. /
Guid
õõ/ 3
>
õõ3 4
(
õõ4 5
model
õõ5 :
.
õõ: ;
Id
õõ; =
)
õõ= >
;
õõ> ?
}
úú 
catch
ùù 
(
ùù 
	Exception
ùù 
ex
ùù 
)
ùù  
{
ûû 
result
üü 
=
üü 
new
üü 
OperationResultVo
üü .
<
üü. /
Guid
üü/ 3
>
üü3 4
(
üü4 5
ex
üü5 7
.
üü7 8
Message
üü8 ?
)
üü? @
;
üü@ A
}
†† 
return
¢¢ 
result
¢¢ 
;
¢¢ 
}
££ 	
public
•• #
OperationResultListVo
•• $
<
••$ %%
BrainstormIdeaViewModel
••% <
>
••< =
GetAllBySessionId
••> O
(
••O P
Guid
••P T
userId
••U [
,
••[ \
Guid
••] a
	sessionId
••b k
)
••k l
{
¶¶ 	#
OperationResultListVo
ßß !
<
ßß! "%
BrainstormIdeaViewModel
ßß" 9
>
ßß9 :
result
ßß; A
;
ßßA B
try
©© 
{
™™ 

IQueryable
´´ 
<
´´ 
BrainstormIdea
´´ )
>
´´) *
	allModels
´´+ 4
=
´´5 6&
brainstormIdeaRepository
´´7 O
.
´´O P
GetAll
´´P V
(
´´V W
)
´´W X
.
´´X Y
Where
´´Y ^
(
´´^ _
x
´´_ `
=>
´´a c
x
´´d e
.
´´e f
	SessionId
´´f o
==
´´p r
	sessionId
´´s |
)
´´| }
;
´´} ~

IQueryable
≠≠ 
<
≠≠ 
BrainstormVote
≠≠ )
>
≠≠) *
currentUserVotes
≠≠+ ;
=
≠≠< =&
brainstormVoteRepository
≠≠> V
.
≠≠V W
GetByUserId
≠≠W b
(
≠≠b c
userId
≠≠c i
)
≠≠i j
;
≠≠j k
IEnumerable
ØØ 
<
ØØ %
BrainstormIdeaViewModel
ØØ 3
>
ØØ3 4
vms
ØØ5 8
=
ØØ9 :
mapper
ØØ; A
.
ØØA B
Map
ØØB E
<
ØØE F
IEnumerable
ØØF Q
<
ØØQ R
BrainstormIdea
ØØR `
>
ØØ` a
,
ØØa b
IEnumerable
ØØc n
<
ØØn o&
BrainstormIdeaViewModelØØo Ü
>ØØÜ á
>ØØá à
(ØØà â
	allModelsØØâ í
)ØØí ì
;ØØì î
foreach
±± 
(
±± %
BrainstormIdeaViewModel
±± 0
item
±±1 5
in
±±6 8
vms
±±9 <
)
±±< =
{
≤≤ 
item
≥≥ 
.
≥≥ 
UserContentType
≥≥ (
=
≥≥) *
UserContentType
≥≥+ :
.
≥≥: ;

VotingItem
≥≥; E
;
≥≥E F
item
¥¥ 
.
¥¥ 
	VoteCount
¥¥ "
=
¥¥# $&
brainstormVoteRepository
¥¥% =
.
¥¥= >
Count
¥¥> C
(
¥¥C D
x
¥¥D E
=>
¥¥F H
x
¥¥I J
.
¥¥J K
IdeaId
¥¥K Q
==
¥¥R T
item
¥¥U Y
.
¥¥Y Z
Id
¥¥Z \
)
¥¥\ ]
;
¥¥] ^
item
µµ 
.
µµ 
Score
µµ 
=
µµ  &
brainstormVoteRepository
µµ! 9
.
µµ9 :
GetAll
µµ: @
(
µµ@ A
)
µµA B
.
µµB C
Where
µµC H
(
µµH I
x
µµI J
=>
µµK M
x
µµN O
.
µµO P
IdeaId
µµP V
==
µµW Y
item
µµZ ^
.
µµ^ _
Id
µµ_ a
)
µµa b
.
µµb c
Sum
µµc f
(
µµf g
x
µµg h
=>
µµi k
(
µµl m
int
µµm p
)
µµp q
x
µµq r
.
µµr s
	VoteValue
µµs |
)
µµ| }
;
µµ} ~
item
∂∂ 
.
∂∂ 
CurrentUserVote
∂∂ (
=
∂∂) *
currentUserVotes
∂∂+ ;
.
∂∂; <
FirstOrDefault
∂∂< J
(
∂∂J K
x
∂∂K L
=>
∂∂M O
x
∂∂P Q
.
∂∂Q R
IdeaId
∂∂R X
==
∂∂Y [
item
∂∂\ `
.
∂∂` a
Id
∂∂a c
)
∂∂c d
?
∂∂d e
.
∂∂e f
	VoteValue
∂∂f o
??
∂∂p r
	VoteValue
∂∂s |
.
∂∂| }
Neutral∂∂} Ñ
;∂∂Ñ Ö
item
∏∏ 
.
∏∏ 
CommentCount
∏∏ %
=
∏∏& ')
brainstormCommentRepository
∏∏( C
.
∏∏C D
Count
∏∏D I
(
∏∏I J
x
∏∏J K
=>
∏∏L N
x
∏∏O P
.
∏∏P Q
IdeaId
∏∏Q W
==
∏∏X Z
item
∏∏[ _
.
∏∏_ `
Id
∏∏` b
)
∏∏b c
;
∏∏c d
}
ππ 
vms
ªª 
=
ªª 
vms
ªª 
.
ªª 
OrderByDescending
ªª +
(
ªª+ ,
x
ªª, -
=>
ªª. 0
x
ªª1 2
.
ªª2 3
Score
ªª3 8
)
ªª8 9
.
ªª9 :
ThenByDescending
ªª: J
(
ªªJ K
x
ªªK L
=>
ªªM O
x
ªªP Q
.
ªªQ R

CreateDate
ªªR \
)
ªª\ ]
;
ªª] ^
result
ΩΩ 
=
ΩΩ 
new
ΩΩ #
OperationResultListVo
ΩΩ 2
<
ΩΩ2 3%
BrainstormIdeaViewModel
ΩΩ3 J
>
ΩΩJ K
(
ΩΩK L
vms
ΩΩL O
)
ΩΩO P
;
ΩΩP Q
}
ææ 
catch
øø 
(
øø 
	Exception
øø 
ex
øø 
)
øø  
{
¿¿ 
result
¡¡ 
=
¡¡ 
new
¡¡ #
OperationResultListVo
¡¡ 2
<
¡¡2 3%
BrainstormIdeaViewModel
¡¡3 J
>
¡¡J K
(
¡¡K L
ex
¡¡L N
.
¡¡N O
Message
¡¡O V
)
¡¡V W
;
¡¡W X
}
¬¬ 
return
ƒƒ 
result
ƒƒ 
;
ƒƒ 
}
≈≈ 	
}
∆∆ 
}«« ∂»
vC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\FeaturedContentAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class %
FeaturedContentAppService *
:+ ,
BaseAppService- ;
,; <&
IFeaturedContentAppService= W
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly &
IFeaturedContentRepository 3
_repository4 ?
;? @
private 
readonly "
IUserContentRepository /
_contentRepository0 B
;B C
private 
readonly &
IUserContentLikeRepository 3
_likeRepository4 C
;C D
private 
readonly )
IUserContentCommentRepository 6
_commentRepository7 I
;I J
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public %
FeaturedContentAppService (
(( )
IMapper) 0
mapper1 7
,7 8
IUnitOfWork9 D

unitOfWorkE O
,O P&
IFeaturedContentRepositoryQ k

repositoryl v
,v w#
IUserContentRepository	x é
contentRepository
è †
,
† °(
IUserContentLikeRepository
¢ º
likeRepository
Ω À
,
À Ã+
IUserContentCommentRepository
Õ Í
commentRepository
Î ¸
)
¸ ˝
{ 	
_mapper   
=   
mapper   
;   
_unitOfWork!! 
=!! 

unitOfWork!! $
;!!$ %
_repository"" 
="" 

repository"" $
;""$ %
_contentRepository## 
=##  
contentRepository##! 2
;##2 3
_likeRepository$$ 
=$$ 
likeRepository$$ ,
;$$, -
_commentRepository%% 
=%%  
commentRepository%%! 2
;%%2 3
}&& 	
public(( 
OperationResultVo((  
<((  !
int((! $
>(($ %
Count((& +
(((+ ,
)((, -
{)) 	
OperationResultVo** 
<** 
int** !
>**! "
result**# )
;**) *
try,, 
{-- 
int.. 
count.. 
=.. 
_repository.. '
...' (
GetAll..( .
(... /
)../ 0
...0 1
Count..1 6
(..6 7
)..7 8
;..8 9
result00 
=00 
new00 
OperationResultVo00 .
<00. /
int00/ 2
>002 3
(003 4
count004 9
)009 :
;00: ;
}11 
catch22 
(22 
	Exception22 
ex22 
)22  
{33 
result44 
=44 
new44 
OperationResultVo44 .
<44. /
int44/ 2
>442 3
(443 4
ex444 6
.446 7
Message447 >
)44> ?
;44? @
}55 
return77 
result77 
;77 
}88 	
public:: !
OperationResultListVo:: $
<::$ %$
FeaturedContentViewModel::% =
>::= >
GetAll::? E
(::E F
)::F G
{;; 	!
OperationResultListVo<< !
<<<! "$
FeaturedContentViewModel<<" :
><<: ;
result<<< B
;<<B C
try>> 
{?? 

IQueryable@@ 
<@@ 
FeaturedContent@@ *
>@@* +
	allModels@@, 5
=@@6 7
_repository@@8 C
.@@C D
GetAll@@D J
(@@J K
)@@K L
;@@L M
IEnumerableBB 
<BB $
FeaturedContentViewModelBB 4
>BB4 5
vmsBB6 9
=BB: ;
_mapperBB< C
.BBC D
MapBBD G
<BBG H
IEnumerableBBH S
<BBS T
FeaturedContentBBT c
>BBc d
,BBd e
IEnumerableBBf q
<BBq r%
FeaturedContentViewModel	BBr ä
>
BBä ã
>
BBã å
(
BBå ç
	allModels
BBç ñ
)
BBñ ó
;
BBó ò
resultDD 
=DD 
newDD !
OperationResultListVoDD 2
<DD2 3$
FeaturedContentViewModelDD3 K
>DDK L
(DDL M
vmsDDM P
)DDP Q
;DDQ R
}EE 
catchFF 
(FF 
	ExceptionFF 
exFF 
)FF  
{GG 
resultHH 
=HH 
newHH !
OperationResultListVoHH 2
<HH2 3$
FeaturedContentViewModelHH3 K
>HHK L
(HHL M
exHHM O
.HHO P
MessageHHP W
)HHW X
;HHX Y
}II 
returnKK 
resultKK 
;KK 
}LL 	
publicNN 
OperationResultVoNN  
<NN  !$
FeaturedContentViewModelNN! 9
>NN9 :
GetByIdNN; B
(NNB C
GuidNNC G
idNNH J
)NNJ K
{OO 	
OperationResultVoPP 
<PP $
FeaturedContentViewModelPP 6
>PP6 7
resultPP8 >
;PP> ?
tryRR 
{SS 
FeaturedContentTT 
modelTT  %
=TT& '
_repositoryTT( 3
.TT3 4
GetByIdTT4 ;
(TT; <
idTT< >
)TT> ?
;TT? @$
FeaturedContentViewModelVV (
vmVV) +
=VV, -
_mapperVV. 5
.VV5 6
MapVV6 9
<VV9 :$
FeaturedContentViewModelVV: R
>VVR S
(VVS T
modelVVT Y
)VVY Z
;VVZ [
resultXX 
=XX 
newXX 
OperationResultVoXX .
<XX. /$
FeaturedContentViewModelXX/ G
>XXG H
(XXH I
vmXXI K
)XXK L
;XXL M
}YY 
catchZZ 
(ZZ 
	ExceptionZZ 
exZZ 
)ZZ  
{[[ 
result\\ 
=\\ 
new\\ 
OperationResultVo\\ .
<\\. /$
FeaturedContentViewModel\\/ G
>\\G H
(\\H I
ex\\I K
.\\K L
Message\\L S
)\\S T
;\\T U
}]] 
return__ 
result__ 
;__ 
}`` 	
publicbb 
OperationResultVobb  
Removebb! '
(bb' (
Guidbb( ,
idbb- /
)bb/ 0
{cc 	
OperationResultVodd 
resultdd $
;dd$ %
tryff 
{gg 
_repositoryjj 
.jj 
Removejj "
(jj" #
idjj# %
)jj% &
;jj& '
_unitOfWorkll 
.ll 
Commitll "
(ll" #
)ll# $
;ll$ %
resultnn 
=nn 
newnn 
OperationResultVonn .
(nn. /
truenn/ 3
)nn3 4
;nn4 5
}oo 
catchpp 
(pp 
	Exceptionpp 
expp 
)pp  
{qq 
resultrr 
=rr 
newrr 
OperationResultVorr .
(rr. /
exrr/ 1
.rr1 2
Messagerr2 9
)rr9 :
;rr: ;
}ss 
returnuu 
resultuu 
;uu 
}vv 	
publicxx 
OperationResultVoxx  
<xx  !
Guidxx! %
>xx% &
Savexx' +
(xx+ ,$
FeaturedContentViewModelxx, D
	viewModelxxE N
)xxN O
{yy 	
OperationResultVozz 
<zz 
Guidzz "
>zz" #
resultzz$ *
;zz* +
try|| 
{}} 
FeaturedContent~~ 
model~~  %
;~~% &
FeaturedContent
ÇÇ 
existing
ÇÇ  (
=
ÇÇ) *
_repository
ÇÇ+ 6
.
ÇÇ6 7
GetById
ÇÇ7 >
(
ÇÇ> ?
	viewModel
ÇÇ? H
.
ÇÇH I
Id
ÇÇI K
)
ÇÇK L
;
ÇÇL M
if
ÑÑ 
(
ÑÑ 
existing
ÑÑ 
!=
ÑÑ 
null
ÑÑ  $
)
ÑÑ$ %
{
ÖÖ 
model
ÜÜ 
=
ÜÜ 
_mapper
ÜÜ #
.
ÜÜ# $
Map
ÜÜ$ '
(
ÜÜ' (
	viewModel
ÜÜ( 1
,
ÜÜ1 2
existing
ÜÜ3 ;
)
ÜÜ; <
;
ÜÜ< =
}
áá 
else
àà 
{
ââ 
model
ää 
=
ää 
_mapper
ää #
.
ää# $
Map
ää$ '
<
ää' (
FeaturedContent
ää( 7
>
ää7 8
(
ää8 9
	viewModel
ää9 B
)
ääB C
;
ääC D
}
ãã 
if
çç 
(
çç 
	viewModel
çç 
.
çç 
Id
çç  
==
çç! #
Guid
çç$ (
.
çç( )
Empty
çç) .
)
çç. /
{
éé 
_repository
èè 
.
èè  
Add
èè  #
(
èè# $
model
èè$ )
)
èè) *
;
èè* +
	viewModel
êê 
.
êê 
Id
êê  
=
êê! "
model
êê# (
.
êê( )
Id
êê) +
;
êê+ ,
}
ëë 
else
íí 
{
ìì 
_repository
îî 
.
îî  
Update
îî  &
(
îî& '
model
îî' ,
)
îî, -
;
îî- .
}
ïï 
_unitOfWork
óó 
.
óó 
Commit
óó "
(
óó" #
)
óó# $
;
óó$ %
result
ôô 
=
ôô 
new
ôô 
OperationResultVo
ôô .
<
ôô. /
Guid
ôô/ 3
>
ôô3 4
(
ôô4 5
model
ôô5 :
.
ôô: ;
Id
ôô; =
)
ôô= >
;
ôô> ?
}
öö 
catch
õõ 
(
õõ 
	Exception
õõ 
ex
õõ 
)
õõ  
{
úú 
result
ùù 
=
ùù 
new
ùù 
OperationResultVo
ùù .
<
ùù. /
Guid
ùù/ 3
>
ùù3 4
(
ùù4 5
ex
ùù5 7
.
ùù7 8
Message
ùù8 ?
)
ùù? @
;
ùù@ A
}
ûû 
return
†† 
result
†† 
;
†† 
}
°° 	
public
§§ 
CarouselViewModel
§§  
GetFeaturedNow
§§! /
(
§§/ 0
)
§§0 1
{
•• 	

IQueryable
¶¶ 
<
¶¶ 
FeaturedContent
¶¶ &
>
¶¶& '
	allModels
¶¶( 1
=
¶¶2 3
_repository
¶¶4 ?
.
¶¶? @
GetAll
¶¶@ F
(
¶¶F G
)
¶¶G H
.
ßß 
Where
ßß 
(
ßß 
x
ßß 
=>
ßß 
x
ßß 
.
ßß 
	StartDate
ßß '
.
ßß' (
Date
ßß( ,
<=
ßß- /
DateTime
ßß0 8
.
ßß8 9
Today
ßß9 >
&&
ßß? A
(
ßßB C
x
ßßC D
.
ßßD E
EndDate
ßßE L
.
ßßL M
Date
ßßM Q
==
ßßR T
DateTime
ßßU ]
.
ßß] ^
MinValue
ßß^ f
||
ßßg i
x
ßßj k
.
ßßk l
EndDate
ßßl s
.
ßßs t
Date
ßßt x
>
ßßy z
DateTimeßß{ É
.ßßÉ Ñ
TodayßßÑ â
)ßßâ ä
)ßßä ã
;ßßã å
if
©© 
(
©© 
	allModels
©© 
.
©© 
Any
©© 
(
©© 
)
©© 
)
©©  
{
™™ 
IEnumerable
´´ 
<
´´ &
FeaturedContentViewModel
´´ 4
>
´´4 5
vms
´´6 9
=
´´: ;
_mapper
´´< C
.
´´C D
Map
´´D G
<
´´G H
IEnumerable
´´H S
<
´´S T
FeaturedContent
´´T c
>
´´c d
,
´´d e
IEnumerable
´´f q
<
´´q r'
FeaturedContentViewModel´´r ä
>´´ä ã
>´´ã å
(´´å ç
	allModels´´ç ñ
)´´ñ ó
;´´ó ò
CarouselViewModel
≠≠ !
model
≠≠" '
=
≠≠( )
new
≠≠* -
CarouselViewModel
≠≠. ?
(
≠≠? @
)
≠≠@ A
;
≠≠A B
model
ØØ 
.
ØØ 
Items
ØØ 
=
ØØ 
vms
ØØ !
.
ØØ! "
ToList
ØØ" (
(
ØØ( )
)
ØØ) *
;
ØØ* +
return
±± 
model
±± 
;
±± 
}
≤≤ 
else
≥≥ 
{
¥¥ 
CarouselViewModel
µµ !
fake
µµ" &
=
µµ' (
FakeData
µµ) 1
.
µµ1 2
FakeCarousel
µµ2 >
(
µµ> ?
)
µµ? @
;
µµ@ A
return
∑∑ 
fake
∑∑ 
;
∑∑ 
}
∏∏ 
}
ππ 	
public
ªª 
OperationResultVo
ªª  
<
ªª  !
Guid
ªª! %
>
ªª% &
Add
ªª' *
(
ªª* +
Guid
ªª+ /
userId
ªª0 6
,
ªª6 7
Guid
ªª8 <
	contentId
ªª= F
,
ªªF G
string
ªªH N
title
ªªO T
,
ªªT U
string
ªªV \
introduction
ªª] i
)
ªªi j
{
ºº 	
OperationResultVo
ΩΩ 
<
ΩΩ 
Guid
ΩΩ "
>
ΩΩ" #
result
ΩΩ$ *
;
ΩΩ* +
try
øø 
{
¿¿ 
FeaturedContent
¡¡  
newFeaturedContent
¡¡  2
=
¡¡3 4
new
¡¡5 8
FeaturedContent
¡¡9 H
(
¡¡H I
)
¡¡I J
;
¡¡J K 
newFeaturedContent
¬¬ "
.
¬¬" #
UserContentId
¬¬# 0
=
¬¬1 2
	contentId
¬¬3 <
;
¬¬< =
UserContent
ƒƒ 
content
ƒƒ #
=
ƒƒ$ % 
_contentRepository
ƒƒ& 8
.
ƒƒ8 9
GetById
ƒƒ9 @
(
ƒƒ@ A
	contentId
ƒƒA J
)
ƒƒJ K
;
ƒƒK L 
newFeaturedContent
∆∆ "
.
∆∆" #
Title
∆∆# (
=
∆∆) *
string
∆∆+ 1
.
∆∆1 2 
IsNullOrWhiteSpace
∆∆2 D
(
∆∆D E
title
∆∆E J
)
∆∆J K
?
∆∆L M
content
∆∆N U
.
∆∆U V
Title
∆∆V [
:
∆∆\ ]
title
∆∆^ c
;
∆∆c d 
newFeaturedContent
«« "
.
««" #
Introduction
««# /
=
««0 1
string
««2 8
.
««8 9 
IsNullOrWhiteSpace
««9 K
(
««K L
introduction
««L X
)
««X Y
?
««Z [
content
««\ c
.
««c d
Introduction
««d p
:
««q r
introduction
««s 
;«« Ä 
newFeaturedContent
…… "
.
……" #
ImageUrl
……# +
=
……, -
string
……. 4
.
……4 5 
IsNullOrWhiteSpace
……5 G
(
……G H
content
……H O
.
……O P
FeaturedImage
……P ]
)
……] ^
||
……_ a
content
……b i
.
……i j
FeaturedImage
……j w
.
……w x
Equals
……x ~
(
……~ 
	Constants…… à
.……à â$
DefaultFeaturedImage……â ù
)……ù û
?……ü †
	Constants……° ™
.……™ ´$
DefaultFeaturedImage……´ ø
:……¿ ¡
UrlFormatter……¬ Œ
.……Œ œ
Image……œ ‘
(……‘ ’
content……’ ‹
.……‹ ›
UserId……› „
,……„ ‰
BlobType……Â Ì
.……Ì Ó
FeaturedImage……Ó ˚
,……˚ ¸
content……˝ Ñ
.……Ñ Ö
FeaturedImage……Ö í
)……í ì
;……ì î 
newFeaturedContent
ÀÀ "
.
ÀÀ" #
	StartDate
ÀÀ# ,
=
ÀÀ- .
DateTime
ÀÀ/ 7
.
ÀÀ7 8
Now
ÀÀ8 ;
;
ÀÀ; < 
newFeaturedContent
ÃÃ "
.
ÃÃ" #
Active
ÃÃ# )
=
ÃÃ* +
true
ÃÃ, 0
;
ÃÃ0 1 
newFeaturedContent
ÕÕ "
.
ÕÕ" #
UserId
ÕÕ# )
=
ÕÕ* +
userId
ÕÕ, 2
;
ÕÕ2 3
_repository
œœ 
.
œœ 
Add
œœ 
(
œœ   
newFeaturedContent
œœ  2
)
œœ2 3
;
œœ3 4
_unitOfWork
—— 
.
—— 
Commit
—— "
(
——" #
)
——# $
;
——$ %
result
”” 
=
”” 
new
”” 
OperationResultVo
”” .
<
””. /
Guid
””/ 3
>
””3 4
(
””4 5 
newFeaturedContent
””5 G
.
””G H
Id
””H J
)
””J K
;
””K L
}
‘‘ 
catch
’’ 
(
’’ 
	Exception
’’ 
ex
’’ 
)
’’  
{
÷÷ 
result
◊◊ 
=
◊◊ 
new
◊◊ 
OperationResultVo
◊◊ .
<
◊◊. /
Guid
◊◊/ 3
>
◊◊3 4
(
◊◊4 5
ex
◊◊5 7
.
◊◊7 8
Message
◊◊8 ?
)
◊◊? @
;
◊◊@ A
}
ÿÿ 
return
⁄⁄ 
result
⁄⁄ 
;
⁄⁄ 
}
€€ 	
public
›› 
IEnumerable
›› 
<
›› .
 UserContentToBeFeaturedViewModel
›› ;
>
››; <$
GetContentToBeFeatured
››= S
(
››S T
)
››T U
{
ﬁﬁ 	

IQueryable
ﬂﬂ 
<
ﬂﬂ 
UserContent
ﬂﬂ "
>
ﬂﬂ" #
	finalList
ﬂﬂ$ -
=
ﬂﬂ. / 
_contentRepository
ﬂﬂ0 B
.
ﬂﬂB C
GetAll
ﬂﬂC I
(
ﬂﬂI J
)
ﬂﬂJ K
;
ﬂﬂK L
List
·· 
<
·· .
 UserContentToBeFeaturedViewModel
·· 1
>
··1 2

viewModels
··3 =
=
··> ?
	finalList
··@ I
.
··I J
	ProjectTo
··J S
<
··S T.
 UserContentToBeFeaturedViewModel
··T t
>
··t u
(
··u v
_mapper
··v }
.
··} ~$
ConfigurationProvider··~ ì
)··ì î
.··î ï
ToList··ï õ
(··õ ú
)··ú ù
;··ù û
foreach
„„ 
(
„„ .
 UserContentToBeFeaturedViewModel
„„ 5
item
„„6 :
in
„„; =

viewModels
„„> H
)
„„H I
{
‰‰ 
FeaturedContent
ÂÂ 
featuredNow
ÂÂ  +
=
ÂÂ, -
_repository
ÂÂ. 9
.
ÂÂ9 :
GetAll
ÂÂ: @
(
ÂÂ@ A
)
ÂÂA B
.
ÂÂB C
FirstOrDefault
ÂÂC Q
(
ÂÂQ R
x
ÂÂR S
=>
ÂÂT V
x
ÂÂW X
.
ÂÂX Y
UserContentId
ÂÂY f
==
ÂÂg i
item
ÂÂj n
.
ÂÂn o
Id
ÂÂo q
&&
ÂÂr t
x
ÂÂu v
.
ÂÂv w
	StartDateÂÂw Ä
.ÂÂÄ Å
DateÂÂÅ Ö
<=ÂÂÜ à
DateTimeÂÂâ ë
.ÂÂë í
TodayÂÂí ó
&&ÂÂò ö
(ÂÂõ ú
xÂÂú ù
.ÂÂù û
EndDateÂÂû •
.ÂÂ• ¶
DateÂÂ¶ ™
==ÂÂ´ ≠
nullÂÂÆ ≤
||ÂÂ≥ µ
xÂÂ∂ ∑
.ÂÂ∑ ∏
EndDateÂÂ∏ ø
.ÂÂø ¿
DateÂÂ¿ ƒ
==ÂÂ≈ «
DateTimeÂÂ» –
.ÂÂ– —
MinValueÂÂ— Ÿ
||ÂÂ⁄ ‹
xÂÂ› ﬁ
.ÂÂﬁ ﬂ
EndDateÂÂﬂ Ê
.ÂÂÊ Á
DateÂÂÁ Î
>ÂÂÏ Ì
DateTimeÂÂÓ ˆ
.ÂÂˆ ˜
TodayÂÂ˜ ¸
)ÂÂ¸ ˝
)ÂÂ˝ ˛
;ÂÂ˛ ˇ
if
ÁÁ 
(
ÁÁ 
featuredNow
ÁÁ 
!=
ÁÁ  "
null
ÁÁ# '
)
ÁÁ' (
{
ËË 
item
ÈÈ 
.
ÈÈ 
CurrentFeatureId
ÈÈ )
=
ÈÈ* +
featuredNow
ÈÈ, 7
.
ÈÈ7 8
Id
ÈÈ8 :
;
ÈÈ: ;
}
ÍÍ 
item
ÌÌ 
.
ÌÌ 

IsFeatured
ÌÌ 
=
ÌÌ  !
item
ÌÌ" &
.
ÌÌ& '
CurrentFeatureId
ÌÌ' 7
.
ÌÌ7 8
HasValue
ÌÌ8 @
;
ÌÌ@ A
item
ÔÔ 
.
ÔÔ 

AuthorName
ÔÔ 
=
ÔÔ  !
string
ÔÔ" (
.
ÔÔ( ) 
IsNullOrWhiteSpace
ÔÔ) ;
(
ÔÔ; <
item
ÔÔ< @
.
ÔÔ@ A

AuthorName
ÔÔA K
)
ÔÔK L
?
ÔÔM N
$str
ÔÔO ]
:
ÔÔ^ _
item
ÔÔ` d
.
ÔÔd e

AuthorName
ÔÔe o
;
ÔÔo p
item
ÒÒ 
.
ÒÒ 
TitleCompliant
ÒÒ #
=
ÒÒ$ %
!
ÒÒ& '
string
ÒÒ' -
.
ÒÒ- . 
IsNullOrWhiteSpace
ÒÒ. @
(
ÒÒ@ A
item
ÒÒA E
.
ÒÒE F
Title
ÒÒF K
)
ÒÒK L
&&
ÒÒM O
item
ÒÒP T
.
ÒÒT U
Title
ÒÒU Z
.
ÒÒZ [
Length
ÒÒ[ a
<=
ÒÒb d
$num
ÒÒe g
;
ÒÒg h
item
ÛÛ 
.
ÛÛ 
IntroCompliant
ÛÛ #
=
ÛÛ$ %
!
ÛÛ& '
string
ÛÛ' -
.
ÛÛ- . 
IsNullOrWhiteSpace
ÛÛ. @
(
ÛÛ@ A
item
ÛÛA E
.
ÛÛE F
Introduction
ÛÛF R
)
ÛÛR S
&&
ÛÛT V
item
ÛÛW [
.
ÛÛ[ \
Introduction
ÛÛ\ h
.
ÛÛh i
Length
ÛÛi o
<=
ÛÛp r
$num
ÛÛs u
;
ÛÛu v
item
ıı 
.
ıı 
ContentCompliant
ıı %
=
ıı& '
!
ıı( )
string
ıı) /
.
ıı/ 0 
IsNullOrWhiteSpace
ıı0 B
(
ııB C
item
ııC G
.
ııG H
Content
ııH O
)
ııO P
&&
ııQ S
item
ııT X
.
ııX Y
Content
ııY `
.
ıı` a
Length
ııa g
>=
ııh j
$num
ıık n
;
ıın o
item
˜˜ 
.
˜˜ 
	IsArticle
˜˜ 
=
˜˜  
!
˜˜! "
string
˜˜" (
.
˜˜( ) 
IsNullOrWhiteSpace
˜˜) ;
(
˜˜; <
item
˜˜< @
.
˜˜@ A
Title
˜˜A F
)
˜˜F G
&&
˜˜H J
!
˜˜K L
string
˜˜L R
.
˜˜R S 
IsNullOrWhiteSpace
˜˜S e
(
˜˜e f
item
˜˜f j
.
˜˜j k
Introduction
˜˜k w
)
˜˜w x
;
˜˜x y
item
˙˙ 
.
˙˙ 
	LikeCount
˙˙ 
=
˙˙  
_likeRepository
˙˙! 0
.
˙˙0 1
GetAll
˙˙1 7
(
˙˙7 8
)
˙˙8 9
.
˙˙9 :
Count
˙˙: ?
(
˙˙? @
x
˙˙@ A
=>
˙˙B D
x
˙˙E F
.
˙˙F G
	ContentId
˙˙G P
==
˙˙Q S
item
˙˙T X
.
˙˙X Y
Id
˙˙Y [
)
˙˙[ \
;
˙˙\ ]
item
¸¸ 
.
¸¸ 
CommentCount
¸¸ !
=
¸¸" # 
_commentRepository
¸¸$ 6
.
¸¸6 7
GetAll
¸¸7 =
(
¸¸= >
)
¸¸> ?
.
¸¸? @
Count
¸¸@ E
(
¸¸E F
x
¸¸F G
=>
¸¸H J
x
¸¸K L
.
¸¸L M
UserContentId
¸¸M Z
==
¸¸[ ]
item
¸¸^ b
.
¸¸b c
Id
¸¸c e
)
¸¸e f
;
¸¸f g
}
˝˝ 

viewModels
ˇˇ 
=
ˇˇ 

viewModels
ˇˇ #
.
ˇˇ# $
OrderByDescending
ˇˇ$ 5
(
ˇˇ5 6
x
ˇˇ6 7
=>
ˇˇ8 :
x
ˇˇ; <
.
ˇˇ< =

IsFeatured
ˇˇ= G
)
ˇˇG H
.
ˇˇH I
ToList
ˇˇI O
(
ˇˇO P
)
ˇˇP Q
;
ˇˇQ R
return
ÅÅ 

viewModels
ÅÅ 
;
ÅÅ 
}
ÇÇ 	
public
ÖÖ 
OperationResultVo
ÖÖ  
	Unfeature
ÖÖ! *
(
ÖÖ* +
Guid
ÖÖ+ /
id
ÖÖ0 2
)
ÖÖ2 3
{
ÜÜ 	
OperationResultVo
áá 
result
áá $
;
áá$ %
try
ââ 
{
ää 
FeaturedContent
éé 
existing
éé  (
=
éé) *
_repository
éé+ 6
.
éé6 7
GetById
éé7 >
(
éé> ?
id
éé? A
)
ééA B
;
ééB C
if
êê 
(
êê 
existing
êê 
!=
êê 
null
êê  $
)
êê$ %
{
ëë 
existing
íí 
.
íí 
EndDate
íí $
=
íí% &
DateTime
íí' /
.
íí/ 0
Now
íí0 3
;
íí3 4
existing
îî 
.
îî 
Active
îî #
=
îî$ %
false
îî& +
;
îî+ ,
_unitOfWork
ññ 
.
ññ  
Commit
ññ  &
(
ññ& '
)
ññ' (
;
ññ( )
}
óó 
result
ôô 
=
ôô 
new
ôô 
OperationResultVo
ôô .
(
ôô. /
true
ôô/ 3
)
ôô3 4
;
ôô4 5
}
öö 
catch
õõ 
(
õõ 
	Exception
õõ 
ex
õõ 
)
õõ  
{
úú 
result
ùù 
=
ùù 
new
ùù 
OperationResultVo
ùù .
(
ùù. /
ex
ùù/ 1
.
ùù1 2
Message
ùù2 9
)
ùù9 :
;
ùù: ;
}
ûû 
return
†† 
result
†† 
;
†† 
}
°° 	
}
¢¢ 
}££ Ïu
mC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\FollowAppService.cs
	namespace

 	
IndieVisible


 
.

 
Application

 "
.

" #
Services

# +
{ 
public 

class 
FollowAppService !
:" #
BaseAppService$ 2
,2 3
IFollowAppService4 E
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly $
IGameFollowDomainService 1#
gameFollowDomainService2 I
;I J
private 
readonly $
IUserFollowDomainService 1#
userFollowDomainService2 I
;I J
public 
FollowAppService 
(  
IMapper  '
mapper( .
,. /
IUnitOfWork0 ;

unitOfWork< F
, $
IGameFollowDomainService &#
gameFollowDomainService' >
, $
IUserFollowDomainService &#
userFollowDomainService' >
)> ?
{ 	
this 
. 
mapper 
= 
mapper  
;  !
this 
. 

unitOfWork 
= 

unitOfWork (
;( )
this 
. #
gameFollowDomainService (
=) *#
gameFollowDomainService+ B
;B C
this 
. #
userFollowDomainService (
=) *#
userFollowDomainService+ B
;B C
} 	
public 
OperationResultVo  

GameFollow! +
(+ ,
Guid, 0
userId1 7
,7 8
Guid9 =
gameId> D
)D E
{ 	
OperationResultVo   
response   &
;  & '
if"" 
("" 
userId"" 
=="" 
Guid"" 
."" 
Empty"" $
)""$ %
{## 
response$$ 
=$$ 
new$$ 
OperationResultVo$$ 0
($$0 1
$str$$1 Y
)$$Y Z
;$$Z [
}%% 
else&& 
{'' 
bool(( 
alreadyLiked(( !
=((" ##
gameFollowDomainService(($ ;
.((; <
GetAll((< B
(((B C
)((C D
.((D E
Any((E H
(((H I
x((I J
=>((K M
x((N O
.((O P
GameId((P V
==((W Y
gameId((Z `
&&((a c
x((d e
.((e f
UserId((f l
==((m o
userId((p v
)((v w
;((w x
if** 
(** 
alreadyLiked**  
)**  !
{++ 
response,, 
=,, 
new,, "
OperationResultVo,,# 4
(,,4 5
false,,5 :
),,: ;
;,,; <
response-- 
.-- 
Message-- $
=--% &
$str--' >
;--> ?
}.. 
else// 
{00 

GameFollow11 
model11 $
=11% &
new11' *

GameFollow11+ 5
(115 6
)116 7
;117 8
model33 
.33 
GameId33  
=33! "
gameId33# )
;33) *
model44 
.44 
UserId44  
=44! "
userId44# )
;44) *
this66 
.66 #
gameFollowDomainService66 0
.660 1
Add661 4
(664 5
model665 :
)66: ;
;66; <

unitOfWork88 
.88 
Commit88 %
(88% &
)88& '
;88' (
int:: 
newCount::  
=::! "
this::# '
.::' (#
gameFollowDomainService::( ?
.::? @
Count::@ E
(::E F
x::F G
=>::H J
x::K L
.::L M
GameId::M S
==::T V
gameId::W ]
)::] ^
;::^ _
response<< 
=<< 
new<< "
OperationResultVo<<# 4
<<<4 5
int<<5 8
><<8 9
(<<9 :
newCount<<: B
)<<B C
;<<C D
}== 
}>> 
return@@ 
response@@ 
;@@ 
}AA 	
publicCC 
OperationResultVoCC  
GameUnfollowCC! -
(CC- .
GuidCC. 2
userIdCC3 9
,CC9 :
GuidCC; ?
gameIdCC@ F
)CCF G
{DD 	
OperationResultVoEE 
responseEE &
;EE& '
ifGG 
(GG 
userIdGG 
==GG 
GuidGG 
.GG 
EmptyGG $
)GG$ %
{HH 
responseII 
=II 
newII 
OperationResultVoII 0
(II0 1
$strII1 [
)II[ \
;II\ ]
}JJ 
elseKK 
{LL 

GameFollowNN 
existingLikeNN '
=NN( )
thisNN* .
.NN. /#
gameFollowDomainServiceNN/ F
.NNF G
GetAllNNG M
(NNM N
)NNN O
.NNO P
FirstOrDefaultNNP ^
(NN^ _
xNN_ `
=>NNa c
xNNd e
.NNe f
GameIdNNf l
==NNm o
gameIdNNp v
&&NNw y
xNNz {
.NN{ |
UserId	NN| Ç
==
NNÉ Ö
userId
NNÜ å
)
NNå ç
;
NNç é
ifPP 
(PP 
existingLikePP  
==PP! #
nullPP$ (
)PP( )
{QQ 
responseRR 
=RR 
newRR "
OperationResultVoRR# 4
(RR4 5
falseRR5 :
)RR: ;
;RR; <
responseSS 
.SS 
MessageSS $
=SS% &
$strSS' I
;SSI J
}TT 
elseUU 
{VV 
thisWW 
.WW 
RemoveGameFollowWW )
(WW) *
existingLikeWW* 6
.WW6 7
IdWW7 9
)WW9 :
;WW: ;

unitOfWorkYY 
.YY 
CommitYY %
(YY% &
)YY& '
;YY' (
int[[ 
newCount[[  
=[[! "
this[[# '
.[[' (#
gameFollowDomainService[[( ?
.[[? @
Count[[@ E
([[E F
x[[F G
=>[[H J
x[[K L
.[[L M
GameId[[M S
==[[T V
gameId[[W ]
)[[] ^
;[[^ _
response]] 
=]] 
new]] "
OperationResultVo]]# 4
<]]4 5
int]]5 8
>]]8 9
(]]9 :
newCount]]: B
)]]B C
;]]C D
}^^ 
}__ 
returnaa 
responseaa 
;aa 
}bb 	
privatedd 
OperationResultVodd !
RemoveGameFollowdd" 2
(dd2 3
Guiddd3 7
iddd8 :
)dd: ;
{ee 	
OperationResultVoff 
resultff $
;ff$ %
tryhh 
{ii 
thisll 
.ll #
gameFollowDomainServicell ,
.ll, -
Removell- 3
(ll3 4
idll4 6
)ll6 7
;ll7 8

unitOfWorknn 
.nn 
Commitnn !
(nn! "
)nn" #
;nn# $
resultpp 
=pp 
newpp 
OperationResultVopp .
(pp. /
truepp/ 3
)pp3 4
;pp4 5
}qq 
catchrr 
(rr 
	Exceptionrr 
exrr 
)rr  
{ss 
resulttt 
=tt 
newtt 
OperationResultVott .
(tt. /
extt/ 1
.tt1 2
Messagett2 9
)tt9 :
;tt: ;
}uu 
returnww 
resultww 
;ww 
}xx 	
public|| 
OperationResultVo||  

UserFollow||! +
(||+ ,
Guid||, 0
userId||1 7
,||7 8
Guid||9 =
followUserId||> J
)||J K
{}} 	
OperationResultVo~~ 
response~~ &
;~~& '
if
ÄÄ 
(
ÄÄ 
userId
ÄÄ 
==
ÄÄ 
Guid
ÄÄ 
.
ÄÄ 
Empty
ÄÄ $
)
ÄÄ$ %
{
ÅÅ 
response
ÇÇ 
=
ÇÇ 
new
ÇÇ 
OperationResultVo
ÇÇ 0
(
ÇÇ0 1
$str
ÇÇ1 Y
)
ÇÇY Z
;
ÇÇZ [
}
ÉÉ 
else
ÑÑ 
{
ÖÖ 
bool
ÜÜ 
alreadyLiked
ÜÜ !
=
ÜÜ" #%
userFollowDomainService
ÜÜ$ ;
.
ÜÜ; <
GetAll
ÜÜ< B
(
ÜÜB C
)
ÜÜC D
.
ÜÜD E
Any
ÜÜE H
(
ÜÜH I
x
ÜÜI J
=>
ÜÜK M
x
ÜÜN O
.
ÜÜO P
UserId
ÜÜP V
==
ÜÜW Y
userId
ÜÜZ `
&&
ÜÜa c
x
ÜÜd e
.
ÜÜe f
FollowUserId
ÜÜf r
==
ÜÜs u
followUserIdÜÜv Ç
)ÜÜÇ É
;ÜÜÉ Ñ
if
àà 
(
àà 
alreadyLiked
àà  
)
àà  !
{
ââ 
response
ää 
=
ää 
new
ää "
OperationResultVo
ää# 4
(
ää4 5
false
ää5 :
)
ää: ;
;
ää; <
response
ãã 
.
ãã 
Message
ãã $
=
ãã% &
$str
ãã' >
;
ãã> ?
}
åå 
else
çç 
{
éé 

UserFollow
èè 
model
èè $
=
èè% &
new
èè' *

UserFollow
èè+ 5
(
èè5 6
)
èè6 7
;
èè7 8
model
ëë 
.
ëë 
FollowUserId
ëë &
=
ëë' (
followUserId
ëë) 5
;
ëë5 6
model
íí 
.
íí 
UserId
íí  
=
íí! "
userId
íí# )
;
íí) *
this
îî 
.
îî %
userFollowDomainService
îî 0
.
îî0 1
Add
îî1 4
(
îî4 5
model
îî5 :
)
îî: ;
;
îî; <

unitOfWork
ññ 
.
ññ 
Commit
ññ %
(
ññ% &
)
ññ& '
;
ññ' (
int
òò 
newCount
òò  
=
òò! "
this
òò# '
.
òò' (%
userFollowDomainService
òò( ?
.
òò? @
Count
òò@ E
(
òòE F
x
òòF G
=>
òòH J
x
òòK L
.
òòL M
FollowUserId
òòM Y
==
òòZ \
followUserId
òò] i
)
òòi j
;
òòj k
response
öö 
=
öö 
new
öö "
OperationResultVo
öö# 4
<
öö4 5
int
öö5 8
>
öö8 9
(
öö9 :
newCount
öö: B
)
ööB C
;
ööC D
}
õõ 
}
úú 
return
ûû 
response
ûû 
;
ûû 
}
üü 	
public
°° 
OperationResultVo
°°  
UserUnfollow
°°! -
(
°°- .
Guid
°°. 2
userId
°°3 9
,
°°9 :
Guid
°°; ?
followUserId
°°@ L
)
°°L M
{
¢¢ 	
OperationResultVo
££ 
response
££ &
;
££& '
if
•• 
(
•• 
userId
•• 
==
•• 
Guid
•• 
.
•• 
Empty
•• $
)
••$ %
{
¶¶ 
response
ßß 
=
ßß 
new
ßß 
OperationResultVo
ßß 0
(
ßß0 1
$str
ßß1 \
)
ßß\ ]
;
ßß] ^
}
®® 
else
©© 
{
™™ 

UserFollow
¨¨ 
existingLike
¨¨ '
=
¨¨( )
this
¨¨* .
.
¨¨. /%
userFollowDomainService
¨¨/ F
.
¨¨F G
GetAll
¨¨G M
(
¨¨M N
)
¨¨N O
.
¨¨O P
FirstOrDefault
¨¨P ^
(
¨¨^ _
x
¨¨_ `
=>
¨¨a c
x
¨¨d e
.
¨¨e f
UserId
¨¨f l
==
¨¨m o
userId
¨¨p v
&&
¨¨w y
x
¨¨z {
.
¨¨{ |
FollowUserId¨¨| à
==¨¨â ã
followUserId¨¨å ò
)¨¨ò ô
;¨¨ô ö
if
ÆÆ 
(
ÆÆ 
existingLike
ÆÆ  
==
ÆÆ! #
null
ÆÆ$ (
)
ÆÆ( )
{
ØØ 
response
∞∞ 
=
∞∞ 
new
∞∞ "
OperationResultVo
∞∞# 4
(
∞∞4 5
false
∞∞5 :
)
∞∞: ;
;
∞∞; <
response
±± 
.
±± 
Message
±± $
=
±±% &
$str
±±' I
;
±±I J
}
≤≤ 
else
≥≥ 
{
¥¥ 
this
µµ 
.
µµ !
RemoveProfileFollow
µµ ,
(
µµ, -
existingLike
µµ- 9
.
µµ9 :
Id
µµ: <
)
µµ< =
;
µµ= >

unitOfWork
∑∑ 
.
∑∑ 
Commit
∑∑ %
(
∑∑% &
)
∑∑& '
;
∑∑' (
int
ππ 
newCount
ππ  
=
ππ! "
this
ππ# '
.
ππ' (%
userFollowDomainService
ππ( ?
.
ππ? @
GetAll
ππ@ F
(
ππF G
)
ππG H
.
ππH I
Count
ππI N
(
ππN O
x
ππO P
=>
ππQ S
x
ππT U
.
ππU V
FollowUserId
ππV b
==
ππc e
followUserId
ππf r
)
ππr s
;
ππs t
response
ªª 
=
ªª 
new
ªª "
OperationResultVo
ªª# 4
<
ªª4 5
int
ªª5 8
>
ªª8 9
(
ªª9 :
newCount
ªª: B
)
ªªB C
;
ªªC D
}
ºº 
}
ΩΩ 
return
øø 
response
øø 
;
øø 
}
¿¿ 	
private
¬¬ 
OperationResultVo
¬¬ !!
RemoveProfileFollow
¬¬" 5
(
¬¬5 6
Guid
¬¬6 :
id
¬¬; =
)
¬¬= >
{
√√ 	
OperationResultVo
ƒƒ 
result
ƒƒ $
;
ƒƒ$ %
try
∆∆ 
{
«« 
this
   
.
   %
userFollowDomainService
   ,
.
  , -
Remove
  - 3
(
  3 4
id
  4 6
)
  6 7
;
  7 8

unitOfWork
ÃÃ 
.
ÃÃ 
Commit
ÃÃ !
(
ÃÃ! "
)
ÃÃ" #
;
ÃÃ# $
result
ŒŒ 
=
ŒŒ 
new
ŒŒ 
OperationResultVo
ŒŒ .
(
ŒŒ. /
true
ŒŒ/ 3
)
ŒŒ3 4
;
ŒŒ4 5
}
œœ 
catch
–– 
(
–– 
	Exception
–– 
ex
–– 
)
––  
{
—— 
result
““ 
=
““ 
new
““ 
OperationResultVo
““ .
(
““. /
ex
““/ 1
.
““1 2
Message
““2 9
)
““9 :
;
““: ;
}
”” 
return
’’ 
result
’’ 
;
’’ 
}
÷÷ 	
}
ÿÿ 
}ŸŸ ∏ò
kC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\GameAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class 
GameAppService 
:  !
BaseAppService" 0
,0 1
IGameAppService2 A
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly 
IGameRepository (

repository) 3
;3 4
private 
readonly 
IGameLikeRepository ,
gameLikeRepository- ?
;? @
private 
readonly &
IGamificationDomainService 3%
gamificationDomainService4 M
;M N
private 
readonly $
IGameFollowDomainService 1#
gameFollowDomainService2 I
;I J
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
GameAppService 
( 
IMapper %
mapper& ,
,, -
IUnitOfWork. 9

unitOfWork: D
,D E
IGameRepositoryF U

repositoryV `
,` a
IGameLikeRepositoryb u
gameLikeRepository	v à
, &
IGamificationDomainService (%
gamificationDomainService) B
, $
IGameFollowDomainService &#
gameFollowDomainService' >
)> ?
{   	
this!! 
.!! 
mapper!! 
=!! 
mapper!!  
;!!  !
this"" 
."" 

unitOfWork"" 
="" 

unitOfWork"" (
;""( )
this## 
.## 

repository## 
=## 

repository## (
;##( )
this$$ 
.$$ 
gameLikeRepository$$ #
=$$$ %
gameLikeRepository$$& 8
;$$8 9
this%% 
.%% %
gamificationDomainService%% *
=%%+ ,%
gamificationDomainService%%- F
;%%F G
this&& 
.&& #
gameFollowDomainService&& (
=&&) *#
gameFollowDomainService&&+ B
;&&B C
}'' 	
public)) 
OperationResultVo))  
<))  !
int))! $
>))$ %
Count))& +
())+ ,
))), -
{** 	
OperationResultVo++ 
<++ 
int++ !
>++! "
result++# )
;++) *
try-- 
{.. 
int// 
count// 
=// 

repository// &
.//& '
GetAll//' -
(//- .
)//. /
./// 0
Count//0 5
(//5 6
)//6 7
;//7 8
result11 
=11 
new11 
OperationResultVo11 .
<11. /
int11/ 2
>112 3
(113 4
count114 9
)119 :
;11: ;
}22 
catch33 
(33 
	Exception33 
ex33 
)33  
{44 
result55 
=55 
new55 
OperationResultVo55 .
<55. /
int55/ 2
>552 3
(553 4
ex554 6
.556 7
Message557 >
)55> ?
;55? @
}66 
return88 
result88 
;88 
}99 	
public<< !
OperationResultListVo<< $
<<<$ %
GameViewModel<<% 2
><<2 3
GetAll<<4 :
(<<: ;
)<<; <
{== 	!
OperationResultListVo>> !
<>>! "
GameViewModel>>" /
>>>/ 0
result>>1 7
;>>7 8
try@@ 
{AA 

IQueryableBB 
<BB 
GameBB 
>BB  
	allModelsBB! *
=BB+ ,

repositoryBB- 7
.BB7 8
GetAllBB8 >
(BB> ?
)BB? @
;BB@ A
IEnumerableDD 
<DD 
GameViewModelDD )
>DD) *
vmsDD+ .
=DD/ 0
mapperDD1 7
.DD7 8
MapDD8 ;
<DD; <
IEnumerableDD< G
<DDG H
GameDDH L
>DDL M
,DDM N
IEnumerableDDO Z
<DDZ [
GameViewModelDD[ h
>DDh i
>DDi j
(DDj k
	allModelsDDk t
)DDt u
;DDu v
resultFF 
=FF 
newFF !
OperationResultListVoFF 2
<FF2 3
GameViewModelFF3 @
>FF@ A
(FFA B
vmsFFB E
)FFE F
;FFF G
}GG 
catchHH 
(HH 
	ExceptionHH 
exHH 
)HH  
{II 
resultJJ 
=JJ 
newJJ !
OperationResultListVoJJ 2
<JJ2 3
GameViewModelJJ3 @
>JJ@ A
(JJA B
exJJB D
.JJD E
MessageJJE L
)JJL M
;JJM N
}KK 
returnMM 
resultMM 
;MM 
}NN 	
publicPP 
OperationResultVoPP  
<PP  !
GameViewModelPP! .
>PP. /
GetByIdPP0 7
(PP7 8
GuidPP8 <
idPP= ?
)PP? @
{QQ 	
OperationResultVoRR 
<RR 
GameViewModelRR +
>RR+ ,
resultRR- 3
;RR3 4
tryTT 
{UU 
GameVV 
modelVV 
=VV 

repositoryVV '
.VV' (
GetByIdVV( /
(VV/ 0
idVV0 2
)VV2 3
;VV3 4
GameViewModelXX 
vmXX  
=XX! "
mapperXX# )
.XX) *
MapXX* -
<XX- .
GameViewModelXX. ;
>XX; <
(XX< =
modelXX= B
)XXB C
;XXC D
SetWebsiteUrlZZ 
(ZZ 
vmZZ  
)ZZ  !
;ZZ! "
vm\\ 
.\\ 
	LikeCount\\ 
=\\ 
gameLikeRepository\\ 1
.\\1 2
Count\\2 7
(\\7 8
x\\8 9
=>\\: <
x\\= >
.\\> ?
GameId\\? E
==\\F H
vm\\I K
.\\K L
Id\\L N
)\\N O
;\\O P
vm]] 
.]] 
FollowerCount]]  
=]]! "#
gameFollowDomainService]]# :
.]]: ;
Count]]; @
(]]@ A
x]]A B
=>]]C E
x]]F G
.]]G H
GameId]]H N
==]]O Q
vm]]R T
.]]T U
Id]]U W
)]]W X
;]]X Y
vm__ 
.__ 
CurrentUserLiked__ #
=__$ %
gameLikeRepository__& 8
.__8 9
GetAll__9 ?
(__? @
)__@ A
.__A B
Any__B E
(__E F
x__F G
=>__H J
x__K L
.__L M
GameId__M S
==__T V
vm__W Y
.__Y Z
Id__Z \
&&__] _
x__` a
.__a b
UserId__b h
==__i k
this__l p
.__p q
CurrentUserId__q ~
)__~ 
;	__ Ä
vm`` 
.``  
CurrentUserFollowing`` '
=``( )
this``* .
.``. /#
gameFollowDomainService``/ F
.``F G
GetAll``G M
(``M N
)``N O
.``O P
Any``P S
(``S T
x``T U
=>``V X
x``Y Z
.``Z [
GameId``[ a
==``b d
vm``e g
.``g h
Id``h j
&&``k m
x``n o
.``o p
UserId``p v
==``w y
this``z ~
.``~ 
CurrentUserId	`` å
)
``å ç
;
``ç é
resultbb 
=bb 
newbb 
OperationResultVobb .
<bb. /
GameViewModelbb/ <
>bb< =
(bb= >
vmbb> @
)bb@ A
;bbA B
}cc 
catchdd 
(dd 
	Exceptiondd 
exdd 
)dd  
{ee 
resultff 
=ff 
newff 
OperationResultVoff .
<ff. /
GameViewModelff/ <
>ff< =
(ff= >
exff> @
.ff@ A
MessageffA H
)ffH I
;ffI J
}gg 
returnii 
resultii 
;ii 
}jj 	
privatell 
staticll 
voidll 
SetWebsiteUrlll )
(ll) *
GameViewModelll* 7
vmll8 :
)ll: ;
{mm 	
ifnn 
(nn 
!nn 
stringnn 
.nn 
IsNullOrWhiteSpacenn *
(nn* +
vmnn+ -
.nn- .

WebsiteUrlnn. 8
)nn8 9
)nn9 :
{oo 
vmpp 
.pp 

WebsiteUrlpp 
=pp 
vmpp  "
.pp" #

WebsiteUrlpp# -
.pp- .
ToLowerpp. 5
(pp5 6
)pp6 7
;pp7 8
ifrr 
(rr 
!rr 
vmrr 
.rr 

WebsiteUrlrr "
.rr" #

StartsWithrr# -
(rr- .
$strrr. 5
)rr5 6
&&rr7 9
!rr: ;
vmrr; =
.rr= >

WebsiteUrlrr> H
.rrH I

StartsWithrrI S
(rrS T
$strrrT \
)rr\ ]
)rr] ^
{ss 
vmtt 
.tt 

WebsiteUrltt !
=tt" #
$strtt$ -
+tt. /
vmtt0 2
.tt2 3

WebsiteUrltt3 =
;tt= >
}uu 
}vv 
}ww 	
publicyy 
OperationResultVoyy  
Removeyy! '
(yy' (
Guidyy( ,
idyy- /
)yy/ 0
{zz 	
OperationResultVo{{ 
result{{ $
;{{$ %
try}} 
{~~ 

repository
ÅÅ 
.
ÅÅ 
Remove
ÅÅ !
(
ÅÅ! "
id
ÅÅ" $
)
ÅÅ$ %
;
ÅÅ% &

unitOfWork
ÉÉ 
.
ÉÉ 
Commit
ÉÉ !
(
ÉÉ! "
)
ÉÉ" #
;
ÉÉ# $
result
ÖÖ 
=
ÖÖ 
new
ÖÖ 
OperationResultVo
ÖÖ .
(
ÖÖ. /
true
ÖÖ/ 3
)
ÖÖ3 4
;
ÖÖ4 5
}
ÜÜ 
catch
áá 
(
áá 
	Exception
áá 
ex
áá 
)
áá  
{
àà 
result
ââ 
=
ââ 
new
ââ 
OperationResultVo
ââ .
(
ââ. /
ex
ââ/ 1
.
ââ1 2
Message
ââ2 9
)
ââ9 :
;
ââ: ;
}
ää 
return
åå 
result
åå 
;
åå 
}
çç 	
public
èè 
OperationResultVo
èè  
<
èè  !
Guid
èè! %
>
èè% &
Save
èè' +
(
èè+ ,
GameViewModel
èè, 9
	viewModel
èè: C
)
èèC D
{
êê 	
OperationResultVo
ëë 
<
ëë 
Guid
ëë "
>
ëë" #
result
ëë$ *
;
ëë* +
try
ìì 
{
îî 
Game
ïï 
model
ïï 
;
ïï 
Game
ôô 
existing
ôô 
=
ôô 

repository
ôô  *
.
ôô* +
GetById
ôô+ 2
(
ôô2 3
	viewModel
ôô3 <
.
ôô< =
Id
ôô= ?
)
ôô? @
;
ôô@ A
if
öö 
(
öö 
existing
öö 
!=
öö 
null
öö  $
)
öö$ %
{
õõ 
model
úú 
=
úú 
mapper
úú "
.
úú" #
Map
úú# &
(
úú& '
	viewModel
úú' 0
,
úú0 1
existing
úú2 :
)
úú: ;
;
úú; <
}
ùù 
else
ûû 
{
üü 
model
†† 
=
†† 
mapper
†† "
.
††" #
Map
††# &
<
††& '
Game
††' +
>
††+ ,
(
††, -
	viewModel
††- 6
)
††6 7
;
††7 8
}
°° 
if
££ 
(
££ 
	viewModel
££ 
.
££ 
Id
££  
==
££! #
Guid
££$ (
.
££( )
Empty
££) .
)
££. /
{
§§ 

repository
•• 
.
•• 
Add
•• "
(
••" #
model
••# (
)
••( )
;
••) *
	viewModel
¶¶ 
.
¶¶ 
Id
¶¶  
=
¶¶! "
model
¶¶# (
.
¶¶( )
Id
¶¶) +
;
¶¶+ ,
this
®® 
.
®® '
gamificationDomainService
®® 2
.
®®2 3
ProcessAction
®®3 @
(
®®@ A
	viewModel
®®A J
.
®®J K
UserId
®®K Q
,
®®Q R
PlatformAction
®®S a
.
®®a b
GameAdd
®®b i
)
®®i j
;
®®j k
}
©© 
else
™™ 
{
´´ 

repository
¨¨ 
.
¨¨ 
Update
¨¨ %
(
¨¨% &
model
¨¨& +
)
¨¨+ ,
;
¨¨, -
}
≠≠ 

unitOfWork
ØØ 
.
ØØ 
Commit
ØØ !
(
ØØ! "
)
ØØ" #
;
ØØ# $
result
±± 
=
±± 
new
±± 
OperationResultVo
±± .
<
±±. /
Guid
±±/ 3
>
±±3 4
(
±±4 5
model
±±5 :
.
±±: ;
Id
±±; =
)
±±= >
;
±±> ?
}
≤≤ 
catch
≥≥ 
(
≥≥ 
	Exception
≥≥ 
ex
≥≥ 
)
≥≥  
{
¥¥ 
result
µµ 
=
µµ 
new
µµ 
OperationResultVo
µµ .
<
µµ. /
Guid
µµ/ 3
>
µµ3 4
(
µµ4 5
ex
µµ5 7
.
µµ7 8
Message
µµ8 ?
)
µµ? @
;
µµ@ A
}
∂∂ 
return
∏∏ 
result
∏∏ 
;
∏∏ 
}
ππ 	
public
ªª 
IEnumerable
ªª 
<
ªª #
GameListItemViewModel
ªª 0
>
ªª0 1
	GetLatest
ªª2 ;
(
ªª; <
Guid
ªª< @
currentUserId
ªªA N
,
ªªN O
int
ªªP S
count
ªªT Y
,
ªªY Z
Guid
ªª[ _
userId
ªª` f
,
ªªf g
	GameGenre
ªªh q
genre
ªªr w
)
ªªw x
{
ºº 	

IQueryable
ΩΩ 
<
ΩΩ 
Game
ΩΩ 
>
ΩΩ 
	allModels
ΩΩ &
=
ΩΩ' (

repository
ΩΩ) 3
.
ΩΩ3 4
GetAll
ΩΩ4 :
(
ΩΩ: ;
)
ΩΩ; <
;
ΩΩ< =
if
øø 
(
øø 
genre
øø 
!=
øø 
$num
øø 
)
øø 
{
¿¿ 
	allModels
¡¡ 
=
¡¡ 
	allModels
¡¡ %
.
¡¡% &
Where
¡¡& +
(
¡¡+ ,
x
¡¡, -
=>
¡¡. 0
x
¡¡1 2
.
¡¡2 3
Genre
¡¡3 8
==
¡¡9 ;
genre
¡¡< A
)
¡¡A B
;
¡¡B C
}
¬¬ 
if
ƒƒ 
(
ƒƒ 
userId
ƒƒ 
!=
ƒƒ 
Guid
ƒƒ 
.
ƒƒ 
Empty
ƒƒ $
)
ƒƒ$ %
{
≈≈ 
	allModels
∆∆ 
=
∆∆ 
	allModels
∆∆ %
.
∆∆% &
Where
∆∆& +
(
∆∆+ ,
x
∆∆, -
=>
∆∆. 0
x
∆∆1 2
.
∆∆2 3
UserId
∆∆3 9
==
∆∆: <
userId
∆∆= C
)
∆∆C D
;
∆∆D E
}
«« 
IOrderedQueryable
…… 
<
…… 
Game
…… "
>
……" #
ordered
……$ +
=
……, -
	allModels
……. 7
.
……7 8
OrderByDescending
……8 I
(
……I J
x
……J K
=>
……L N
x
……O P
.
……P Q

CreateDate
……Q [
)
……[ \
;
……\ ]

IQueryable
ÀÀ 
<
ÀÀ 
Game
ÀÀ 
>
ÀÀ 
taken
ÀÀ "
=
ÀÀ# $
ordered
ÀÀ% ,
.
ÀÀ, -
Take
ÀÀ- 1
(
ÀÀ1 2
count
ÀÀ2 7
)
ÀÀ7 8
;
ÀÀ8 9
List
ÕÕ 
<
ÕÕ #
GameListItemViewModel
ÕÕ &
>
ÕÕ& '
vms
ÕÕ( +
=
ÕÕ, -
taken
ÕÕ. 3
.
ÕÕ3 4
	ProjectTo
ÕÕ4 =
<
ÕÕ= >#
GameListItemViewModel
ÕÕ> S
>
ÕÕS T
(
ÕÕT U
mapper
ÕÕU [
.
ÕÕ[ \#
ConfigurationProvider
ÕÕ\ q
)
ÕÕq r
.
ÕÕr s
ToList
ÕÕs y
(
ÕÕy z
)
ÕÕz {
;
ÕÕ{ |
foreach
œœ 
(
œœ #
GameListItemViewModel
œœ *
item
œœ+ /
in
œœ0 2
vms
œœ3 6
)
œœ6 7
{
–– 
item
—— 
.
—— 
ThumbnailUrl
—— !
=
——" #
string
——$ *
.
——* + 
IsNullOrWhiteSpace
——+ =
(
——= >
item
——> B
.
——B C
ThumbnailUrl
——C O
)
——O P
||
——Q S
	Constants
——T ]
.
——] ^"
DefaultGameThumbnail
——^ r
.
——r s
Contains
——s {
(
——{ |
item——| Ä
.——Ä Å
ThumbnailUrl——Å ç
)——ç é
?——è ê
	Constants——ë ö
.——ö õ$
DefaultGameThumbnail——õ Ø
:——∞ ±
UrlFormatter——≤ æ
.——æ ø
Image——ø ƒ
(——ƒ ≈
item——≈ …
.——…  
UserId——  –
,——– —
BlobType——“ ⁄
.——⁄ €
GameThumbnail——€ Ë
,——Ë È
item——Í Ó
.——Ó Ô
ThumbnailUrl——Ô ˚
)——˚ ¸
;——¸ ˝
item
““ 
.
““ 
DeveloperImageUrl
““ &
=
““' (
UrlFormatter
““) 5
.
““5 6
ProfileImage
““6 B
(
““B C
item
““C G
.
““G H
UserId
““H N
)
““N O
;
““O P
}
”” 
return
’’ 
vms
’’ 
;
’’ 
}
÷÷ 	
public
ÿÿ 
IEnumerable
ÿÿ 
<
ÿÿ 
SelectListItemVo
ÿÿ +
>
ÿÿ+ ,
	GetByUser
ÿÿ- 6
(
ÿÿ6 7
Guid
ÿÿ7 ;
userId
ÿÿ< B
)
ÿÿB C
{
ŸŸ 	

IQueryable
⁄⁄ 
<
⁄⁄ 
Game
⁄⁄ 
>
⁄⁄ 
	allModels
⁄⁄ &
=
⁄⁄' (

repository
⁄⁄) 3
.
⁄⁄3 4
GetAll
⁄⁄4 :
(
⁄⁄: ;
)
⁄⁄; <
.
⁄⁄< =
Where
⁄⁄= B
(
⁄⁄B C
x
⁄⁄C D
=>
⁄⁄E G
x
⁄⁄H I
.
⁄⁄I J
UserId
⁄⁄J P
==
⁄⁄Q S
userId
⁄⁄T Z
)
⁄⁄Z [
;
⁄⁄[ \
List
‹‹ 
<
‹‹ 
SelectListItemVo
‹‹ !
>
‹‹! "
vms
‹‹# &
=
‹‹' (
	allModels
‹‹) 2
.
‹‹2 3
	ProjectTo
‹‹3 <
<
‹‹< =
SelectListItemVo
‹‹= M
>
‹‹M N
(
‹‹N O
mapper
‹‹O U
.
‹‹U V#
ConfigurationProvider
‹‹V k
)
‹‹k l
.
‹‹l m
ToList
‹‹m s
(
‹‹s t
)
‹‹t u
;
‹‹u v
return
ﬁﬁ 
vms
ﬁﬁ 
;
ﬁﬁ 
}
ﬂﬂ 	
}
‡‡ 
}·· ö[
qC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\GameFollowAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class  
GameFollowAppService %
:& '
BaseAppService( 6
,6 7!
IGameFollowAppService8 M
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly $
IGameFollowDomainService 1#
gameFollowDomainService2 I
;I J
public  
GameFollowAppService #
(# $
IMapper$ +
mapper, 2
,2 3
IUnitOfWork4 ?

unitOfWork@ J
, $
IGameFollowDomainService &#
gameFollowDomainService' >
)> ?
{ 	
this 
. 
mapper 
= 
mapper  
;  !
this 
. 

unitOfWork 
= 

unitOfWork (
;( )
this 
. #
gameFollowDomainService (
=) *#
gameFollowDomainService+ B
;B C
} 	
public 
OperationResultVo  
<  !
int! $
>$ %
Count& +
(+ ,
), -
{ 	
OperationResultVo 
< 
int !
>! "
result# )
;) *
try 
{   
int!! 
count!! 
=!! #
gameFollowDomainService!! 3
.!!3 4
Count!!4 9
(!!9 :
)!!: ;
;!!; <
result## 
=## 
new## 
OperationResultVo## .
<##. /
int##/ 2
>##2 3
(##3 4
count##4 9
)##9 :
;##: ;
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 
result'' 
='' 
new'' 
OperationResultVo'' .
<''. /
int''/ 2
>''2 3
(''3 4
ex''4 6
.''6 7
Message''7 >
)''> ?
;''? @
}(( 
return** 
result** 
;** 
}++ 	
public-- !
OperationResultListVo-- $
<--$ %
GameFollowViewModel--% 8
>--8 9
GetAll--: @
(--@ A
)--A B
{.. 	!
OperationResultListVo// !
<//! "
GameFollowViewModel//" 5
>//5 6
result//7 =
;//= >
try11 
{22 
IEnumerable33 
<33 

GameFollow33 &
>33& '
	allModels33( 1
=332 3
this334 8
.338 9#
gameFollowDomainService339 P
.33P Q
GetAll33Q W
(33W X
)33X Y
;33Y Z
IEnumerable55 
<55 
GameFollowViewModel55 /
>55/ 0
vms551 4
=555 6
mapper557 =
.55= >
Map55> A
<55A B
IEnumerable55B M
<55M N

GameFollow55N X
>55X Y
,55Y Z
IEnumerable55[ f
<55f g
GameFollowViewModel55g z
>55z {
>55{ |
(55| }
	allModels	55} Ü
)
55Ü á
;
55á à
result77 
=77 
new77 !
OperationResultListVo77 2
<772 3
GameFollowViewModel773 F
>77F G
(77G H
vms77H K
)77K L
;77L M
}88 
catch99 
(99 
	Exception99 
ex99 
)99  
{:: 
result;; 
=;; 
new;; !
OperationResultListVo;; 2
<;;2 3
GameFollowViewModel;;3 F
>;;F G
(;;G H
ex;;H J
.;;J K
Message;;K R
);;R S
;;;S T
}<< 
return>> 
result>> 
;>> 
}?? 	
publicAA !
OperationResultListVoAA $
<AA$ %
GameFollowViewModelAA% 8
>AA8 9
GetByGameIdAA: E
(AAE F
GuidAAF J
gameIdAAK Q
)AAQ R
{BB 	!
OperationResultListVoCC !
<CC! "
GameFollowViewModelCC" 5
>CC5 6
resultCC7 =
;CC= >
tryEE 
{FF 
IEnumerableGG 
<GG 

GameFollowGG &
>GG& '
	allModelsGG( 1
=GG2 3
thisGG4 8
.GG8 9#
gameFollowDomainServiceGG9 P
.GGP Q
GetByGameIdGGQ \
(GG\ ]
gameIdGG] c
)GGc d
;GGd e
IEnumerableII 
<II 
GameFollowViewModelII /
>II/ 0
vmsII1 4
=II5 6
mapperII7 =
.II= >
MapII> A
<IIA B
IEnumerableIIB M
<IIM N

GameFollowIIN X
>IIX Y
,IIY Z
IEnumerableII[ f
<IIf g
GameFollowViewModelIIg z
>IIz {
>II{ |
(II| }
	allModels	II} Ü
)
IIÜ á
;
IIá à
resultKK 
=KK 
newKK !
OperationResultListVoKK 2
<KK2 3
GameFollowViewModelKK3 F
>KKF G
(KKG H
vmsKKH K
)KKK L
;KKL M
}LL 
catchMM 
(MM 
	ExceptionMM 
exMM 
)MM  
{NN 
resultOO 
=OO 
newOO !
OperationResultListVoOO 2
<OO2 3
GameFollowViewModelOO3 F
>OOF G
(OOG H
exOOH J
.OOJ K
MessageOOK R
)OOR S
;OOS T
}PP 
returnRR 
resultRR 
;RR 
}SS 	
publicUU 
OperationResultVoUU  
<UU  !
GameFollowViewModelUU! 4
>UU4 5
GetByIdUU6 =
(UU= >
GuidUU> B
idUUC E
)UUE F
{VV 	
OperationResultVoWW 
<WW 
GameFollowViewModelWW 1
>WW1 2
resultWW3 9
;WW9 :
tryYY 
{ZZ 

GameFollow[[ 
model[[  
=[[! "
this[[# '
.[[' (#
gameFollowDomainService[[( ?
.[[? @
GetById[[@ G
([[G H
id[[H J
)[[J K
;[[K L
GameFollowViewModel]] #
vm]]$ &
=]]' (
mapper]]) /
.]]/ 0
Map]]0 3
<]]3 4
GameFollowViewModel]]4 G
>]]G H
(]]H I
model]]I N
)]]N O
;]]O P
result__ 
=__ 
new__ 
OperationResultVo__ .
<__. /
GameFollowViewModel__/ B
>__B C
(__C D
vm__D F
)__F G
;__G H
}`` 
catchaa 
(aa 
	Exceptionaa 
exaa 
)aa  
{bb 
resultcc 
=cc 
newcc 
OperationResultVocc .
<cc. /
GameFollowViewModelcc/ B
>ccB C
(ccC D
exccD F
.ccF G
MessageccG N
)ccN O
;ccO P
}dd 
returnff 
resultff 
;ff 
}gg 	
publicii 
OperationResultVoii  
Removeii! '
(ii' (
Guidii( ,
idii- /
)ii/ 0
{jj 	
OperationResultVokk 
resultkk $
;kk$ %
trymm 
{nn 
thisqq 
.qq #
gameFollowDomainServiceqq ,
.qq, -
Removeqq- 3
(qq3 4
idqq4 6
)qq6 7
;qq7 8

unitOfWorkss 
.ss 
Commitss !
(ss! "
)ss" #
;ss# $
resultuu 
=uu 
newuu 
OperationResultVouu .
(uu. /
trueuu/ 3
)uu3 4
;uu4 5
}vv 
catchww 
(ww 
	Exceptionww 
exww 
)ww  
{xx 
resultyy 
=yy 
newyy 
OperationResultVoyy .
(yy. /
exyy/ 1
.yy1 2
Messageyy2 9
)yy9 :
;yy: ;
}zz 
return|| 
result|| 
;|| 
}}} 	
public 
OperationResultVo  
<  !
Guid! %
>% &
Save' +
(+ ,
GameFollowViewModel, ?
	viewModel@ I
)I J
{
ÄÄ 	
OperationResultVo
ÅÅ 
<
ÅÅ 
Guid
ÅÅ "
>
ÅÅ" #
result
ÅÅ$ *
;
ÅÅ* +
try
ÉÉ 
{
ÑÑ 

GameFollow
ÖÖ 
model
ÖÖ  
;
ÖÖ  !

GameFollow
ââ 
existing
ââ #
=
ââ$ %
this
ââ& *
.
ââ* +%
gameFollowDomainService
ââ+ B
.
ââB C
GetById
ââC J
(
ââJ K
	viewModel
ââK T
.
ââT U
Id
ââU W
)
ââW X
;
ââX Y
if
ää 
(
ää 
existing
ää 
!=
ää 
null
ää  $
)
ää$ %
{
ãã 
model
åå 
=
åå 
mapper
åå "
.
åå" #
Map
åå# &
(
åå& '
	viewModel
åå' 0
,
åå0 1
existing
åå2 :
)
åå: ;
;
åå; <
}
çç 
else
éé 
{
èè 
model
êê 
=
êê 
mapper
êê "
.
êê" #
Map
êê# &
<
êê& '

GameFollow
êê' 1
>
êê1 2
(
êê2 3
	viewModel
êê3 <
)
êê< =
;
êê= >
}
ëë 
if
ìì 
(
ìì 
	viewModel
ìì 
.
ìì 
Id
ìì  
==
ìì! #
Guid
ìì$ (
.
ìì( )
Empty
ìì) .
)
ìì. /
{
îî 
this
ïï 
.
ïï %
gameFollowDomainService
ïï 0
.
ïï0 1
Add
ïï1 4
(
ïï4 5
model
ïï5 :
)
ïï: ;
;
ïï; <
	viewModel
ññ 
.
ññ 
Id
ññ  
=
ññ! "
model
ññ# (
.
ññ( )
Id
ññ) +
;
ññ+ ,
}
óó 
else
òò 
{
ôô 
this
öö 
.
öö %
gameFollowDomainService
öö 0
.
öö0 1
Update
öö1 7
(
öö7 8
model
öö8 =
)
öö= >
;
öö> ?
}
õõ 

unitOfWork
ùù 
.
ùù 
Commit
ùù !
(
ùù! "
)
ùù" #
;
ùù# $
result
üü 
=
üü 
new
üü 
OperationResultVo
üü .
<
üü. /
Guid
üü/ 3
>
üü3 4
(
üü4 5
model
üü5 :
.
üü: ;
Id
üü; =
)
üü= >
;
üü> ?
}
†† 
catch
°° 
(
°° 
	Exception
°° 
ex
°° 
)
°°  
{
¢¢ 
result
££ 
=
££ 
new
££ 
OperationResultVo
££ .
<
££. /
Guid
££/ 3
>
££3 4
(
££4 5
ex
££5 7
.
££7 8
Message
££8 ?
)
££? @
;
££@ A
}
§§ 
return
¶¶ 
result
¶¶ 
;
¶¶ 
}
ßß 	
}
®® 
}©© ¡,
pC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\ImageStorageService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{		 
public

 

class

 
ImageStorageService

 $
:

% & 
IImageStorageService

' ;
{ 
private 
readonly 
IConfiguration '
_config( /
;/ 0
private 
CloudStorageAccount #
storageAccount$ 2
;2 3
private 
CloudBlobContainer "
cloudBlobContainer# 5
;5 6
public 
ImageStorageService "
(" #
IConfiguration# 1
config2 8
)8 9
{ 	
_config 
= 
config 
; 
} 	
public 
async 
Task 
< 
string  
>  !
StoreImageAsync" 1
(1 2
string2 8
	container9 B
,B C
stringD J
filenameK S
,S T
byteU Y
[Y Z
]Z [
image\ a
)a b
{ 	
string 
filenameonly 
=  !
Path" &
.& '
GetFileName' 2
(2 3
filename3 ;
); <
;< =
string #
storageConnectionString *
=+ ,
_config- 4
[4 5
$str5 O
]O P
;P Q
if 
( 
CloudStorageAccount #
.# $
TryParse$ ,
(, -#
storageConnectionString- D
,D E
outF I
storageAccountJ X
)X Y
)Y Z
{ 
CloudBlobClient 
cloudBlobClient  /
=0 1
storageAccount2 @
.@ A!
CreateCloudBlobClientA V
(V W
)W X
;X Y
cloudBlobContainer!! "
=!!# $
cloudBlobClient!!% 4
.!!4 5!
GetContainerReference!!5 J
(!!J K
	container!!K T
)!!T U
;!!U V
bool"" 
created"" 
="" 
await"" $
cloudBlobContainer""% 7
.""7 8"
CreateIfNotExistsAsync""8 N
(""N O
)""O P
;""P Q
if## 
(## 
created## 
)## 
{$$ $
BlobContainerPermissions&& ,
permissions&&- 8
=&&9 :
new&&; >$
BlobContainerPermissions&&? W
{'' 
PublicAccess(( $
=((% &)
BlobContainerPublicAccessType((' D
.((D E
Blob((E I
})) 
;)) 
await++ 
cloudBlobContainer++ ,
.++, -
SetPermissionsAsync++- @
(++@ A
permissions++A L
)++L M
;++M N
},, 
CloudBlockBlob// 
cloudBlockBlob// -
=//. /
cloudBlobContainer//0 B
.//B C!
GetBlockBlobReference//C X
(//X Y
filename//Y a
)//a b
;//b c
if00 
(00 
image00 
!=00 
null00 !
)00! "
{11 
await22 
cloudBlockBlob22 (
.22( )$
UploadFromByteArrayAsync22) A
(22A B
image22B G
,22G H
$num22I J
,22J K
image22L Q
.22Q R
Length22R X
)22X Y
;22Y Z
}33 
}44 
return66 
filename66 
;66 
}77 	
public:: 
async:: 
Task:: 
<:: 
string::  
>::  !
DeleteImageAsync::" 2
(::2 3
string::3 9
	container::: C
,::C D
string::E K
filename::L T
)::T U
{;; 	
if== 
(== 
!== 
string== 
.== 
IsNullOrWhiteSpace== *
(==* +
filename==+ 3
)==3 4
)==4 5
{>> 
string?? 
filenameonly?? #
=??$ %
Path??& *
.??* +
GetFileName??+ 6
(??6 7
filename??7 ?
)??? @
;??@ A
stringAA #
storageConnectionStringAA .
=AA/ 0
_configAA1 8
[AA8 9
$strAA9 S
]AAS T
;AAT U
ifCC 
(CC 
CloudStorageAccountCC '
.CC' (
TryParseCC( 0
(CC0 1#
storageConnectionStringCC1 H
,CCH I
outCCJ M
storageAccountCCN \
)CC\ ]
)CC] ^
{DD 
CloudBlobClientFF #
cloudBlobClientFF$ 3
=FF4 5
storageAccountFF6 D
.FFD E!
CreateCloudBlobClientFFE Z
(FFZ [
)FF[ \
;FF\ ]
cloudBlobContainerHH &
=HH' (
cloudBlobClientHH) 8
.HH8 9!
GetContainerReferenceHH9 N
(HHN O
	containerHHO X
)HHX Y
;HHY Z
CloudBlockBlobKK "
cloudBlockBlobKK# 1
=KK2 3
cloudBlobContainerKK4 F
.KKF G!
GetBlockBlobReferenceKKG \
(KK\ ]
filenameKK] e
)KKe f
;KKf g
awaitMM 
cloudBlockBlobMM (
.MM( )
DeleteIfExistsAsyncMM) <
(MM< =
)MM= >
;MM> ?
}NN 
}OO 
returnQQ 
filenameQQ 
;QQ 
}RR 	
}SS 
}TT ±∞
kC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\LikeAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class 
LikeAppService 
:  !
BaseAppService" 0
,0 1
ILikeAppService2 A
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly &
IUserContentLikeRepository 3"
_contentLikeRepository4 J
;J K
private 
readonly 
IGameLikeRepository ,
_gameLikeRepository- @
;@ A
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
LikeAppService 
( 
IMapper %
mapper& ,
,, -
IUnitOfWork. 9

unitOfWork: D
, &
IUserContentLikeRepository (!
contentLikeRepository) >
,> ?
IGameLikeRepository@ S
gameLikeRepositoryT f
)f g
{ 	
_mapper 
= 
mapper 
; 
_unitOfWork 
= 

unitOfWork $
;$ %"
_contentLikeRepository "
=# $!
contentLikeRepository% :
;: ;
_gameLikeRepository 
=  !
gameLikeRepository" 4
;4 5
} 	
public   
OperationResultVo    
<    !
int  ! $
>  $ %
Count  & +
(  + ,
)  , -
{!! 	
OperationResultVo"" 
<"" 
int"" !
>""! "
result""# )
;"") *
try$$ 
{%% 
int&& 
count&& 
=&& "
_contentLikeRepository&& 2
.&&2 3
GetAll&&3 9
(&&9 :
)&&: ;
.&&; <
Count&&< A
(&&A B
)&&B C
;&&C D
result(( 
=(( 
new(( 
OperationResultVo(( .
<((. /
int((/ 2
>((2 3
(((3 4
count((4 9
)((9 :
;((: ;
})) 
catch** 
(** 
	Exception** 
ex** 
)**  
{++ 
result,, 
=,, 
new,, 
OperationResultVo,, .
<,,. /
int,,/ 2
>,,2 3
(,,3 4
ex,,4 6
.,,6 7
Message,,7 >
),,> ?
;,,? @
}-- 
return// 
result// 
;// 
}00 	
public22 !
OperationResultListVo22 $
<22$ %
UserLikeViewModel22% 6
>226 7
GetAll228 >
(22> ?
)22? @
{33 	!
OperationResultListVo44 !
<44! "
UserLikeViewModel44" 3
>443 4
result445 ;
;44; <
try66 
{77 

IQueryable88 
<88 
UserContentLike88 *
>88* +
	allModels88, 5
=886 7"
_contentLikeRepository888 N
.88N O
GetAll88O U
(88U V
)88V W
;88W X
IEnumerable:: 
<:: 
UserLikeViewModel:: -
>::- .
vms::/ 2
=::3 4
_mapper::5 <
.::< =
Map::= @
<::@ A
IEnumerable::A L
<::L M
UserContentLike::M \
>::\ ]
,::] ^
IEnumerable::_ j
<::j k
UserLikeViewModel::k |
>::| }
>::} ~
(::~ 
	allModels	:: à
)
::à â
;
::â ä
result<< 
=<< 
new<< !
OperationResultListVo<< 2
<<<2 3
UserLikeViewModel<<3 D
><<D E
(<<E F
vms<<F I
)<<I J
;<<J K
}== 
catch>> 
(>> 
	Exception>> 
ex>> 
)>>  
{?? 
result@@ 
=@@ 
new@@ !
OperationResultListVo@@ 2
<@@2 3
UserLikeViewModel@@3 D
>@@D E
(@@E F
ex@@F H
.@@H I
Message@@I P
)@@P Q
;@@Q R
}AA 
returnCC 
resultCC 
;CC 
}DD 	
publicFF 
OperationResultVoFF  
<FF  !
UserLikeViewModelFF! 2
>FF2 3
GetByIdFF4 ;
(FF; <
GuidFF< @
idFFA C
)FFC D
{GG 	
OperationResultVoHH 
<HH 
UserLikeViewModelHH /
>HH/ 0
resultHH1 7
;HH7 8
tryJJ 
{KK 
UserContentLikeLL 
modelLL  %
=LL& '"
_contentLikeRepositoryLL( >
.LL> ?
GetByIdLL? F
(LLF G
idLLG I
)LLI J
;LLJ K
UserLikeViewModelNN !
vmNN" $
=NN% &
_mapperNN' .
.NN. /
MapNN/ 2
<NN2 3
UserLikeViewModelNN3 D
>NND E
(NNE F
modelNNF K
)NNK L
;NNL M
resultPP 
=PP 
newPP 
OperationResultVoPP .
<PP. /
UserLikeViewModelPP/ @
>PP@ A
(PPA B
vmPPB D
)PPD E
;PPE F
}QQ 
catchRR 
(RR 
	ExceptionRR 
exRR 
)RR  
{SS 
resultTT 
=TT 
newTT 
OperationResultVoTT .
<TT. /
UserLikeViewModelTT/ @
>TT@ A
(TTA B
exTTB D
.TTD E
MessageTTE L
)TTL M
;TTM N
}UU 
returnWW 
resultWW 
;WW 
}XX 	
publicZZ 
OperationResultVoZZ  
RemoveZZ! '
(ZZ' (
GuidZZ( ,
idZZ- /
)ZZ/ 0
{[[ 	
OperationResultVo\\ 
result\\ $
;\\$ %
try^^ 
{__ "
_contentLikeRepositorybb &
.bb& '
Removebb' -
(bb- .
idbb. 0
)bb0 1
;bb1 2
_unitOfWorkdd 
.dd 
Commitdd "
(dd" #
)dd# $
;dd$ %
resultff 
=ff 
newff 
OperationResultVoff .
(ff. /
trueff/ 3
)ff3 4
;ff4 5
}gg 
catchhh 
(hh 
	Exceptionhh 
exhh 
)hh  
{ii 
resultjj 
=jj 
newjj 
OperationResultVojj .
(jj. /
exjj/ 1
.jj1 2
Messagejj2 9
)jj9 :
;jj: ;
}kk 
returnmm 
resultmm 
;mm 
}nn 	
publicpp 
OperationResultVopp  
<pp  !
Guidpp! %
>pp% &
Savepp' +
(pp+ ,
UserLikeViewModelpp, =
	viewModelpp> G
)ppG H
{qq 	
OperationResultVorr 
<rr 
Guidrr "
>rr" #
resultrr$ *
;rr* +
trytt 
{uu 
UserContentLikevv 
modelvv  %
;vv% &
UserContentLikezz 
existingzz  (
=zz) *"
_contentLikeRepositoryzz+ A
.zzA B
GetByIdzzB I
(zzI J
	viewModelzzJ S
.zzS T
IdzzT V
)zzV W
;zzW X
if{{ 
({{ 
existing{{ 
!={{ 
null{{  $
){{$ %
{|| 
model}} 
=}} 
_mapper}} #
.}}# $
Map}}$ '
(}}' (
	viewModel}}( 1
,}}1 2
existing}}3 ;
)}}; <
;}}< =
}~~ 
else 
{
ÄÄ 
model
ÅÅ 
=
ÅÅ 
_mapper
ÅÅ #
.
ÅÅ# $
Map
ÅÅ$ '
<
ÅÅ' (
UserContentLike
ÅÅ( 7
>
ÅÅ7 8
(
ÅÅ8 9
	viewModel
ÅÅ9 B
)
ÅÅB C
;
ÅÅC D
}
ÇÇ 
if
ÑÑ 
(
ÑÑ 
	viewModel
ÑÑ 
.
ÑÑ 
Id
ÑÑ  
==
ÑÑ! #
Guid
ÑÑ$ (
.
ÑÑ( )
Empty
ÑÑ) .
)
ÑÑ. /
{
ÖÖ $
_contentLikeRepository
ÜÜ *
.
ÜÜ* +
Add
ÜÜ+ .
(
ÜÜ. /
model
ÜÜ/ 4
)
ÜÜ4 5
;
ÜÜ5 6
	viewModel
áá 
.
áá 
Id
áá  
=
áá! "
model
áá# (
.
áá( )
Id
áá) +
;
áá+ ,
}
àà 
else
ââ 
{
ää $
_contentLikeRepository
ãã *
.
ãã* +
Update
ãã+ 1
(
ãã1 2
model
ãã2 7
)
ãã7 8
;
ãã8 9
}
åå 
_unitOfWork
éé 
.
éé 
Commit
éé "
(
éé" #
)
éé# $
;
éé$ %
result
êê 
=
êê 
new
êê 
OperationResultVo
êê .
<
êê. /
Guid
êê/ 3
>
êê3 4
(
êê4 5
model
êê5 :
.
êê: ;
Id
êê; =
)
êê= >
;
êê> ?
}
ëë 
catch
íí 
(
íí 
	Exception
íí 
ex
íí 
)
íí  
{
ìì 
result
îî 
=
îî 
new
îî 
OperationResultVo
îî .
<
îî. /
Guid
îî/ 3
>
îî3 4
(
îî4 5
ex
îî5 7
.
îî7 8
Message
îî8 ?
)
îî? @
;
îî@ A
}
ïï 
return
óó 
result
óó 
;
óó 
}
òò 	
public
öö 
OperationResultVo
öö  
ContentLike
öö! ,
(
öö, -
Guid
öö- 1
likedId
öö2 9
)
öö9 :
{
õõ 	
OperationResultVo
úú 
response
úú &
;
úú& '
bool
ûû 
alreadyLiked
ûû 
=
ûû $
_contentLikeRepository
ûû  6
.
ûû6 7
GetAll
ûû7 =
(
ûû= >
)
ûû> ?
.
ûû? @
Any
ûû@ C
(
ûûC D
x
ûûD E
=>
ûûF H
x
ûûI J
.
ûûJ K
	ContentId
ûûK T
==
ûûU W
likedId
ûûX _
&&
ûû` b
x
ûûc d
.
ûûd e
UserId
ûûe k
==
ûûl n
this
ûûo s
.
ûûs t
CurrentUserIdûût Å
)ûûÅ Ç
;ûûÇ É
if
†† 
(
†† 
alreadyLiked
†† 
)
†† 
{
°° 
response
¢¢ 
=
¢¢ 
new
¢¢ 
OperationResultVo
¢¢ 0
(
¢¢0 1
false
¢¢1 6
)
¢¢6 7
;
¢¢7 8
response
££ 
.
££ 
Message
££  
=
££! "
$str
££# :
;
££: ;
}
§§ 
else
•• 
{
¶¶ 
UserContentLike
ßß 
model
ßß  %
=
ßß& '
new
ßß( +
UserContentLike
ßß, ;
(
ßß; <
)
ßß< =
;
ßß= >
model
©© 
.
©© 
	ContentId
©© 
=
©©  !
likedId
©©" )
;
©©) *
model
™™ 
.
™™ 
UserId
™™ 
=
™™ 
this
™™ #
.
™™# $
CurrentUserId
™™$ 1
;
™™1 2$
_contentLikeRepository
¨¨ &
.
¨¨& '
Add
¨¨' *
(
¨¨* +
model
¨¨+ 0
)
¨¨0 1
;
¨¨1 2
_unitOfWork
ÆÆ 
.
ÆÆ 
Commit
ÆÆ "
(
ÆÆ" #
)
ÆÆ# $
;
ÆÆ$ %
int
∞∞ 
newCount
∞∞ 
=
∞∞ $
_contentLikeRepository
∞∞ 5
.
∞∞5 6
GetAll
∞∞6 <
(
∞∞< =
)
∞∞= >
.
∞∞> ?
Count
∞∞? D
(
∞∞D E
x
∞∞E F
=>
∞∞G I
x
∞∞J K
.
∞∞K L
	ContentId
∞∞L U
==
∞∞V X
likedId
∞∞Y `
&&
∞∞a c
x
∞∞d e
.
∞∞e f
UserId
∞∞f l
==
∞∞m o
this
∞∞p t
.
∞∞t u
CurrentUserId∞∞u Ç
)∞∞Ç É
;∞∞É Ñ
response
≤≤ 
=
≤≤ 
new
≤≤ 
OperationResultVo
≤≤ 0
<
≤≤0 1
int
≤≤1 4
>
≤≤4 5
(
≤≤5 6
newCount
≤≤6 >
)
≤≤> ?
;
≤≤? @
}
≥≥ 
return
µµ 
response
µµ 
;
µµ 
}
∂∂ 	
public
∏∏ 
OperationResultVo
∏∏  
ContentUnlike
∏∏! .
(
∏∏. /
Guid
∏∏/ 3
likedId
∏∏4 ;
)
∏∏; <
{
ππ 	
OperationResultVo
∫∫ 
response
∫∫ &
;
∫∫& '
UserContentLike
ºº 
existingLike
ºº (
=
ºº) *$
_contentLikeRepository
ºº+ A
.
ººA B
GetAll
ººB H
(
ººH I
)
ººI J
.
ººJ K
FirstOrDefault
ººK Y
(
ººY Z
x
ººZ [
=>
ºº\ ^
x
ºº_ `
.
ºº` a
	ContentId
ººa j
==
ººk m
likedId
ººn u
&&
ººv x
x
ººy z
.
ººz {
UserIdºº{ Å
==ººÇ Ñ
thisººÖ â
.ººâ ä
CurrentUserIdººä ó
)ººó ò
;ººò ô
if
ææ 
(
ææ 
existingLike
ææ 
==
ææ 
null
ææ  $
)
ææ$ %
{
øø 
response
¿¿ 
=
¿¿ 
new
¿¿ 
OperationResultVo
¿¿ 0
(
¿¿0 1
false
¿¿1 6
)
¿¿6 7
;
¿¿7 8
response
¡¡ 
.
¡¡ 
Message
¡¡  
=
¡¡! "
$str
¡¡# 6
;
¡¡6 7
}
¬¬ 
else
√√ 
{
ƒƒ 
this
≈≈ 
.
≈≈ 
Remove
≈≈ 
(
≈≈ 
existingLike
≈≈ (
.
≈≈( )
Id
≈≈) +
)
≈≈+ ,
;
≈≈, -
_unitOfWork
«« 
.
«« 
Commit
«« "
(
««" #
)
««# $
;
««$ %
int
…… 
newCount
…… 
=
…… $
_contentLikeRepository
…… 5
.
……5 6
GetAll
……6 <
(
……< =
)
……= >
.
……> ?
Count
……? D
(
……D E
x
……E F
=>
……G I
x
……J K
.
……K L
	ContentId
……L U
==
……V X
likedId
……Y `
&&
……a c
x
……d e
.
……e f
UserId
……f l
==
……m o
this
……p t
.
……t u
CurrentUserId……u Ç
)……Ç É
;……É Ñ
response
ÀÀ 
=
ÀÀ 
new
ÀÀ 
OperationResultVo
ÀÀ 0
<
ÀÀ0 1
int
ÀÀ1 4
>
ÀÀ4 5
(
ÀÀ5 6
newCount
ÀÀ6 >
)
ÀÀ> ?
;
ÀÀ? @
}
ÃÃ 
return
ŒŒ 
response
ŒŒ 
;
ŒŒ 
}
œœ 	
public
—— 
OperationResultVo
——  
GameLike
——! )
(
——) *
Guid
——* .
likedId
——/ 6
)
——6 7
{
““ 	
OperationResultVo
”” 
response
”” &
;
””& '
if
’’ 
(
’’ 
this
’’ 
.
’’ 
CurrentUserId
’’ "
==
’’# %
Guid
’’& *
.
’’* +
Empty
’’+ 0
)
’’0 1
{
÷÷ 
response
◊◊ 
=
◊◊ 
new
◊◊ 
OperationResultVo
◊◊ 0
(
◊◊0 1
$str
◊◊1 W
)
◊◊W X
;
◊◊X Y
}
ÿÿ 
else
ŸŸ 
{
⁄⁄ 
bool
€€ 
alreadyLiked
€€ !
=
€€" #!
_gameLikeRepository
€€$ 7
.
€€7 8
GetAll
€€8 >
(
€€> ?
)
€€? @
.
€€@ A
Any
€€A D
(
€€D E
x
€€E F
=>
€€G I
x
€€J K
.
€€K L
GameId
€€L R
==
€€S U
likedId
€€V ]
&&
€€^ `
x
€€a b
.
€€b c
UserId
€€c i
==
€€j l
this
€€m q
.
€€q r
CurrentUserId
€€r 
)€€ Ä
;€€Ä Å
if
›› 
(
›› 
alreadyLiked
››  
)
››  !
{
ﬁﬁ 
response
ﬂﬂ 
=
ﬂﬂ 
new
ﬂﬂ "
OperationResultVo
ﬂﬂ# 4
(
ﬂﬂ4 5
false
ﬂﬂ5 :
)
ﬂﬂ: ;
;
ﬂﬂ; <
response
‡‡ 
.
‡‡ 
Message
‡‡ $
=
‡‡% &
$str
‡‡' ;
;
‡‡; <
}
·· 
else
‚‚ 
{
„„ 
GameLike
‰‰ 
model
‰‰ "
=
‰‰# $
new
‰‰% (
GameLike
‰‰) 1
(
‰‰1 2
)
‰‰2 3
;
‰‰3 4
model
ÊÊ 
.
ÊÊ 
GameId
ÊÊ  
=
ÊÊ! "
likedId
ÊÊ# *
;
ÊÊ* +
model
ÁÁ 
.
ÁÁ 
UserId
ÁÁ  
=
ÁÁ! "
this
ÁÁ# '
.
ÁÁ' (
CurrentUserId
ÁÁ( 5
;
ÁÁ5 6!
_gameLikeRepository
ÈÈ '
.
ÈÈ' (
Add
ÈÈ( +
(
ÈÈ+ ,
model
ÈÈ, 1
)
ÈÈ1 2
;
ÈÈ2 3
_unitOfWork
ÎÎ 
.
ÎÎ  
Commit
ÎÎ  &
(
ÎÎ& '
)
ÎÎ' (
;
ÎÎ( )
int
ÌÌ 
newCount
ÌÌ  
=
ÌÌ! "!
_gameLikeRepository
ÌÌ# 6
.
ÌÌ6 7
GetAll
ÌÌ7 =
(
ÌÌ= >
)
ÌÌ> ?
.
ÌÌ? @
Count
ÌÌ@ E
(
ÌÌE F
x
ÌÌF G
=>
ÌÌH J
x
ÌÌK L
.
ÌÌL M
GameId
ÌÌM S
==
ÌÌT V
likedId
ÌÌW ^
&&
ÌÌ_ a
x
ÌÌb c
.
ÌÌc d
UserId
ÌÌd j
==
ÌÌk m
this
ÌÌn r
.
ÌÌr s
CurrentUserIdÌÌs Ä
)ÌÌÄ Å
;ÌÌÅ Ç
response
ÔÔ 
=
ÔÔ 
new
ÔÔ "
OperationResultVo
ÔÔ# 4
<
ÔÔ4 5
int
ÔÔ5 8
>
ÔÔ8 9
(
ÔÔ9 :
newCount
ÔÔ: B
)
ÔÔB C
;
ÔÔC D
}
 
}
ÒÒ 
return
ÛÛ 
response
ÛÛ 
;
ÛÛ 
}
ÙÙ 	
public
ˆˆ 
OperationResultVo
ˆˆ  

GameUnlike
ˆˆ! +
(
ˆˆ+ ,
Guid
ˆˆ, 0
likedId
ˆˆ1 8
)
ˆˆ8 9
{
˜˜ 	
OperationResultVo
¯¯ 
response
¯¯ &
;
¯¯& '
if
˙˙ 
(
˙˙ 
this
˙˙ 
.
˙˙ 
CurrentUserId
˙˙ "
==
˙˙# %
Guid
˙˙& *
.
˙˙* +
Empty
˙˙+ 0
)
˙˙0 1
{
˚˚ 
response
¸¸ 
=
¸¸ 
new
¸¸ 
OperationResultVo
¸¸ 0
(
¸¸0 1
$str
¸¸1 Y
)
¸¸Y Z
;
¸¸Z [
}
˝˝ 
else
˛˛ 
{
ˇˇ 
GameLike
ÅÅ 
existingLike
ÅÅ %
=
ÅÅ& '!
_gameLikeRepository
ÅÅ( ;
.
ÅÅ; <
GetAll
ÅÅ< B
(
ÅÅB C
)
ÅÅC D
.
ÅÅD E
FirstOrDefault
ÅÅE S
(
ÅÅS T
x
ÅÅT U
=>
ÅÅV X
x
ÅÅY Z
.
ÅÅZ [
GameId
ÅÅ[ a
==
ÅÅb d
likedId
ÅÅe l
&&
ÅÅm o
x
ÅÅp q
.
ÅÅq r
UserId
ÅÅr x
==
ÅÅy {
thisÅÅ| Ä
.ÅÅÄ Å
CurrentUserIdÅÅÅ é
)ÅÅé è
;ÅÅè ê
if
ÉÉ 
(
ÉÉ 
existingLike
ÉÉ  
==
ÉÉ! #
null
ÉÉ$ (
)
ÉÉ( )
{
ÑÑ 
response
ÖÖ 
=
ÖÖ 
new
ÖÖ "
OperationResultVo
ÖÖ# 4
(
ÖÖ4 5
false
ÖÖ5 :
)
ÖÖ: ;
;
ÖÖ; <
response
ÜÜ 
.
ÜÜ 
Message
ÜÜ $
=
ÜÜ% &
$str
ÜÜ' 7
;
ÜÜ7 8
}
áá 
else
àà 
{
ââ 
this
ää 
.
ää 
RemoveGameLike
ää '
(
ää' (
existingLike
ää( 4
.
ää4 5
Id
ää5 7
)
ää7 8
;
ää8 9
_unitOfWork
åå 
.
åå  
Commit
åå  &
(
åå& '
)
åå' (
;
åå( )
int
éé 
newCount
éé  
=
éé! "!
_gameLikeRepository
éé# 6
.
éé6 7
GetAll
éé7 =
(
éé= >
)
éé> ?
.
éé? @
Count
éé@ E
(
ééE F
x
ééF G
=>
ééH J
x
ééK L
.
ééL M
GameId
ééM S
==
ééT V
likedId
ééW ^
&&
éé_ a
x
ééb c
.
ééc d
UserId
ééd j
==
éék m
this
één r
.
éér s
CurrentUserIdéés Ä
)ééÄ Å
;ééÅ Ç
response
êê 
=
êê 
new
êê "
OperationResultVo
êê# 4
<
êê4 5
int
êê5 8
>
êê8 9
(
êê9 :
newCount
êê: B
)
êêB C
;
êêC D
}
ëë 
}
íí 
return
îî 
response
îî 
;
îî 
}
ïï 	
private
óó 
OperationResultVo
óó !
RemoveGameLike
óó" 0
(
óó0 1
Guid
óó1 5
id
óó6 8
)
óó8 9
{
òò 	
OperationResultVo
ôô 
result
ôô $
;
ôô$ %
try
õõ 
{
úú !
_gameLikeRepository
üü #
.
üü# $
Remove
üü$ *
(
üü* +
id
üü+ -
)
üü- .
;
üü. /
_unitOfWork
°° 
.
°° 
Commit
°° "
(
°°" #
)
°°# $
;
°°$ %
result
££ 
=
££ 
new
££ 
OperationResultVo
££ .
(
££. /
true
££/ 3
)
££3 4
;
££4 5
}
§§ 
catch
•• 
(
•• 
	Exception
•• 
ex
•• 
)
••  
{
¶¶ 
result
ßß 
=
ßß 
new
ßß 
OperationResultVo
ßß .
(
ßß. /
ex
ßß/ 1
.
ßß1 2
Message
ßß2 9
)
ßß9 :
;
ßß: ;
}
®® 
return
™™ 
result
™™ 
;
™™ 
}
´´ 	
}
¨¨ 
}≠≠ ©i
sC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\NotificationAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class "
NotificationAppService '
:( )
BaseAppService* 8
,8 9#
INotificationAppService: Q
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly #
INotificationRepository 0#
_notificationRepository1 H
;H I
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public "
NotificationAppService %
(% &
IMapper& -
mapper. 4
,4 5
IUnitOfWork6 A

unitOfWorkB L
,L M#
INotificationRepositoryN e"
notificationRepositoryf |
)| }
{ 	
_mapper 
= 
mapper 
; 
_unitOfWork 
= 

unitOfWork $
;$ %#
_notificationRepository #
=$ %"
notificationRepository& <
;< =
} 	
public 
OperationResultVo  
<  !
int! $
>$ %
Count& +
(+ ,
), -
{   	
OperationResultVo!! 
<!! 
int!! !
>!!! "
result!!# )
=!!* +
new!!, /
OperationResultVo!!0 A
<!!A B
int!!B E
>!!E F
(!!F G
string!!G M
.!!M N
Empty!!N S
)!!S T
;!!T U
return## 
result## 
;## 
}$$ 	
public&& !
OperationResultListVo&& $
<&&$ %%
NotificationItemViewModel&&% >
>&&> ?
GetAll&&@ F
(&&F G
)&&G H
{'' 	!
OperationResultListVo(( !
<((! "%
NotificationItemViewModel((" ;
>((; <
result((= C
=((D E
new((F I!
OperationResultListVo((J _
<((_ `%
NotificationItemViewModel((` y
>((y z
(((z {
string	(({ Å
.
((Å Ç
Empty
((Ç á
)
((á à
;
((à â
return++ 
result++ 
;++ 
},, 	
public.. !
OperationResultListVo.. $
<..$ %%
NotificationItemViewModel..% >
>..> ?
GetById..@ G
(..G H
Guid..H L
id..M O
)..O P
{// 	!
OperationResultListVo00 !
<00! "%
NotificationItemViewModel00" ;
>00; <
result00= C
=00D E
new00F I!
OperationResultListVo00J _
<00_ `%
NotificationItemViewModel00` y
>00y z
(00z {
string	00{ Å
.
00Å Ç
Empty
00Ç á
)
00á à
;
00à â
return22 
result22 
;22 
}33 	
public55 !
OperationResultListVo55 $
<55$ %%
NotificationItemViewModel55% >
>55> ?
GetByUserId55@ K
(55K L
Guid55L P
userId55Q W
,55W X
int55Y \
count55] b
)55b c
{66 	!
OperationResultListVo77 !
<77! "%
NotificationItemViewModel77" ;
>77; <
result77= C
;77C D
List99 
<99 
Notification99 
>99 
notifications99 ,
=99- .#
_notificationRepository99/ F
.99F G
Get99G J
(99J K
x99K L
=>99M O
x99P Q
.99Q R
UserId99R X
==99Y [
userId99\ b
)99b c
.99c d
OrderByDescending99d u
(99u v
x99v w
=>99x z
x99{ |
.99| }

CreateDate	99} á
)
99á à
.
99à â
Take
99â ç
(
99ç é
count
99é ì
)
99ì î
.
99î ï
ToList
99ï õ
(
99õ ú
)
99ú ù
;
99ù û
List;; 
<;; %
NotificationItemViewModel;; *
>;;* +
tempList;;, 4
=;;5 6
new;;7 :
List;;; ?
<;;? @%
NotificationItemViewModel;;@ Y
>;;Y Z
(;;Z [
);;[ \
;;;\ ]
foreach<< 
(<< 
Notification<< !
notification<<" .
in<</ 1
notifications<<2 ?
)<<? @
{== %
NotificationItemViewModel>> )
vm>>* ,
=>>- .
new>>/ 2%
NotificationItemViewModel>>3 L
{?? 
Id@@ 
=@@ 
notification@@ %
.@@% &
Id@@& (
,@@( )
UserIdAA 
=AA 
notificationAA )
.AA) *
UserIdAA* 0
,AA0 1
TextBB 
=BB 
notificationBB '
.BB' (
TextBB( ,
,BB, -
UrlCC 
=CC 
notificationCC &
.CC& '
UrlCC' *
,CC* +
IsReadDD 
=DD 
notificationDD )
.DD) *
IsReadDD* 0
,DD0 1

CreateDateEE 
=EE  
notificationEE! -
.EE- .

CreateDateEE. 8
,EE8 9
TypeFF 
=FF 
notificationFF '
.FF' (
TypeFF( ,
}GG 
;GG 
tempListII 
.II 
AddII 
(II 
vmII 
)II  
;II  !
}JJ 
resultLL 
=LL 
newLL !
OperationResultListVoLL .
<LL. /%
NotificationItemViewModelLL/ H
>LLH I
(LLI J
tempListLLJ R
)LLR S
;LLS T
returnNN 
resultNN 
;NN 
}OO 	
publicQQ 
OperationResultVoQQ  
RemoveQQ! '
(QQ' (
GuidQQ( ,
idQQ- /
)QQ/ 0
{RR 	
OperationResultVoSS 
resultSS $
=SS% &
newSS' *
OperationResultVoSS+ <
(SS< =
stringSS= C
.SSC D
EmptySSD I
)SSI J
;SSJ K
returnUU 
resultUU 
;UU 
}VV 	
publicXX 
OperationResultVoXX  
<XX  !
GuidXX! %
>XX% &
SaveXX' +
(XX+ ,$
UserPreferencesViewModelXX, D
	viewModelXXE N
)XXN O
{YY 	
OperationResultVoZZ 
<ZZ 
GuidZZ "
>ZZ" #
resultZZ$ *
=ZZ+ ,
newZZ- 0
OperationResultVoZZ1 B
<ZZB C
GuidZZC G
>ZZG H
(ZZH I
stringZZI O
.ZZO P
EmptyZZP U
)ZZU V
;ZZV W
return\\ 
result\\ 
;\\ 
}]] 	
OperationResultVo__ 
<__ %
NotificationItemViewModel__ 3
>__3 4
ICrudAppService__5 D
<__D E%
NotificationItemViewModel__E ^
>__^ _
.___ `
GetById__` g
(__g h
Guid__h l
id__m o
)__o p
{`` 	
throwaa 
newaa #
NotImplementedExceptionaa -
(aa- .
)aa. /
;aa/ 0
}bb 	
publicdd 
OperationResultVodd  
<dd  !
Guiddd! %
>dd% &
Savedd' +
(dd+ ,%
NotificationItemViewModeldd, E
	viewModelddF O
)ddO P
{ee 	
OperationResultVoff 
<ff 
Guidff "
>ff" #
resultff$ *
;ff* +
tryhh 
{ii 
Notificationjj 
modeljj "
;jj" #
Notificationnn 
existingnn %
=nn& '#
_notificationRepositorynn( ?
.nn? @
GetByIdnn@ G
(nnG H
	viewModelnnH Q
.nnQ R
IdnnR T
)nnT U
;nnU V
ifoo 
(oo 
existingoo 
!=oo 
nulloo  $
)oo$ %
{pp 
modelqq 
=qq 
_mapperqq #
.qq# $
Mapqq$ '
(qq' (
	viewModelqq( 1
,qq1 2
existingqq3 ;
)qq; <
;qq< =
}rr 
elsess 
{tt 
modeluu 
=uu 
_mapperuu #
.uu# $
Mapuu$ '
<uu' (
Notificationuu( 4
>uu4 5
(uu5 6
	viewModeluu6 ?
)uu? @
;uu@ A
}vv 
ifxx 
(xx 
	viewModelxx 
.xx 
Idxx  
==xx! #
Guidxx$ (
.xx( )
Emptyxx) .
)xx. /
{yy #
_notificationRepositoryzz +
.zz+ ,
Addzz, /
(zz/ 0
modelzz0 5
)zz5 6
;zz6 7
	viewModel{{ 
.{{ 
Id{{  
={{! "
model{{# (
.{{( )
Id{{) +
;{{+ ,
}|| 
else}} 
{~~ #
_notificationRepository +
.+ ,
Update, 2
(2 3
model3 8
)8 9
;9 :
}
ÄÄ 
_unitOfWork
ÇÇ 
.
ÇÇ 
Commit
ÇÇ "
(
ÇÇ" #
)
ÇÇ# $
;
ÇÇ$ %
result
ÑÑ 
=
ÑÑ 
new
ÑÑ 
OperationResultVo
ÑÑ .
<
ÑÑ. /
Guid
ÑÑ/ 3
>
ÑÑ3 4
(
ÑÑ4 5
model
ÑÑ5 :
.
ÑÑ: ;
Id
ÑÑ; =
)
ÑÑ= >
;
ÑÑ> ?
}
ÖÖ 
catch
ÜÜ 
(
ÜÜ 
	Exception
ÜÜ 
ex
ÜÜ 
)
ÜÜ  
{
áá 
result
àà 
=
àà 
new
àà 
OperationResultVo
àà .
<
àà. /
Guid
àà/ 3
>
àà3 4
(
àà4 5
ex
àà5 7
.
àà7 8
Message
àà8 ?
)
àà? @
;
àà@ A
}
ââ 
return
ãã 
result
ãã 
;
ãã 
}
åå 	
public
éé 
OperationResultVo
éé  
Notify
éé! '
(
éé' (
Guid
éé( ,
targetUserId
éé- 9
,
éé9 :
NotificationType
éé; K
notificationType
ééL \
,
éé\ ]
Guid
éé^ b
likedId
ééc j
,
ééj k
string
éél r
text
éés w
,
ééw x
string
ééy 
urlééÄ É
)ééÉ Ñ
{
èè 	'
NotificationItemViewModel
êê %
vm
êê& (
=
êê) *
new
êê+ .'
NotificationItemViewModel
êê/ H
(
êêH I
)
êêI J
;
êêJ K
vm
ëë 
.
ëë 
UserId
ëë 
=
ëë 
targetUserId
ëë $
;
ëë$ %
vm
íí 
.
íí 
Text
íí 
=
íí 
text
íí 
;
íí 
vm
ìì 
.
ìì 
Url
ìì 
=
ìì 
url
ìì 
;
ìì 
vm
îî 
.
îî 
Type
îî 
=
îî 
notificationType
îî &
;
îî& '
OperationResultVo
ññ 
<
ññ 
Guid
ññ "
>
ññ" #

saveResult
ññ$ .
=
ññ/ 0
this
ññ1 5
.
ññ5 6
Save
ññ6 :
(
ññ: ;
vm
ññ; =
)
ññ= >
;
ññ> ?
return
òò 

saveResult
òò 
;
òò 
}
ôô 	
public
õõ 
OperationResultVo
õõ  

MarkAsRead
õõ! +
(
õõ+ ,
Guid
õõ, 0
id
õõ1 3
)
õõ3 4
{
úú 	
OperationResultVo
ùù 
result
ùù $
=
ùù% &
new
ùù' *
OperationResultVo
ùù+ <
(
ùù< =
true
ùù= A
)
ùùA B
;
ùùB C
try
üü 
{
†† 
Notification
°° 
notification
°° )
=
°°* +%
_notificationRepository
°°, C
.
°°C D
GetById
°°D K
(
°°K L
id
°°L N
)
°°N O
;
°°O P
if
££ 
(
££ 
notification
££  
!=
££! #
null
££$ (
)
££( )
{
§§ 
notification
••  
.
••  !
IsRead
••! '
=
••( )
true
••* .
;
••. /%
_notificationRepository
¶¶ +
.
¶¶+ ,
Update
¶¶, 2
(
¶¶2 3
notification
¶¶3 ?
)
¶¶? @
;
¶¶@ A
_unitOfWork
®® 
.
®®  
Commit
®®  &
(
®®& '
)
®®' (
;
®®( )
}
©© 
}
™™ 
catch
´´ 
(
´´ 
	Exception
´´ 
ex
´´ 
)
´´  
{
¨¨ 
result
≠≠ 
=
≠≠ 
new
≠≠ 
OperationResultVo
≠≠ .
(
≠≠. /
ex
≠≠/ 1
.
≠≠1 2
Message
≠≠2 9
)
≠≠9 :
;
≠≠: ;
}
ÆÆ 
return
∞∞ 
result
∞∞ 
;
∞∞ 
}
±± 	
}
≤≤ 
}≥≥ é˙
nC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\ProfileAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class 
ProfileAppService "
:# $
BaseAppService% 3
,3 4
IProfileAppService5 G
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly 
IProfileRepository +

repository, 6
;6 7
private 
readonly 
IGameRepository (
gameRepository) 7
;7 8
private 
readonly "
IUserContentRepository /!
userContentRepository0 E
;E F
private 
readonly )
IUserContentCommentRepository 6(
userContentCommentRepository7 S
;S T
private 
readonly (
IBrainstormCommentRepository 5'
brainstormCommentRepository6 Q
;Q R
private 
readonly &
IGamificationDomainService 3%
gamificationDomainService4 M
;M N
private 
readonly $
IUserFollowDomainService 1#
userFollowDomainService2 I
;I J
private 
readonly (
IUserConnectionDomainService 5'
userConnectionDomainService6 Q
;Q R
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public!! 
ProfileAppService!!  
(!!  !
IMapper!!! (
mapper!!) /
,!!/ 0
IUnitOfWork!!1 <

unitOfWork!!= G
,!!G H
IProfileRepository!!I [

repository!!\ f
,!!f g
IGameRepository!!h w
gameRepository	!!x Ü
,
!!Ü á$
IUserContentRepository
!!à û#
userContentRepository
!!ü ¥
,"" )
IUserContentCommentRepository"" +(
userContentCommentRepository"", H
,## (
IBrainstormCommentRepository## *&
brainstormCommentRepositor##+ E
,$$ &
IGamificationDomainService$$ (%
gamificationDomainService$$) B
,%% $
IUserFollowDomainService%% &#
userFollowDomainService%%' >
,&& (
IUserConnectionDomainService&& *'
userConnectionDomainService&&+ F
)&&F G
{'' 	
this(( 
.(( 
mapper(( 
=(( 
mapper((  
;((  !
this)) 
.)) 

unitOfWork)) 
=)) 

unitOfWork)) (
;))( )
this** 
.** 

repository** 
=** 

repository** (
;**( )
this++ 
.++ 
gameRepository++ 
=++  !
gameRepository++" 0
;++0 1
this,, 
.,, !
userContentRepository,, &
=,,' (!
userContentRepository,,) >
;,,> ?
this-- 
.-- (
userContentCommentRepository-- -
=--. /(
userContentCommentRepository--0 L
;--L M
this.. 
... '
brainstormCommentRepository.. ,
=..- .&
brainstormCommentRepositor../ I
;..I J
this// 
.// %
gamificationDomainService// *
=//+ ,%
gamificationDomainService//- F
;//F G
this00 
.00 #
userFollowDomainService00 (
=00) *#
userFollowDomainService00+ B
;00B C
this11 
.11 '
userConnectionDomainService11 ,
=11- .'
userConnectionDomainService11/ J
;11J K
}22 	
public55 
OperationResultVo55  
<55  !
int55! $
>55$ %
Count55& +
(55+ ,
)55, -
{66 	
OperationResultVo77 
<77 
int77 !
>77! "
result77# )
;77) *
try99 
{:: 
int;; 
count;; 
=;; 

repository;; &
.;;& '
GetAll;;' -
(;;- .
);;. /
.;;/ 0
Count;;0 5
(;;5 6
);;6 7
;;;7 8
result== 
=== 
new== 
OperationResultVo== .
<==. /
int==/ 2
>==2 3
(==3 4
count==4 9
)==9 :
;==: ;
}>> 
catch?? 
(?? 
	Exception?? 
ex?? 
)??  
{@@ 
resultAA 
=AA 
newAA 
OperationResultVoAA .
<AA. /
intAA/ 2
>AA2 3
(AA3 4
exAA4 6
.AA6 7
MessageAA7 >
)AA> ?
;AA? @
}BB 
returnDD 
resultDD 
;DD 
}EE 	
publicGG !
OperationResultListVoGG $
<GG$ %
ProfileViewModelGG% 5
>GG5 6
GetAllGG7 =
(GG= >
)GG> ?
{HH 	!
OperationResultListVoII !
<II! "
ProfileViewModelII" 2
>II2 3
resultII4 :
;II: ;
tryKK 
{LL 

IQueryableMM 
<MM 
UserProfileMM &
>MM& '
	allModelsMM( 1
=MM2 3

repositoryMM4 >
.MM> ?
GetAllMM? E
(MME F
)MMF G
;MMG H
IEnumerableOO 
<OO 
ProfileViewModelOO ,
>OO, -
vmsOO. 1
=OO2 3
mapperOO4 :
.OO: ;
MapOO; >
<OO> ?
IEnumerableOO? J
<OOJ K
UserProfileOOK V
>OOV W
,OOW X
IEnumerableOOY d
<OOd e
ProfileViewModelOOe u
>OOu v
>OOv w
(OOw x
	allModels	OOx Å
)
OOÅ Ç
;
OOÇ É
resultQQ 
=QQ 
newQQ !
OperationResultListVoQQ 2
<QQ2 3
ProfileViewModelQQ3 C
>QQC D
(QQD E
vmsQQE H
)QQH I
;QQI J
}RR 
catchSS 
(SS 
	ExceptionSS 
exSS 
)SS  
{TT 
resultUU 
=UU 
newUU !
OperationResultListVoUU 2
<UU2 3
ProfileViewModelUU3 C
>UUC D
(UUD E
exUUE G
.UUG H
MessageUUH O
)UUO P
;UUP Q
}VV 
returnXX 
resultXX 
;XX 
}YY 	
public[[ 
OperationResultVo[[  
<[[  !
ProfileViewModel[[! 1
>[[1 2
GetById[[3 :
([[: ;
Guid[[; ?
id[[@ B
)[[B C
{\\ 	
OperationResultVo]] 
<]] 
ProfileViewModel]] .
>]]. /
result]]0 6
;]]6 7
try__ 
{`` 
UserProfileaa 
modelaa !
=aa" #

repositoryaa$ .
.aa. /
GetByIdaa/ 6
(aa6 7
idaa7 9
)aa9 :
;aa: ;
ProfileViewModelcc  
vmcc! #
=cc$ %
mappercc& ,
.cc, -
Mapcc- 0
<cc0 1
ProfileViewModelcc1 A
>ccA B
(ccB C
modelccC H
)ccH I
;ccI J
resultee 
=ee 
newee 
OperationResultVoee .
<ee. /
ProfileViewModelee/ ?
>ee? @
(ee@ A
vmeeA C
)eeC D
;eeD E
}ff 
catchgg 
(gg 
	Exceptiongg 
exgg 
)gg  
{hh 
resultii 
=ii 
newii 
OperationResultVoii .
<ii. /
ProfileViewModelii/ ?
>ii? @
(ii@ A
exiiA C
.iiC D
MessageiiD K
)iiK L
;iiL M
}jj 
returnll 
resultll 
;ll 
}mm 	
publicoo 
OperationResultVooo  
Removeoo! '
(oo' (
Guidoo( ,
idoo- /
)oo/ 0
{pp 	
OperationResultVoqq 
resultqq $
;qq$ %
tryss 
{tt 

repositoryww 
.ww 
Removeww !
(ww! "
idww" $
)ww$ %
;ww% &

unitOfWorkyy 
.yy 
Commityy !
(yy! "
)yy" #
;yy# $
result{{ 
={{ 
new{{ 
OperationResultVo{{ .
({{. /
true{{/ 3
){{3 4
;{{4 5
}|| 
catch}} 
(}} 
	Exception}} 
ex}} 
)}}  
{~~ 
result 
= 
new 
OperationResultVo .
(. /
ex/ 1
.1 2
Message2 9
)9 :
;: ;
}
ÄÄ 
return
ÇÇ 
result
ÇÇ 
;
ÇÇ 
}
ÉÉ 	
public
ÖÖ 
OperationResultVo
ÖÖ  
<
ÖÖ  !
Guid
ÖÖ! %
>
ÖÖ% &
Save
ÖÖ' +
(
ÖÖ+ ,
ProfileViewModel
ÖÖ, <
	viewModel
ÖÖ= F
)
ÖÖF G
{
ÜÜ 	
OperationResultVo
áá 
<
áá 
Guid
áá "
>
áá" #
result
áá$ *
;
áá* +
try
ââ 
{
ää 
UserProfile
ãã 
model
ãã !
;
ãã! "
	viewModel
çç 
.
çç 
GameJoltUrl
çç %
=
çç& '
	viewModel
çç( 1
.
çç1 2
GameJoltUrl
çç2 =
?
çç= >
.
çç> ?
	TrimStart
çç? H
(
ççH I
$char
ççI L
)
ççL M
;
ççM N
UserProfile
ëë 
existing
ëë $
=
ëë% &

repository
ëë' 1
.
ëë1 2
GetById
ëë2 9
(
ëë9 :
	viewModel
ëë: C
.
ëëC D
Id
ëëD F
)
ëëF G
;
ëëG H
if
íí 
(
íí 
existing
íí 
!=
íí 
null
íí  $
)
íí$ %
{
ìì 
model
îî 
=
îî 
mapper
îî "
.
îî" #
Map
îî# &
(
îî& '
	viewModel
îî' 0
,
îî0 1
existing
îî2 :
)
îî: ;
;
îî; <
}
ïï 
else
ññ 
{
óó 
model
òò 
=
òò 
mapper
òò "
.
òò" #
Map
òò# &
<
òò& '
UserProfile
òò' 2
>
òò2 3
(
òò3 4
	viewModel
òò4 =
)
òò= >
;
òò> ?
}
ôô 
if
õõ 
(
õõ 
model
õõ 
.
õõ 
Type
õõ 
==
õõ !
$num
õõ" #
)
õõ# $
{
úú 
model
ùù 
.
ùù 
Type
ùù 
=
ùù  
ProfileType
ùù! ,
.
ùù, -
Personal
ùù- 5
;
ùù5 6
}
ûû 
if
†† 
(
†† 
	viewModel
†† 
.
†† 
Id
††  
==
††! #
Guid
††$ (
.
††( )
Empty
††) .
)
††. /
{
°° 

repository
¢¢ 
.
¢¢ 
Add
¢¢ "
(
¢¢" #
model
¢¢# (
)
¢¢( )
;
¢¢) *
	viewModel
££ 
.
££ 
Id
££  
=
££! "
model
££# (
.
££( )
Id
££) +
;
££+ ,
}
§§ 
else
•• 
{
¶¶ 

repository
ßß 
.
ßß 
Update
ßß %
(
ßß% &
model
ßß& +
)
ßß+ ,
;
ßß, -
}
®® 

IQueryable
™™ 
<
™™ 
Game
™™ 
>
™™  
games
™™! &
=
™™' (
gameRepository
™™) 7
.
™™7 8
GetAll
™™8 >
(
™™> ?
)
™™? @
.
™™@ A
Where
™™A F
(
™™F G
x
™™G H
=>
™™I K
x
™™L M
.
™™M N
UserId
™™N T
==
™™U W
	viewModel
™™X a
.
™™a b
UserId
™™b h
)
™™h i
;
™™i j
foreach
¨¨ 
(
¨¨ 
Game
¨¨ 
g
¨¨ 
in
¨¨  "
games
¨¨# (
)
¨¨( )
{
≠≠ 
g
ÆÆ 
.
ÆÆ 
DeveloperName
ÆÆ #
=
ÆÆ$ %
	viewModel
ÆÆ& /
.
ÆÆ/ 0
Name
ÆÆ0 4
;
ÆÆ4 5
}
ØØ 

IQueryable
±± 
<
±± 
UserContent
±± &
>
±±& '
posts
±±( -
=
±±. /#
userContentRepository
±±0 E
.
±±E F
GetAll
±±F L
(
±±L M
)
±±M N
.
±±N O
Where
±±O T
(
±±T U
x
±±U V
=>
±±W Y
x
±±Z [
.
±±[ \
UserId
±±\ b
==
±±c e
	viewModel
±±f o
.
±±o p
UserId
±±p v
)
±±v w
;
±±w x
foreach
≥≥ 
(
≥≥ 
UserContent
≥≥ $
p
≥≥% &
in
≥≥' )
posts
≥≥* /
)
≥≥/ 0
{
¥¥ 
p
µµ 
.
µµ 

AuthorName
µµ  
=
µµ! "
	viewModel
µµ# ,
.
µµ, -
Name
µµ- 1
;
µµ1 2
}
∂∂ 

IQueryable
∏∏ 
<
∏∏  
UserContentComment
∏∏ -
>
∏∏- .
comments
∏∏/ 7
=
∏∏8 9*
userContentCommentRepository
∏∏: V
.
∏∏V W
GetAll
∏∏W ]
(
∏∏] ^
)
∏∏^ _
.
∏∏_ `
Where
∏∏` e
(
∏∏e f
x
∏∏f g
=>
∏∏h j
x
∏∏k l
.
∏∏l m
UserId
∏∏m s
==
∏∏t v
	viewModel∏∏w Ä
.∏∏Ä Å
UserId∏∏Å á
)∏∏á à
;∏∏à â
foreach
∫∫ 
(
∫∫  
UserContentComment
∫∫ +
c
∫∫, -
in
∫∫. 0
comments
∫∫1 9
)
∫∫9 :
{
ªª 
c
ºº 
.
ºº 

AuthorName
ºº  
=
ºº! "
	viewModel
ºº# ,
.
ºº, -
Name
ºº- 1
;
ºº1 2
}
ΩΩ 

IQueryable
øø 
<
øø 
BrainstormComment
øø ,
>
øø, - 
brainstormComments
øø. @
=
øøA B)
brainstormCommentRepository
øøC ^
.
øø^ _
GetAll
øø_ e
(
øøe f
)
øøf g
.
øøg h
Where
øøh m
(
øøm n
x
øøn o
=>
øøp r
x
øøs t
.
øøt u
UserId
øøu {
==
øø| ~
	viewModeløø à
.øøà â
UserIdøøâ è
)øøè ê
;øøê ë
foreach
¡¡ 
(
¡¡ 
BrainstormComment
¡¡ *
bc
¡¡+ -
in
¡¡. 0 
brainstormComments
¡¡1 C
)
¡¡C D
{
¬¬ 
bc
√√ 
.
√√ 

AuthorName
√√ !
=
√√" #
	viewModel
√√$ -
.
√√- .
Name
√√. 2
;
√√2 3
}
ƒƒ 

unitOfWork
∆∆ 
.
∆∆ 
Commit
∆∆ !
(
∆∆! "
)
∆∆" #
;
∆∆# $
result
»» 
=
»» 
new
»» 
OperationResultVo
»» .
<
»». /
Guid
»»/ 3
>
»»3 4
(
»»4 5
model
»»5 :
.
»»: ;
Id
»»; =
)
»»= >
;
»»> ?
}
…… 
catch
   
(
   
	Exception
   
ex
   
)
    
{
ÀÀ 
result
ÃÃ 
=
ÃÃ 
new
ÃÃ 
OperationResultVo
ÃÃ .
<
ÃÃ. /
Guid
ÃÃ/ 3
>
ÃÃ3 4
(
ÃÃ4 5
ex
ÃÃ5 7
.
ÃÃ7 8
Message
ÃÃ8 ?
)
ÃÃ? @
;
ÃÃ@ A
}
ÕÕ 
return
œœ 
result
œœ 
;
œœ 
}
–– 	
public
‘‘ 
ProfileViewModel
‘‘ 
GetByUserId
‘‘  +
(
‘‘+ ,
Guid
‘‘, 0
userId
‘‘1 7
,
‘‘7 8
ProfileType
‘‘9 D
type
‘‘E I
)
‘‘I J
{
’’ 	
return
÷÷ 
GetByUserId
÷÷ 
(
÷÷ 
userId
÷÷ %
,
÷÷% &
userId
÷÷' -
,
÷÷- .
type
÷÷/ 3
)
÷÷3 4
;
÷÷4 5
}
◊◊ 	
public
ÿÿ 
ProfileViewModel
ÿÿ 
GetByUserId
ÿÿ  +
(
ÿÿ+ ,
Guid
ÿÿ, 0
currentUserId
ÿÿ1 >
,
ÿÿ> ?
Guid
ÿÿ@ D
userId
ÿÿE K
,
ÿÿK L
ProfileType
ÿÿM X
type
ÿÿY ]
)
ÿÿ] ^
{
ŸŸ 	
ProfileViewModel
⁄⁄ 
vm
⁄⁄ 
=
⁄⁄  !
new
⁄⁄" %
ProfileViewModel
⁄⁄& 6
(
⁄⁄6 7
)
⁄⁄7 8
;
⁄⁄8 9
IEnumerable
‹‹ 
<
‹‹ 
UserProfile
‹‹ #
>
‹‹# $
profiles
‹‹% -
=
‹‹. /

repository
‹‹0 :
.
‹‹: ;
GetByUserId
‹‹; F
(
‹‹F G
userId
‹‹G M
)
‹‹M N
;
‹‹N O
UserProfile
›› 
model
›› 
=
›› 
profiles
››  (
.
››( )
FirstOrDefault
››) 7
(
››7 8
x
››8 9
=>
››: <
x
››= >
.
››> ?
Type
››? C
==
››D F
type
››G K
)
››K L
;
››L M
if
ﬂﬂ 
(
ﬂﬂ 
profiles
ﬂﬂ 
.
ﬂﬂ 
Any
ﬂﬂ 
(
ﬂﬂ 
)
ﬂﬂ 
&&
ﬂﬂ !
model
ﬂﬂ" '
!=
ﬂﬂ( *
null
ﬂﬂ+ /
)
ﬂﬂ/ 0
{
‡‡ 
vm
·· 
=
·· 
mapper
·· 
.
·· 
Map
·· 
(
··  
model
··  %
,
··% &
vm
··' )
)
··) *
;
··* +
}
‚‚ 
else
„„ 
{
‰‰ 
return
ÂÂ 
null
ÂÂ 
;
ÂÂ 
}
ÊÊ 
vm
ËË 
.
ËË 
CoverImageUrl
ËË 
=
ËË 
UrlFormatter
ËË +
.
ËË+ ,
ProfileCoverImage
ËË, =
(
ËË= >
vm
ËË> @
.
ËË@ A
UserId
ËËA G
,
ËËG H
vm
ËËI K
.
ËËK L
Id
ËËL N
)
ËËN O
;
ËËO P
vm
ÍÍ 
.
ÍÍ 
ProfileImageUrl
ÍÍ 
=
ÍÍ  
UrlFormatter
ÍÍ! -
.
ÍÍ- .
ProfileImage
ÍÍ. :
(
ÍÍ: ;
vm
ÍÍ; =
.
ÍÍ= >
UserId
ÍÍ> D
)
ÍÍD E
;
ÍÍE F'
FormatExternalNetworkUrls
ÏÏ %
(
ÏÏ% &
vm
ÏÏ& (
)
ÏÏ( )
;
ÏÏ) *
vm
ÓÓ 
.
ÓÓ 
Counters
ÓÓ 
.
ÓÓ 
Games
ÓÓ 
=
ÓÓ 
gameRepository
ÓÓ  .
.
ÓÓ. /
Count
ÓÓ/ 4
(
ÓÓ4 5
x
ÓÓ5 6
=>
ÓÓ7 9
x
ÓÓ: ;
.
ÓÓ; <
UserId
ÓÓ< B
==
ÓÓC E
vm
ÓÓF H
.
ÓÓH I
UserId
ÓÓI O
)
ÓÓO P
;
ÓÓP Q
vm
ÔÔ 
.
ÔÔ 
Counters
ÔÔ 
.
ÔÔ 
Posts
ÔÔ 
=
ÔÔ #
userContentRepository
ÔÔ  5
.
ÔÔ5 6
Count
ÔÔ6 ;
(
ÔÔ; <
x
ÔÔ< =
=>
ÔÔ> @
x
ÔÔA B
.
ÔÔB C
UserId
ÔÔC I
==
ÔÔJ L
vm
ÔÔM O
.
ÔÔO P
UserId
ÔÔP V
)
ÔÔV W
;
ÔÔW X
vm
 
.
 
Counters
 
.
 
Comments
  
=
! "*
userContentCommentRepository
# ?
.
? @
Count
@ E
(
E F
x
F G
=>
H J
x
K L
.
L M
UserId
M S
==
T V
vm
W Y
.
Y Z
UserId
Z `
)
` a
;
a b
Gamification
ÚÚ 
gamification
ÚÚ %
=
ÚÚ& '
this
ÚÚ( ,
.
ÚÚ, -'
gamificationDomainService
ÚÚ- F
.
ÚÚF G%
GetGamificationByUserId
ÚÚG ^
(
ÚÚ^ _
userId
ÚÚ_ e
)
ÚÚe f
;
ÚÚf g

unitOfWork
ÙÙ 
.
ÙÙ 
Commit
ÙÙ 
(
ÙÙ 
)
ÙÙ 
;
ÙÙ  
GamificationLevel
˜˜ 
currentLevel
˜˜ *
=
˜˜+ ,
this
˜˜- 1
.
˜˜1 2'
gamificationDomainService
˜˜2 K
.
˜˜K L
GetLevel
˜˜L T
(
˜˜T U
gamification
˜˜U a
.
˜˜a b 
CurrentLevelNumber
˜˜b t
)
˜˜t u
;
˜˜u v
vm
˘˘ 
.
˘˘ 
IndieXp
˘˘ 
.
˘˘ 
	LevelName
˘˘  
=
˘˘! "
currentLevel
˘˘# /
.
˘˘/ 0
Name
˘˘0 4
;
˘˘4 5
vm
˙˙ 
.
˙˙ 
IndieXp
˙˙ 
.
˙˙ 
Level
˙˙ 
=
˙˙ 
gamification
˙˙ +
.
˙˙+ , 
CurrentLevelNumber
˙˙, >
;
˙˙> ?
vm
˚˚ 
.
˚˚ 
IndieXp
˚˚ 
.
˚˚ 
LevelXp
˚˚ 
=
˚˚  
gamification
˚˚! -
.
˚˚- .
XpCurrentLevel
˚˚. <
;
˚˚< =
vm
¸¸ 
.
¸¸ 
IndieXp
¸¸ 
.
¸¸ 
NextLevelXp
¸¸ "
=
¸¸# $
gamification
¸¸% 1
.
¸¸1 2
XpToNextLevel
¸¸2 ?
+
¸¸@ A
gamification
¸¸B N
.
¸¸N O
XpCurrentLevel
¸¸O ]
;
¸¸] ^
vm
˛˛ 
.
˛˛ 
Counters
˛˛ 
.
˛˛ 
	Followers
˛˛ !
=
˛˛" #
this
˛˛$ (
.
˛˛( )%
userFollowDomainService
˛˛) @
.
˛˛@ A
Count
˛˛A F
(
˛˛F G
x
˛˛G H
=>
˛˛I K
x
˛˛L M
.
˛˛M N
FollowUserId
˛˛N Z
==
˛˛[ ]
vm
˛˛^ `
.
˛˛` a
UserId
˛˛a g
)
˛˛g h
;
˛˛h i
vm
ˇˇ 
.
ˇˇ 
Counters
ˇˇ 
.
ˇˇ 
	Following
ˇˇ !
=
ˇˇ" #
this
ˇˇ$ (
.
ˇˇ( )%
userFollowDomainService
ˇˇ) @
.
ˇˇ@ A
Count
ˇˇA F
(
ˇˇF G
x
ˇˇG H
=>
ˇˇI K
x
ˇˇL M
.
ˇˇM N
UserId
ˇˇN T
==
ˇˇU W
currentUserId
ˇˇX e
)
ˇˇe f
;
ˇˇf g
var
ÄÄ 
connectionsToUser
ÄÄ !
=
ÄÄ" #
this
ÄÄ$ (
.
ÄÄ( ))
userConnectionDomainService
ÄÄ) D
.
ÄÄD E
Count
ÄÄE J
(
ÄÄJ K
x
ÄÄK L
=>
ÄÄM O
x
ÄÄP Q
.
ÄÄQ R
TargetUserId
ÄÄR ^
==
ÄÄ_ a
vm
ÄÄb d
.
ÄÄd e
UserId
ÄÄe k
&&
ÄÄl n
x
ÄÄo p
.
ÄÄp q
ApprovalDate
ÄÄq }
.
ÄÄ} ~
HasValueÄÄ~ Ü
)ÄÄÜ á
;ÄÄá à
var
ÅÅ !
connectionsFromUser
ÅÅ #
=
ÅÅ$ %
this
ÅÅ& *
.
ÅÅ* +)
userConnectionDomainService
ÅÅ+ F
.
ÅÅF G
Count
ÅÅG L
(
ÅÅL M
x
ÅÅM N
=>
ÅÅO Q
x
ÅÅR S
.
ÅÅS T
UserId
ÅÅT Z
==
ÅÅ[ ]
vm
ÅÅ^ `
.
ÅÅ` a
UserId
ÅÅa g
&&
ÅÅh j
x
ÅÅk l
.
ÅÅl m
ApprovalDate
ÅÅm y
.
ÅÅy z
HasValueÅÅz Ç
)ÅÅÇ É
;ÅÅÉ Ñ
vm
ÉÉ 
.
ÉÉ 
Counters
ÉÉ 
.
ÉÉ 
Connections
ÉÉ #
=
ÉÉ$ %
connectionsToUser
ÉÉ& 7
+
ÉÉ8 9!
connectionsFromUser
ÉÉ: M
;
ÉÉM N
vm
ÖÖ 
.
ÖÖ "
CurrentUserFollowing
ÖÖ #
=
ÖÖ$ %
this
ÖÖ& *
.
ÖÖ* +%
userFollowDomainService
ÖÖ+ B
.
ÖÖB C
Get
ÖÖC F
(
ÖÖF G
x
ÖÖG H
=>
ÖÖI K
x
ÖÖL M
.
ÖÖM N
UserId
ÖÖN T
==
ÖÖU W
currentUserId
ÖÖX e
&&
ÖÖf h
x
ÖÖi j
.
ÖÖj k
FollowUserId
ÖÖk w
==
ÖÖx z
vm
ÖÖ{ }
.
ÖÖ} ~
UserIdÖÖ~ Ñ
)ÖÖÑ Ö
.ÖÖÖ Ü
AnyÖÖÜ â
(ÖÖâ ä
)ÖÖä ã
;ÖÖã å
vm
ÜÜ 
.
ÜÜ 
ConnectionControl
ÜÜ  
.
ÜÜ  !"
CurrentUserConnected
ÜÜ! 5
=
ÜÜ6 7
this
ÜÜ8 <
.
ÜÜ< =)
userConnectionDomainService
ÜÜ= X
.
ÜÜX Y
CheckConnection
ÜÜY h
(
ÜÜh i
currentUserId
ÜÜi v
,
ÜÜv w
vm
ÜÜx z
.
ÜÜz {
UserIdÜÜ{ Å
,ÜÜÅ Ç
trueÜÜÉ á
,ÜÜá à
trueÜÜâ ç
)ÜÜç é
;ÜÜé è
vm
áá 
.
áá 
ConnectionControl
áá  
.
áá  !(
CurrentUserWantsToFollowMe
áá! ;
=
áá< =
this
áá> B
.
ááB C)
userConnectionDomainService
ááC ^
.
áá^ _
CheckConnection
áá_ n
(
áán o
vm
ááo q
.
ááq r
UserId
áár x
,
ááx y
currentUserIdááz á
,ááá à
falseááâ é
,ááé è
falseááê ï
)ááï ñ
;ááñ ó
vm
àà 
.
àà 
ConnectionControl
àà  
.
àà  !!
ConnectionIsPending
àà! 4
=
àà5 6
this
àà7 ;
.
àà; <)
userConnectionDomainService
àà< W
.
ààW X
CheckConnection
ààX g
(
ààg h
currentUserId
ààh u
,
ààu v
vm
ààw y
.
àày z
UserIdààz Ä
,ààÄ Å
falseààÇ á
,ààá à
trueààâ ç
)ààç é
;ààé è
return
ää 
vm
ää 
;
ää 
}
ãã 	
private
çç 
static
çç 
void
çç '
FormatExternalNetworkUrls
çç 5
(
çç5 6
ProfileViewModel
çç6 F
vm
ççG I
)
ççI J
{
éé 	
if
èè 
(
èè 
!
èè 
string
èè 
.
èè  
IsNullOrWhiteSpace
èè *
(
èè* +
vm
èè+ -
.
èè- .
	ItchIoUrl
èè. 7
)
èè7 8
)
èè8 9
{
êê 
vm
ëë 
.
ëë 
	ItchIoUrl
ëë 
=
ëë 
vm
ëë !
.
ëë! "
	ItchIoUrl
ëë" +
.
ëë+ ,
ToLower
ëë, 3
(
ëë3 4
)
ëë4 5
.
ëë5 6
Replace
ëë6 =
(
ëë= >
$str
ëë> A
,
ëëA B
$str
ëëC F
)
ëëF G
;
ëëG H
if
íí 
(
íí 
!
íí 
vm
íí 
.
íí 
	ItchIoUrl
íí !
.
íí! "
EndsWith
íí" *
(
íí* +
$str
íí+ 4
)
íí4 5
)
íí5 6
{
ìì 
vm
îî 
.
îî 
	ItchIoUrl
îî  
=
îî! "
$str
îî# -
+
îî. /
vm
îî0 2
.
îî2 3
	ItchIoUrl
îî3 <
+
îî= >
$str
îî? I
;
îîI J
}
ïï 
}
ññ 
if
òò 
(
òò 
!
òò 
string
òò 
.
òò  
IsNullOrWhiteSpace
òò *
(
òò* +
vm
òò+ -
.
òò- .
GameJoltUrl
òò. 9
)
òò9 :
)
òò: ;
{
ôô 
vm
öö 
.
öö 
GameJoltUrl
öö 
=
öö  
vm
öö! #
.
öö# $
GameJoltUrl
öö$ /
.
öö/ 0
ToLower
öö0 7
(
öö7 8
)
öö8 9
.
öö9 :
Replace
öö: A
(
ööA B
$str
ööB E
,
ööE F
$str
ööG J
)
ööJ K
;
ööK L
if
õõ 
(
õõ 
!
õõ 
vm
õõ 
.
õõ 
GameJoltUrl
õõ #
.
õõ# $
EndsWith
õõ$ ,
(
õõ, -
$str
õõ- 6
)
õõ6 7
)
õõ7 8
{
úú 
vm
ùù 
.
ùù 
GameJoltUrl
ùù "
=
ùù# $
$str
ùù% =
+
ùù> ?
vm
ùù@ B
.
ùùB C
GameJoltUrl
ùùC N
;
ùùN O
}
ûû 
}
üü 
if
°° 
(
°° 
!
°° 
string
°° 
.
°°  
IsNullOrWhiteSpace
°° *
(
°°* +
vm
°°+ -
.
°°- .
UnityConnectUrl
°°. =
)
°°= >
)
°°> ?
{
¢¢ 
vm
££ 
.
££ 
UnityConnectUrl
££ "
=
££# $
vm
££% '
.
££' (
UnityConnectUrl
££( 7
.
££7 8
ToLower
££8 ?
(
££? @
)
££@ A
.
££A B
Replace
££B I
(
££I J
$str
££J M
,
££M N
$str
££O R
)
££R S
;
££S T
if
§§ 
(
§§ 
!
§§ 
vm
§§ 
.
§§ 
UnityConnectUrl
§§ '
.
§§' (
EndsWith
§§( 0
(
§§0 1
$str
§§1 :
)
§§: ;
)
§§; <
{
•• 
vm
¶¶ 
.
¶¶ 
UnityConnectUrl
¶¶ &
=
¶¶' (
$str
¶¶) G
+
¶¶H I
vm
¶¶J L
.
¶¶L M
UnityConnectUrl
¶¶M \
;
¶¶\ ]
}
ßß 
}
®® 
}
©© 	
public
´´ 
ProfileViewModel
´´ 
GenerateNewOne
´´  .
(
´´. /
ProfileType
´´/ :
type
´´; ?
)
´´? @
{
¨¨ 	
ProfileViewModel
≠≠ 
profile
≠≠ $
=
≠≠% &
new
≠≠' *
ProfileViewModel
≠≠+ ;
(
≠≠; <
)
≠≠< =
;
≠≠= >
Random
ÆÆ 
r
ÆÆ 
=
ÆÆ 
new
ÆÆ 
Random
ÆÆ !
(
ÆÆ! "
(
ÆÆ" #
int
ÆÆ# &
)
ÆÆ& '
DateTime
ÆÆ' /
.
ÆÆ/ 0
Now
ÆÆ0 3
.
ÆÆ3 4
Ticks
ÆÆ4 9
)
ÆÆ9 :
;
ÆÆ: ;
profile
∞∞ 
.
∞∞ 
Type
∞∞ 
=
∞∞ 
ProfileType
∞∞ &
.
∞∞& '
Personal
∞∞' /
;
∞∞/ 0
profile
≤≤ 
.
≤≤ 
Name
≤≤ 
=
≤≤ 
$str
≤≤ !
+
≤≤" #
r
≤≤$ %
.
≤≤% &
Next
≤≤& *
(
≤≤* +
$num
≤≤+ -
,
≤≤- .
$num
≤≤/ 3
)
≤≤3 4
.
≤≤4 5
ToString
≤≤5 =
(
≤≤= >
)
≤≤> ?
;
≤≤? @
profile
≥≥ 
.
≥≥ 
Motto
≥≥ 
=
≥≥ 
$str
≥≥ E
;
≥≥E F
profile
µµ 
.
µµ 
Bio
µµ 
=
µµ 
profile
µµ !
.
µµ! "
Name
µµ" &
+
µµ' (
$str
µµ) |
;
µµ| }
profile
∑∑ 
.
∑∑ 

StudioName
∑∑ 
=
∑∑  
$str
∑∑! 6
;
∑∑6 7
profile
∏∏ 
.
∏∏ 
Location
∏∏ 
=
∏∏ 
$str
∏∏ )
;
∏∏) *
profile
∫∫ 
.
∫∫ 
ProfileImageUrl
∫∫ #
=
∫∫$ %
	Constants
∫∫& /
.
∫∫/ 0
DefaultAvatar
∫∫0 =
;
∫∫= >
profile
ªª 
.
ªª 
CoverImageUrl
ªª !
=
ªª" #
	Constants
ªª$ -
.
ªª- .#
DefaultGameCoverImage
ªª. C
;
ªªC D
return
ΩΩ 
profile
ΩΩ 
;
ΩΩ 
}
ææ 	
}
¿¿ 
}¡¡ “Y
pC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\UserBadgeAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class 
UserBadgeAppService $
:% & 
IUserBadgeAppService' ;
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly #
IUserBadgeDomainService 0"
userBadgeDomainService1 G
;G H
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
UserBadgeAppService "
(" #
IMapper# *
mapper+ 1
,1 2
IUnitOfWork3 >

unitOfWork? I
,I J#
IUserBadgeDomainServiceK b"
userBadgeDomainServicec y
)y z
{ 	
this 
. 
mapper 
= 
mapper  
;  !
this 
. 

unitOfWork 
= 

unitOfWork (
;( )
this 
. "
userBadgeDomainService '
=( )"
userBadgeDomainService* @
;@ A
} 	
public 
OperationResultVo  
<  !
int! $
>$ %
Count& +
(+ ,
), -
{ 	
OperationResultVo 
< 
int !
>! "
result# )
;) *
try   
{!! 
int"" 
count"" 
="" "
userBadgeDomainService"" 2
.""2 3
Count""3 8
(""8 9
)""9 :
;"": ;
result$$ 
=$$ 
new$$ 
OperationResultVo$$ .
<$$. /
int$$/ 2
>$$2 3
($$3 4
count$$4 9
)$$9 :
;$$: ;
}%% 
catch&& 
(&& 
	Exception&& 
ex&& 
)&&  
{'' 
result(( 
=(( 
new(( 
OperationResultVo(( .
<((. /
int((/ 2
>((2 3
(((3 4
ex((4 6
.((6 7
Message((7 >
)((> ?
;((? @
})) 
return++ 
result++ 
;++ 
},, 	
public.. !
OperationResultListVo.. $
<..$ %
UserBadgeViewModel..% 7
>..7 8
GetAll..9 ?
(..? @
)..@ A
{// 	!
OperationResultListVo00 !
<00! "
UserBadgeViewModel00" 4
>004 5
result006 <
;00< =
try22 
{33 
IEnumerable44 
<44 
	UserBadge44 %
>44% &
	allModels44' 0
=441 2"
userBadgeDomainService443 I
.44I J
GetAll44J P
(44P Q
)44Q R
;44R S
IEnumerable66 
<66 
UserBadgeViewModel66 .
>66. /
vms660 3
=664 5
mapper666 <
.66< =
Map66= @
<66@ A
IEnumerable66A L
<66L M
	UserBadge66M V
>66V W
,66W X
IEnumerable66Y d
<66d e
UserBadgeViewModel66e w
>66w x
>66x y
(66y z
	allModels	66z É
)
66É Ñ
;
66Ñ Ö
result88 
=88 
new88 !
OperationResultListVo88 2
<882 3
UserBadgeViewModel883 E
>88E F
(88F G
vms88G J
)88J K
;88K L
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
result<< 
=<< 
new<< !
OperationResultListVo<< 2
<<<2 3
UserBadgeViewModel<<3 E
><<E F
(<<F G
ex<<G I
.<<I J
Message<<J Q
)<<Q R
;<<R S
}== 
return?? 
result?? 
;?? 
}@@ 	
publicBB 
OperationResultVoBB  
<BB  !
UserBadgeViewModelBB! 3
>BB3 4
GetByIdBB5 <
(BB< =
GuidBB= A
idBBB D
)BBD E
{CC 	
OperationResultVoDD 
<DD 
UserBadgeViewModelDD 0
>DD0 1
resultDD2 8
;DD8 9
tryFF 
{GG 
	UserBadgeHH 
modelHH 
=HH  !"
userBadgeDomainServiceHH" 8
.HH8 9
GetByIdHH9 @
(HH@ A
idHHA C
)HHC D
;HHD E
UserBadgeViewModelJJ "
vmJJ# %
=JJ& '
mapperJJ( .
.JJ. /
MapJJ/ 2
<JJ2 3
UserBadgeViewModelJJ3 E
>JJE F
(JJF G
modelJJG L
)JJL M
;JJM N
resultLL 
=LL 
newLL 
OperationResultVoLL .
<LL. /
UserBadgeViewModelLL/ A
>LLA B
(LLB C
vmLLC E
)LLE F
;LLF G
}MM 
catchNN 
(NN 
	ExceptionNN 
exNN 
)NN  
{OO 
resultPP 
=PP 
newPP 
OperationResultVoPP .
<PP. /
UserBadgeViewModelPP/ A
>PPA B
(PPB C
exPPC E
.PPE F
MessagePPF M
)PPM N
;PPN O
}QQ 
returnSS 
resultSS 
;SS 
}TT 	
publicVV !
OperationResultListVoVV $
<VV$ %
UserBadgeViewModelVV% 7
>VV7 8
	GetByUserVV9 B
(VVB C
GuidVVC G
userIdVVH N
)VVN O
{WW 	!
OperationResultListVoXX !
<XX! "
UserBadgeViewModelXX" 4
>XX4 5
resultXX6 <
;XX< =
tryZZ 
{[[ 
IEnumerable\\ 
<\\ 
	UserBadge\\ %
>\\% &
	allModels\\' 0
=\\1 2"
userBadgeDomainService\\3 I
.\\I J
GetByUserId\\J U
(\\U V
userId\\V \
)\\\ ]
;\\] ^
IEnumerable^^ 
<^^ 
UserBadgeViewModel^^ .
>^^. /
vms^^0 3
=^^4 5
mapper^^6 <
.^^< =
Map^^= @
<^^@ A
IEnumerable^^A L
<^^L M
	UserBadge^^M V
>^^V W
,^^W X
IEnumerable^^Y d
<^^d e
UserBadgeViewModel^^e w
>^^w x
>^^x y
(^^y z
	allModels	^^z É
)
^^É Ñ
;
^^Ñ Ö
result`` 
=`` 
new`` !
OperationResultListVo`` 2
<``2 3
UserBadgeViewModel``3 E
>``E F
(``F G
vms``G J
)``J K
;``K L
}aa 
catchbb 
(bb 
	Exceptionbb 
exbb 
)bb  
{cc 
resultdd 
=dd 
newdd !
OperationResultListVodd 2
<dd2 3
UserBadgeViewModeldd3 E
>ddE F
(ddF G
exddG I
.ddI J
MessageddJ Q
)ddQ R
;ddR S
}ee 
returngg 
resultgg 
;gg 
}hh 	
publicjj 
OperationResultVojj  
<jj  !
Guidjj! %
>jj% &
Savejj' +
(jj+ ,
UserBadgeViewModeljj, >
	viewModeljj? H
)jjH I
{kk 	
OperationResultVoll 
<ll 
Guidll "
>ll" #
resultll$ *
;ll* +
trynn 
{oo 
	UserBadgepp 
modelpp 
;pp  
	UserBadgett 
existingtt "
=tt# $"
userBadgeDomainServicett% ;
.tt; <
GetByIdtt< C
(ttC D
	viewModelttD M
.ttM N
IdttN P
)ttP Q
;ttQ R
ifuu 
(uu 
existinguu 
!=uu 
nulluu  $
)uu$ %
{vv 
modelww 
=ww 
mapperww "
.ww" #
Mapww# &
(ww& '
	viewModelww' 0
,ww0 1
existingww2 :
)ww: ;
;ww; <
}xx 
elseyy 
{zz 
model{{ 
={{ 
mapper{{ "
.{{" #
Map{{# &
<{{& '
	UserBadge{{' 0
>{{0 1
({{1 2
	viewModel{{2 ;
){{; <
;{{< =
}|| 
if~~ 
(~~ 
	viewModel~~ 
.~~ 
Id~~  
==~~! #
Guid~~$ (
.~~( )
Empty~~) .
)~~. /
{ $
userBadgeDomainService
ÄÄ *
.
ÄÄ* +
Add
ÄÄ+ .
(
ÄÄ. /
model
ÄÄ/ 4
)
ÄÄ4 5
;
ÄÄ5 6
	viewModel
ÅÅ 
.
ÅÅ 
Id
ÅÅ  
=
ÅÅ! "
model
ÅÅ# (
.
ÅÅ( )
Id
ÅÅ) +
;
ÅÅ+ ,
}
ÇÇ 
else
ÉÉ 
{
ÑÑ $
userBadgeDomainService
ÖÖ *
.
ÖÖ* +
Update
ÖÖ+ 1
(
ÖÖ1 2
model
ÖÖ2 7
)
ÖÖ7 8
;
ÖÖ8 9
}
ÜÜ 

unitOfWork
àà 
.
àà 
Commit
àà !
(
àà! "
)
àà" #
;
àà# $
result
ää 
=
ää 
new
ää 
OperationResultVo
ää .
<
ää. /
Guid
ää/ 3
>
ää3 4
(
ää4 5
model
ää5 :
.
ää: ;
Id
ää; =
)
ää= >
;
ää> ?
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
result
éé 
=
éé 
new
éé 
OperationResultVo
éé .
<
éé. /
Guid
éé/ 3
>
éé3 4
(
éé4 5
ex
éé5 7
.
éé7 8
Message
éé8 ?
)
éé? @
;
éé@ A
}
èè 
return
ëë 
result
ëë 
;
ëë 
}
íí 	
public
îî 
OperationResultVo
îî  
Remove
îî! '
(
îî' (
Guid
îî( ,
id
îî- /
)
îî/ 0
{
ïï 	
OperationResultVo
ññ 
result
ññ $
;
ññ$ %
try
òò 
{
ôô $
userBadgeDomainService
úú &
.
úú& '
Remove
úú' -
(
úú- .
id
úú. 0
)
úú0 1
;
úú1 2

unitOfWork
ûû 
.
ûû 
Commit
ûû !
(
ûû! "
)
ûû" #
;
ûû# $
result
†† 
=
†† 
new
†† 
OperationResultVo
†† .
(
††. /
true
††/ 3
)
††3 4
;
††4 5
}
°° 
catch
¢¢ 
(
¢¢ 
	Exception
¢¢ 
ex
¢¢ 
)
¢¢  
{
££ 
result
§§ 
=
§§ 
new
§§ 
OperationResultVo
§§ .
(
§§. /
ex
§§/ 1
.
§§1 2
Message
§§2 9
)
§§9 :
;
§§: ;
}
•• 
return
ßß 
result
ßß 
;
ßß 
}
®® 	
}
©© 
}™™ å∂
uC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\UserConnectionAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class $
UserConnectionAppService )
:* +
BaseAppService, :
,: ;%
IUserConnectionAppService< U
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly (
IUserConnectionDomainService 5'
userConnectionDomainService6 Q
;Q R
public $
UserConnectionAppService '
(' (
IMapper( /
mapper0 6
,6 7
IUnitOfWork8 C

unitOfWorkD N
, (
IUserConnectionDomainService *'
userConnectionDomainService+ F
)F G
{ 	
this 
. 
mapper 
= 
mapper  
;  !
this 
. 

unitOfWork 
= 

unitOfWork (
;( )
this 
. '
userConnectionDomainService ,
=- .'
userConnectionDomainService/ J
;J K
} 	
public 
OperationResultVo  
<  !
int! $
>$ %
Count& +
(+ ,
), -
{ 	
OperationResultVo 
< 
int !
>! "
result# )
;) *
try   
{!! 
int"" 
count"" 
="" 
this""  
.""  !'
userConnectionDomainService""! <
.""< =
Count""= B
(""B C
)""C D
;""D E
result$$ 
=$$ 
new$$ 
OperationResultVo$$ .
<$$. /
int$$/ 2
>$$2 3
($$3 4
count$$4 9
)$$9 :
;$$: ;
}%% 
catch&& 
(&& 
	Exception&& 
ex&& 
)&&  
{'' 
result(( 
=(( 
new(( 
OperationResultVo(( .
<((. /
int((/ 2
>((2 3
(((3 4
ex((4 6
.((6 7
Message((7 >
)((> ?
;((? @
})) 
return++ 
result++ 
;++ 
},, 	
public.. !
OperationResultListVo.. $
<..$ %#
UserConnectionViewModel..% <
>..< =
GetAll..> D
(..D E
)..E F
{// 	!
OperationResultListVo00 !
<00! "#
UserConnectionViewModel00" 9
>009 :
result00; A
;00A B
try22 
{33 
IEnumerable44 
<44 
UserConnection44 *
>44* +
	allModels44, 5
=446 7
this448 <
.44< ='
userConnectionDomainService44= X
.44X Y
GetAll44Y _
(44_ `
)44` a
;44a b
IEnumerable66 
<66 #
UserConnectionViewModel66 3
>663 4
vms665 8
=669 :
mapper66; A
.66A B
Map66B E
<66E F
IEnumerable66F Q
<66Q R
UserConnection66R `
>66` a
,66a b
IEnumerable66c n
<66n o$
UserConnectionViewModel	66o Ü
>
66Ü á
>
66á à
(
66à â
	allModels
66â í
)
66í ì
;
66ì î
result88 
=88 
new88 !
OperationResultListVo88 2
<882 3#
UserConnectionViewModel883 J
>88J K
(88K L
vms88L O
)88O P
;88P Q
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
result<< 
=<< 
new<< !
OperationResultListVo<< 2
<<<2 3#
UserConnectionViewModel<<3 J
><<J K
(<<K L
ex<<L N
.<<N O
Message<<O V
)<<V W
;<<W X
}== 
return?? 
result?? 
;?? 
}@@ 	
publicBB 
OperationResultVoBB  
<BB  !#
UserConnectionViewModelBB! 8
>BB8 9
GetByIdBB: A
(BBA B
GuidBBB F
idBBG I
)BBI J
{CC 	
OperationResultVoDD 
<DD #
UserConnectionViewModelDD 5
>DD5 6
resultDD7 =
;DD= >
tryFF 
{GG 
UserConnectionHH 
modelHH $
=HH% &
thisHH' +
.HH+ ,'
userConnectionDomainServiceHH, G
.HHG H
GetByIdHHH O
(HHO P
idHHP R
)HHR S
;HHS T#
UserConnectionViewModelJJ '
vmJJ( *
=JJ+ ,
mapperJJ- 3
.JJ3 4
MapJJ4 7
<JJ7 8#
UserConnectionViewModelJJ8 O
>JJO P
(JJP Q
modelJJQ V
)JJV W
;JJW X
resultLL 
=LL 
newLL 
OperationResultVoLL .
<LL. /#
UserConnectionViewModelLL/ F
>LLF G
(LLG H
vmLLH J
)LLJ K
;LLK L
}MM 
catchNN 
(NN 
	ExceptionNN 
exNN 
)NN  
{OO 
resultPP 
=PP 
newPP 
OperationResultVoPP .
<PP. /#
UserConnectionViewModelPP/ F
>PPF G
(PPG H
exPPH J
.PPJ K
MessagePPK R
)PPR S
;PPS T
}QQ 
returnSS 
resultSS 
;SS 
}TT 	
publicVV 
OperationResultVoVV  
RemoveVV! '
(VV' (
GuidVV( ,
idVV- /
)VV/ 0
{WW 	
OperationResultVoXX 
resultXX $
;XX$ %
tryZZ 
{[[ 
this^^ 
.^^ '
userConnectionDomainService^^ 0
.^^0 1
Remove^^1 7
(^^7 8
id^^8 :
)^^: ;
;^^; <

unitOfWork`` 
.`` 
Commit`` !
(``! "
)``" #
;``# $
resultbb 
=bb 
newbb 
OperationResultVobb .
(bb. /
truebb/ 3
)bb3 4
;bb4 5
}cc 
catchdd 
(dd 
	Exceptiondd 
exdd 
)dd  
{ee 
resultff 
=ff 
newff 
OperationResultVoff .
(ff. /
exff/ 1
.ff1 2
Messageff2 9
)ff9 :
;ff: ;
}gg 
returnii 
resultii 
;ii 
}jj 	
publicll 
OperationResultVoll  
<ll  !
Guidll! %
>ll% &
Savell' +
(ll+ ,#
UserConnectionViewModelll, C
	viewModelllD M
)llM N
{mm 	
OperationResultVonn 
<nn 
Guidnn "
>nn" #
resultnn$ *
;nn* +
trypp 
{qq 
UserConnectionrr 
modelrr $
;rr$ %
UserConnectionvv 
existingvv '
=vv( )
thisvv* .
.vv. /'
userConnectionDomainServicevv/ J
.vvJ K
GetByIdvvK R
(vvR S
	viewModelvvS \
.vv\ ]
Idvv] _
)vv_ `
;vv` a
ifww 
(ww 
existingww 
!=ww 
nullww  $
)ww$ %
{xx 
modelyy 
=yy 
mapperyy "
.yy" #
Mapyy# &
(yy& '
	viewModelyy' 0
,yy0 1
existingyy2 :
)yy: ;
;yy; <
}zz 
else{{ 
{|| 
model}} 
=}} 
mapper}} "
.}}" #
Map}}# &
<}}& '
UserConnection}}' 5
>}}5 6
(}}6 7
	viewModel}}7 @
)}}@ A
;}}A B
}~~ 
if
ÄÄ 
(
ÄÄ 
	viewModel
ÄÄ 
.
ÄÄ 
Id
ÄÄ  
==
ÄÄ! #
Guid
ÄÄ$ (
.
ÄÄ( )
Empty
ÄÄ) .
)
ÄÄ. /
{
ÅÅ 
this
ÇÇ 
.
ÇÇ )
userConnectionDomainService
ÇÇ 4
.
ÇÇ4 5
Add
ÇÇ5 8
(
ÇÇ8 9
model
ÇÇ9 >
)
ÇÇ> ?
;
ÇÇ? @
	viewModel
ÉÉ 
.
ÉÉ 
Id
ÉÉ  
=
ÉÉ! "
model
ÉÉ# (
.
ÉÉ( )
Id
ÉÉ) +
;
ÉÉ+ ,
}
ÑÑ 
else
ÖÖ 
{
ÜÜ 
this
áá 
.
áá )
userConnectionDomainService
áá 4
.
áá4 5
Update
áá5 ;
(
áá; <
model
áá< A
)
ááA B
;
ááB C
}
àà 

unitOfWork
ää 
.
ää 
Commit
ää !
(
ää! "
)
ää" #
;
ää# $
result
åå 
=
åå 
new
åå 
OperationResultVo
åå .
<
åå. /
Guid
åå/ 3
>
åå3 4
(
åå4 5
model
åå5 :
.
åå: ;
Id
åå; =
)
åå= >
;
åå> ?
}
çç 
catch
éé 
(
éé 
	Exception
éé 
ex
éé 
)
éé  
{
èè 
result
êê 
=
êê 
new
êê 
OperationResultVo
êê .
<
êê. /
Guid
êê/ 3
>
êê3 4
(
êê4 5
ex
êê5 7
.
êê7 8
Message
êê8 ?
)
êê? @
;
êê@ A
}
ëë 
return
ìì 
result
ìì 
;
ìì 
}
îî 	
public
óó #
OperationResultListVo
óó $
<
óó$ %%
UserConnectionViewModel
óó% <
>
óó< =
GetByTargetUserId
óó> O
(
óóO P
Guid
óóP T
targetUserId
óóU a
)
óóa b
{
òò 	#
OperationResultListVo
ôô !
<
ôô! "%
UserConnectionViewModel
ôô" 9
>
ôô9 :
result
ôô; A
;
ôôA B
try
õõ 
{
úú 
IEnumerable
ùù 
<
ùù 
UserConnection
ùù *
>
ùù* +
	allModels
ùù, 5
=
ùù6 7
this
ùù8 <
.
ùù< =)
userConnectionDomainService
ùù= X
.
ùùX Y
GetByTargetUserId
ùùY j
(
ùùj k
targetUserId
ùùk w
)
ùùw x
;
ùùx y
IEnumerable
üü 
<
üü %
UserConnectionViewModel
üü 3
>
üü3 4
vms
üü5 8
=
üü9 :
mapper
üü; A
.
üüA B
Map
üüB E
<
üüE F
IEnumerable
üüF Q
<
üüQ R
UserConnection
üüR `
>
üü` a
,
üüa b
IEnumerable
üüc n
<
üün o&
UserConnectionViewModelüüo Ü
>üüÜ á
>üüá à
(üüà â
	allModelsüüâ í
)üüí ì
;üüì î
result
°° 
=
°° 
new
°° #
OperationResultListVo
°° 2
<
°°2 3%
UserConnectionViewModel
°°3 J
>
°°J K
(
°°K L
vms
°°L O
)
°°O P
;
°°P Q
}
¢¢ 
catch
££ 
(
££ 
	Exception
££ 
ex
££ 
)
££  
{
§§ 
result
•• 
=
•• 
new
•• #
OperationResultListVo
•• 2
<
••2 3%
UserConnectionViewModel
••3 J
>
••J K
(
••K L
ex
••L N
.
••N O
Message
••O V
)
••V W
;
••W X
}
¶¶ 
return
®® 
result
®® 
;
®® 
}
©© 	
public
´´ 
OperationResultVo
´´  
Connect
´´! (
(
´´( )
Guid
´´) -
currentUserId
´´. ;
,
´´; <
Guid
´´= A
userId
´´B H
)
´´H I
{
¨¨ 	
try
≠≠ 
{
ÆÆ 
Guid
ØØ 
newId
ØØ 
;
ØØ 
UserConnection
±± 
model
±± $
=
±±% &
new
±±' *
UserConnection
±±+ 9
{
≤≤ 
UserId
≥≥ 
=
≥≥ 
currentUserId
≥≥ *
,
≥≥* +
TargetUserId
¥¥  
=
¥¥! "
userId
¥¥# )
}
µµ 
;
µµ 
UserConnection
ππ 
existing
ππ '
=
ππ( )
this
ππ* .
.
ππ. /)
userConnectionDomainService
ππ/ J
.
ππJ K
Get
ππK N
(
ππN O
currentUserId
ππO \
,
ππ\ ]
userId
ππ^ d
)
ππd e
;
ππe f
if
ªª 
(
ªª 
existing
ªª 
!=
ªª 
null
ªª  $
)
ªª$ %
{
ºº 
return
ΩΩ 
new
ΩΩ 
OperationResultVo
ΩΩ 0
(
ΩΩ0 1
$str
ΩΩ1 Z
)
ΩΩZ [
;
ΩΩ[ \
}
ææ 
else
øø 
{
¿¿ 
this
¬¬ 
.
¬¬ )
userConnectionDomainService
¬¬ 4
.
¬¬4 5
Add
¬¬5 8
(
¬¬8 9
model
¬¬9 >
)
¬¬> ?
;
¬¬? @
newId
ƒƒ 
=
ƒƒ 
model
ƒƒ !
.
ƒƒ! "
Id
ƒƒ" $
;
ƒƒ$ %
}
≈≈ 

unitOfWork
«« 
.
«« 
Commit
«« !
(
««! "
)
««" #
;
««# $
int
…… 
newCount
…… 
=
…… 
this
…… #
.
……# $)
userConnectionDomainService
……$ ?
.
……? @
Count
……@ E
(
……E F
x
……F G
=>
……H J
x
……K L
.
……L M
TargetUserId
……M Y
==
……Z \
userId
……] c
||
……d f
x
……g h
.
……h i
UserId
……i o
==
……p r
userId
……s y
&&
……z |
x
……} ~
.
……~ 
ApprovalDate…… ã
.……ã å
HasValue……å î
)……î ï
;……ï ñ
return
ÀÀ 
new
ÀÀ 
OperationResultVo
ÀÀ ,
<
ÀÀ, -
int
ÀÀ- 0
>
ÀÀ0 1
(
ÀÀ1 2
newCount
ÀÀ2 :
)
ÀÀ: ;
;
ÀÀ; <
}
ÃÃ 
catch
ÕÕ 
(
ÕÕ 
	Exception
ÕÕ 
ex
ÕÕ 
)
ÕÕ  
{
ŒŒ 
return
œœ 
new
œœ 
OperationResultVo
œœ ,
(
œœ, -
ex
œœ- /
.
œœ/ 0
Message
œœ0 7
)
œœ7 8
;
œœ8 9
}
–– 
}
—— 	
public
”” 
OperationResultVo
””  

Disconnect
””! +
(
””+ ,
Guid
””, 0
currentUserId
””1 >
,
””> ?
Guid
””@ D
userId
””E K
)
””K L
{
‘‘ 	
try
’’ 
{
÷÷ 
UserConnection
ŸŸ 
toMe
ŸŸ #
=
ŸŸ$ %
this
ŸŸ& *
.
ŸŸ* +)
userConnectionDomainService
ŸŸ+ F
.
ŸŸF G
Get
ŸŸG J
(
ŸŸJ K
currentUserId
ŸŸK X
,
ŸŸX Y
userId
ŸŸZ `
)
ŸŸ` a
;
ŸŸa b
UserConnection
⁄⁄ 
fromMe
⁄⁄ %
=
⁄⁄& '
this
⁄⁄( ,
.
⁄⁄, -)
userConnectionDomainService
⁄⁄- H
.
⁄⁄H I
Get
⁄⁄I L
(
⁄⁄L M
userId
⁄⁄M S
,
⁄⁄S T
currentUserId
⁄⁄U b
)
⁄⁄b c
;
⁄⁄c d
if
‹‹ 
(
‹‹ 
toMe
‹‹ 
==
‹‹ 
null
‹‹  
&&
‹‹! #
fromMe
‹‹$ *
==
‹‹+ -
null
‹‹. 2
)
‹‹2 3
{
›› 
return
ﬁﬁ 
new
ﬁﬁ 
OperationResultVo
ﬁﬁ 0
(
ﬁﬁ0 1
$str
ﬁﬁ1 V
)
ﬁﬁV W
;
ﬁﬁW X
}
ﬂﬂ 
else
‡‡ 
{
·· 
if
‚‚ 
(
‚‚ 
toMe
‚‚ 
!=
‚‚ 
null
‚‚  $
)
‚‚$ %
{
„„ 
this
‰‰ 
.
‰‰ )
userConnectionDomainService
‰‰ 8
.
‰‰8 9
Remove
‰‰9 ?
(
‰‰? @
toMe
‰‰@ D
.
‰‰D E
Id
‰‰E G
)
‰‰G H
;
‰‰H I
}
ÂÂ 
if
ÊÊ 
(
ÊÊ 
fromMe
ÊÊ 
!=
ÊÊ !
null
ÊÊ" &
)
ÊÊ& '
{
ÁÁ 
this
ËË 
.
ËË )
userConnectionDomainService
ËË 8
.
ËË8 9
Remove
ËË9 ?
(
ËË? @
fromMe
ËË@ F
.
ËËF G
Id
ËËG I
)
ËËI J
;
ËËJ K
}
ÈÈ 
}
ÍÍ 

unitOfWork
ÏÏ 
.
ÏÏ 
Commit
ÏÏ !
(
ÏÏ! "
)
ÏÏ" #
;
ÏÏ# $
int
ÓÓ 
newCount
ÓÓ 
=
ÓÓ 
this
ÓÓ #
.
ÓÓ# $)
userConnectionDomainService
ÓÓ$ ?
.
ÓÓ? @
Count
ÓÓ@ E
(
ÓÓE F
x
ÓÓF G
=>
ÓÓH J
x
ÓÓK L
.
ÓÓL M
TargetUserId
ÓÓM Y
==
ÓÓZ \
userId
ÓÓ] c
)
ÓÓc d
;
ÓÓd e
return
 
new
 
OperationResultVo
 ,
<
, -
int
- 0
>
0 1
(
1 2
newCount
2 :
)
: ;
;
; <
}
ÒÒ 
catch
ÚÚ 
(
ÚÚ 
	Exception
ÚÚ 
ex
ÚÚ 
)
ÚÚ  
{
ÛÛ 
return
ÙÙ 
new
ÙÙ 
OperationResultVo
ÙÙ ,
(
ÙÙ, -
ex
ÙÙ- /
.
ÙÙ/ 0
Message
ÙÙ0 7
)
ÙÙ7 8
;
ÙÙ8 9
}
ıı 
}
ˆˆ 	
public
¯¯ 
OperationResultVo
¯¯  
Allow
¯¯! &
(
¯¯& '
Guid
¯¯' +
currentUserId
¯¯, 9
,
¯¯9 :
Guid
¯¯; ?
userId
¯¯@ F
)
¯¯F G
{
˘˘ 	
OperationResultVo
˙˙ 
result
˙˙ $
;
˙˙$ %
try
¸¸ 
{
˝˝ 
UserConnection
ÄÄ 
existing
ÄÄ '
=
ÄÄ( )
this
ÄÄ* .
.
ÄÄ. /)
userConnectionDomainService
ÄÄ/ J
.
ÄÄJ K
Get
ÄÄK N
(
ÄÄN O
userId
ÄÄO U
,
ÄÄU V
currentUserId
ÄÄW d
)
ÄÄd e
;
ÄÄe f
if
ÇÇ 
(
ÇÇ 
existing
ÇÇ 
==
ÇÇ 
null
ÇÇ  $
)
ÇÇ$ %
{
ÉÉ 
result
ÑÑ 
=
ÑÑ 
new
ÑÑ  
OperationResultVo
ÑÑ! 2
(
ÑÑ2 3
$str
ÑÑ3 c
)
ÑÑc d
;
ÑÑd e
}
ÖÖ 
else
ÜÜ 
{
áá 
existing
àà 
.
àà 
ApprovalDate
àà )
=
àà* +
DateTime
àà, 4
.
àà4 5
Now
àà5 8
;
àà8 9
this
ää 
.
ää )
userConnectionDomainService
ää 4
.
ää4 5
Update
ää5 ;
(
ää; <
existing
ää< D
)
ääD E
;
ääE F
}
ãã 

unitOfWork
çç 
.
çç 
Commit
çç !
(
çç! "
)
çç" #
;
çç# $
int
èè 
newCount
èè 
=
èè 
this
èè #
.
èè# $)
userConnectionDomainService
èè$ ?
.
èè? @
Count
èè@ E
(
èèE F
x
èèF G
=>
èèH J
x
èèK L
.
èèL M
TargetUserId
èèM Y
==
èèZ \
userId
èè] c
||
èèd f
x
èèg h
.
èèh i
UserId
èèi o
==
èèp r
userId
èès y
&&
èèz |
x
èè} ~
.
èè~ 
ApprovalDateèè ã
.èèã å
HasValueèèå î
)èèî ï
;èèï ñ
result
ëë 
=
ëë 
new
ëë 
OperationResultVo
ëë .
<
ëë. /
int
ëë/ 2
>
ëë2 3
(
ëë3 4
newCount
ëë4 <
)
ëë< =
;
ëë= >
}
íí 
catch
ìì 
(
ìì 
	Exception
ìì 
ex
ìì 
)
ìì  
{
îî 
result
ïï 
=
ïï 
new
ïï 
OperationResultVo
ïï .
(
ïï. /
ex
ïï/ 1
.
ïï1 2
Message
ïï2 9
)
ïï9 :
;
ïï: ;
}
ññ 
return
òò 
result
òò 
;
òò 
}
ôô 	
public
õõ 
OperationResultVo
õõ  
Deny
õõ! %
(
õõ% &
Guid
õõ& *
currentUserId
õõ+ 8
,
õõ8 9
Guid
õõ: >
userId
õõ? E
)
õõE F
{
úú 	
OperationResultVo
ùù 
result
ùù $
;
ùù$ %
try
üü 
{
†† 
UserConnection
££ 
existing
££ '
=
££( )
this
££* .
.
££. /)
userConnectionDomainService
££/ J
.
££J K
Get
££K N
(
££N O
userId
££O U
,
££U V
currentUserId
££W d
)
££d e
;
££e f
if
•• 
(
•• 
existing
•• 
==
•• 
null
••  $
)
••$ %
{
¶¶ 
result
ßß 
=
ßß 
new
ßß  
OperationResultVo
ßß! 2
(
ßß2 3
$str
ßß3 c
)
ßßc d
;
ßßd e
}
®® 
else
©© 
{
™™ 
this
´´ 
.
´´ )
userConnectionDomainService
´´ 4
.
´´4 5
Remove
´´5 ;
(
´´; <
existing
´´< D
.
´´D E
Id
´´E G
)
´´G H
;
´´H I
}
¨¨ 

unitOfWork
ÆÆ 
.
ÆÆ 
Commit
ÆÆ !
(
ÆÆ! "
)
ÆÆ" #
;
ÆÆ# $
int
∞∞ 
newCount
∞∞ 
=
∞∞ 
this
∞∞ #
.
∞∞# $)
userConnectionDomainService
∞∞$ ?
.
∞∞? @
Count
∞∞@ E
(
∞∞E F
x
∞∞F G
=>
∞∞H J
x
∞∞K L
.
∞∞L M
TargetUserId
∞∞M Y
==
∞∞Z \
userId
∞∞] c
||
∞∞d f
x
∞∞g h
.
∞∞h i
UserId
∞∞i o
==
∞∞p r
userId
∞∞s y
&&
∞∞z |
x
∞∞} ~
.
∞∞~ 
ApprovalDate∞∞ ã
.∞∞ã å
HasValue∞∞å î
)∞∞î ï
;∞∞ï ñ
result
≤≤ 
=
≤≤ 
new
≤≤ 
OperationResultVo
≤≤ .
<
≤≤. /
int
≤≤/ 2
>
≤≤2 3
(
≤≤3 4
newCount
≤≤4 <
)
≤≤< =
;
≤≤= >
}
≥≥ 
catch
¥¥ 
(
¥¥ 
	Exception
¥¥ 
ex
¥¥ 
)
¥¥  
{
µµ 
result
∂∂ 
=
∂∂ 
new
∂∂ 
OperationResultVo
∂∂ .
(
∂∂. /
ex
∂∂/ 1
.
∂∂1 2
Message
∂∂2 9
)
∂∂9 :
;
∂∂: ;
}
∑∑ 
return
ππ 
result
ππ 
;
ππ 
}
∫∫ 	
}
ªª 
}ºº ÿå
rC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\UserContentAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class !
UserContentAppService &
:' (
BaseAppService) 7
,7 8"
IUserContentAppService9 O
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly "
IUserContentRepository /

repository0 :
;: ;
private 
readonly &
IUserContentLikeRepository 3
likeRepository4 B
;B C
private 
readonly )
IUserContentCommentRepository 6
commentRepository7 H
;H I
private 
readonly &
IGamificationDomainService 3%
gamificationDomainService4 M
;M N
private 
readonly $
IGameFollowDomainService 1#
gameFollowDomainService2 I
;I J
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public !
UserContentAppService $
($ %
IMapper% ,
mapper- 3
,3 4
IUnitOfWork5 @

unitOfWorkA K
,   "
IUserContentRepository   $

repository  % /
,!! &
IUserContentLikeRepository!! (
likeRepository!!) 7
,!!7 8)
IUserContentCommentRepository!!9 V
commentRepository!!W h
,"" &
IGamificationDomainService"" (%
gamificationDomainService"") B
,## $
IGameFollowDomainService## &#
gameFollowDomainService##' >
)##> ?
{$$ 	
this%% 
.%% 
mapper%% 
=%% 
mapper%%  
;%%  !
this&& 
.&& 

unitOfWork&& 
=&& 

unitOfWork&& (
;&&( )
this'' 
.'' 

repository'' 
='' 

repository'' (
;''( )
this(( 
.(( 
likeRepository(( 
=((  !
likeRepository((" 0
;((0 1
this)) 
.)) 
commentRepository)) "
=))# $
commentRepository))% 6
;))6 7
this** 
.** %
gamificationDomainService** *
=**+ ,%
gamificationDomainService**- F
;**F G
this++ 
.++ #
gameFollowDomainService++ (
=++) *#
gameFollowDomainService+++ B
;++B C
},, 	
public.. 
OperationResultVo..  
<..  !
int..! $
>..$ %
Count..& +
(..+ ,
).., -
{// 	
OperationResultVo00 
<00 
int00 !
>00! "
result00# )
;00) *
try22 
{33 
int44 
count44 
=44 

repository44 &
.44& '
GetAll44' -
(44- .
)44. /
.44/ 0
Count440 5
(445 6
)446 7
;447 8
result66 
=66 
new66 
OperationResultVo66 .
<66. /
int66/ 2
>662 3
(663 4
count664 9
)669 :
;66: ;
}77 
catch88 
(88 
	Exception88 
ex88 
)88  
{99 
result:: 
=:: 
new:: 
OperationResultVo:: .
<::. /
int::/ 2
>::2 3
(::3 4
ex::4 6
.::6 7
Message::7 >
)::> ?
;::? @
};; 
return== 
result== 
;== 
}>> 	
public@@ !
OperationResultListVo@@ $
<@@$ % 
UserContentViewModel@@% 9
>@@9 :
GetAll@@; A
(@@A B
)@@B C
{AA 	!
OperationResultListVoBB !
<BB! " 
UserContentViewModelBB" 6
>BB6 7
resultBB8 >
;BB> ?
tryDD 
{EE 

IQueryableFF 
<FF 
UserContentFF &
>FF& '
	allModelsFF( 1
=FF2 3

repositoryFF4 >
.FF> ?
GetAllFF? E
(FFE F
)FFF G
;FFG H
IEnumerableHH 
<HH  
UserContentViewModelHH 0
>HH0 1
vmsHH2 5
=HH6 7
mapperHH8 >
.HH> ?
MapHH? B
<HHB C
IEnumerableHHC N
<HHN O
UserContentHHO Z
>HHZ [
,HH[ \
IEnumerableHH] h
<HHh i 
UserContentViewModelHHi }
>HH} ~
>HH~ 
(	HH Ä
	allModels
HHÄ â
)
HHâ ä
;
HHä ã
resultJJ 
=JJ 
newJJ !
OperationResultListVoJJ 2
<JJ2 3 
UserContentViewModelJJ3 G
>JJG H
(JJH I
vmsJJI L
)JJL M
;JJM N
}KK 
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL  
{MM 
resultNN 
=NN 
newNN !
OperationResultListVoNN 2
<NN2 3 
UserContentViewModelNN3 G
>NNG H
(NNH I
exNNI K
.NNK L
MessageNNL S
)NNS T
;NNT U
}OO 
returnQQ 
resultQQ 
;QQ 
}RR 	
publicTT 
OperationResultVoTT  
<TT  ! 
UserContentViewModelTT! 5
>TT5 6
GetByIdTT7 >
(TT> ?
GuidTT? C
idTTD F
)TTF G
{UU 	
OperationResultVoVV 
<VV  
UserContentViewModelVV 2
>VV2 3
resultVV4 :
;VV: ;
tryXX 
{YY 
UserContentZZ 
modelZZ !
=ZZ" #

repositoryZZ$ .
.ZZ. /
GetByIdZZ/ 6
(ZZ6 7
idZZ7 9
)ZZ9 :
;ZZ: ; 
UserContentViewModel\\ $
vm\\% '
=\\( )
mapper\\* 0
.\\0 1
Map\\1 4
<\\4 5 
UserContentViewModel\\5 I
>\\I J
(\\J K
model\\K P
)\\P Q
;\\Q R
vm__ 
.__ 
Content__ 
=__ 
FormatContentToShow__ 0
(__0 1
vm__1 3
.__3 4
Content__4 ;
)__; <
;__< =
vmaa 
.aa 
UserContentTypeaa "
=aa# $
UserContentTypeaa% 4
.aa4 5
Postaa5 9
;aa9 :
vmcc 
.cc 
HasFeaturedImagecc #
=cc$ %
!cc& '
stringcc' -
.cc- .
IsNullOrWhiteSpacecc. @
(cc@ A
vmccA C
.ccC D
FeaturedImageccD Q
)ccQ R
&&ccS U
!ccV W
vmccW Y
.ccY Z
FeaturedImageccZ g
.ccg h
Containscch p
(ccp q
	Constantsccq z
.ccz {!
DefaultFeaturedImage	cc{ è
)
ccè ê
;
ccê ë
vmee 
.ee 
FeaturedMediaTypeee $
=ee% &
GetMediaTypeee' 3
(ee3 4
vmee4 6
.ee6 7
FeaturedImageee7 D
)eeD E
;eeE F
ifgg 
(gg 
vmgg 
.gg 
FeaturedMediaTypegg (
!=gg) +
	MediaTypegg, 5
.gg5 6
Youtubegg6 =
)gg= >
{hh 
vmii 
.ii 
FeaturedImageii $
=ii% &
SetFeaturedImageii' 7
(ii7 8
vmii8 :
.ii: ;
UserIdii; A
,iiA B
vmiiC E
.iiE F
FeaturedImageiiF S
)iiS T
;iiT U
}jj 
resultmm 
=mm 
newmm 
OperationResultVomm .
<mm. / 
UserContentViewModelmm/ C
>mmC D
(mmD E
vmmmE G
)mmG H
;mmH I
}nn 
catchoo 
(oo 
	Exceptionoo 
exoo 
)oo  
{pp 
resultqq 
=qq 
newqq 
OperationResultVoqq .
<qq. / 
UserContentViewModelqq/ C
>qqC D
(qqD E
exqqE G
.qqG H
MessageqqH O
)qqO P
;qqP Q
}rr 
returntt 
resulttt 
;tt 
}uu 	
publicww 
OperationResultVoww  
Removeww! '
(ww' (
Guidww( ,
idww- /
)ww/ 0
{xx 	
OperationResultVoyy 
resultyy $
;yy$ %
try{{ 
{|| 

repository 
. 
Remove !
(! "
id" $
)$ %
;% &

unitOfWork
ÅÅ 
.
ÅÅ 
Commit
ÅÅ !
(
ÅÅ! "
)
ÅÅ" #
;
ÅÅ# $
result
ÉÉ 
=
ÉÉ 
new
ÉÉ 
OperationResultVo
ÉÉ .
(
ÉÉ. /
true
ÉÉ/ 3
)
ÉÉ3 4
;
ÉÉ4 5
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
result
áá 
=
áá 
new
áá 
OperationResultVo
áá .
(
áá. /
ex
áá/ 1
.
áá1 2
Message
áá2 9
)
áá9 :
;
áá: ;
}
àà 
return
ää 
result
ää 
;
ää 
}
ãã 	
public
çç 
OperationResultVo
çç  
<
çç  !
Guid
çç! %
>
çç% &
Save
çç' +
(
çç+ ,"
UserContentViewModel
çç, @
	viewModel
ççA J
)
ççJ K
{
éé 	
OperationResultVo
èè 
<
èè 
Guid
èè "
>
èè" #
result
èè$ *
;
èè* +
try
ëë 
{
íí 
UserContent
ìì 
model
ìì !
;
ìì! "
UserContent
ïï 
latest
ïï "
=
ïï# $

repository
ïï% /
.
ïï/ 0
GetAll
ïï0 6
(
ïï6 7
)
ïï7 8
.
ïï8 9
OrderBy
ïï9 @
(
ïï@ A
x
ïïA B
=>
ïïC E
x
ïïF G
.
ïïG H

CreateDate
ïïH R
)
ïïR S
.
ïïS T
Last
ïïT X
(
ïïX Y
)
ïïY Z
;
ïïZ [
bool
ññ 
sameContent
ññ  
=
ññ! "
latest
ññ# )
.
ññ) *
Content
ññ* 1
.
ññ1 2
Trim
ññ2 6
(
ññ6 7
)
ññ7 8
.
ññ8 9
ToLower
ññ9 @
(
ññ@ A
)
ññA B
.
ññB C
Replace
ññC J
(
ññJ K
$str
ññK N
,
ññN O
string
ññP V
.
ññV W
Empty
ññW \
)
ññ\ ]
.
ññ] ^
Equals
ññ^ d
(
ññd e
	viewModel
ññe n
.
ññn o
Content
ñño v
.
ññv w
Trim
ññw {
(
ññ{ |
)
ññ| }
.
ññ} ~
ToLowerññ~ Ö
(ññÖ Ü
)ññÜ á
.ññá à
Replaceññà è
(ññè ê
$strññê ì
,ññì î
stringññï õ
.ññõ ú
Emptyññú °
)ññ° ¢
)ññ¢ £
;ññ£ §
bool
óó 
sameId
óó 
=
óó 
latest
óó $
.
óó$ %
Id
óó% '
==
óó( *
	viewModel
óó+ 4
.
óó4 5
Id
óó5 7
;
óó7 8
if
ôô 
(
ôô 
sameContent
ôô 
&&
ôô  "
!
ôô# $
sameId
ôô$ *
)
ôô* +
{
öö 
return
õõ 
new
õõ 
OperationResultVo
õõ 0
<
õõ0 1
Guid
õõ1 5
>
õõ5 6
(
õõ6 7
$str
õõ7 t
)
õõt u
;
õõu v
}
úú 
string
ûû 
youtubePattern
ûû %
=
ûû& '
$str
ûû( \
;
ûû\ ]
	viewModel
†† 
.
†† 
Content
†† !
=
††" #
Regex
††$ )
.
††) *
Replace
††* 1
(
††1 2
	viewModel
††2 ;
.
††; <
Content
††< C
,
††C D
youtubePattern
††E S
,
††S T
delegate
††U ]
(
††^ _
Match
††_ d
match
††e j
)
††j k
{
°° 
string
¢¢ 
v
¢¢ 
=
¢¢ 
match
¢¢ $
.
¢¢$ %
ToString
¢¢% -
(
¢¢- .
)
¢¢. /
;
¢¢/ 0
if
££ 
(
££ 
match
££ 
.
££ 
Index
££ #
==
££$ &
$num
££' (
&&
££) +
String
££, 2
.
££2 3 
IsNullOrWhiteSpace
££3 E
(
££E F
	viewModel
££F O
.
££O P
FeaturedImage
££P ]
)
££] ^
)
££^ _
{
§§ 
	viewModel
•• !
.
••! "
FeaturedImage
••" /
=
••0 1
v
••2 3
;
••3 4
return
¶¶ 
String
¶¶ %
.
¶¶% &
Empty
¶¶& +
;
¶¶+ ,
}
ßß 
else
®® 
{
©© 
return
™™ 
string
™™ %
.
™™% &
Format
™™& ,
(
™™, -
$str
™™- G
,
™™G H
v
™™I J
)
™™J K
;
™™K L
}
´´ 
}
≠≠ 
)
≠≠ 
;
≠≠ 
UserContent
±± 
existing
±± $
=
±±% &

repository
±±' 1
.
±±1 2
GetById
±±2 9
(
±±9 :
	viewModel
±±: C
.
±±C D
Id
±±D F
)
±±F G
;
±±G H
if
≤≤ 
(
≤≤ 
existing
≤≤ 
!=
≤≤ 
null
≤≤  $
)
≤≤$ %
{
≥≥ 
model
¥¥ 
=
¥¥ 
mapper
¥¥ "
.
¥¥" #
Map
¥¥# &
(
¥¥& '
	viewModel
¥¥' 0
,
¥¥0 1
existing
¥¥2 :
)
¥¥: ;
;
¥¥; <
}
µµ 
else
∂∂ 
{
∑∑ 
model
∏∏ 
=
∏∏ 
mapper
∏∏ "
.
∏∏" #
Map
∏∏# &
<
∏∏& '
UserContent
∏∏' 2
>
∏∏2 3
(
∏∏3 4
	viewModel
∏∏4 =
)
∏∏= >
;
∏∏> ?
PlatformAction
∫∫ "
action
∫∫# )
=
∫∫* +
	viewModel
∫∫, 5
.
∫∫5 6
	IsComplex
∫∫6 ?
?
∫∫@ A
PlatformAction
∫∫B P
.
∫∫P Q
ComplexPost
∫∫Q \
:
∫∫] ^
PlatformAction
∫∫_ m
.
∫∫m n

SimplePost
∫∫n x
;
∫∫x y
this
ºº 
.
ºº '
gamificationDomainService
ºº 2
.
ºº2 3
ProcessAction
ºº3 @
(
ºº@ A
	viewModel
ººA J
.
ººJ K
UserId
ººK Q
,
ººQ R
action
ººS Y
)
ººY Z
;
ººZ [
}
ΩΩ 
if
øø 
(
øø 
	viewModel
øø 
.
øø 
Id
øø  
==
øø! #
Guid
øø$ (
.
øø( )
Empty
øø) .
)
øø. /
{
¿¿ 

repository
¡¡ 
.
¡¡ 
Add
¡¡ "
(
¡¡" #
model
¡¡# (
)
¡¡( )
;
¡¡) *
	viewModel
¬¬ 
.
¬¬ 
Id
¬¬  
=
¬¬! "
model
¬¬# (
.
¬¬( )
Id
¬¬) +
;
¬¬+ ,
}
√√ 
else
ƒƒ 
{
≈≈ 

repository
∆∆ 
.
∆∆ 
Update
∆∆ %
(
∆∆% &
model
∆∆& +
)
∆∆+ ,
;
∆∆, -
}
«« 

unitOfWork
…… 
.
…… 
Commit
…… !
(
……! "
)
……" #
;
……# $
result
ÀÀ 
=
ÀÀ 
new
ÀÀ 
OperationResultVo
ÀÀ .
<
ÀÀ. /
Guid
ÀÀ/ 3
>
ÀÀ3 4
(
ÀÀ4 5
model
ÀÀ5 :
.
ÀÀ: ;
Id
ÀÀ; =
)
ÀÀ= >
;
ÀÀ> ?
}
ÃÃ 
catch
ÕÕ 
(
ÕÕ 
	Exception
ÕÕ 
ex
ÕÕ 
)
ÕÕ  
{
ŒŒ 
result
œœ 
=
œœ 
new
œœ 
OperationResultVo
œœ .
<
œœ. /
Guid
œœ/ 3
>
œœ3 4
(
œœ4 5
ex
œœ5 7
.
œœ7 8
Message
œœ8 ?
)
œœ? @
;
œœ@ A
}
–– 
return
““ 
result
““ 
;
““ 
}
”” 	
public
’’ 
int
’’ 
CountArticles
’’  
(
’’  !
)
’’! "
{
÷÷ 	
int
◊◊ 
count
◊◊ 
=
◊◊ 

repository
◊◊ "
.
◊◊" #
Count
◊◊# (
(
◊◊( )
x
◊◊) *
=>
◊◊+ -
!
◊◊. /
string
◊◊/ 5
.
◊◊5 6 
IsNullOrWhiteSpace
◊◊6 H
(
◊◊H I
x
◊◊I J
.
◊◊J K
Title
◊◊K P
)
◊◊P Q
&&
◊◊R T
!
◊◊U V
string
◊◊V \
.
◊◊\ ] 
IsNullOrWhiteSpace
◊◊] o
(
◊◊o p
x
◊◊p q
.
◊◊q r
Introduction
◊◊r ~
)
◊◊~ 
)◊◊ Ä
;◊◊Ä Å
return
ŸŸ 
count
ŸŸ 
;
ŸŸ 
}
⁄⁄ 	
public
‹‹ 
IEnumerable
‹‹ 
<
‹‹ *
UserContentListItemViewModel
‹‹ 7
>
‹‹7 8
GetActivityFeed
‹‹9 H
(
‹‹H I
Guid
‹‹I M
currentUserId
‹‹N [
,
‹‹[ \
int
‹‹] `
count
‹‹a f
,
‹‹f g
Guid
‹‹h l
gameId
‹‹m s
,
‹‹s t
Guid
‹‹u y
userId‹‹z Ä
,‹‹Ä Å
List‹‹Ç Ü
<‹‹Ü á!
SupportedLanguage‹‹á ò
>‹‹ò ô
	languages‹‹ö £
)‹‹£ §
{
›› 	

IQueryable
ﬁﬁ 
<
ﬁﬁ 
UserContent
ﬁﬁ "
>
ﬁﬁ" #
	allModels
ﬁﬁ$ -
=
ﬁﬁ. /

repository
ﬁﬁ0 :
.
ﬁﬁ: ;
GetAll
ﬁﬁ; A
(
ﬁﬁA B
)
ﬁﬁB C
;
ﬁﬁC D
if
‡‡ 
(
‡‡ 
userId
‡‡ 
!=
‡‡ 
null
‡‡ 
&&
‡‡ !
userId
‡‡" (
!=
‡‡) +
Guid
‡‡, 0
.
‡‡0 1
Empty
‡‡1 6
)
‡‡6 7
{
·· 
	allModels
‚‚ 
=
‚‚ 
	allModels
‚‚ %
.
‚‚% &
Where
‚‚& +
(
‚‚+ ,
x
‚‚, -
=>
‚‚. 0
x
‚‚1 2
.
‚‚2 3
UserId
‚‚3 9
!=
‚‚: <
Guid
‚‚= A
.
‚‚A B
Empty
‚‚B G
&&
‚‚H J
x
‚‚K L
.
‚‚L M
UserId
‚‚M S
==
‚‚T V
userId
‚‚W ]
)
‚‚] ^
;
‚‚^ _
}
„„ 
if
ÂÂ 
(
ÂÂ 
gameId
ÂÂ 
!=
ÂÂ 
null
ÂÂ 
&&
ÂÂ !
gameId
ÂÂ" (
!=
ÂÂ) +
Guid
ÂÂ, 0
.
ÂÂ0 1
Empty
ÂÂ1 6
)
ÂÂ6 7
{
ÊÊ 
	allModels
ÁÁ 
=
ÁÁ 
	allModels
ÁÁ %
.
ÁÁ% &
Where
ÁÁ& +
(
ÁÁ+ ,
x
ÁÁ, -
=>
ÁÁ. 0
x
ÁÁ1 2
.
ÁÁ2 3
GameId
ÁÁ3 9
!=
ÁÁ: <
Guid
ÁÁ= A
.
ÁÁA B
Empty
ÁÁB G
&&
ÁÁH J
x
ÁÁK L
.
ÁÁL M
GameId
ÁÁM S
==
ÁÁT V
gameId
ÁÁW ]
)
ÁÁ] ^
;
ÁÁ^ _
}
ËË 
if
ÍÍ 
(
ÍÍ 
	languages
ÍÍ 
!=
ÍÍ 
null
ÍÍ !
&&
ÍÍ" $
	languages
ÍÍ% .
.
ÍÍ. /
Any
ÍÍ/ 2
(
ÍÍ2 3
)
ÍÍ3 4
)
ÍÍ4 5
{
ÎÎ 
	allModels
ÏÏ 
=
ÏÏ 
	allModels
ÏÏ %
.
ÏÏ% &
Where
ÏÏ& +
(
ÏÏ+ ,
x
ÏÏ, -
=>
ÏÏ. 0
x
ÏÏ1 2
.
ÏÏ2 3
Language
ÏÏ3 ;
==
ÏÏ< >
$num
ÏÏ? @
||
ÏÏA C
	languages
ÏÏD M
.
ÏÏM N
Contains
ÏÏN V
(
ÏÏV W
x
ÏÏW X
.
ÏÏX Y
Language
ÏÏY a
)
ÏÏa b
)
ÏÏb c
;
ÏÏc d
}
ÌÌ 
IOrderedQueryable
ÔÔ 
<
ÔÔ 
UserContent
ÔÔ )
>
ÔÔ) *
orderedList
ÔÔ+ 6
=
ÔÔ7 8
	allModels
ÔÔ9 B
.
 
OrderByDescending
 "
(
" #
x
# $
=>
% '
x
( )
.
) *

CreateDate
* 4
)
4 5
;
5 6

IQueryable
ÚÚ 
<
ÚÚ 
UserContent
ÚÚ "
>
ÚÚ" #
	finalList
ÚÚ$ -
=
ÚÚ. /
orderedList
ÚÚ0 ;
.
ÚÚ; <
Take
ÚÚ< @
(
ÚÚ@ A
count
ÚÚA F
)
ÚÚF G
;
ÚÚG H
List
ÙÙ 
<
ÙÙ *
UserContentListItemViewModel
ÙÙ -
>
ÙÙ- .

viewModels
ÙÙ/ 9
=
ÙÙ: ;
	finalList
ÙÙ< E
.
ÙÙE F
	ProjectTo
ÙÙF O
<
ÙÙO P*
UserContentListItemViewModel
ÙÙP l
>
ÙÙl m
(
ÙÙm n
mapper
ÙÙn t
.
ÙÙt u$
ConfigurationProviderÙÙu ä
)ÙÙä ã
.ÙÙã å
ToListÙÙå í
(ÙÙí ì
)ÙÙì î
;ÙÙî ï
foreach
ˆˆ 
(
ˆˆ *
UserContentListItemViewModel
ˆˆ 1
item
ˆˆ2 6
in
ˆˆ7 9

viewModels
ˆˆ: D
)
ˆˆD E
{
˜˜ 
item
¯¯ 
.
¯¯ 

AuthorName
¯¯ 
=
¯¯  !
string
¯¯" (
.
¯¯( ) 
IsNullOrWhiteSpace
¯¯) ;
(
¯¯; <
item
¯¯< @
.
¯¯@ A

AuthorName
¯¯A K
)
¯¯K L
?
¯¯M N
$str
¯¯O ]
:
¯¯^ _
item
¯¯` d
.
¯¯d e

AuthorName
¯¯e o
;
¯¯o p
item
˘˘ 
.
˘˘ 
AuthorPicture
˘˘ "
=
˘˘# $
UrlFormatter
˘˘% 1
.
˘˘1 2
ProfileImage
˘˘2 >
(
˘˘> ?
item
˘˘? C
.
˘˘C D
UserId
˘˘D J
)
˘˘J K
;
˘˘K L
item
˚˚ 
.
˚˚ 
	IsArticle
˚˚ 
=
˚˚  
!
˚˚! "
string
˚˚" (
.
˚˚( ) 
IsNullOrWhiteSpace
˚˚) ;
(
˚˚; <
item
˚˚< @
.
˚˚@ A
Title
˚˚A F
)
˚˚F G
&&
˚˚H J
!
˚˚K L
string
˚˚L R
.
˚˚R S 
IsNullOrWhiteSpace
˚˚S e
(
˚˚e f
item
˚˚f j
.
˚˚j k
Introduction
˚˚k w
)
˚˚w x
;
˚˚x y
item
˝˝ 
.
˝˝ 
HasFeaturedImage
˝˝ %
=
˝˝& '
!
˝˝( )
string
˝˝) /
.
˝˝/ 0 
IsNullOrWhiteSpace
˝˝0 B
(
˝˝B C
item
˝˝C G
.
˝˝G H
FeaturedImage
˝˝H U
)
˝˝U V
&&
˝˝W Y
!
˝˝Z [
item
˝˝[ _
.
˝˝_ `
FeaturedImage
˝˝` m
.
˝˝m n
Contains
˝˝n v
(
˝˝v w
	Constants˝˝w Ä
.˝˝Ä Å$
DefaultFeaturedImage˝˝Å ï
)˝˝ï ñ
;˝˝ñ ó
item
ˇˇ 
.
ˇˇ 
FeaturedImageType
ˇˇ &
=
ˇˇ' (
this
ˇˇ) -
.
ˇˇ- .
GetMediaType
ˇˇ. :
(
ˇˇ: ;
item
ˇˇ; ?
.
ˇˇ? @
FeaturedImage
ˇˇ@ M
)
ˇˇM N
;
ˇˇN O
if
ÅÅ 
(
ÅÅ 
item
ÅÅ 
.
ÅÅ 
FeaturedImageType
ÅÅ *
!=
ÅÅ+ -
	MediaType
ÅÅ. 7
.
ÅÅ7 8
Youtube
ÅÅ8 ?
)
ÅÅ? @
{
ÇÇ 
item
ÉÉ 
.
ÉÉ 
FeaturedImage
ÉÉ &
=
ÉÉ' (
SetFeaturedImage
ÉÉ) 9
(
ÉÉ9 :
item
ÉÉ: >
.
ÉÉ> ?
UserId
ÉÉ? E
,
ÉÉE F
item
ÉÉG K
.
ÉÉK L
FeaturedImage
ÉÉL Y
)
ÉÉY Z
;
ÉÉZ [
}
ÑÑ 
item
ÜÜ 
.
ÜÜ 
	LikeCount
ÜÜ 
=
ÜÜ  
likeRepository
ÜÜ! /
.
ÜÜ/ 0
GetAll
ÜÜ0 6
(
ÜÜ6 7
)
ÜÜ7 8
.
ÜÜ8 9
Count
ÜÜ9 >
(
ÜÜ> ?
x
ÜÜ? @
=>
ÜÜA C
x
ÜÜD E
.
ÜÜE F
	ContentId
ÜÜF O
==
ÜÜP R
item
ÜÜS W
.
ÜÜW X
Id
ÜÜX Z
)
ÜÜZ [
;
ÜÜ[ \
item
àà 
.
àà 
CommentCount
àà !
=
àà" #
commentRepository
àà$ 5
.
àà5 6
GetAll
àà6 <
(
àà< =
)
àà= >
.
àà> ?
Count
àà? D
(
ààD E
x
ààE F
=>
ààG I
x
ààJ K
.
ààK L
UserContentId
ààL Y
==
ààZ \
item
àà] a
.
ààa b
Id
ààb d
)
ààd e
;
ààe f
if
ää 
(
ää 
currentUserId
ää !
!=
ää" $
Guid
ää% )
.
ää) *
Empty
ää* /
)
ää/ 0
{
ãã 
item
åå 
.
åå 
CurrentUserLiked
åå )
=
åå* +
likeRepository
åå, :
.
åå: ;
GetAll
åå; A
(
ååA B
)
ååB C
.
ååC D
Any
ååD G
(
ååG H
x
ååH I
=>
ååJ L
x
ååM N
.
ååN O
	ContentId
ååO X
==
ååY [
item
åå\ `
.
åå` a
Id
ååa c
&&
ååd f
x
ååg h
.
ååh i
UserId
ååi o
==
ååp r
currentUserIdåås Ä
)ååÄ Å
;ååÅ Ç
IOrderedQueryable
éé %
<
éé% & 
UserContentComment
éé& 8
>
éé8 9
comments
éé: B
=
ééC D
commentRepository
ééE V
.
ééV W
GetAll
ééW ]
(
éé] ^
)
éé^ _
.
éé_ `
Where
éé` e
(
éée f
x
ééf g
=>
ééh j
x
éék l
.
éél m
UserContentId
éém z
==
éé{ }
iteméé~ Ç
.ééÇ É
IdééÉ Ö
)ééÖ Ü
.ééÜ á
OrderByééá é
(ééé è
xééè ê
=>ééë ì
xééî ï
.ééï ñ

CreateDateééñ †
)éé† °
;éé° ¢

IQueryable
êê 
<
êê )
UserContentCommentViewModel
êê :
>
êê: ;

commentsVm
êê< F
=
êêG H
comments
êêI Q
.
êêQ R
	ProjectTo
êêR [
<
êê[ \)
UserContentCommentViewModel
êê\ w
>
êêw x
(
êêx y
mapper
êêy 
.êê Ä%
ConfigurationProviderêêÄ ï
)êêï ñ
;êêñ ó
item
íí 
.
íí 
Comments
íí !
=
íí" #

commentsVm
íí$ .
.
íí. /
ToList
íí/ 5
(
íí5 6
)
íí6 7
;
íí7 8
foreach
îî 
(
îî )
UserContentCommentViewModel
îî 8
comment
îî9 @
in
îîA C
item
îîD H
.
îîH I
Comments
îîI Q
)
îîQ R
{
ïï 
comment
ññ 
.
ññ  

AuthorName
ññ  *
=
ññ+ ,
string
ññ- 3
.
ññ3 4 
IsNullOrWhiteSpace
ññ4 F
(
ññF G
comment
ññG N
.
ññN O

AuthorName
ññO Y
)
ññY Z
?
ññ[ \
$str
ññ] k
:
ññl m
comment
ññn u
.
ññu v

AuthorNameññv Ä
;ññÄ Å
comment
óó 
.
óó  
AuthorPicture
óó  -
=
óó. /
UrlFormatter
óó0 <
.
óó< =
ProfileImage
óó= I
(
óóI J
comment
óóJ Q
.
óóQ R
UserId
óóR X
)
óóX Y
;
óóY Z
comment
òò 
.
òò  
Text
òò  $
=
òò% &
string
òò' -
.
òò- . 
IsNullOrWhiteSpace
òò. @
(
òò@ A
comment
òòA H
.
òòH I
Text
òòI M
)
òòM N
?
òòO P
$str
òòQ u
:
òòv w
comment
òòx 
.òò Ä
TextòòÄ Ñ
;òòÑ Ö
}
ôô 
}
öö 
item
úú 
.
úú 
Content
úú 
=
úú !
FormatContentToShow
úú 2
(
úú2 3
item
úú3 7
.
úú7 8
Content
úú8 ?
)
úú? @
;
úú@ A
item
ùù 
.
ùù 
UserContentType
ùù $
=
ùù% &
UserContentType
ùù' 6
.
ùù6 7
Post
ùù7 ;
;
ùù; <
}
ûû 
return
†† 

viewModels
†† 
;
†† 
}
°° 	
private
££ 
static
££ 
string
££ 
SetFeaturedImage
££ .
(
££. /
Guid
££/ 3
userId
££4 :
,
££: ;
string
££< B
featuredImage
££C P
)
££P Q
{
§§ 	
return
•• 
string
•• 
.
••  
IsNullOrWhiteSpace
•• ,
(
••, -
featuredImage
••- :
)
••: ;
||
••< >
featuredImage
••? L
.
••L M
Equals
••M S
(
••S T
	Constants
••T ]
.
••] ^"
DefaultFeaturedImage
••^ r
)
••r s
?
••t u
	Constants
••v 
.•• Ä$
DefaultFeaturedImage••Ä î
:••ï ñ
UrlFormatter••ó £
.••£ §
Image••§ ©
(••© ™
userId••™ ∞
,••∞ ±
BlobType••≤ ∫
.••∫ ª
FeaturedImage••ª »
,••» …
featuredImage••  ◊
)••◊ ÿ
;••ÿ Ÿ
}
¶¶ 	
private
®® 
string
®® !
FormatContentToShow
®® *
(
®®* +
string
®®+ 1
content
®®2 9
)
®®9 :
{
©© 	
content
™™ 
.
™™ 
Replace
™™ 
(
™™ 
$str
™™ -
,
™™- .
$str
™™/ Q
)
™™Q R
;
™™R S
string
¨¨ 

patternUrl
¨¨ 
=
¨¨ 
$str¨¨  ú
;¨¨ú ù
Regex
ÆÆ 

regexImage
ÆÆ 
=
ÆÆ 
new
ÆÆ "
Regex
ÆÆ# (
(
ÆÆ( )

patternUrl
ÆÆ) 3
)
ÆÆ3 4
;
ÆÆ4 5
MatchCollection
∞∞ 

matchesImg
∞∞ &
=
∞∞' (

regexImage
∞∞) 3
.
∞∞3 4
Matches
∞∞4 ;
(
∞∞; <
content
∞∞< C
)
∞∞C D
;
∞∞D E
bool
≤≤ 
ismatch
≤≤ 
=
≤≤ 

regexImage
≤≤ %
.
≤≤% &
IsMatch
≤≤& -
(
≤≤- .
content
≤≤. 5
)
≤≤5 6
;
≤≤6 7
foreach
¥¥ 
(
¥¥ 
Match
¥¥ 
match
¥¥  
in
¥¥! #

matchesImg
¥¥$ .
)
¥¥. /
{
µµ 
string
∂∂ 
	toReplace
∂∂  
=
∂∂! "
match
∂∂# (
.
∂∂( )
Groups
∂∂) /
[
∂∂/ 0
$num
∂∂0 1
]
∂∂1 2
.
∂∂2 3
Value
∂∂3 8
;
∂∂8 9
string
∑∑ 
	urlBefore
∑∑  
=
∑∑! "
match
∑∑# (
.
∑∑( )
Groups
∑∑) /
[
∑∑/ 0
$num
∑∑0 1
]
∑∑1 2
.
∑∑2 3
Value
∑∑3 8
;
∑∑8 9
string
∏∏ 
url
∏∏ 
=
∏∏ 
match
∏∏ "
.
∏∏" #
Groups
∏∏# )
[
∏∏) *
$num
∏∏* +
]
∏∏+ ,
.
∏∏, -
Value
∏∏- 2
;
∏∏2 3
string
ππ 
urlComplement
ππ $
=
ππ% &
match
ππ' ,
.
ππ, -
Groups
ππ- 3
[
ππ3 4
$num
ππ4 5
]
ππ5 6
.
ππ6 7
Value
ππ7 <
;
ππ< =
string
∫∫ 
urlAfter
∫∫ 
=
∫∫  !
match
∫∫" '
.
∫∫' (
Groups
∫∫( .
[
∫∫. /
$num
∫∫/ 0
]
∫∫0 1
.
∫∫1 2
Value
∫∫2 7
;
∫∫7 8
url
ºº 
=
ºº 
!
ºº 
	toReplace
ºº  
.
ºº  !
ToLower
ºº! (
(
ºº( )
)
ºº) *
.
ºº* +

StartsWith
ºº+ 5
(
ºº5 6
$str
ºº6 <
)
ºº< =
?
ºº> ?
String
ºº@ F
.
ººF G
Format
ººG M
(
ººM N
$str
ººN Z
,
ººZ [
url
ºº\ _
)
ºº_ `
:
ººa b
url
ººc f
;
ººf g
string
ææ 
newText
ææ 
=
ææ  
string
ææ! '
.
ææ' (
Empty
ææ( -
;
ææ- .
if
øø 
(
øø 
string
øø 
.
øø  
IsNullOrWhiteSpace
øø -
(
øø- .
	urlBefore
øø. 7
)
øø7 8
&&
øø9 ;
string
øø< B
.
øøB C 
IsNullOrWhiteSpace
øøC U
(
øøU V
urlAfter
øøV ^
)
øø^ _
)
øø_ `
{
¿¿ 
newText
¡¡ 
=
¡¡ 
string
¡¡ $
.
¡¡$ %
Format
¡¡% +
(
¡¡+ ,
$str
¡¡, r
,
¡¡r s
url
¡¡t w
)
¡¡w x
;
¡¡x y
}
¬¬ 
else
√√ 
{
ƒƒ 
newText
≈≈ 
=
≈≈ 
String
≈≈ $
.
≈≈$ %
Format
≈≈% +
(
≈≈+ ,
$str
≈≈, A
,
≈≈A B
url
≈≈C F
)
≈≈F G
;
≈≈G H
}
∆∆ 
content
»» 
=
»» 
content
»» !
.
»»! "
Replace
»»" )
(
»») *
	toReplace
»»* 3
,
»»3 4
newText
»»5 <
)
»»< =
;
»»= >
}
…… 
return
ÀÀ 
content
ÀÀ 
;
ÀÀ 
}
ÃÃ 	
}
ÕÕ 
}ŒŒ ñc
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\UserContentCommentAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class (
UserContentCommentAppService -
:. /)
IUserContentCommentAppService0 M
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly )
IUserContentCommentRepository 6
_repository7 B
;B C
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public (
UserContentCommentAppService +
(+ ,
IMapper, 3
mapper4 :
,: ;
IUnitOfWork< G

unitOfWorkH R
,R S)
IUserContentCommentRepositoryT q

repositoryr |
)| }
{ 	
_mapper 
= 
mapper 
; 
_unitOfWork 
= 

unitOfWork $
;$ %
_repository 
= 

repository $
;$ %
} 	
public 
OperationResultVo  
<  !
int! $
>$ %
Count& +
(+ ,
), -
{ 	
OperationResultVo 
< 
int !
>! "
result# )
;) *
try!! 
{"" 
int## 
count## 
=## 
_repository## '
.##' (
GetAll##( .
(##. /
)##/ 0
.##0 1
Count##1 6
(##6 7
)##7 8
;##8 9
result%% 
=%% 
new%% 
OperationResultVo%% .
<%%. /
int%%/ 2
>%%2 3
(%%3 4
count%%4 9
)%%9 :
;%%: ;
}&& 
catch'' 
('' 
	Exception'' 
ex'' 
)''  
{(( 
result)) 
=)) 
new)) 
OperationResultVo)) .
<)). /
int))/ 2
>))2 3
())3 4
ex))4 6
.))6 7
Message))7 >
)))> ?
;))? @
}** 
return,, 
result,, 
;,, 
}-- 	
public// !
OperationResultListVo// $
<//$ %'
UserContentCommentViewModel//% @
>//@ A
GetAll//B H
(//H I
)//I J
{00 	!
OperationResultListVo11 !
<11! "'
UserContentCommentViewModel11" =
>11= >
result11? E
;11E F
try33 
{44 

IQueryable55 
<55 
UserContentComment55 -
>55- .
	allModels55/ 8
=559 :
_repository55; F
.55F G
GetAll55G M
(55M N
)55N O
;55O P
IEnumerable77 
<77 '
UserContentCommentViewModel77 7
>777 8
vms779 <
=77= >
_mapper77? F
.77F G
Map77G J
<77J K
IEnumerable77K V
<77V W
UserContentComment77W i
>77i j
,77j k
IEnumerable77l w
<77w x(
UserContentCommentViewModel	77x ì
>
77ì î
>
77î ï
(
77ï ñ
	allModels
77ñ ü
)
77ü †
;
77† °
result99 
=99 
new99 !
OperationResultListVo99 2
<992 3'
UserContentCommentViewModel993 N
>99N O
(99O P
vms99P S
)99S T
;99T U
}:: 
catch;; 
(;; 
	Exception;; 
ex;; 
);;  
{<< 
result== 
=== 
new== !
OperationResultListVo== 2
<==2 3'
UserContentCommentViewModel==3 N
>==N O
(==O P
ex==P R
.==R S
Message==S Z
)==Z [
;==[ \
}>> 
return@@ 
result@@ 
;@@ 
}AA 	
publicCC 
OperationResultVoCC  
<CC  !'
UserContentCommentViewModelCC! <
>CC< =
GetByIdCC> E
(CCE F
GuidCCF J
idCCK M
)CCM N
{DD 	
OperationResultVoEE 
<EE '
UserContentCommentViewModelEE 9
>EE9 :
resultEE; A
;EEA B
tryGG 
{HH 
UserContentCommentII "
modelII# (
=II) *
_repositoryII+ 6
.II6 7
GetByIdII7 >
(II> ?
idII? A
)IIA B
;IIB C'
UserContentCommentViewModelKK +
vmKK, .
=KK/ 0
_mapperKK1 8
.KK8 9
MapKK9 <
<KK< ='
UserContentCommentViewModelKK= X
>KKX Y
(KKY Z
modelKKZ _
)KK_ `
;KK` a
resultMM 
=MM 
newMM 
OperationResultVoMM .
<MM. /'
UserContentCommentViewModelMM/ J
>MMJ K
(MMK L
vmMML N
)MMN O
;MMO P
}NN 
catchOO 
(OO 
	ExceptionOO 
exOO 
)OO  
{PP 
resultQQ 
=QQ 
newQQ 
OperationResultVoQQ .
<QQ. /'
UserContentCommentViewModelQQ/ J
>QQJ K
(QQK L
exQQL N
.QQN O
MessageQQO V
)QQV W
;QQW X
}RR 
returnTT 
resultTT 
;TT 
}UU 	
publicWW 
OperationResultVoWW  
RemoveWW! '
(WW' (
GuidWW( ,
idWW- /
)WW/ 0
{XX 	
OperationResultVoYY 
resultYY $
;YY$ %
try[[ 
{\\ 
_repository__ 
.__ 
Remove__ "
(__" #
id__# %
)__% &
;__& '
_unitOfWorkaa 
.aa 
Commitaa "
(aa" #
)aa# $
;aa$ %
resultcc 
=cc 
newcc 
OperationResultVocc .
(cc. /
truecc/ 3
)cc3 4
;cc4 5
}dd 
catchee 
(ee 
	Exceptionee 
exee 
)ee  
{ff 
resultgg 
=gg 
newgg 
OperationResultVogg .
(gg. /
exgg/ 1
.gg1 2
Messagegg2 9
)gg9 :
;gg: ;
}hh 
returnjj 
resultjj 
;jj 
}kk 	
publicmm 
OperationResultVomm  
<mm  !
Guidmm! %
>mm% &
Savemm' +
(mm+ ,'
UserContentCommentViewModelmm, G
	viewModelmmH Q
)mmQ R
{nn 	
OperationResultVooo 
<oo 
Guidoo "
>oo" #
resultoo$ *
;oo* +
tryqq 
{rr 
UserContentCommentss "
modelss# (
;ss( )
UserContentCommentww "
existingww# +
=ww, -
_repositoryww. 9
.ww9 :
GetByIdww: A
(wwA B
	viewModelwwB K
.wwK L
IdwwL N
)wwN O
;wwO P
ifxx 
(xx 
existingxx 
!=xx 
nullxx  $
)xx$ %
{yy 
modelzz 
=zz 
_mapperzz #
.zz# $
Mapzz$ '
(zz' (
	viewModelzz( 1
,zz1 2
existingzz3 ;
)zz; <
;zz< =
}{{ 
else|| 
{}} 
model~~ 
=~~ 
_mapper~~ #
.~~# $
Map~~$ '
<~~' (
UserContentComment~~( :
>~~: ;
(~~; <
	viewModel~~< E
)~~E F
;~~F G
} 
if
ÅÅ 
(
ÅÅ 
	viewModel
ÅÅ 
.
ÅÅ 
Id
ÅÅ  
==
ÅÅ! #
Guid
ÅÅ$ (
.
ÅÅ( )
Empty
ÅÅ) .
)
ÅÅ. /
{
ÇÇ 
_repository
ÉÉ 
.
ÉÉ  
Add
ÉÉ  #
(
ÉÉ# $
model
ÉÉ$ )
)
ÉÉ) *
;
ÉÉ* +
	viewModel
ÑÑ 
.
ÑÑ 
Id
ÑÑ  
=
ÑÑ! "
model
ÑÑ# (
.
ÑÑ( )
Id
ÑÑ) +
;
ÑÑ+ ,
}
ÖÖ 
else
ÜÜ 
{
áá 
_repository
àà 
.
àà  
Update
àà  &
(
àà& '
model
àà' ,
)
àà, -
;
àà- .
}
ââ 
_unitOfWork
ãã 
.
ãã 
Commit
ãã "
(
ãã" #
)
ãã# $
;
ãã$ %
result
çç 
=
çç 
new
çç 
OperationResultVo
çç .
<
çç. /
Guid
çç/ 3
>
çç3 4
(
çç4 5
model
çç5 :
.
çç: ;
Id
çç; =
)
çç= >
;
çç> ?
}
éé 
catch
èè 
(
èè 
	Exception
èè 
ex
èè 
)
èè  
{
êê 
result
ëë 
=
ëë 
new
ëë 
OperationResultVo
ëë .
<
ëë. /
Guid
ëë/ 3
>
ëë3 4
(
ëë4 5
ex
ëë5 7
.
ëë7 8
Message
ëë8 ?
)
ëë? @
;
ëë@ A
}
íí 
return
îî 
result
îî 
;
îî 
}
ïï 	
public
óó 
OperationResultVo
óó  
Comment
óó! (
(
óó( ))
UserContentCommentViewModel
óó) D
	viewModel
óóE N
)
óóN O
{
òò 	
OperationResultVo
ôô 
response
ôô &
;
ôô& '
bool
õõ "
commentAlreadyExists
õõ %
=
õõ& '
_repository
õõ( 3
.
õõ3 4
GetAll
õõ4 :
(
õõ: ;
)
õõ; <
.
õõ< =
Any
õõ= @
(
õõ@ A
x
õõA B
=>
õõC E
x
õõF G
.
õõG H
UserContentId
õõH U
==
õõV X
	viewModel
õõY b
.
õõb c
UserContentId
õõc p
&&
õõq s
x
õõt u
.
õõu v
UserId
õõv |
==
õõ} 
	viewModelõõÄ â
.õõâ ä
UserIdõõä ê
&&õõë ì
xõõî ï
.õõï ñ
Textõõñ ö
.õõö õ
Equalsõõõ °
(õõ° ¢
	viewModelõõ¢ ´
.õõ´ ¨
Textõõ¨ ∞
)õõ∞ ±
)õõ± ≤
;õõ≤ ≥
if
ùù 
(
ùù "
commentAlreadyExists
ùù $
)
ùù$ %
{
ûû 
response
üü 
=
üü 
new
üü 
OperationResultVo
üü 0
(
üü0 1
false
üü1 6
)
üü6 7
;
üü7 8
response
†† 
.
†† 
Message
††  
=
††! "
$str
††# 7
;
††7 8
}
°° 
else
¢¢ 
{
££  
UserContentComment
§§ "
model
§§# (
=
§§) *
_mapper
§§+ 2
.
§§2 3
Map
§§3 6
<
§§6 7 
UserContentComment
§§7 I
>
§§I J
(
§§J K
	viewModel
§§K T
)
§§T U
;
§§U V
_repository
¶¶ 
.
¶¶ 
Add
¶¶ 
(
¶¶  
model
¶¶  %
)
¶¶% &
;
¶¶& '
_unitOfWork
®® 
.
®® 
Commit
®® "
(
®®" #
)
®®# $
;
®®$ %
int
™™ 
newCount
™™ 
=
™™ 
_repository
™™ *
.
™™* +
GetAll
™™+ 1
(
™™1 2
)
™™2 3
.
™™3 4
Count
™™4 9
(
™™9 :
x
™™: ;
=>
™™< >
x
™™? @
.
™™@ A
UserContentId
™™A N
==
™™O Q
model
™™R W
.
™™W X
UserContentId
™™X e
&&
™™f h
x
™™i j
.
™™j k
UserId
™™k q
==
™™r t
model
™™u z
.
™™z {
UserId™™{ Å
)™™Å Ç
;™™Ç É
response
¨¨ 
=
¨¨ 
new
¨¨ 
OperationResultVo
¨¨ 0
<
¨¨0 1
int
¨¨1 4
>
¨¨4 5
(
¨¨5 6
newCount
¨¨6 >
)
¨¨> ?
;
¨¨? @
}
≠≠ 
return
∞∞ 
response
∞∞ 
;
∞∞ 
}
±± 	
}
≤≤ 
}≥≥ ém
qC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\UserFollowAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class  
UserFollowAppService %
:& '
BaseAppService( 6
,6 7!
IUserFollowAppService8 M
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly $
IUserFollowDomainService 1#
gameFollowDomainService2 I
;I J
public  
UserFollowAppService #
(# $
IMapper$ +
mapper, 2
,2 3
IUnitOfWork4 ?

unitOfWork@ J
, $
IUserFollowDomainService &#
gameFollowDomainService' >
)> ?
{ 	
this 
. 
mapper 
= 
mapper  
;  !
this 
. 

unitOfWork 
= 

unitOfWork (
;( )
this 
. #
gameFollowDomainService (
=) *#
gameFollowDomainService+ B
;B C
} 	
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
OperationResultVo  
<  !
int! $
>$ %
Count& +
(+ ,
), -
{ 	
OperationResultVo 
< 
int !
>! "
result# )
;) *
try!! 
{"" 
int## 
count## 
=## #
gameFollowDomainService## 3
.##3 4
Count##4 9
(##9 :
)##: ;
;##; <
result%% 
=%% 
new%% 
OperationResultVo%% .
<%%. /
int%%/ 2
>%%2 3
(%%3 4
count%%4 9
)%%9 :
;%%: ;
}&& 
catch'' 
('' 
	Exception'' 
ex'' 
)''  
{(( 
result)) 
=)) 
new)) 
OperationResultVo)) .
<)). /
int))/ 2
>))2 3
())3 4
ex))4 6
.))6 7
Message))7 >
)))> ?
;))? @
}** 
return,, 
result,, 
;,, 
}-- 	
public// !
OperationResultListVo// $
<//$ %
UserFollowViewModel//% 8
>//8 9
GetAll//: @
(//@ A
)//A B
{00 	!
OperationResultListVo11 !
<11! "
UserFollowViewModel11" 5
>115 6
result117 =
;11= >
try33 
{44 
IEnumerable55 
<55 

UserFollow55 &
>55& '
	allModels55( 1
=552 3
this554 8
.558 9#
gameFollowDomainService559 P
.55P Q
GetAll55Q W
(55W X
)55X Y
;55Y Z
IEnumerable77 
<77 
UserFollowViewModel77 /
>77/ 0
vms771 4
=775 6
mapper777 =
.77= >
Map77> A
<77A B
IEnumerable77B M
<77M N

UserFollow77N X
>77X Y
,77Y Z
IEnumerable77[ f
<77f g
UserFollowViewModel77g z
>77z {
>77{ |
(77| }
	allModels	77} Ü
)
77Ü á
;
77á à
result99 
=99 
new99 !
OperationResultListVo99 2
<992 3
UserFollowViewModel993 F
>99F G
(99G H
vms99H K
)99K L
;99L M
}:: 
catch;; 
(;; 
	Exception;; 
ex;; 
);;  
{<< 
result== 
=== 
new== !
OperationResultListVo== 2
<==2 3
UserFollowViewModel==3 F
>==F G
(==G H
ex==H J
.==J K
Message==K R
)==R S
;==S T
}>> 
return@@ 
result@@ 
;@@ 
}AA 	
publicCC !
OperationResultListVoCC $
<CC$ %
UserFollowViewModelCC% 8
>CC8 9
GetByUserIdCC: E
(CCE F
GuidCCF J
userIdCCK Q
)CCQ R
{DD 	!
OperationResultListVoEE !
<EE! "
UserFollowViewModelEE" 5
>EE5 6
resultEE7 =
;EE= >
tryGG 
{HH 
IEnumerableII 
<II 

UserFollowII &
>II& '
	allModelsII( 1
=II2 3
thisII4 8
.II8 9#
gameFollowDomainServiceII9 P
.IIP Q
GetByUserIdIIQ \
(II\ ]
userIdII] c
)IIc d
;IId e
IEnumerableKK 
<KK 
UserFollowViewModelKK /
>KK/ 0
vmsKK1 4
=KK5 6
mapperKK7 =
.KK= >
MapKK> A
<KKA B
IEnumerableKKB M
<KKM N

UserFollowKKN X
>KKX Y
,KKY Z
IEnumerableKK[ f
<KKf g
UserFollowViewModelKKg z
>KKz {
>KK{ |
(KK| }
	allModels	KK} Ü
)
KKÜ á
;
KKá à
resultMM 
=MM 
newMM !
OperationResultListVoMM 2
<MM2 3
UserFollowViewModelMM3 F
>MMF G
(MMG H
vmsMMH K
)MMK L
;MML M
}NN 
catchOO 
(OO 
	ExceptionOO 
exOO 
)OO  
{PP 
resultQQ 
=QQ 
newQQ !
OperationResultListVoQQ 2
<QQ2 3
UserFollowViewModelQQ3 F
>QQF G
(QQG H
exQQH J
.QQJ K
MessageQQK R
)QQR S
;QQS T
}RR 
returnTT 
resultTT 
;TT 
}UU 	
publicWW 
OperationResultVoWW  
<WW  !
UserFollowViewModelWW! 4
>WW4 5
GetByIdWW6 =
(WW= >
GuidWW> B
idWWC E
)WWE F
{XX 	
OperationResultVoYY 
<YY 
UserFollowViewModelYY 1
>YY1 2
resultYY3 9
;YY9 :
try[[ 
{\\ 

UserFollow]] 
model]]  
=]]! "
this]]# '
.]]' (#
gameFollowDomainService]]( ?
.]]? @
GetById]]@ G
(]]G H
id]]H J
)]]J K
;]]K L
UserFollowViewModel__ #
vm__$ &
=__' (
mapper__) /
.__/ 0
Map__0 3
<__3 4
UserFollowViewModel__4 G
>__G H
(__H I
model__I N
)__N O
;__O P
resultaa 
=aa 
newaa 
OperationResultVoaa .
<aa. /
UserFollowViewModelaa/ B
>aaB C
(aaC D
vmaaD F
)aaF G
;aaG H
}bb 
catchcc 
(cc 
	Exceptioncc 
excc 
)cc  
{dd 
resultee 
=ee 
newee 
OperationResultVoee .
<ee. /
UserFollowViewModelee/ B
>eeB C
(eeC D
exeeD F
.eeF G
MessageeeG N
)eeN O
;eeO P
}ff 
returnhh 
resulthh 
;hh 
}ii 	
publickk 
OperationResultVokk  
Removekk! '
(kk' (
Guidkk( ,
idkk- /
)kk/ 0
{ll 	
OperationResultVomm 
resultmm $
;mm$ %
tryoo 
{pp 
thisss 
.ss #
gameFollowDomainServicess ,
.ss, -
Removess- 3
(ss3 4
idss4 6
)ss6 7
;ss7 8

unitOfWorkuu 
.uu 
Commituu !
(uu! "
)uu" #
;uu# $
resultww 
=ww 
newww 
OperationResultVoww .
(ww. /
trueww/ 3
)ww3 4
;ww4 5
}xx 
catchyy 
(yy 
	Exceptionyy 
exyy 
)yy  
{zz 
result{{ 
={{ 
new{{ 
OperationResultVo{{ .
({{. /
ex{{/ 1
.{{1 2
Message{{2 9
){{9 :
;{{: ;
}|| 
return~~ 
result~~ 
;~~ 
} 	
public
ÅÅ 
OperationResultVo
ÅÅ  
<
ÅÅ  !
Guid
ÅÅ! %
>
ÅÅ% &
Save
ÅÅ' +
(
ÅÅ+ ,!
UserFollowViewModel
ÅÅ, ?
	viewModel
ÅÅ@ I
)
ÅÅI J
{
ÇÇ 	
OperationResultVo
ÉÉ 
<
ÉÉ 
Guid
ÉÉ "
>
ÉÉ" #
result
ÉÉ$ *
;
ÉÉ* +
try
ÖÖ 
{
ÜÜ 

UserFollow
áá 
model
áá  
;
áá  !

UserFollow
ãã 
existing
ãã #
=
ãã$ %
this
ãã& *
.
ãã* +%
gameFollowDomainService
ãã+ B
.
ããB C
GetById
ããC J
(
ããJ K
	viewModel
ããK T
.
ããT U
Id
ããU W
)
ããW X
;
ããX Y
if
åå 
(
åå 
existing
åå 
!=
åå 
null
åå  $
)
åå$ %
{
çç 
model
éé 
=
éé 
mapper
éé "
.
éé" #
Map
éé# &
(
éé& '
	viewModel
éé' 0
,
éé0 1
existing
éé2 :
)
éé: ;
;
éé; <
}
èè 
else
êê 
{
ëë 
model
íí 
=
íí 
mapper
íí "
.
íí" #
Map
íí# &
<
íí& '

UserFollow
íí' 1
>
íí1 2
(
íí2 3
	viewModel
íí3 <
)
íí< =
;
íí= >
}
ìì 
if
ïï 
(
ïï 
	viewModel
ïï 
.
ïï 
Id
ïï  
==
ïï! #
Guid
ïï$ (
.
ïï( )
Empty
ïï) .
)
ïï. /
{
ññ 
this
óó 
.
óó %
gameFollowDomainService
óó 0
.
óó0 1
Add
óó1 4
(
óó4 5
model
óó5 :
)
óó: ;
;
óó; <
	viewModel
òò 
.
òò 
Id
òò  
=
òò! "
model
òò# (
.
òò( )
Id
òò) +
;
òò+ ,
}
ôô 
else
öö 
{
õõ 
this
úú 
.
úú %
gameFollowDomainService
úú 0
.
úú0 1
Update
úú1 7
(
úú7 8
model
úú8 =
)
úú= >
;
úú> ?
}
ùù 

unitOfWork
üü 
.
üü 
Commit
üü !
(
üü! "
)
üü" #
;
üü# $
result
°° 
=
°° 
new
°° 
OperationResultVo
°° .
<
°°. /
Guid
°°/ 3
>
°°3 4
(
°°4 5
model
°°5 :
.
°°: ;
Id
°°; =
)
°°= >
;
°°> ?
}
¢¢ 
catch
££ 
(
££ 
	Exception
££ 
ex
££ 
)
££  
{
§§ 
result
•• 
=
•• 
new
•• 
OperationResultVo
•• .
<
••. /
Guid
••/ 3
>
••3 4
(
••4 5
ex
••5 7
.
••7 8
Message
••8 ?
)
••? @
;
••@ A
}
¶¶ 
return
®® 
result
®® 
;
®® 
}
©© 	
public
´´ #
OperationResultListVo
´´ $
<
´´$ %!
UserFollowViewModel
´´% 8
>
´´8 9
GetByFollowedId
´´: I
(
´´I J
Guid
´´J N
followUserId
´´O [
)
´´[ \
{
¨¨ 	#
OperationResultListVo
≠≠ !
<
≠≠! "!
UserFollowViewModel
≠≠" 5
>
≠≠5 6
result
≠≠7 =
;
≠≠= >
try
ØØ 
{
∞∞ 
IEnumerable
±± 
<
±± 

UserFollow
±± &
>
±±& '
	allModels
±±( 1
=
±±2 3
this
±±4 8
.
±±8 9%
gameFollowDomainService
±±9 P
.
±±P Q
Get
±±Q T
(
±±T U
x
±±U V
=>
±±W Y
x
±±Z [
.
±±[ \
FollowUserId
±±\ h
==
±±i k
followUserId
±±l x
)
±±x y
;
±±y z
IEnumerable
≥≥ 
<
≥≥ !
UserFollowViewModel
≥≥ /
>
≥≥/ 0
vms
≥≥1 4
=
≥≥5 6
mapper
≥≥7 =
.
≥≥= >
Map
≥≥> A
<
≥≥A B
IEnumerable
≥≥B M
<
≥≥M N

UserFollow
≥≥N X
>
≥≥X Y
,
≥≥Y Z
IEnumerable
≥≥[ f
<
≥≥f g!
UserFollowViewModel
≥≥g z
>
≥≥z {
>
≥≥{ |
(
≥≥| }
	allModels≥≥} Ü
)≥≥Ü á
;≥≥á à
result
µµ 
=
µµ 
new
µµ #
OperationResultListVo
µµ 2
<
µµ2 3!
UserFollowViewModel
µµ3 F
>
µµF G
(
µµG H
vms
µµH K
)
µµK L
;
µµL M
}
∂∂ 
catch
∑∑ 
(
∑∑ 
	Exception
∑∑ 
ex
∑∑ 
)
∑∑  
{
∏∏ 
result
ππ 
=
ππ 
new
ππ #
OperationResultListVo
ππ 2
<
ππ2 3!
UserFollowViewModel
ππ3 F
>
ππF G
(
ππG H
ex
ππH J
.
ππJ K
Message
ππK R
)
ππR S
;
ππS T
}
∫∫ 
return
ºº 
result
ºº 
;
ºº 
}
ΩΩ 	
}
ææ 
}øø ›X
vC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\Services\UserPreferencesAppService.cs
	namespace 	
IndieVisible
 
. 
Application "
." #
Services# +
{ 
public 

class %
UserPreferencesAppService *
:+ ,
BaseAppService- ;
,; <&
IUserPreferencesAppService= W
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly &
IUserPreferencesRepository 3
_repository4 ?
;? @
public 
Guid 
CurrentUserId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public %
UserPreferencesAppService (
(( )
IMapper) 0
mapper1 7
,7 8
IUnitOfWork9 D

unitOfWorkE O
,O P&
IUserPreferencesRepositoryQ k

repositoryl v
)v w
{ 	
_mapper 
= 
mapper 
; 
_unitOfWork 
= 

unitOfWork $
;$ %
_repository 
= 

repository $
;$ %
} 	
public 
OperationResultVo  
<  !
int! $
>$ %
Count& +
(+ ,
), -
{ 	
OperationResultVo 
< 
int !
>! "
result# )
;) *
try!! 
{"" 
int## 
count## 
=## 
_repository## '
.##' (
GetAll##( .
(##. /
)##/ 0
.##0 1
Count##1 6
(##6 7
)##7 8
;##8 9
result%% 
=%% 
new%% 
OperationResultVo%% .
<%%. /
int%%/ 2
>%%2 3
(%%3 4
count%%4 9
)%%9 :
;%%: ;
}&& 
catch'' 
('' 
	Exception'' 
ex'' 
)''  
{(( 
result)) 
=)) 
new)) 
OperationResultVo)) .
<)). /
int))/ 2
>))2 3
())3 4
ex))4 6
.))6 7
Message))7 >
)))> ?
;))? @
}** 
return,, 
result,, 
;,, 
}-- 	
public// !
OperationResultListVo// $
<//$ %$
UserPreferencesViewModel//% =
>//= >
GetAll//? E
(//E F
)//F G
{00 	!
OperationResultListVo11 !
<11! "$
UserPreferencesViewModel11" :
>11: ;
result11< B
;11B C
try33 
{44 

IQueryable55 
<55 
UserPreferences55 *
>55* +
	allModels55, 5
=556 7
_repository558 C
.55C D
GetAll55D J
(55J K
)55K L
;55L M
IEnumerable77 
<77 $
UserPreferencesViewModel77 4
>774 5
vms776 9
=77: ;
_mapper77< C
.77C D
Map77D G
<77G H
IEnumerable77H S
<77S T
UserPreferences77T c
>77c d
,77d e
IEnumerable77f q
<77q r%
UserPreferencesViewModel	77r ä
>
77ä ã
>
77ã å
(
77å ç
	allModels
77ç ñ
)
77ñ ó
;
77ó ò
result99 
=99 
new99 !
OperationResultListVo99 2
<992 3$
UserPreferencesViewModel993 K
>99K L
(99L M
vms99M P
)99P Q
;99Q R
}:: 
catch;; 
(;; 
	Exception;; 
ex;; 
);;  
{<< 
result== 
=== 
new== !
OperationResultListVo== 2
<==2 3$
UserPreferencesViewModel==3 K
>==K L
(==L M
ex==M O
.==O P
Message==P W
)==W X
;==X Y
}>> 
return@@ 
result@@ 
;@@ 
}AA 	
publicCC 
OperationResultVoCC  
<CC  !$
UserPreferencesViewModelCC! 9
>CC9 :
GetByIdCC; B
(CCB C
GuidCCC G
idCCH J
)CCJ K
{DD 	
OperationResultVoEE 
<EE $
UserPreferencesViewModelEE 6
>EE6 7
resultEE8 >
;EE> ?
tryGG 
{HH 
UserPreferencesII 
modelII  %
=II& '
_repositoryII( 3
.II3 4
GetByIdII4 ;
(II; <
idII< >
)II> ?
;II? @$
UserPreferencesViewModelKK (
vmKK) +
=KK, -
_mapperKK. 5
.KK5 6
MapKK6 9
<KK9 :$
UserPreferencesViewModelKK: R
>KKR S
(KKS T
modelKKT Y
)KKY Z
;KKZ [
resultMM 
=MM 
newMM 
OperationResultVoMM .
<MM. /$
UserPreferencesViewModelMM/ G
>MMG H
(MMH I
vmMMI K
)MMK L
;MML M
}NN 
catchOO 
(OO 
	ExceptionOO 
exOO 
)OO  
{PP 
resultQQ 
=QQ 
newQQ 
OperationResultVoQQ .
<QQ. /$
UserPreferencesViewModelQQ/ G
>QQG H
(QQH I
exQQI K
.QQK L
MessageQQL S
)QQS T
;QQT U
}RR 
returnTT 
resultTT 
;TT 
}UU 	
publicWW $
UserPreferencesViewModelWW '
GetByUserIdWW( 3
(WW3 4
GuidWW4 8
userIdWW9 ?
)WW? @
{XX 	
UserPreferencesYY 
modelYY !
=YY" #
_repositoryYY$ /
.YY/ 0
GetAllYY0 6
(YY6 7
)YY7 8
.YY8 9
FirstOrDefaultYY9 G
(YYG H
xYYH I
=>YYJ L
xYYM N
.YYN O
UserIdYYO U
==YYV X
userIdYYY _
)YY_ `
;YY` a
if[[ 
([[ 
model[[ 
==[[ 
null[[ 
)[[ 
{\\ 
model]] 
=]] 
new]] 
UserPreferences]] +
(]]+ ,
)]], -
;]]- .
model^^ 
.^^ 
UserId^^ 
=^^ 
userId^^ %
;^^% &
}__ $
UserPreferencesViewModelaa $
vmaa% '
=aa( )
_mapperaa* 1
.aa1 2
Mapaa2 5
<aa5 6$
UserPreferencesViewModelaa6 N
>aaN O
(aaO P
modelaaP U
)aaU V
;aaV W
returncc 
vmcc 
;cc 
}dd 	
publicff 
OperationResultVoff  
Removeff! '
(ff' (
Guidff( ,
idff- /
)ff/ 0
{gg 	
OperationResultVohh 
resulthh $
;hh$ %
tryjj 
{kk 
_repositorynn 
.nn 
Removenn "
(nn" #
idnn# %
)nn% &
;nn& '
_unitOfWorkpp 
.pp 
Commitpp "
(pp" #
)pp# $
;pp$ %
resultrr 
=rr 
newrr 
OperationResultVorr .
(rr. /
truerr/ 3
)rr3 4
;rr4 5
}ss 
catchtt 
(tt 
	Exceptiontt 
extt 
)tt  
{uu 
resultvv 
=vv 
newvv 
OperationResultVovv .
(vv. /
exvv/ 1
.vv1 2
Messagevv2 9
)vv9 :
;vv: ;
}ww 
returnyy 
resultyy 
;yy 
}zz 	
public|| 
OperationResultVo||  
<||  !
Guid||! %
>||% &
Save||' +
(||+ ,$
UserPreferencesViewModel||, D
	viewModel||E N
)||N O
{}} 	
OperationResultVo~~ 
<~~ 
Guid~~ "
>~~" #
result~~$ *
;~~* +
try
ÄÄ 
{
ÅÅ 
UserPreferences
ÇÇ 
model
ÇÇ  %
;
ÇÇ% &
if
ÑÑ 
(
ÑÑ 
	viewModel
ÑÑ 
.
ÑÑ 
Id
ÑÑ  
==
ÑÑ! #
	viewModel
ÑÑ$ -
.
ÑÑ- .
UserId
ÑÑ. 4
)
ÑÑ4 5
{
ÖÖ 
	viewModel
ÜÜ 
.
ÜÜ 
Id
ÜÜ  
=
ÜÜ! "
Guid
ÜÜ# '
.
ÜÜ' (
Empty
ÜÜ( -
;
ÜÜ- .
}
áá 
UserPreferences
ãã 
existing
ãã  (
=
ãã) *
_repository
ãã+ 6
.
ãã6 7
GetById
ãã7 >
(
ãã> ?
	viewModel
ãã? H
.
ããH I
Id
ããI K
)
ããK L
;
ããL M
if
åå 
(
åå 
existing
åå 
!=
åå 
null
åå  $
)
åå$ %
{
çç 
model
éé 
=
éé 
_mapper
éé #
.
éé# $
Map
éé$ '
(
éé' (
	viewModel
éé( 1
,
éé1 2
existing
éé3 ;
)
éé; <
;
éé< =
}
èè 
else
êê 
{
ëë 
model
íí 
=
íí 
_mapper
íí #
.
íí# $
Map
íí$ '
<
íí' (
UserPreferences
íí( 7
>
íí7 8
(
íí8 9
	viewModel
íí9 B
)
ííB C
;
ííC D
}
ìì 
if
ïï 
(
ïï 
	viewModel
ïï 
.
ïï 
Id
ïï  
==
ïï! #
Guid
ïï$ (
.
ïï( )
Empty
ïï) .
)
ïï. /
{
ññ 
_repository
óó 
.
óó  
Add
óó  #
(
óó# $
model
óó$ )
)
óó) *
;
óó* +
	viewModel
òò 
.
òò 
Id
òò  
=
òò! "
model
òò# (
.
òò( )
Id
òò) +
;
òò+ ,
}
ôô 
else
öö 
{
õõ 
_repository
úú 
.
úú  
Update
úú  &
(
úú& '
model
úú' ,
)
úú, -
;
úú- .
}
ùù 
_unitOfWork
üü 
.
üü 
Commit
üü "
(
üü" #
)
üü# $
;
üü$ %
result
°° 
=
°° 
new
°° 
OperationResultVo
°° .
<
°°. /
Guid
°°/ 3
>
°°3 4
(
°°4 5
model
°°5 :
.
°°: ;
Id
°°; =
)
°°= >
;
°°> ?
}
¢¢ 
catch
££ 
(
££ 
	Exception
££ 
ex
££ 
)
££  
{
§§ 
result
•• 
=
•• 
new
•• 
OperationResultVo
•• .
<
••. /
Guid
••/ 3
>
••3 4
(
••4 5
ex
••5 7
.
••7 8
Message
••8 ?
)
••? @
;
••@ A
}
¶¶ 
return
®® 
result
®® 
;
®® 
}
©© 	
}
™™ 
}´´ ¢
lC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\BaseViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
{ 
public 

abstract 
class 
BaseViewModel '
{ 
public		 
Guid		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 

CreateDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
bool 
CurrentUserLiked $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
bool  
CurrentUserFollowing (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
PermissionsVo 
Permissions (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
BaseViewModel 
( 
) 
{ 	
Permissions 
= 
new 
PermissionsVo +
(+ ,
), -
;- .
} 	
} 
} ¸	
ÑC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Brainstorm\BrainstormCommentViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .

Brainstorm. 8
{ 
public 

class &
BrainstormCommentViewModel +
:, -
BaseViewModel. ;
{ 
public		 
Guid		 
?		 
ParentCommentId		 $
{		% &
get		' *
;		* +
set		, /
;		/ 0
}		1 2
public 
Guid 
IdeaId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 

AuthorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
AuthorPicture #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
Text 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ı
ÅC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Brainstorm\BrainstormIdeaViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .

Brainstorm. 8
{ 
public 

class #
BrainstormIdeaViewModel (
:) *-
!UserGeneratedCommentBaseViewModel+ L
<L M&
BrainstormCommentViewModelM g
>g h
{ 
public		 
Guid		 
	SessionId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
[ 	
Required	 
] 
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
	VoteCount 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
CommentCount 
{  !
get" %
;% &
set' *
;* +
}, -
public 
int 
Score 
{ 
get 
; 
internal  (
set) ,
;, -
}. /
public 
	VoteValue 
CurrentUserVote (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ‘	
ÑC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Brainstorm\BrainstormSessionViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .

Brainstorm. 8
{ 
public		 

class		 &
BrainstormSessionViewModel		 +
:		, -
BaseViewModel		. ;
{

 
[ 	
Required	 
] 
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public !
BrainstormSessionType $
Type% )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
Guid 
? 
TargetContextId $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ï
ÅC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Brainstorm\BrainstormVoteViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .

Brainstorm. 8
{ 
public 

class #
BrainstormVoteViewModel (
:) *
BaseViewModel+ 8
{		 
public

 
Guid

 
VotingItemId

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
	VoteValue 
	VoteValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} æ
ÇC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Content\UserContentCommentViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Content. 5
{ 
public 

class '
UserContentCommentViewModel ,
:- .&
UserGeneratedBaseViewModel/ I
{		 
public

 
Guid

 
ParentCommentId

 #
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
0 1
public 
Guid 
UserContentId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
Text 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ƒ
ÉC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Content\UserContentListItemViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Content. 5
{ 
public 

class (
UserContentListItemViewModel -
:. /-
!UserGeneratedCommentBaseViewModel0 Q
<Q R'
UserContentCommentViewModelR m
>m n
{ 
public 
string 
FeaturedImage #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public

 
string

 
Title

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
string 
Introduction "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
Content 
{ 
get  #
;# $
set% (
;( )
}* +
public 
SupportedLanguage  
Language! )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
int 
	LikeCount 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
CommentCount 
{  !
get" %
;% &
set' *
;* +
}, -
public 
bool 
CurrentUserLiked $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
Guid 
GameId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
GameName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
bool 
	IsArticle 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
HasFeaturedImage $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public   
	MediaType   
FeaturedImageType   *
{  + ,
get  - 0
;  0 1
set  2 5
;  5 6
}  7 8
}!! 
}"" •
áC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Content\UserContentToBeFeaturedViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Content. 5
{ 
public		 

class		 ,
 UserContentToBeFeaturedViewModel		 1
:		2 3&
UserGeneratedBaseViewModel		4 N
{

 
public 
string 
FeaturedImage #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Introduction "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
Content 
{ 
get  #
;# $
set% (
;( )
}* +
public 
SupportedLanguage  
Language! )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
int 
	LikeCount 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
CommentCount 
{  !
get" %
;% &
set' *
;* +
}, -
public 
bool 
CurrentUserLiked $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
Guid 
GameId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
GameName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
bool 
	IsArticle 
{ 
get  #
;# $
set% (
;( )
}* +
public   
bool   
TitleCompliant   "
{  # $
get  % (
;  ( )
set  * -
;  - .
}  / 0
public"" 
bool"" 
IntroCompliant"" "
{""# $
get""% (
;""( )
set""* -
;""- .
}""/ 0
public## 
bool## 
ContentCompliant## $
{##% &
get##' *
;##* +
internal##, 4
set##5 8
;##8 9
}##: ;
public$$ 
bool$$ 

IsFeatured$$ 
{$$  
get$$! $
;$$$ %
internal$$& .
set$$/ 2
;$$2 3
}$$4 5
public%% 
Guid%% 
?%% 
CurrentFeatureId%% %
{%%& '
get%%( +
;%%+ ,
internal%%- 5
set%%6 9
;%%9 :
}%%; <
}&& 
}'' ≠!
{C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Content\UserContentViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Content. 5
{ 
public 

class  
UserContentViewModel %
:& '&
UserGeneratedBaseViewModel( B
{		 
[ 	
Display	 
( 
Name 
= 
$str (
)( )
]) *
public 
string 
FeaturedImage #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Display	 
( 
Name 
= 
$str  
)  !
]! "
public 
List 
< 
string 
> 
Images "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
StringLength	 
( 
$num 
) 
] 
[ 	
Display	 
( 
Name 
= 
$str 
)  
]  !
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Display	 
( 
Name 
= 
$str &
)& '
]' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! ?
)? @
]@ A
public 
string 
Introduction "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Display	 
( 
Name 
= 
$str !
)! "
]" #
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
public 
string 
Content 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
Display	 
( 
Name 
= 
$str "
)" #
]# $
public 
SupportedLanguage  
Language! )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[   	
Display  	 
(   
Name   
=   
$str   &
)  & '
]  ' (
public!! 
Guid!! 
?!! 
GameId!! 
{!! 
get!! !
;!!! "
set!!# &
;!!& '
}!!( )
public"" 
string"" 
	GameTitle"" 
{""  !
get""" %
;""% &
set""' *
;""* +
}"", -
public## 
string## 
GameThumbnail## #
{##$ %
get##& )
;##) *
set##+ .
;##. /
}##0 1
public%% 
bool%% 
HasFeaturedImage%% $
{%%% &
get%%' *
;%%* +
set%%, /
;%%/ 0
}%%1 2
public&& 
	MediaType&& 
FeaturedMediaType&& *
{&&+ ,
get&&- 0
;&&0 1
set&&2 5
;&&5 6
}&&7 8
public(( 
bool(( 
	IsComplex(( 
{(( 
get((  #
{(($ %
return((& ,
!((- .
string((. 4
.((4 5
IsNullOrWhiteSpace((5 G
(((G H
this((H L
.((L M
Title((M R
)((R S
&&((T V
!((W X
string((X ^
.((^ _
IsNullOrWhiteSpace((_ q
(((q r
this((r v
.((v w
FeaturedImage	((w Ñ
)
((Ñ Ö
;
((Ö Ü
}
((á à
}
((â ä
})) 
}** ¬
áC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\FeaturedContent\FeaturedContentViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
FeaturedContent. =
{ 
public 

class $
FeaturedContentViewModel )
:* +
BaseViewModel, 9
{ 
public		 
bool		 
Active		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public 
Guid 
UserContentId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Introduction "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
DateTime 
	StartDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTime 
EndDate 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
ImageUrl 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ⁄
wC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Game\GameFollowViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Game. 2
{ 
public 

class 
GameFollowViewModel $
:% &
BaseViewModel' 4
{ 
public		 
Guid		 
GameId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
}

 
} ∫%
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Game\GameListItemViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Game. 2
{		 
public

 

class

 !
GameListItemViewModel

 &
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
ThumbnailUrl "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
DeveloperImageUrl '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
DeveloperName #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
	Platforms 
{  !
get" %
;% &
set' *
;* +
}, -
private 
List 
< 
string 
> 
_platformList *
;* +
public 
List 
< 
string 
> 
PlatformList (
{ 	
get   
{!! 
if"" 
("" 
_platformList"" !
==""" $
null""% )
||""* ,
!""- .
_platformList"". ;
.""; <
Any""< ?
(""? @
)""@ A
)""A B
{## 
_platformList$$ !
=$$" #
PopulatePlatforms$$$ 5
($$5 6
)$$6 7
;$$7 8
}%% 
return'' 
_platformList'' $
;''$ %
}(( 
})) 	
public++ !
GameListItemViewModel++ $
(++$ %
)++% &
{,, 	
}-- 	
private// 
List// 
<// 
string// 
>// 
PopulatePlatforms// .
(//. /
)/// 0
{00 	
List11 
<11 
string11 
>11 
platformList11 %
=11& '
new11( +
List11, 0
<110 1
string111 7
>117 8
(118 9
)119 :
;11: ;
if33 
(33 
!33 
string33 
.33 
IsNullOrWhiteSpace33 *
(33* +
this33+ /
.33/ 0
	Platforms330 9
)339 :
)33: ;
{44 
string55 
[55 
]55 
values55 
=55  !
this55" &
.55& '
	Platforms55' 0
.550 1
Split551 6
(556 7
$char557 :
)55: ;
;55; <
values77 
.77 
Where77 
(77 
x77 
=>77 !
!77" #
string77# )
.77) *
IsNullOrWhiteSpace77* <
(77< =
x77= >
)77> ?
)77? @
.77@ A
ToList77A G
(77G H
)77H I
.77I J
ForEach77J Q
(77Q R
x77R S
=>77T V
{88 
GamePlatforms99 !
parsedValue99" -
;99- .
bool;; 
convertionOK;; %
=;;& '
Enum;;( ,
.;;, -
TryParse;;- 5
<;;5 6
GamePlatforms;;6 C
>;;C D
(;;D E
x;;E F
,;;F G
out;;H K
parsedValue;;L W
);;W X
;;;X Y
if== 
(== 
convertionOK== $
)==$ %
{>> 
string?? 
uiClass?? &
=??' (
parsedValue??) 4
.??4 5
GetAttributeOfType??5 G
<??G H
UiInfoAttribute??H W
>??W X
(??X Y
)??Y Z
.??Z [
Class??[ `
;??` a
platformListAA $
.AA$ %
AddAA% (
(AA( )
uiClassAA) 0
)AA0 1
;AA1 2
}BB 
}CC 
)CC 
;CC 
}DD 
returnFF 
platformListFF 
;FF  
}GG 	
}HH 
}II ®)
qC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Game\GameViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Game. 2
{ 
public 

class 
GameViewModel 
:  &
UserGeneratedBaseViewModel! ;
{		 
[

 	
Required

	 
(

 
ErrorMessage

 
=

  
$str

! 8
)

8 9
]

9 :
[ 	
	MinLength	 
( 
$num 
) 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
Display	 
( 
Name 
= 
$str 
)  
]  !
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Display	 
( 
Name 
= 
$str 
) 
] 
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
[ 	
Display	 
( 
Name 
= 
$str 
)  
]  !
public 
	GameGenre 
Genre 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Display	 
( 
Name 
= 
$str %
)% &
]& '
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Display	 
( 
Name 
= 
$str %
)% &
]& '
public 
string 
CoverImageUrl #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Display	 
( 
Name 
= 
$str #
)# $
]$ %
public 
string 
ThumbnailUrl "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Display	 
( 
Name 
= 
$str  
)  !
]! "
public   

GameEngine   
Engine    
{  ! "
get  # &
;  & '
set  ( +
;  + ,
}  - .
["" 	
Display""	 
("" 
Name"" 
="" 
$str"" '
)""' (
]""( )
public## 
CodeLanguage## 
Language## $
{##% &
get##' *
;##* +
set##, /
;##/ 0
}##1 2
[%% 	
Display%%	 
(%% 
Name%% 
=%% 
$str%% !
)%%! "
]%%" #
public&& 
string&& 

WebsiteUrl&&  
{&&! "
get&&# &
;&&& '
set&&( +
;&&+ ,
}&&- .
[(( 	
Display((	 
((( 
Name(( 
=(( 
$str((  
)((  !
]((! "
public)) 

GameStatus)) 
Status))  
{))! "
get))# &
;))& '
set))( +
;))+ ,
}))- .
[++ 	
Display++	 
(++ 
Name++ 
=++ 
$str++ &
)++& '
]++' (
public,, 
DateTime,, 
?,, 
ReleaseDate,, $
{,,% &
get,,' *
;,,* +
set,,, /
;,,/ 0
},,1 2
[.. 	
Display..	 
(.. 
Name.. 
=.. 
$str.. #
)..# $
]..$ %
public// 
List// 
<// 
GamePlatforms// !
>//! "
	Platforms//# ,
{//- .
get/// 2
;//2 3
set//4 7
;//7 8
}//9 :
public33 
string33 
FacebookUrl33 !
{33" #
get33$ '
;33' (
set33) ,
;33, -
}33. /
public55 
string55 

TwitterUrl55  
{55! "
get55# &
;55& '
set55( +
;55+ ,
}55- .
public77 
string77 
InstagramUrl77 "
{77# $
get77% (
;77( )
set77* -
;77- .
}77/ 0
public;; 
int;; 
FollowerCount;;  
{;;! "
get;;# &
;;;& '
set;;( +
;;;+ ,
};;- .
public<< 
int<< 
CommentCount<< 
{<<  !
get<<" %
;<<% &
set<<' *
;<<* +
}<<, -
public== 
int== 
	LikeCount== 
{== 
get== "
;==" #
set==$ '
;==' (
}==) *
}?? 
}@@ Ï
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Gamification\UserBadgeViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Gamification. :
{ 
public 

class 
UserBadgeViewModel #
:$ %
BaseViewModel& 3
{		 
public

 
	BadgeType

 
Badge

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
} 
} Ô
uC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Home\CarouselViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Home. 2
{ 
public		 

class		 
CarouselViewModel		 "
{

 
public 
List 
< $
FeaturedContentViewModel ,
>, -
Items. 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
} 
} Ç
uC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Home\CountersViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Home. 2
{ 
public 

class 
CountersViewModel "
{		 
public

 
int

 

GamesCount

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
int 

UsersCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
ArticlesCount  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
int 
	JamsCount 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ˝

ÖC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\Notification\NotificationItemViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
Notification. :
{ 
public 

class %
NotificationItemViewModel *
:+ ,
BaseViewModel- :
{		 
public

 
string

 
Text

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
Icon 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
	IconColor 
{  !
get" %
;% &
set' *
;* +
}, -
public 
bool 
IsRead 
{ 
get  
;  !
set" %
;% &
}' (
public 
NotificationType 
Type  $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} î
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\UserGeneratedBaseViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
{ 
public		 

abstract		 
class		 &
UserGeneratedBaseViewModel		 4
:		5 6
BaseViewModel		7 D
{

 
[ 	
Display	 
( 
Name 
= 
$str (
)( )
]) *
public 
string 
AuthorPicture #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Display	 
( 
Name 
= 
$str %
)% &
]& '
public 
string 

AuthorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
UserContentType 
UserContentType .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public &
UserGeneratedBaseViewModel )
() *
)* +
:, -
base. 2
(2 3
)3 4
{ 	
} 	
} 
public 

abstract 
class -
!UserGeneratedCommentBaseViewModel ;
<; <
TComment< D
>D E
:F G&
UserGeneratedBaseViewModelH b
{ 
public 
List 
< 
TComment 
> 
Comments &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public -
!UserGeneratedCommentBaseViewModel 0
(0 1
)1 2
:3 4
base5 9
(9 :
): ;
{ 	
Comments 
= 
new 
List 
<  
TComment  (
>( )
() *
)* +
;+ ,
} 	
}   
}## Ö
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\UserLike\UserLikeViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
UserLike. 6
{ 
public 

class 
UserLikeViewModel "
:# $
BaseViewModel% 2
{		 
public

 
Guid

 
LikedId

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
LikeTargetType 

TargetType (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} î
áC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\UserPreferences\UserPreferencesViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
UserPreferences. =
{ 
public		 

class		 $
UserPreferencesViewModel		 )
:		* +
BaseViewModel		, 9
{

 
[ 	
Display	 
( 
Name 
= 
$str %
)% &
]& '
public 
SupportedLanguage  

UiLanguage! +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
[ 	
Display	 
( 
Name 
= 
$str *
)* +
]+ ,
public 
string 
ContentLanguages &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
[ 	
Display	 
( 
Name 
= 
$str *
)* +
]+ ,
public 
List 
< 
SupportedLanguage %
>% &
	Languages' 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
} 
} çH
tC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\User\ProfileViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
User. 2
{ 
public 

class 
ProfileViewModel !
:! "
BaseViewModel# 0
{		 
public

 
ProfileType

 
Type

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
] 
[ 	
Display	 
( 
Name 
= 
$str $
)$ %
]% &
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Motto 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
ProfileImageUrl %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
CoverImageUrl #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
Bio 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 

StudioName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Location 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
bool 
HasOtherProfiles $
{% &
get' *
{   
return!! 
!!! 
string!! 
.!! 
IsNullOrWhiteSpace!! 1
(!!1 2
GameJoltUrl!!2 =
)!!= >
||"" 
!"" 
string"" 
."" 
IsNullOrWhiteSpace"" 1
(""1 2
	ItchIoUrl""2 ;
)""; <
||## 
!## 
string## 
.## 
IsNullOrWhiteSpace## 1
(##1 2

IndieDbUrl##2 <
)##< =
||$$ 
!$$ 
string$$ 
.$$ 
IsNullOrWhiteSpace$$ 1
($$1 2
GameDevNetUrl$$2 ?
)$$? @
||%% 
!%% 
string%% 
.%% 
IsNullOrWhiteSpace%% 1
(%%1 2
UnityConnectUrl%%2 A
)%%A B
;%%B C
}&& 
}'' 	
[(( 	
Display((	 
((( 
Name(( 
=(( 
$str(( !
)((! "
]((" #
public)) 
string)) 
GameJoltUrl)) !
{))" #
get))$ '
;))' (
set))) ,
;)), -
})). /
[++ 	
Display++	 
(++ 
Name++ 
=++ 
$str++ !
)++! "
]++" #
public,, 
string,, 
	ItchIoUrl,, 
{,,  !
get,," %
;,,% &
set,,' *
;,,* +
},,, -
[.. 	
Display..	 
(.. 
Name.. 
=.. 
$str.. !
)..! "
].." #
public// 
string// 

IndieDbUrl//  
{//! "
get//# &
;//& '
set//( +
;//+ ,
}//- .
[11 	
Display11	 
(11 
Name11 
=11 
$str11 %
)11% &
]11& '
public22 
string22 
GameDevNetUrl22 #
{22$ %
get22& )
;22) *
set22+ .
;22. /
}220 1
[44 	
Display44	 
(44 
Name44 
=44 
$str44 '
)44' (
]44( )
public55 
string55 
UnityConnectUrl55 %
{55& '
get55( +
;55+ ,
set55- 0
;550 1
}552 3
public:: 
UserCounters:: 
Counters:: $
{::% &
get::' *
;::* +
set::, /
;::/ 0
}::1 2
public<< 
IndieXpCounter<< 
IndieXp<< %
{<<& '
get<<( +
;<<+ ,
set<<- 0
;<<0 1
}<<2 3
public>> 

Dictionary>> 
<>> 
ExternalLinks>> '
,>>' (
string>>) /
>>>/ 0
ExternalLinks>>1 >
{>>? @
get>>A D
;>>D E
set>>F I
;>>I J
}>>K L
public@@ &
ConnectionControlViewModel@@ )
ConnectionControl@@* ;
{@@< =
get@@> A
;@@A B
set@@C F
;@@F G
}@@H I
publicBB 
ProfileViewModelBB 
(BB  
)BB  !
{CC 	
CountersDD 
=DD 
newDD 
UserCountersDD '
(DD' (
)DD( )
;DD) *
IndieXpEE 
=EE 
newEE 
IndieXpCounterEE (
(EE( )
)EE) *
;EE* +
ExternalLinksFF 
=FF 
newFF 

DictionaryFF  *
<FF* +
ExternalLinksFF+ 8
,FF8 9
stringFF: @
>FF@ A
(FFA B
)FFB C
;FFC D
ConnectionControlGG 
=GG 
newGG  #&
ConnectionControlViewModelGG$ >
(GG> ?
)GG? @
;GG@ A
}HH 	
}II 
publicKK 

classKK 
IndieXpCounterKK 
{LL 
publicMM 
intMM 
LevelMM 
{MM 
getMM 
;MM 
setMM  #
;MM# $
}MM% &
publicOO 
intOO 
LevelXpOO 
{OO 
getOO  
;OO  !
setOO" %
;OO% &
}OO' (
publicQQ 
intQQ 
NextLevelXpQQ 
{QQ  
getQQ! $
;QQ$ %
setQQ& )
;QQ) *
}QQ+ ,
publicSS 
intSS 
XpToNextLevelSS  
{TT 	
getUU 
{VV 
returnWW 
NextLevelXpWW "
-WW# $
LevelXpWW% ,
;WW, -
}XX 
}YY 	
public[[ 
int[[ !
PercentageToNextLevel[[ (
{\\ 	
get]] 
{^^ 
int__ 

percentage__ 
=__  
(__! "
int__" %
)__% &
Math__& *
.__* +
Round__+ 0
(__0 1
(__1 2
double__2 8
)__8 9
(__9 :
$num__: =
*__> ?
LevelXp__@ G
)__G H
/__I J
NextLevelXp__K V
)__V W
;__W X
returnaa 

percentageaa !
;aa! "
}bb 
}cc 	
publicee 
stringee 
	LevelNameee 
{ee  !
getee" %
;ee% &
setee' *
;ee* +
}ee, -
}ff 
publichh 

classhh 
UserCountershh 
{ii 
publicjj 
intjj 
	Followersjj 
{jj 
getjj "
;jj" #
setjj$ '
;jj' (
}jj) *
publicll 
intll 
	Followingll 
{ll 
getll "
;ll" #
setll$ '
;ll' (
}ll) *
publicnn 
intnn 
Connectionsnn 
{nn  
getnn! $
;nn$ %
setnn& )
;nn) *
}nn+ ,
publicpp 
intpp 
Gamespp 
{pp 
getpp 
;pp 
setpp  #
;pp# $
}pp% &
publicrr 
intrr 
Postsrr 
{rr 
getrr 
;rr 
setrr  #
;rr# $
}rr% &
publictt 
inttt 
Commentstt 
{tt 
gettt !
;tt! "
settt# &
;tt& '
}tt( )
publicvv 
intvv 
Jamsvv 
{vv 
getvv 
;vv 
setvv "
;vv" #
}vv$ %
}ww 
publicyy 

classyy &
ConnectionControlViewModelyy +
{zz 
public{{ 
bool{{ 
ConnectionIsPending{{ '
{{{( )
get{{* -
;{{- .
set{{/ 2
;{{2 3
}{{4 5
public}} 
bool}}  
CurrentUserConnected}} (
{}}) *
get}}+ .
;}}. /
set}}0 3
;}}3 4
}}}5 6
public 
bool &
CurrentUserWantsToFollowMe .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
}
ÄÄ 
}ÅÅ Ë
{C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\User\UserConnectionViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
User. 2
{ 
public 

class #
UserConnectionViewModel (
:) *
BaseViewModel+ 8
{ 
public		 
Guid		 
TargetUserId		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
}

 
} ‡
wC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Application\ViewModels\User\UserFollowViewModel.cs
	namespace 	
IndieVisible
 
. 
Application "
." #

ViewModels# -
.- .
User. 2
{ 
public 

class 
UserFollowViewModel $
:% &
BaseViewModel' 4
{ 
public 
Guid 
FollowUserId  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
}		 