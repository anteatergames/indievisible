î
mC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Base\IDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
{		 
public

 

	interface

 
IDomainService

 #
<

# $
T

$ %
>

% &
{ 
int 
Count 
( 
) 
; 
IEnumerable 
< 
T 
> 
GetAll 
( 
) 
;  
int 
Count 
( 

Expression 
< 
Func !
<! "
T" #
,# $
bool% )
>) *
>* +
where, 1
)1 2
;2 3
IEnumerable 
< 
T 
> 
Get 
( 

Expression %
<% &
Func& *
<* +
T+ ,
,, -
bool. 2
>2 3
>3 4
where5 :
): ;
;; <
T 	
GetById
 
( 
Guid 
id 
) 
; 
IEnumerable 
< 
T 
> 
GetByUserId "
(" #
Guid# '
userId( .
). /
;/ 0
Guid 
Add 
( 
T 
model 
) 
; 
Guid 
Update 
( 
T 
model 
) 
; 
void 
Remove 
( 
Guid 
id 
) 
; 
} 
} ü
jC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Base\IRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )
Base) -
{ 
public		 

	interface		 
IRepository		  
<		  !
TEntity		! (
>		( )
:		* +
IDisposable		, 7
where		8 =
TEntity		> E
:		F G
class		H M
{

 
void 
Add 
( 
TEntity 
obj 
) 
; 
TEntity 
GetById 
( 
Guid 
id 
)  
;  !
int 
Count 
( 

Expression 
< 
Func !
<! "
TEntity" )
,) *
bool+ /
>/ 0
>0 1
where2 7
)7 8
;8 9

IQueryable 
< 
TEntity 
> 
Get 
(  

Expression  *
<* +
Func+ /
</ 0
TEntity0 7
,7 8
bool9 =
>= >
>> ?
where@ E
)E F
;F G

IQueryable 
< 
TEntity 
> 
GetAll "
(" #
)# $
;$ %
void 
Update 
( 
TEntity 
obj 
)  
;  !
void 
Remove 
( 
Guid 
id 
) 
; 
int 
SaveChanges 
( 
) 
; 
} 
} ˝
jC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Base\IUnitOfWork.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )
Base) -
{ 
public 

	interface 
IUnitOfWork  
:! "
IDisposable# .
{ 
bool 
Commit 
( 
) 
; 
} 
}		 ñ
ÅC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IBrainstormCommentRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface (
IBrainstormCommentRepository 1
:2 3
IRepository4 ?
<? @
BrainstormComment@ Q
>Q R
{ 
} 
}		 å
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IBrainstormIdeaRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface %
IBrainstormIdeaRepository .
:/ 0
IRepository1 <
<< =
BrainstormIdea= K
>K L
{ 
}		 
}

 ñ
ÅC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IBrainstormSessionRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface (
IBrainstormSessionRepository 1
:2 3
IRepository4 ?
<? @
BrainstormSession@ Q
>Q R
{ 
} 
}		 ©
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IBrainstormVoteRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface %
IBrainstormVoteRepository .
:/ 0
IRepository1 <
<< =
BrainstormVote= K
>K L
{		 
new

 

IQueryable

 
<

 
BrainstormVote

 %
>

% &
GetAll

' -
(

- .
)

. /
;

/ 0
BrainstormVote 
Get 
( 
Guid 
votingItemId  ,
,, -
Guid. 2
userId3 9
)9 :
;: ;

IQueryable 
< 
BrainstormVote !
>! "
GetByUserId# .
(. /
Guid/ 3
userId4 :
): ;
;; <
} 
} è
C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IFeaturedContentRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface &
IFeaturedContentRepository /
:0 1
IRepository2 =
<= >
FeaturedContent> M
>M N
{ 
} 
}		 Ä
zC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IGameFollowRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{		 
public

 

	interface

 !
IGameFollowRepository

 *
:

+ ,
IRepository

- 8
<

8 9

GameFollow

9 C
>

C D
{ 
} 
} ˙
xC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IGameLikeRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface 
IGameLikeRepository (
:) *
IRepository+ 6
<6 7
GameLike7 ?
>? @
{ 
} 
}		 Ó
tC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IGameRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface 
IGameRepository $
:% &
IRepository' 2
<2 3
Game3 7
>7 8
{ 
} 
}		 Ø
ÇC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IGamificationActionRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface )
IGamificationActionRepository 2
:3 4
IRepository5 @
<@ A
GamificationActionA S
>S T
{ 
GamificationAction		 
GetByAction		 &
(		& '
PlatformAction		' 5
action		6 <
)		< =
;		= >
}

 
} •
ÅC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IGamificationLevelRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface (
IGamificationLevelRepository 1
:2 3
IRepository4 ?
<? @
GamificationLevel@ Q
>Q R
{ 
GamificationLevel 
GetByNumber %
(% &
int& )
levelNumber* 5
)5 6
;6 7
}		 
}

 å
|C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IGamificationRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface #
IGamificationRepository ,
:- .
IRepository/ :
<: ;
Gamification; G
>G H
{ 
Gamification		 
GetByUserId		  
(		  !
Guid		! %
userId		& ,
)		, -
;		- .
}

 
} Ü
|C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\INotificationRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface #
INotificationRepository ,
:- .
IRepository/ :
<: ;
Notification; G
>G H
{ 
} 
}		 ∑
wC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IProfileRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface 
IProfileRepository '
:( )
IRepository* 5
<5 6
UserProfile6 A
>A B
{		 
IEnumerable

 
<

 
UserProfile

 
>

  
GetByUserId

! ,
(

, -
Guid

- 1
userId

2 8
)

8 9
;

9 :
} 
} ∑
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IUserBadgeRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface  
IUserBadgeRepository )
:* +
IRepository, 7
<7 8
	UserBadge8 A
