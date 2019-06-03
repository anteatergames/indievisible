ˇP
yC:\Users\daniel.gomes.ext\Documents\GitHub\indievisible\IndieVisible.Infra.CrossCutting.IoC\NativeInjectorBootStrapper.cs
	namespace 	
IndieVisible
 
. 
Infra 
. 
CrossCutting )
.) *
IoC* -
{ 
public 

class &
NativeInjectorBootStrapper +
{ 
public 
static 
void 
RegisterServices +
(+ ,
IServiceCollection, >
services? G
)G H
{ 	
services 
. 
AddSingleton !
<! " 
IHttpContextAccessor" 6
,6 7
HttpContextAccessor8 K
>K L
(L M
)M N
;N O
services 
. 
	AddScoped 
< 
IGameAppService .
,. /
GameAppService0 >
>> ?
(? @
)@ A
;A B
services 
. 
	AddScoped 
< 
IGameRepository .
,. /
GameRepository0 >
>> ?
(? @
)@ A
;A B
services## 
.## 
	AddScoped## 
<## 
IProfileAppService## 1
,##1 2
ProfileAppService##3 D
>##D E
(##E F
)##F G
;##G H
services$$ 
.$$ 
	AddScoped$$ 
<$$ 
IProfileRepository$$ 1
,$$1 2
ProfileRepository$$3 D
>$$D E
($$E F
)$$F G
;$$G H
services(( 
.(( 
	AddScoped(( 
<(( "
IUserContentAppService(( 5
,((5 6!
UserContentAppService((7 L
>((L M
(((M N
)((N O
;((O P
services)) 
.)) 
	AddScoped)) 
<)) "
IUserContentRepository)) 5
,))5 6!
UserContentRepository))7 L
>))L M
())M N
)))N O
;))O P
services-- 
.-- 
	AddScoped-- 
<-- !
IBrainstormAppService-- 4
,--4 5 
BrainstormAppService--6 J
>--J K
(--K L
)--L M
;--M N
services.. 
... 
	AddScoped.. 
<.. (
IBrainstormSessionRepository.. ;
,..; <'
BrainstormSessionRepository..= X
>..X Y
(..Y Z
)..Z [
;..[ \
services// 
.// 
	AddScoped// 
<// %
IBrainstormIdeaRepository// 8
,//8 9$
BrainstormIdeaRepository//: R
>//R S
(//S T
)//T U
;//U V
services00 
.00 
	AddScoped00 
<00 %
IBrainstormVoteRepository00 8
,008 9$
BrainstormVoteRepository00: R
>00R S
(00S T
)00T U
;00U V
services11 
.11 
	AddScoped11 
<11 (
IBrainstormCommentRepository11 ;
,11; <'
BrainstormCommentRepository11= X
>11X Y
(11Y Z
)11Z [
;11[ \
services55 
.55 
	AddScoped55 
<55 &
IFeaturedContentAppService55 9
,559 :%
FeaturedContentAppService55; T
>55T U
(55U V
)55V W
;55W X
services66 
.66 
	AddScoped66 
<66 &
IFeaturedContentRepository66 9
,669 :%
FeaturedContentRepository66; T
>66T U
(66U V
)66V W
;66W X
services:: 
.:: 
	AddScoped:: 
<:: &
IUserPreferencesAppService:: 9
,::9 :%
UserPreferencesAppService::; T
>::T U
(::U V
)::V W
;::W X
services;; 
.;; 
	AddScoped;; 
<;; &
IUserPreferencesRepository;; 9
,;;9 :%
UserPreferencesRepository;;; T
>;;T U
(;;U V
);;V W
;;;W X
services?? 
.?? 
	AddScoped?? 
<?? #
INotificationAppService?? 6
,??6 7"
NotificationAppService??8 N
>??N O
(??O P
)??P Q
;??Q R
services@@ 
.@@ 
	AddScoped@@ 
<@@ &
IGamificationDomainService@@ 9
,@@9 :%
GamificationDomainService@@; T
>@@T U
(@@U V
)@@V W
;@@W X
servicesAA 
.AA 
	AddScopedAA 
<AA #
IUserBadgeDomainServiceAA 6
,AA6 7"
UserBadgeDomainServiceAA8 N
>AAN O
(AAO P
)AAP Q
;AAQ R
servicesBB 
.BB 
	AddScopedBB 
<BB #
INotificationRepositoryBB 6
,BB6 7"
NotificationRepositoryBB8 N
>BBN O
(BBO P
)BBP Q
;BBQ R
servicesFF 
.FF 
	AddScopedFF 
<FF  
IUserBadgeAppServiceFF 3
,FF3 4
UserBadgeAppServiceFF5 H
>FFH I
(FFI J
)FFJ K
;FFK L
servicesGG 
.GG 
	AddScopedGG 
<GG #
IGamificationRepositoryGG 6
,GG6 7"
GamificationRepositoryGG8 N
>GGN O
(GGO P
)GGP Q
;GGQ R
servicesHH 
.HH 
	AddScopedHH 
<HH )
IGamificationActionRepositoryHH <
,HH< =(
GamificationActionRepositoryHH> Z
>HHZ [
(HH[ \
)HH\ ]
;HH] ^
servicesII 
.II 
	AddScopedII 
<II (
IGamificationLevelRepositoryII ;
,II; <'
GamificationLevelRepositoryII= X
>IIX Y
(IIY Z
)IIZ [
;II[ \
servicesJJ 
.JJ 
	AddScopedJJ 
<JJ  
IUserBadgeRepositoryJJ 3
,JJ3 4
UserBadgeRepositoryJJ5 H
>JJH I
(JJI J
)JJJ K
;JJK L
servicesNN 
.NN 
	AddScopedNN 
<NN )
IUserContentCommentAppServiceNN <
,NN< =(
UserContentCommentAppServiceNN> Z
>NNZ [
(NN[ \
)NN\ ]
;NN] ^
servicesOO 
.OO 
	AddScopedOO 
<OO )
IUserContentCommentRepositoryOO <
,OO< =(
UserContentCommentRepositoryOO> Z
>OOZ [
(OO[ \
)OO\ ]
;OO] ^
servicesQQ 
.QQ 
	AddScopedQQ 
<QQ 
ILikeAppServiceQQ .
,QQ. /
LikeAppServiceQQ0 >
>QQ> ?
(QQ? @
)QQ@ A
;QQA B
servicesRR 
.RR 
	AddScopedRR 
<RR &
IUserContentLikeRepositoryRR 9
,RR9 :%
UserContentLikeRepositoryRR; T
>RRT U
(RRU V
)RRV W
;RRW X
servicesSS 
.SS 
	AddScopedSS 
<SS 
IGameLikeRepositorySS 2
,SS2 3
GameLikeRepositorySS4 F
>SSF G
(SSG H
)SSH I
;SSI J
servicesUU 
.UU 
	AddScopedUU 
<UU 
IFollowAppServiceUU 0
,UU0 1
FollowAppServiceUU2 B
>UUB C
(UUC D
)UUD E
;UUE F
servicesWW 
.WW 
	AddScopedWW 
<WW !
IGameFollowAppServiceWW 4
,WW4 5 
GameFollowAppServiceWW6 J
>WWJ K
(WWK L
)WWL M
;WWM N
servicesXX 
.XX 
	AddScopedXX 
<XX $
IGameFollowDomainServiceXX 7
,XX7 8#
GameFollowDomainServiceXX9 P
>XXP Q
(XXQ R
)XXR S
;XXS T
servicesYY 
.YY 
	AddScopedYY 
<YY !
IGameFollowRepositoryYY 4
,YY4 5 
GameFollowRepositoryYY6 J
>YYJ K
(YYK L
)YYL M
;YYM N
services[[ 
.[[ 
	AddScoped[[ 
<[[ !
IUserFollowAppService[[ 4
,[[4 5 
UserFollowAppService[[6 J
>[[J K
([[K L
)[[L M
;[[M N
services\\ 
.\\ 
	AddScoped\\ 
<\\ $
IUserFollowDomainService\\ 7
,\\7 8#
UserFollowDomainService\\9 P
>\\P Q
(\\Q R
)\\R S
;\\S T
services]] 
.]] 
	AddScoped]] 
<]] !
IUserFollowRepository]] 4
,]]4 5 
UserFollowRepository]]6 J
>]]J K
(]]K L
)]]L M
;]]M N
services__ 
.__ 
	AddScoped__ 
<__ %
IUserConnectionAppService__ 8
,__8 9$
UserConnectionAppService__: R
>__R S
(__S T
)__T U
;__U V
services`` 
.`` 
	AddScoped`` 
<`` (
IUserConnectionDomainService`` ;
,``; <'
UserConnectionDomainService``= X
>``X Y
(``Y Z
)``Z [
;``[ \
servicesaa 
.aa 
	AddScopedaa 
<aa %
IUserConnectionRepositoryaa 8
,aa8 9$
UserConnectionRepositoryaa: R
>aaR S
(aaS T
)aaT U
;aaU V
servicesqq 
.qq 
	AddScopedqq 
<qq 
IndieVisibleContextqq 2
>qq2 3
(qq3 4
)qq4 5
;qq5 6
servicesrr 
.rr 
	AddScopedrr 
<rr 
IUnitOfWorkrr *
,rr* +

UnitOfWorkrr, 6
>rr6 7
(rr7 8
)rr8 9
;rr9 :
serviceszz 
.zz 
AddTransientzz !
<zz! "
IEmailSenderzz" .
,zz. / 
SendGridEmailServicezz0 D
>zzD E
(zzE F
)zzF G
;zzG H
services
ÄÄ 
.
ÄÄ 
AddTransient
ÄÄ !
<
ÄÄ! ""
IImageStorageService
ÄÄ" 6
,
ÄÄ6 7!
ImageStorageService
ÄÄ8 K
>
ÄÄK L
(
ÄÄL M
)
ÄÄM N
;
ÄÄN O
}
ÅÅ 	
}
ÇÇ 
}ÉÉ 