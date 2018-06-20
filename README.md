# LotteryTicket

> C Sharp 项目双色球

Author(作者) : susmote

<br>

***觉得项目对你有帮助的话记得点上面的Star:star:***

![1528891347750](images/1528891347750.png)



<br>

> 未经授权不可随意传播，建议自己写，用双手成就你们的梦想

  ![img](images/1343C1A9.jpg)

 <br>

[TOC]

<br>

项目目录说明:airplane:

- LotteryTicket  :  双色球项目本地win10系统版（加了很多修饰）
  - Program.cs  :  主程序文件
  - init_window.cs  :  初始化窗口类
  - luckfunc.cs  :  主要功能的类
- LotteryTicket_easy  :  双色球项目机房win7版（适用于vs2010），完成了基本功能，相比:point_up:的项目简单了很多
  - Program.cs  :  主程序文件
  - init_window.cs  :  初始化窗口类
  - luckfunc.cs  :  主要功能的类
- images    : 说明文档中的图片

<br>

### 一.项目配置条件:

- Project_Name（项目名称） : 	LotteryTicket
- Framework（运行框架）      :     .NETFramework Version = v4.7.2
- IDE（集成开发环境）            :      Jetbrains Rider
- Main  System（操作系统）  :     Windows 10

![项目运行条件](/images/1528381992179.png)

<br>

<br>

### 二.双色球规则

<br>

1.“双色球”每注投注号码由6个红色球号码和1个蓝色球号码组成。红色球号码从1—33中选择；蓝色球号码从1—16中选择。每注金额人民币2元。 

2.单式投注，由购买者从01-33共33个红色号码球中选择6个号码，并从01-16共16个蓝色号码球中选择1个号码，组合为一注投注号码的基本投注。

   ![彩票选择实例图](images/20121226180431215b4.png) 

3.中奖规则如图

![双色球中奖规则](images/20130205200221990eb.png)



<br><br>

### 三.程序特点

##### 1.使用var关键字

> var 是3.5新出的一个定义变量的类型，其实也就是弱化类型的定义，var可代替任何类型，编译器会根据上下文来判断你到底是想用什么类型的 

<br>

使用var定义变量时有以下四个特点： 

1. 必须在定义时初始化。也就是必须是`var s = “abcd”`形式，而不能是如下形式： 

```c#
var s;
s = “abcd”;
```

2. 一但初始化完成，就不能再给变量赋与初始化值类型不同的值了。 
3. var要求是局部变量。 
4.  使用var定义变量和object不同，它在效率上和使用强类型方式定义变量完全一样。 

<br>

var关键字是C# 3.5开始新增的特性，称为推断类型 . 可以赋予局部变量推断“类型”var 而不是显式类型。var 关键字指示编译器根据初始化语句右侧的表达式推断变量的类型。推断类型可以是内置类型、匿名类型、用户定义类型、.NET Framework 类库中定义的类型或任何表达式。 

<br>

在我的程序中为了适应新特性就大量使用了var关键字，最主要还是被编辑器要求的，例如我的这些代码

```c#
var tem_blue_ball = new int[16];	//申明一个int数组对象
var blue_ball = new string[16];		//申明一个字符串数组对象
var res_blue_ball = "01";		//申明一个字符串对象
var random = new Random();		//申明一个Randow对象，用于产生随机数
var index = random.Next(blue_ball.Length);		//将产生的随机数赋值给变量
```

<br>

##### 2.封装类与方法

> 在程序的编写中，我避免了使用面向过程的方法，为了使程序具有可重用性，我使用的面向对象的方法，对每个方法都进行了封装

<br>

### 四.功能实例

##### 1.生成随机双色球

> 生成随机双色球当然少不了random对象的使用

###### ①生成红色随机随机数字

​	在生成红色随机数字时，我先定义了一个用来存储所有的从1-33的数字的`int`类型的数组，因为要实现输出01、02类似的数字，我又通过对象的`ToString`方法对每一个元素进行了格式化，最后得到了一个存储"01"、"02" ...、"32"、"33"的字符串数组，也就是所有的红色号码球，下面是部分代码:

```c#
var tem_red_ball = new int[33];
var red_ball = new string[33];
var res_red_ball = new string[6];
for (var i = 1; i <= tem_red_ball.Length; i++)
{
    tem_red_ball[i - 1] = i;
    var sig_redball = tem_red_ball[i - 1].ToString("D2");
    red_ball[i - 1] = sig_redball;
}
```

​	为了防止重复数字出现，我又定义了一个`bool`类型的数组，数组大小也就是整个红球的数量，从01到33，如果这个号码已经被选了，那么这个`bool`数组指定号码的位置就被标为`true`，然后，下面就是随机数字的生成，实例化一个随机对象，然后通过随机对象的`Next`方法,生成01到33的随机数，然后把它存到一个大小为6的数组中，最终作为变量返回即可。在这里我使用了一个while循环

```C#
while(true)
{
    var index = random.Next(red_ball.Length);  
    if(used_number[index])  
        continue ;
    res_red_ball[length++] = red_ball[index];
    used_number[index] = true ;
    if(length == res_red_ball.Length) 
        break ;
}
```