>A B
{		 
IEnumerable

 
<

 
	UserBadge

 
>

 
GetByUserId

 *
(

* +
Guid

+ /
userId

0 6
)

6 7
;

7 8
} 
} å
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IUserConnectionRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public		 

	interface		 %
IUserConnectionRepository		 .
:		/ 0
IRepository		1 <
<		< =
UserConnection		= K
>		K L
{

 
} 
} ô
ÇC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IUserContentCommentRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface )
IUserContentCommentRepository 2
:3 4
IRepository5 @
<@ A
UserContentCommentA S
>S T
{ 
} 
}		 è
C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IUserContentLikeRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface &
IUserContentLikeRepository /
:0 1
IRepository2 =
<= >
UserContentLike> M
>M N
{ 
} 
}		 §
{C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IUserContentRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface "
IUserContentRepository +
:, -
IRepository. 9
<9 :
UserContent: E
>E F
{ 
new		 

IQueryable		 
<		 
UserContent		 "
>		" #
GetAll		$ *
(		* +
)		+ ,
;		, -
}

 
} Ä
zC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IUserFollowRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{		 
public

 

	interface

 !
IUserFollowRepository

 *
:

+ ,
IRepository

- 8
<

8 9

UserFollow

9 C
>

C D
{ 
} 
} î
C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Repository\IUserPreferencesRepository.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )

