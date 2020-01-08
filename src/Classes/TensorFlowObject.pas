﻿// MIT License
// Copyright (c) 2019-2020 Wuping Xin.
//
// Permission is hereby  granted, free of charge, to any  person obtaining a copy
// of this software and associated  documentation files (the "Software"), to deal
// in the Software  without restriction, including without  limitation the rights
// to  use, copy,  modify, merge,  publish, distribute,  sublicense, and/or  sell
// copies  of  the Software,  and  to  permit persons  to  whom  the Software  is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE  IS PROVIDED "AS  IS", WITHOUT WARRANTY  OF ANY KIND,  EXPRESS OR
// IMPLIED,  INCLUDING BUT  NOT  LIMITED TO  THE  WARRANTIES OF  MERCHANTABILITY,
// FITNESS FOR  A PARTICULAR PURPOSE AND  NONINFRINGEMENT. IN NO EVENT  SHALL THE
// AUTHORS  OR COPYRIGHT  HOLDERS  BE  LIABLE FOR  ANY  CLAIM,  DAMAGES OR  OTHER
// LIABILITY, WHETHER IN AN ACTION OF  CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE  OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace TensorFlow.Island.Classes;

uses
  RemObjects.Elements.System;

type
  TensorFlowObjectDisposedException<T> = public class(Exception)
  public
    constructor (aObject: TensorFlowObject<T>);
    begin
      inherited constructor($'{aObject.ToString} instance was already disposed.');
    end;
  end;

  ObjectDisposeAction<T> = public block(aObjectPtr: ^T);

  TensorFlowObject<T> = public abstract class(IDisposable)
  private
    fDisposeAction: ObjectDisposeAction<T>;
    fDisposed: Boolean := false;
    fObjectPtr: ^T := nil;

    finalizer;
    begin
      if not fDisposed then Dispose(false);
    end;
  protected
    constructor withObjectPtr(aObjectPtr: ^T) DisposeAction(aAction: ObjectDisposeAction<T>);
    begin
      fObjectPtr := aObjectPtr;
      fDisposeAction := aAction;
    end;

    method Dispose(aDisposing: Boolean); virtual;
    begin
      if fDisposed then exit;     
      fDisposeAction(fObjectPtr);
      fDisposed := true;
    end;
  public
    method Dispose;
    begin
      Dispose(true);
    end;

    property ObjectPtr: ^T 
      read begin
        if fDisposed then 
          raise new TensorFlowObjectDisposedException<T>(self)
        else
          exit fObjectPtr;
      end;
  end;
end.