<br>

###### ②.生成蓝色随机数字

> 生成蓝色随机数字球比较简单，一个简单的随机生成即可

为了达到和红色一样有01、02...的效果，我在这还是通过代码生成 了一个大小为16的字符串数组，然后通过随机生成索引最终获得了这个随机数，关键代码如下

```C#
var random = new Random();
var index = random.Next(blue_ball.Length);
res_blue_ball = blue_ball[index];
```

<br>

##### 2.对程序呈现效果进行修饰

###### ①. 绘制控制台边框

> 这个已经在我的win10平台上实现，但是机房win7会出现很多bug，所以提交作品中不加修饰

效果如下图

![1528979068596](images/1528979068596.png)

***边框给了一种更好的视觉效果***

在这里我使用的是制表符，通过嵌套循环生成界面边框

实现原理介绍:

1. 使用了C#自带的`Console`命名空间中的方法，`Console.setCursorPosition`可以用来设置控制台程序中光标的位置，从而实现在控制台程序中尽情作画
2. 为了使程序更加具有逻辑性，以及提升代码的重构性，我使用了多层嵌套循环判断，通过这种操作，可以使程序适应多种情况的变动，减少之后Coding的代码量，也就是避免了重复造轮子的现象
3. 对窗口属性进行了适应，可以根据窗口的大小自动生成边框，在这里我使用的是`Console`类中的`Console.WindowHeight`和`Console.WindowWidth`,这个可以直接获取当前窗口的大小

<br>

部分循环代码如下

```c#
//绘制边框
for (var i = 0; i <= Console.WindowHeight; i++)
{
    if (i == 0)
    {
        Console.SetCursorPosition(0, i);
        for (var j = 1; j <= Console.WindowWidth-1; j++)
        {
            if (j == 1)
            {
                Console.Write('╔');
                continue;
            }else if (j == Console.WindowWidth-1)
            {
                Console.Write("╗");
                continue;
            }
            Console.Write("═");
        }
    }
    else if (i == Console.WindowHeight - 2)
    {
......
```

###### ②.在程序中加入了一定的颜色和符号

> 使程序更加的具有可视性，对于程序的整体美观提高了一定高度

部分效果如下

![颜色和符号](images/1529370009899.png)

这样使整个程序的结构更加的清晰，使用者也很清楚自己的选号情况，总而言之，大大的提升了使用者的体验感觉

<br>

控制台程序中的输入添加颜色，运用了自带的`Console`类中的`ForegroundColor`和`BackgroundColor`,他们的值是`ConsoleColor`中的变量,其中有很多种常用的颜色

- `ForegroundColor` : 代表的是前置颜色,或者说是表面的颜色,再通俗一点也就是输出文字的颜色
- `BackgroundColor` : 代表的是背景颜色,一般的控制台程序都是黑色的背景颜色,我在自己Win10版的程序中运用了白色的背景颜色,这样显得控制台程序也不是那么的千篇一律,也是可以做出一种高端的感觉,当然纯属于自己的想法
- `ConsoleColor` : 这个类中有很多常用的颜色,例如我上面做双色球所用到的蓝色和红色,分别可以用`ConsoleColor.Red`和`ConsoleColor.Blue`来表示,但是需要注意的是一旦改变了，就一直会是这种颜色,所以必须要随时改变回去,如我的主体颜色,白色

<br>

我定义的输入红蓝球的部分代码如下

```c#
public void input_redball()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("●");

}
public void input_blueball()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("●");
}

public void input_title(string title)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(title);
}
```

> 分别代表了输出红球、篮球、和标题的函数方法，这样使得程序具有可重用性，也就是不需要每次都在程序中写一遍这样的代码,使用时直接调用函数即可

<br>

<br>

##### 3.获奖判断方法的实现

> 在判断获奖号码时，我同样是定义了一个函数去判断，优点就不用我再去说了

这个函数所需要的形式参数是自己买的号（包括自选和机选）,以及最终开奖的号码，两个参数都是`string[]`（字符串数组）类型的，返回的值是一个`bool[]`（布尔数组）类型的，代表的是买的号中奖与否的判定结果，这个号中奖了则标记为`true`，反之为`false`

①.首先判断蓝色球是否中奖，这里的原因是因为蓝色球只有一个，而红色球有6个需要判断，判断蓝色球后，就可以专注于后续红色球的判断

②.红色球中奖的判断运用了两个`for`循环,用每个买的号的球与开奖号球做比较,如果这个买的号有与中奖号球相同，那么则标记为`true`，这样就很顺畅的完成了真个判断中奖的功能

部分代码如下

```c#
for (var i = 0; i < input_ball.Length - 1; i++)
{
    for (var j = 0; j < right_choose.Length - 1; j++)
    {
        if (input_ball[i] == right_choose[j])
        {
            right_ball[i] = true;
            break;
        }
        else
        {
            right_ball[i] = false;
        }
    }
}
```