Repository) 3
{ 
public 

	interface &
IUserPreferencesRepository /
:0 1
IRepository2 =
<= >
UserPreferences> M
>M N
{ 
UserPreferences		 
GetByUserId		 #
(		# $
Guid		$ (
id		) +
)		+ ,
;		, -
}

 
} ¡
zC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Service\IGameFollowDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )
Service) 0
{ 
public		 

	interface		 $
IGameFollowDomainService		 -
:		. /
IDomainService		0 >
<		> ?

GameFollow		? I
>		I J
{

 
int 
Count 
( 

Expression 
< 
Func !
<! "

GameFollow" ,
,, -
bool. 2
>2 3
>3 4
where5 :
): ;
;; <
IEnumerable 
< 

GameFollow 
> 
GetByGameId  +
(+ ,
Guid, 0
gameId1 7
)7 8
;8 9
} 
} É
|C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Service\IGamificationDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )
Service) 0
{ 
public		 

	interface		 &
IGamificationDomainService		 /
{

 
void 
ProcessAction 
( 
Guid 
userId  &
,& '
PlatformAction( 6
action7 =
)= >
;> ?
Gamification #
GetGamificationByUserId ,
(, -
Guid- 1
userId2 8
)8 9
;9 :
GamificationLevel 
GetLevel "
(" #
int# &
levelNumber' 2
)2 3
;3 4
} 
} Ä
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Service\IUserBadgeDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )
Service) 0
{ 
public		 

	interface		 #
IUserBadgeDomainService		 ,
:		- .
IDomainService		/ =
<		= >
	UserBadge		> G
>		G H
{

 
} 
} ¬	
~C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Service\IUserConnectionDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )
Service) 0
{ 
public 

	interface (
IUserConnectionDomainService 1
:2 3
IDomainService4 B
<B C
UserConnectionC Q
>Q R
{		 
IEnumerable

 
<

 
UserConnection

 "
>

" #
GetByTargetUserId

$ 5
(

5 6
Guid

6 :
targetUserId

; G
)

G H
;

H I
UserConnection 
Get 
( 
Guid 
currentUserId  -
,- .
Guid/ 3
userId4 :
): ;
;; <
bool 
CheckConnection 
( 
Guid !
currentUserId" /
,/ 0
Guid1 5
userId6 <
,< =
bool> B
acceptedC K
,K L
boolM Q
bothWaysR Z
)Z [
;[ \
} 
} É
zC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Interfaces\Service\IUserFollowDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 

Interfaces (
.( )
Service) 0
{ 
public		 

	interface		 $
IUserFollowDomainService		 -
:		. /
IDomainService		0 >
<		> ?

UserFollow		? I
>		I J
{

 
} 
} ”

gC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\BrainstormComment.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
BrainstormComment "
:# $
Entity% +
{		 
public

 
Guid

 
?

 
ParentCommentId

 $
{

% &
get

' *
;

* +
set

, /
;

/ 0
}

1 2
public 
Guid 
IdeaId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 

AuthorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
AuthorPicture #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
Text 
{ 
get  
;  !
set" %
;% &
}' (
public 
virtual 
BrainstormIdea %
Idea& *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
} Á
dC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\BrainstormIdea.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
BrainstormIdea 
:  !
Entity" (
{		 
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
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
Guid 
	SessionId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
virtual 
BrainstormSession (
Session) 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
virtual 
ICollection "
<" #
BrainstormComment# 4
>4 5
Comments6 >
{? @
getA D
;D E
setF I
;I J
}K L
public 
virtual 
ICollection "
<" #
BrainstormVote# 1
>1 2
Votes3 8
{8 9
get: =
;= >
set? B
;B C
}D E
} 
} ˚	
gC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\BrainstormSession.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
BrainstormSession "
:# $
Entity% +
{		 
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
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public !
BrainstormSessionType $
Type% )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
Guid 
? 
TargetContextId $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
virtual 
ICollection "
<" #
BrainstormIdea# 1
>1 2
Ideas3 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
} 
} Ê
dC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\BrainstormVote.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
BrainstormVote		 
:		  !
Entity		" (
{

 
public 
Guid 
IdeaId 
{ 
get  
;  !
set" %
;% &
}' (
public 
	VoteValue 
	VoteValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
virtual 
BrainstormIdea %
Idea& *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
} √
eC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\FeaturedContent.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
FeaturedContent  
:! "
Entity# )
{		 
public

 
bool

 
Active

 
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
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Introduction "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
DateTime 
	StartDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTime 
EndDate 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
ImageUrl 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ≥
ZC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\Game.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
Game		 
:		 
ExternalEntity		 &
{

 
public 
Game 
( 
) 
{ 	
} 	
public 
string 
DeveloperName #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
	GameGenre 
Genre 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
CoverImageUrl #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
ThumbnailUrl "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 

GameEngine 
Engine  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
CodeLanguage 
Language $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public!! 
string!! 

WebsiteUrl!!  
{!!! "
get!!# &
;!!& '
set!!( +
;!!+ ,
}!!- .
public## 

GameStatus## 
Status##  
{##! "
get### &
;##& '
set##( +
;##+ ,
}##- .
public%% 
DateTime%% 
?%% 
ReleaseDate%% $
{%%% &
get%%' *
;%%* +
set%%, /
;%%/ 0
}%%1 2
public'' 
string'' 
	Platforms'' 
{''  !
get''" %
;''% &
set''' *
;''* +
}'', -
public)) 
virtual)) 
ICollection)) "
<))" #
UserContent))# .
>)). /
UserContents))0 <
{))= >
get))? B
;))B C
set))D G
;))G H
}))I J
public-- 
string-- 
FacebookUrl-- !
{--" #
get--$ '
;--' (
set--) ,
;--, -
}--. /
public// 
string// 

TwitterUrl//  
{//! "
get//# &
;//& '
set//( +
;//+ ,
}//- .
public11 
string11 
InstagramUrl11 "
{11# $
get11% (
;11( )
set11* -
;11- .
}11/ 0
}33 
}44 â
`C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\GameFollow.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 

GameFollow 
: 
Entity $
{		 
public

 
Guid

 
GameId

 
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
' (
} 
} Ö
^C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\GameLike.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
GameLike 
: 
Entity "
{		 
public

 
Guid

 
GameId

 
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
' (
} 
} Ì
bC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\Gamification.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
Gamification 
: 
Entity  &
{		 
public

 
int

 
CurrentLevelNumber

 %
{

& '
get

( +
;

+ ,
set

- 0
;

0 1
}

2 3
public 
int 
XpTotal 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
XpCurrentLevel !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
XpToNextLevel  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} æ
hC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\GamificationAction.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
GamificationAction		 #
:		$ %
Entity		& ,
{

 
public 
PlatformAction 
Action $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
int 

ScoreValue 
{ 
get  #
;# $
set% (
;( )
}* +
} 
}  
gC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\GamificationLevel.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
GamificationLevel "
:# $
Entity% +
{		 
public

 
int

 
Number

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
XpToAchieve 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ﬁ
bC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\Notification.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
Notification		 
:		 
Entity		  &
{

 
public 
NotificationType 
Type  $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
bool 
IsRead 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Text 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
} 
} ã
_C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserBadge.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
	UserBadge		 
:		 
Entity		 #
{

 
public 
	BadgeType 
Badge 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} »
dC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserConnection.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
UserConnection 
:  !
Entity" (
{		 
public

 
Guid

 
TargetUserId
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
public 
DateTime 
? 
ApprovalDate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} Ç
aC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserContent.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
UserContent		 
:		 
Entity		 %
{

 
public 
string 

AuthorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
AuthorPicture #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
FeaturedImage #
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Introduction "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
Content 
{ 
get  #
;# $
set% (
;( )
}* +
public 
SupportedLanguage  
Language! )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
Guid 
? 
GameId 
{ 
get !
;! "
set# &
;& '
}( )
public 
virtual 
Game 
Game  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
virtual 
ICollection "
<" #
UserContentLike# 2
>2 3
Likes4 9
{: ;
get< ?
;? @
setA D
;D E
}F G
public 
virtual 
ICollection "
<" #
UserContentComment# 5
>5 6
Comments7 ?
{@ A
getB E
;E F
setG J
;J K
}L M
} 
}   ò	
hC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserContentComment.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 
UserContentComment #
:$ %
Entity& ,
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
string 

AuthorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
AuthorPicture #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
Text 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ñ
eC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserContentLike.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
UserContentLike		  
:		! "
Entity		# )
{

 
public 
Guid 
	ContentId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} è
`C:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserFollow.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public 

class 

UserFollow 
: 
Entity $
{		 
public

 
Guid

 
FollowUserId
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
- .
} 
} »
eC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserPreferences.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{ 
public		 

class		 
UserPreferences		  
:		! "
Entity		# )
{

 
public 
SupportedLanguage  

UiLanguage! +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
ContentLanguages &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} ö

aC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Models\UserProfile.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Models $
{		 
public

 

class

 
UserProfile

 
:

 
ExternalEntity

 -
{ 
public 
ProfileType 
Type 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Motto 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Bio 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 

StudioName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Location 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ˛)
nC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Services\Base\BaseDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Services &
{ 
public 

abstract 
class 
BaseDomainService +
<+ ,
T, -
,- .
TRepository/ :
>: ;
:< =
IDomainService> L
<L M
TM N
>N O
whereP U
TV W
:W X
EntityY _
where` e
TRepositoryf q
:r s
classt y
,y z
IRepository	{ Ü
<
Ü á
T
á à
>
à â
{ 
	protected 
readonly 
TRepository &

repository' 1
;1 2
public 
BaseDomainService  
(  !
TRepository! ,

repository- 7
)7 8
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
Guid 
Add 
( 
T 
model 
)  
{ 	
this 
. 

repository 
. 
Add 
(  
model  %
)% &
;& '
return 
model 
. 
Id 
; 
} 	
public 
int 
Count 
( 
) 
{ 	
int   
count   
=   
this   
.   

repository   '
.  ' (
Count  ( -
(  - .
x  . /
=>  0 2
true  3 7
)  7 8
;  8 9
return"" 
count"" 
;"" 
}## 	
public%% 
int%% 
Count%% 
(%% 

Expression%% #
<%%# $
Func%%$ (
<%%( )
T%%) *
,%%* +
bool%%, 0
>%%0 1
>%%1 2
where%%3 8
)%%8 9
{&& 	
var'' 
count'' 
='' 
this'' 
.'' 

repository'' '
.''' (
Count''( -
(''- .
where''. 3
)''3 4
;''4 5
return)) 
count)) 
;)) 
}** 	
public,, 
IEnumerable,, 
<,, 
T,, 
>,, 
Get,, !
(,,! "

Expression,," ,
<,,, -
Func,,- 1
<,,1 2
T,,2 3
,,,3 4
bool,,5 9
>,,9 :
>,,: ;
where,,< A
),,A B
{-- 	
var.. 
objs.. 
=.. 
this.. 
... 

repository.. %
...% &
Get..& )
(..) *
where..* /
)../ 0
;..0 1
return00 
objs00 
.00 
ToList00 
(00 
)00  
;00  !
}11 	
public33 
IEnumerable33 
<33 
T33 
>33 
GetAll33 $
(33$ %
)33% &
{44 	
var55 
objs55 
=55 
this55 
.55 

repository55 &
.55& '
GetAll55' -
(55- .
)55. /
;55/ 0
return77 
objs77 
.77 
ToList77 
(77 
)77  
;77  !
}88 	
public:: 
T:: 
GetById:: 
(:: 
Guid:: 
id::  
)::  !
{;; 	
var<< 
obj<< 
=<< 
this<< 
.<< 

repository<< %
.<<% &
GetById<<& -
(<<- .
id<<. 0
)<<0 1
;<<1 2
return>> 
obj>> 
;>> 
}?? 	
publicAA 
IEnumerableAA 
<AA 
TAA 
>AA 
GetByUserIdAA )
(AA) *
GuidAA* .
userIdAA/ 5
)AA5 6
{BB 	
varCC 
objCC 
=CC 
thisCC 
.CC 

repositoryCC %
.CC% &
GetCC& )
(CC) *
xCC* +
=>CC, .
xCC/ 0
.CC0 1
UserIdCC1 7
==CC8 :
userIdCC; A
)CCA B
;CCB C
returnEE 
objEE 
.EE 
ToListEE 
(EE 
)EE 
;EE  
}FF 	
publicHH 
voidHH 
RemoveHH 
(HH 
GuidHH 
idHH  "
)HH" #
{II 	
thisJJ 
.JJ 

repositoryJJ 
.JJ 
RemoveJJ "
(JJ" #
idJJ# %
)JJ% &
;JJ& '
}KK 	
publicMM 
GuidMM 
UpdateMM 
(MM 
TMM 
modelMM "
)MM" #
{NN 	
thisOO 
.OO 

repositoryOO 
.OO 
UpdateOO "
(OO" #
modelOO# (
)OO( )
;OO) *
returnQQ 
modelQQ 
.QQ 
IdQQ 
;QQ 
}RR 	
}SS 
}TT ¬*
oC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Services\GameFollowDomainService.cs
	namespace		 	
