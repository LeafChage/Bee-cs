# Bee
Structured Logging for C#.

# How To Use
## Default
```cs
var logger = new Bee.Logger<Bee.LogLabel>(new Bee.Writer(), "Title");

// add log
logger.Log(LogLabel.Info, "user request success");
logger.Log(LogLabel.Error, "user request error");

// output all log
logger.Write();
```

## CustomWriter
```cs
// you need define implements Bee.IWriter (ex: CustomWriter)
var logger = new Bee.Logger<Bee.LogLabel>(new CustomWriter(), "Title");

// call IWriter.Write in Bee.Logger.Log 
logger.Log(LogLabel.Info, "user request success");
logger.Log(LogLabel.Error, "user request error");

// call IWriter.WriteAll
logger.Write();
```

## CustomLogLabel
```cs
// you need define Enum (ex: CustomLabel)
var logger = new Bee.Logger<CustomLabel>(new Bee.Writer(), "Title");
// can use CustomLabel
logger.Log(CustomLabel.XXX, "user request success");
logger.Log(CustomLabel.YYY, "user request error");

logger.Write();
```

## Nest log
```cs
var logger = new Bee.Logger<Bee.LogLabel>(new Bee.Writer(), "Title");

logger.Log(CustomLabel.XXX, "user request success");
logger.Log(CustomLabel.YYY, "user request error");

var child = logger.Child(LogLabel.Info, "call child");
child.Log(LogLabel.Error, "child dayo");
child.Log(LogLabel.Error, "child dayo2");
child.Log(LogLabel.Error, "child dayo3");

logger.Write();
```

## Nest log and custome label for child
```cs
var logger = new Bee.Logger<Bee.LogLabel>(new Bee.Writer(), "Title");

logger.Log(CustomLabel.XXX, "user request success");
logger.Log(CustomLabel.YYY, "user request error");

// you need define Enum (ex: CustomLabel)
var child = logger.Child<CustomLabel>(LogLabel.Info, "call child");
child.Log(CustomLabel.XXX, "child dayo");
child.Log(CustomLabel.YYY, "child dayo2");
child.Log(CustomLabel.XXX, "child dayo3");

logger.Write();
```