IndieVisible		
 
.		 
Domain		 
.		 
Services		 &
{

 
public 

class #
GameFollowDomainService (
:) *$
IGameFollowDomainService+ C
{ 
private 
readonly !
IGameFollowRepository . 
gameFollowRepository/ C
;C D
public #
GameFollowDomainService &
(& '!
IGameFollowRepository' < 
gameFollowRepository= Q
)Q R
{ 	
this 
.  
gameFollowRepository %
=& ' 
gameFollowRepository( <
;< =
} 	
public 
int 
Count 
( 
) 
{ 	
int 
count 
= 
this 
.  
gameFollowRepository 1
.1 2
Count2 7
(7 8
x8 9
=>: <
true= A
)A B
;B C
return 
count 
; 
} 	
public 
IEnumerable 
< 

GameFollow %
>% &
GetAll' -
(- .
). /
{ 	
System 
. 
Linq 
. 

IQueryable "
<" #

GameFollow# -
>- .
model/ 4
=5 6
this7 ;
.; < 
gameFollowRepository< P
.P Q
GetAllQ W
(W X
)X Y
;Y Z
return 
model 
; 
}   	
public"" 

GameFollow"" 
GetById"" !
(""! "
Guid""" &
id""' )
)"") *
{## 	

GameFollow$$ 
model$$ 
=$$ 
this$$ #
.$$# $ 
gameFollowRepository$$$ 8
.$$8 9
GetById$$9 @
($$@ A
id$$A C
)$$C D
;$$D E
return&& 
model&& 
;&& 
}'' 	
public)) 
IEnumerable)) 
<)) 

GameFollow)) %
>))% &
GetByUserId))' 2
())2 3
Guid))3 7
userId))8 >
)))> ?
{** 	
throw++ 
new++ #
NotImplementedException++ -
(++- .
)++. /
;++/ 0
},, 	
public.. 
void.. 
Remove.. 
(.. 
Guid.. 
id..  "
).." #
{// 	
this00 
.00  
gameFollowRepository00 %
.00% &
Remove00& ,
(00, -
id00- /
)00/ 0
;000 1
}11 	
public33 
Guid33 
Add33 
(33 

GameFollow33 "
model33# (
)33( )
{44 	
this55 
.55  
gameFollowRepository55 %
.55% &
Add55& )
(55) *
model55* /
)55/ 0
;550 1
return77 
model77 
.77 
Id77 
;77 
}88 	
public:: 
Guid:: 
Update:: 
(:: 

GameFollow:: %
model::& +
)::+ ,
{;; 	
this<< 
.<<  
gameFollowRepository<< %
.<<% &
Update<<& ,
(<<, -
model<<- 2
)<<2 3
;<<3 4
return>> 
model>> 
.>> 
Id>> 
;>> 
}?? 	
publicAA 
intAA 
CountAA 
(AA 

ExpressionAA #
<AA# $
FuncAA$ (
<AA( )

GameFollowAA) 3
,AA3 4
boolAA5 9
>AA9 :
>AA: ;
whereAA< A
)AAA B
{BB 	
varCC 
countCC 
=CC 
thisCC 
.CC  
gameFollowRepositoryCC 1
.CC1 2
CountCC2 7
(CC7 8
whereCC8 =
)CC= >
;CC> ?
returnEE 
countEE 
;EE 
}FF 	
publicHH 
IEnumerableHH 
<HH 

GameFollowHH %
>HH% &
GetByGameIdHH' 2
(HH2 3
GuidHH3 7
gameIdHH8 >
)HH> ?
{II 	
varJJ 
	followersJJ 
=JJ 
thisJJ  
.JJ  ! 
gameFollowRepositoryJJ! 5
.JJ5 6
GetJJ6 9
(JJ9 :
xJJ: ;
=>JJ< >
xJJ? @
.JJ@ A
GameIdJJA G
==JJH J
gameIdJJK Q
)JJQ R
;JJR S
returnLL 
	followersLL 
.LL 
ToListLL #
(LL# $
)LL$ %
;LL% &
}MM 	
publicOO 
IEnumerableOO 
<OO 

GameFollowOO %
>OO% &
GetOO' *
(OO* +

ExpressionOO+ 5
<OO5 6
FuncOO6 :
<OO: ;

GameFollowOO; E
,OOE F
boolOOG K
>OOK L
>OOL M
whereOON S
)OOS T
{PP 	
throwQQ 
newQQ #
NotImplementedExceptionQQ -
(QQ- .
)QQ. /
;QQ/ 0
}RR 	
}SS 
}TT Ÿ;
qC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Services\GamificationDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Services &
{ 
public		 

class		 %
GamificationDomainService		 *
:		+ ,&
IGamificationDomainService		- G
{

 
private 
readonly #
IGamificationRepository 0"
gamificationRepository1 G
;G H
private 
readonly )
IGamificationActionRepository 6(
gamificationActionRepository7 S
;S T
private 
readonly (
IGamificationLevelRepository 5'
gamificationLevelRepository6 Q
;Q R
public %
GamificationDomainService (
(( )#
IGamificationRepository) @"
gamificationRepositoryA W
,W X)
IGamificationActionRepositoryY v)
gamificationActionRepository	w ì
,
ì î*
IGamificationLevelRepository
ï ±)
gamificationLevelRepository
≤ Õ
)
Õ Œ
{ 	
this 
. "
gamificationRepository '
=( )"
gamificationRepository* @
;@ A
this 
. (
gamificationActionRepository -
=. /(
gamificationActionRepository0 L
;L M
this 
. '
gamificationLevelRepository ,
=- .'
gamificationLevelRepository/ J
;J K
} 	
public 
Gamification #
GetGamificationByUserId 3
(3 4
Guid4 8
userId9 ?
)? @
{ 	
Gamification 
userGamification )
=* +"
gamificationRepository, B
.B C
GetByUserIdC N
(N O
userIdO U
)U V
;V W
if 
( 
userGamification  
==! #
null$ (
)( )
{ 
userGamification  
=! "#
GenerateNewGamification# :
(: ;
userId; A
)A B
;B C
this 
. "
gamificationRepository +
.+ ,
Add, /
(/ 0
userGamification0 @
)@ A
;A B
} 
return!! 
userGamification!! #
;!!# $
}"" 	
public$$ 
GamificationLevel$$  
GetLevel$$! )
($$) *
int$$* -
levelNumber$$. 9
)$$9 :
{%% 	
var&& 
level&& 
=&& '
gamificationLevelRepository&& 3
.&&3 4
GetByNumber&&4 ?
(&&? @
levelNumber&&@ K
)&&K L
;&&L M
return(( 
level(( 
;(( 
})) 	
public++ 
void++ 
ProcessAction++ !
(++! "
Guid++" &
userId++' -
,++- .
PlatformAction++/ =
action++> D
)++D E
{,, 	
GamificationAction-- 
actionToProcess-- .
=--/ 0
this--1 5
.--5 6(
gamificationActionRepository--6 R
.--R S
GetByAction--S ^
(--^ _
action--_ e
)--e f
;--f g
Gamification// 
userGamification// )
=//* +
this//, 0
.//0 1"
gamificationRepository//1 G
.//G H
GetByUserId//H S
(//S T
userId//T Z
)//Z [
;//[ \
if11 
(11 
userGamification11  
==11! #
null11$ (
)11( )
{22 
userGamification33  
=33! "#
GenerateNewGamification33# :
(33: ;
userId33; A
)33A B
;33B C
userGamification55  
.55  !
XpCurrentLevel55! /
+=550 2
actionToProcess553 B
.55B C

ScoreValue55C M
;55M N
userGamification66  
.66  !
XpTotal66! (
+=66) +
actionToProcess66, ;
.66; <

ScoreValue66< F
;66F G
userGamification77  
.77  !
XpToNextLevel77! .
=77/ 0
actionToProcess771 @
.77@ A

ScoreValue77A K
;77K L
this99 
.99 "
gamificationRepository99 +
.99+ ,
Add99, /
(99/ 0
userGamification990 @
)99@ A
;99A B
}:: 
else;; 
{<< 
userGamification==  
.==  !
XpCurrentLevel==! /
+===0 2
actionToProcess==3 B
.==B C

ScoreValue==C M
;==M N
userGamification>>  
.>>  !
XpTotal>>! (
+=>>) +
actionToProcess>>, ;
.>>; <

ScoreValue>>< F
;>>F G
userGamification??  
.??  !
XpToNextLevel??! .
-=??/ 1
actionToProcess??2 A
.??A B

ScoreValue??B L
;??L M
ifAA 
(AA 
userGamificationAA $
.AA$ %
XpToNextLevelAA% 2
<=AA3 5
$numAA6 7
)AA7 8
{BB 
GamificationLevelCC %
newLevelCC& .
=CC/ 0
thisCC1 5
.CC5 6'
gamificationLevelRepositoryCC6 Q
.CCQ R
GetByNumberCCR ]
(CC] ^
userGamificationCC^ n
.CCn o
CurrentLevelNumber	CCo Å
+
CCÇ É
$num
CCÑ Ö
)
CCÖ Ü
;
CCÜ á
ifEE 
(EE 
newLevelEE  
!=EE! #
nullEE$ (
)EE( )
{FF 
userGamificationGG (
.GG( )
CurrentLevelNumberGG) ;
++GG; =
;GG= >
userGamificationHH (
.HH( )
XpCurrentLevelHH) 7
=HH8 9
$numHH: ;
;HH; <
userGamificationII (
.II( )
XpToNextLevelII) 6
=II7 8
newLevelII9 A
.IIA B
XpToAchieveIIB M
;IIM N
}JJ 
}KK 
thisMM 
.MM "
gamificationRepositoryMM +
.MM+ ,
UpdateMM, 2
(MM2 3
userGamificationMM3 C
)MMC D
;MMD E
}NN 
}OO 	
privateQQ 
GamificationQQ #
GenerateNewGamificationQQ 4
(QQ4 5
GuidQQ5 9
userIdQQ: @
)QQ@ A
{RR 	
GamificationSS 
userGamificationSS )
;SS) *
GamificationLevelTT 

firstLevelTT (
=TT) *
thisTT+ /
.TT/ 0'
gamificationLevelRepositoryTT0 K
.TTK L
GetByNumberTTL W
(TTW X
$numTTX Y
)TTY Z
;TTZ [
userGamificationVV 
=VV 
newVV "
GamificationVV# /
{WW 
CurrentLevelNumberXX "
=XX# $

firstLevelXX% /
.XX/ 0
NumberXX0 6
,XX6 7
UserIdYY 
=YY 
userIdYY 
,YY  
XpCurrentLevelZZ 
=ZZ  
$numZZ! "
,ZZ" #
XpToNextLevel[[ 
=[[ 

firstLevel[[  *
.[[* +
XpToAchieve[[+ 6
,[[6 7
XpTotal\\ 
=\\ 
$num\\ 
}]] 
;]] 
return__ 
userGamification__ #
;__# $
}`` 	
}aa 
}bb ÷%
nC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Services\UserBadgeDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Services &
{		 
public

 

class

 "
UserBadgeDomainService

 '
:

( )#
IUserBadgeDomainService

* A
{ 
private 
readonly  
IUserBadgeRepository -
userBadgeRepository. A
;A B
public "
UserBadgeDomainService %
(% & 
IUserBadgeRepository& :
userBadgeRepository; N
)N O
{ 	
this 
. 
userBadgeRepository $
=% &
userBadgeRepository' :
;: ;
} 	
public 
int 
Count 
( 
) 
{ 	
int 
count 
= 
this 
. 
userBadgeRepository 0
.0 1
Count1 6
(6 7
x7 8
=>9 ;
true< @
)@ A
;A B
return 
count 
; 
} 	
public 
IEnumerable 
< 
	UserBadge $
>$ %
GetAll& ,
(, -
)- .
{ 	
System 
. 
Linq 
. 

IQueryable "
<" #
	UserBadge# ,
>, -
model. 3
=4 5
this6 :
.: ;
userBadgeRepository; N
.N O
GetAllO U
(U V
)V W
;W X
return 
model 
; 
} 	
public!! 
	UserBadge!! 
GetById!!  
(!!  !
Guid!!! %
id!!& (
)!!( )
{"" 	
	UserBadge## 
model## 
=## 
this## "
.##" #
userBadgeRepository### 6
.##6 7
GetById##7 >
(##> ?
id##? A
)##A B
;##B C
return%% 
model%% 
;%% 
}&& 	
public(( 
IEnumerable(( 
<(( 
	UserBadge(( $
>(($ %
GetByUserId((& 1
(((1 2
Guid((2 6
userId((7 =
)((= >
{)) 	
IEnumerable** 
<** 
	UserBadge** !
>**! "
model**# (
=**) *
this**+ /
.**/ 0
userBadgeRepository**0 C
.**C D
GetByUserId**D O
(**O P
userId**P V
)**V W
;**W X
return,, 
model,, 
;,, 
}-- 	
public// 
void// 
Remove// 
(// 
Guid// 
id//  "
)//" #
{00 	
this11 
.11 
userBadgeRepository11 $
.11$ %
Remove11% +
(11+ ,
id11, .
)11. /
;11/ 0
}22 	
public44 
Guid44 
Add44 
(44 
	UserBadge44 !
model44" '
)44' (
{55 	
this66 
.66 
userBadgeRepository66 $
.66$ %
Add66% (
(66( )
model66) .
)66. /
;66/ 0
return88 
model88 
.88 
Id88 
;88 
}99 	
public;; 
Guid;; 
Update;; 
(;; 
	UserBadge;; $
model;;% *
);;* +
{<< 	
this== 
.== 
userBadgeRepository== $
.==$ %
Update==% +
(==+ ,
model==, 1
)==1 2
;==2 3
return?? 
model?? 
.?? 
Id?? 
;?? 
}@@ 	
publicBB 
intBB 
CountBB 
(BB 

ExpressionBB #
<BB# $
FuncBB$ (
<BB( )
	UserBadgeBB) 2
,BB2 3
boolBB4 8
>BB8 9
>BB9 :
whereBB; @
)BB@ A
{CC 	
throwDD 
newDD #
NotImplementedExceptionDD -
(DD- .
)DD. /
;DD/ 0
}EE 	
publicGG 
IEnumerableGG 
<GG 
	UserBadgeGG $
>GG$ %
GetGG& )
(GG) *

ExpressionGG* 4
<GG4 5
FuncGG5 9
<GG9 :
	UserBadgeGG: C
,GGC D
boolGGE I
>GGI J
>GGJ K
whereGGL Q
)GGQ R
{HH 	
throwII 
newII #
NotImplementedExceptionII -
(II- .
)II. /
;II/ 0
}JJ 	
}KK 
}LL ‹!
sC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Services\UserConnectionDomainService.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
Services &
{		 
public

 

class

 '
UserConnectionDomainService

 ,
:

- .
BaseDomainService

/ @
<

@ A
UserConnection

A O
,

O P%
IUserConnectionRepository

Q j
>

j k
,

k l)
IUserConnectionDomainService	

m â
{ 
public '
UserConnectionDomainService *
(* +%
IUserConnectionRepository+ D

repositoryE O
)O P
:Q R
baseS W
(W X

repositoryX b
)b c
{ 	
} 	
public 
IEnumerable 
< 
UserConnection )
>) *
GetByTargetUserId+ <
(< =
Guid= A
targetUserIdB N
)N O
{ 	

IQueryable 
< 
UserConnection %
>% &
connnections' 3
=4 5
this6 :
.: ;

repository; E
.E F
GetF I
(I J
xJ K
=>L N
xO P
.P Q
TargetUserIdQ ]
==^ `
targetUserIda m
)m n
;n o
return 
connnections 
.  
ToList  &
(& '
)' (
;( )
} 	
public 
UserConnection 
Get !
(! "
Guid" &
currentUserId' 4
,4 5
Guid6 :
userId; A
)A B
{ 	
UserConnection 
existingConnection -
=. /
this0 4
.4 5

repository5 ?
.? @
Get@ C
(C D
xD E
=>F H
xI J
.J K
UserIdK Q
==R T
currentUserIdU b
&&c e
xf g
.g h
TargetUserIdh t
==u w
userIdx ~
)~ 
.	 Ä
FirstOrDefault
Ä é
(
é è
)
è ê
;
ê ë
return 
existingConnection %
;% &
} 	
public 
bool 
CheckConnection #
(# $
Guid$ (
currentUserId) 6
,6 7
Guid8 <
userId= C
,C D
boolE I
acceptedJ R
,R S
boolT X
bothWaysY a
)a b
{ 	
var   
exists   
=   
this   
.   

repository   (
.  ( )
Get  ) ,
(  , -
x  - .
=>  / 1
x  2 3
.  3 4
UserId  4 :
==  ; =
currentUserId  > K
&&  L N
x  O P
.  P Q
TargetUserId  Q ]
==  ^ `
userId  a g
&&  h j
x  k l
.  l m
ApprovalDate  m y
.  y z
HasValue	  z Ç
==
  É Ö
accepted
  Ü é
)
  é è
.
  è ê
Any
  ê ì
(
  ì î
)
  î ï
;
  ï ñ
if"" 
("" 
bothWays"" 
)"" 
{## 
var$$ 

existsToMe$$ 
=$$  
this$$! %
.$$% &

repository$$& 0
.$$0 1
Get$$1 4
($$4 5
x$$5 6
=>$$7 9
x$$: ;
.$$; <
UserId$$< B
==$$C E
userId$$F L
&&$$M O
x$$P Q
.$$Q R
TargetUserId$$R ^
==$$_ a
currentUserId$$b o
&&$$p r
x$$s t
.$$t u
ApprovalDate	$$u Å
.
$$Å Ç
HasValue
$$Ç ä
==
$$ã ç
accepted
$$é ñ
)
$$ñ ó
.
$$ó ò
Any
$$ò õ
(
$$õ ú
)
$$ú ù
;
$$ù û
exists&& 
=&& 
exists&& 
||&&  "

existsToMe&&# -
;&&- .
}'' 
return)) 
exists)) 
;)) 
}** 	
}++ 
},, æ
oC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\Services\UserFollowDomainService.cs
	namespace		 	
IndieVisible		
 
.		 
Domain		 
.		 
Services		 &
{

 
public 

class #
UserFollowDomainService (
:) *
BaseDomainService+ <
<< =

UserFollow= G
,G H!
IUserFollowRepositoryI ^
>^ _
,_ `$
IUserFollowDomainServicea y
{ 
public #
UserFollowDomainService &
(& '!
IUserFollowRepository' <

repository= G
)G H
:I J
baseK O
(O P

repositoryP Z
)Z [
{ 	
} 	
} 
} ı+
mC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\ValueObjects\OperationResultVo.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
ValueObjects *
{ 
public 

class 
OperationResultVo "
{ 
public		 
bool		 
Success		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
public 
OperationResultVo  
(  !
bool! %
success& -
)- .
{ 	
this 
. 
Success 
= 
success "
;" #
} 	
public 
OperationResultVo  
(  !
bool! %
success& -
,- .
string/ 5
message6 =
)= >
:? @
thisA E
(E F
successF M
)M N
{ 	
this 
. 
Message 
= 
message "
;" #
} 	
public 
OperationResultVo  
(  !
string! '
message( /
)/ 0
:1 2
this3 7
(7 8
false8 =
)= >
{ 	
this 
. 
Message 
= 
message "
;" #
} 	
} 
public 

class !
OperationResultHtmlVo &
:' (
OperationResultVo) :
{ 
public   
string   
Html   
{   
get    
;    !
set  " %
;  % &
}  ' (
public"" !
OperationResultHtmlVo"" $
(""$ %
string""% +
html"", 0
)""0 1
:""2 3
base""4 8
(""8 9
true""9 =
)""= >
{## 	
this$$ 
.$$ 
Html$$ 
=$$ 
html$$ 
;$$ 
}%% 	
public&& !
OperationResultHtmlVo&& $
(&&$ %
bool&&% )
success&&* 1
,&&1 2
string&&3 9
message&&: A
)&&A B
:&&C D
base&&E I
(&&I J
success&&J Q
,&&Q R
message&&S Z
)&&Z [
{'' 	
}(( 	
})) 
public,, 

class,, %
OperationResultRedirectVo,, *
:,,+ ,
OperationResultVo,,- >
{-- 
public.. 
string.. 
Url.. 
{.. 
get.. 
;..  
set..! $
;..$ %
}..& '
public00 %
OperationResultRedirectVo00 (
(00( )
string00) /
url000 3
)003 4
:005 6
base007 ;
(00; <
true00< @
)00@ A
{11 	
this22 
.22 
Url22 
=22 
url22 
;22 
}33 	
public44 %
OperationResultRedirectVo44 (
(44( )
bool44) -
success44. 5
,445 6
string447 =
message44> E
)44E F
:44G H
base44I M
(44M N
success44N U
,44U V
message44W ^
)44^ _
{55 	
}66 	
}77 
public:: 

class:: 
OperationResultVo:: "
<::" #
T::# $
>::$ %
:::& '
OperationResultVo::( 9
{;; 
public<< 
T<< 
Value<< 
{<< 
get<< 
;<< 
set<< !
;<<! "
}<<# $
public>> 
OperationResultVo>>  
(>>  !
T>>! "
item>># '
)>>' (
:>>) *
base>>+ /
(>>/ 0
true>>0 4
)>>4 5
{?? 	
this@@ 
.@@ 
Value@@ 
=@@ 
item@@ 
;@@ 
}AA 	
publicBB 
OperationResultVoBB  
(BB  !
stringBB! '
messageBB( /
)BB/ 0
:BB1 2
baseBB3 7
(BB7 8
messageBB8 ?
)BB? @
{CC 	
}DD 	
}EE 
publicHH 

classHH !
OperationResultListVoHH &
<HH& '
THH' (
>HH( )
:HH* +
OperationResultVoHH, =
{II 
publicJJ 
IEnumerableJJ 
<JJ 
TJJ 
>JJ 
ValueJJ #
{JJ$ %
getJJ& )
;JJ) *
setJJ+ .
;JJ. /
}JJ0 1
publicLL !
OperationResultListVoLL $
(LL$ %
IEnumerableLL% 0
<LL0 1
TLL1 2
>LL2 3
itemsLL4 9
)LL9 :
:LL; <
baseLL= A
(LLA B
trueLLB F
)LLF G
{MM 	
thisNN 
.NN 
SuccessNN 
=NN 
trueNN 
;NN  
thisOO 
.OO 
ValueOO 
=OO 
itemsOO 
;OO 
}PP 	
publicRR !
OperationResultListVoRR $
(RR$ %
stringRR% +
messageRR, 3
)RR3 4
:RR5 6
baseRR7 ;
(RR; <
messageRR< C
)RRC D
{SS 	
}TT 	
}UU 
}VV ö
iC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\ValueObjects\PermissionsVo.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
ValueObjects *
{ 
public 

class 
PermissionsVo 
{ 
public		 
bool		 
CanEdit		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 
bool

 
CanPostActivity
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
0 1
} 
} ±
lC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Domain\ValueObjects\SelectListItemVo.cs
	namespace 	
IndieVisible
 
. 
Domain 
. 
ValueObjects *
{ 
public 

class 
SelectListItemVo !
{ 
public		 
string		 
Value		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
string 
Text 
{ 
get  
;  !
set" %
;% &
}' (
public 
bool 
Selected 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} 