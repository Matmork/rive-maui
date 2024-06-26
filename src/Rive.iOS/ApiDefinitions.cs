using System;
using CoreGraphics;
using Foundation;
using MetalKit;
using ObjCRuntime;
using UIKit;

namespace Rive.iOS
{
	/*[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double RiveRuntimeVersionNumber;
		[Field ("RiveRuntimeVersionNumber", "__Internal")]
		double RiveRuntimeVersionNumber { get; }

		// extern const unsigned char[] RiveRuntimeVersionString;
		[Field ("RiveRuntimeVersionString", "__Internal")]
		byte[] RiveRuntimeVersionString { get; }
	}*/

	// typedef _Bool (^LoadAsset)(RiveFileAsset * _Nonnull, NSData * _Nonnull, RiveFactory * _Nonnull);
	delegate bool LoadAsset (RiveFileAsset arg0, NSData arg1, RiveFactory arg2);

	// @interface RiveFile : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveFile
	{
		// @property (readonly, class) uint majorVersion;
		[Static]
		[Export ("majorVersion")]
		uint MajorVersion { get; }

		// @property (readonly, class) uint minorVersion;
		[Static]
		[Export ("minorVersion")]
		uint MinorVersion { get; }

		// @property _Bool isLoaded;
		[Export ("isLoaded")]
		bool IsLoaded { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		NSObject Delegate { get; set; }

		// @property (weak) id _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nullable)initWithByteArray:(NSArray * _Nonnull)bytes loadCdn:(_Bool)cdn error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithByteArray:loadCdn:error:")]
		//[Verify (StronglyTypedNSArray)]
		NativeHandle Constructor (NSObject[] bytes, bool cdn, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithByteArray:(NSArray * _Nonnull)bytes loadCdn:(_Bool)cdn customAssetLoader:(LoadAsset _Nonnull)customAssetLoader error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithByteArray:loadCdn:customAssetLoader:error:")]
		//[Verify (StronglyTypedNSArray)]
		NativeHandle Constructor (NSObject[] bytes, bool cdn, LoadAsset customAssetLoader, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithBytes:(UInt8 * _Nonnull)bytes byteLength:(UInt64)length loadCdn:(_Bool)cdn error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithBytes:byteLength:loadCdn:error:")]
		unsafe NativeHandle Constructor (IntPtr bytes, ulong length, bool cdn, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithBytes:(UInt8 * _Nonnull)bytes byteLength:(UInt64)length loadCdn:(_Bool)cdn customAssetLoader:(LoadAsset _Nonnull)customAssetLoader error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithBytes:byteLength:loadCdn:customAssetLoader:error:")]
		unsafe NativeHandle Constructor (IntPtr bytes, ulong length, bool cdn, LoadAsset customAssetLoader, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithData:(NSData * _Nonnull)bytes loadCdn:(_Bool)cdn error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithData:loadCdn:error:")]
		NativeHandle Constructor (NSData bytes, bool cdn, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithData:(NSData * _Nonnull)bytes loadCdn:(_Bool)cdn customAssetLoader:(LoadAsset _Nonnull)customAssetLoader error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithData:loadCdn:customAssetLoader:error:")]
		NativeHandle Constructor (NSData bytes, bool cdn, LoadAsset customAssetLoader, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithResource:(NSString * _Nonnull)resourceName withExtension:(NSString * _Nonnull)extension loadCdn:(_Bool)cdn error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithResource:withExtension:loadCdn:error:")]
		NativeHandle Constructor (string resourceName, string extension, bool cdn, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithResource:(NSString * _Nonnull)resourceName withExtension:(NSString * _Nonnull)extension loadCdn:(_Bool)cdn customAssetLoader:(LoadAsset _Nonnull)customAssetLoader error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithResource:withExtension:loadCdn:customAssetLoader:error:")]
		NativeHandle Constructor (string resourceName, string extension, bool cdn, LoadAsset customAssetLoader, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithResource:(NSString * _Nonnull)resourceName loadCdn:(_Bool)cdn error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithResource:loadCdn:error:")]
		NativeHandle Constructor (string resourceName, bool cdn, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithResource:(NSString * _Nonnull)resourceName loadCdn:(_Bool)cdn customAssetLoader:(LoadAsset _Nonnull)customAssetLoader error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithResource:loadCdn:customAssetLoader:error:")]
		NativeHandle Constructor (string resourceName, bool cdn, LoadAsset customAssetLoader, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithHttpUrl:(NSString * _Nonnull)url loadCdn:(_Bool)cdn withDelegate:(id<RiveFileDelegate> _Nonnull)delegate;
		[Export ("initWithHttpUrl:loadCdn:withDelegate:")]
		NativeHandle Constructor (string url, bool cdn, RiveFileDelegate @delegate);

		// -(instancetype _Nullable)initWithHttpUrl:(NSString * _Nonnull)url loadCdn:(_Bool)cdn customAssetLoader:(LoadAsset _Nonnull)customAssetLoader withDelegate:(id<RiveFileDelegate> _Nonnull)delegate;
		[Export ("initWithHttpUrl:loadCdn:customAssetLoader:withDelegate:")]
		NativeHandle Constructor (string url, bool cdn, LoadAsset customAssetLoader, RiveFileDelegate @delegate);

		// -(RiveArtboard * _Nullable)artboard:(NSError * _Nullable * _Nullable)error;
		[Export ("artboard:")]
		[return: NullAllowed]
		RiveArtboard Artboard ([NullAllowed] out NSError error);

		// -(NSInteger)artboardCount;
		[Export ("artboardCount")]
		//[Verify (MethodToProperty)]
		nint ArtboardCount { get; }

		// -(RiveArtboard * _Nullable)artboardFromIndex:(NSInteger)index error:(NSError * _Nullable * _Nullable)error;
		[Export ("artboardFromIndex:error:")]
		[return: NullAllowed]
		RiveArtboard ArtboardFromIndex (nint index, [NullAllowed] out NSError error);

		// -(RiveArtboard * _Nullable)artboardFromName:(NSString * _Nonnull)name error:(NSError * _Nullable * _Nullable)error;
		[Export ("artboardFromName:error:")]
		[return: NullAllowed]
		RiveArtboard ArtboardFromName (string name, [NullAllowed] out NSError error);

		// -(NSArray<NSString *> * _Nonnull)artboardNames;
		[Export ("artboardNames")]
		//[Verify (MethodToProperty)]
		string[] ArtboardNames { get; }
	}

	// @protocol RiveFileDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface RiveFileDelegate
	{
		// @required -(BOOL)riveFileDidLoad:(RiveFile * _Nonnull)riveFile error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("riveFileDidLoad:error:")]
		bool Error (RiveFile riveFile, [NullAllowed] out NSError error);
	}

	// @interface RiveArtboard : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveArtboard
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }

		// -(CGRect)bounds;
		[Export ("bounds")]
		//[Verify (MethodToProperty)]
		CGRect Bounds { get; }

		// -(NSInteger)animationCount;
		[Export ("animationCount")]
		//[Verify (MethodToProperty)]
		nint AnimationCount { get; }

		// -(NSArray<NSString *> * _Nonnull)animationNames;
		[Export ("animationNames")]
		//[Verify (MethodToProperty)]
		string[] AnimationNames { get; }

		// -(RiveLinearAnimationInstance * _Nullable)animationFromIndex:(NSInteger)index error:(NSError * _Nullable * _Nullable)error;
		[Export ("animationFromIndex:error:")]
		[return: NullAllowed]
		RiveLinearAnimationInstance AnimationFromIndex (nint index, [NullAllowed] out NSError error);

		// -(RiveLinearAnimationInstance * _Nullable)animationFromName:(NSString * _Nonnull)name error:(NSError * _Nullable * _Nullable)error;
		[Export ("animationFromName:error:")]
		[return: NullAllowed]
		RiveLinearAnimationInstance AnimationFromName (string name, [NullAllowed] out NSError error);

		// -(NSInteger)stateMachineCount;
		[Export ("stateMachineCount")]
		//[Verify (MethodToProperty)]
		nint StateMachineCount { get; }

		// -(NSArray<NSString *> * _Nonnull)stateMachineNames;
		[Export ("stateMachineNames")]
		//[Verify (MethodToProperty)]
		string[] StateMachineNames { get; }

		// -(RiveStateMachineInstance * _Nullable)stateMachineFromIndex:(NSInteger)index error:(NSError * _Nullable * _Nullable)error;
		[Export ("stateMachineFromIndex:error:")]
		[return: NullAllowed]
		RiveStateMachineInstance StateMachineFromIndex (nint index, [NullAllowed] out NSError error);

		// -(RiveStateMachineInstance * _Nullable)stateMachineFromName:(NSString * _Nonnull)name error:(NSError * _Nullable * _Nullable)error;
		[Export ("stateMachineFromName:error:")]
		[return: NullAllowed]
		RiveStateMachineInstance StateMachineFromName (string name, [NullAllowed] out NSError error);

		// -(RiveStateMachineInstance * _Nullable)defaultStateMachine;
		[NullAllowed, Export ("defaultStateMachine")]
		//[Verify (MethodToProperty)]
		RiveStateMachineInstance DefaultStateMachine { get; }

		// -(RiveTextValueRun * _Nullable)textRun:(NSString * _Nonnull)name;
		[Export ("textRun:")]
		[return: NullAllowed]
		RiveTextValueRun TextRun (string name);

		// -(void)advanceBy:(double)elapsedSeconds;
		[Export ("advanceBy:")]
		void AdvanceBy (double elapsedSeconds);

		/*// -(void)draw:(RiveRenderer * _Nonnull)renderer;
		[Export ("draw:")]
		void Draw (RiveRenderer renderer);*/
	}

	// @interface RiveSMIInput : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveSMIInput
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }

		// -(_Bool)isBoolean;
		[Export ("isBoolean")]
		//[Verify (MethodToProperty)]
		bool IsBoolean { get; }

		// -(_Bool)isTrigger;
		[Export ("isTrigger")]
		//[Verify (MethodToProperty)]
		bool IsTrigger { get; }

		// -(_Bool)isNumber;
		[Export ("isNumber")]
		//[Verify (MethodToProperty)]
		bool IsNumber { get; }
	}

	// @interface RiveSMITrigger : RiveSMIInput
	[BaseType (typeof(RiveSMIInput))]
	interface RiveSMITrigger
	{
		// -(void)fire;
		[Export ("fire")]
		void Fire ();
	}

	// @interface RiveSMIBool : RiveSMIInput
	[BaseType (typeof(RiveSMIInput))]
	interface RiveSMIBool
	{
		// -(_Bool)value;
		// -(void)setValue:(_Bool)newValue;
		[Export ("value")]
		//[Verify (MethodToProperty)]
		bool Value { get; set; }
	}

	// @interface RiveSMINumber : RiveSMIInput
	[BaseType (typeof(RiveSMIInput))]
	interface RiveSMINumber
	{
		// -(float)value;
		// -(void)setValue:(float)newValue;
		[Export ("value")]
		//[Verify (MethodToProperty)]
		float Value { get; set; }
	}

	// @interface RiveLinearAnimationInstance : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveLinearAnimationInstance
	{
		// -(float)time;
		// -(void)setTime:(float)time;
		[Export ("time")]
		//[Verify (MethodToProperty)]
		float Time { get; set; }

		// -(float)endTime;
		[Export ("endTime")]
		float EndTime ();

		// -(_Bool)advanceBy:(double)elapsedSeconds;
		[Export ("advanceBy:")]
		bool AdvanceBy (double elapsedSeconds);

		// -(int)direction;
		[Export ("direction")]
		int Direction ();

		// -(void)direction:(int)direction;
		[Export ("direction:")]
		void Direction (int direction);

		// -(int)loop;
		[Export ("loop")]
		int Loop ();

		// -(void)loop:(int)loopMode;
		[Export ("loop:")]
		void Loop (int loopMode);

		// -(_Bool)didLoop;
		[Export ("didLoop")]
		bool DidLoop ();

		// -(NSString * _Nonnull)name;
		[Export ("name")]
		string Name ();

		// -(NSInteger)fps;
		[Export ("fps")]
		nint Fps ();

		// -(NSInteger)workStart;
		[Export ("workStart")]
		nint WorkStart ();

		// -(NSInteger)workEnd;
		[Export ("workEnd")]
		nint WorkEnd ();

		// -(NSInteger)duration;
		[Export ("duration")]
		nint Duration ();

		// -(NSInteger)effectiveDuration;
		[Export ("effectiveDuration")]
		nint EffectiveDuration ();

		// -(float)effectiveDurationInSeconds;
		[Export ("effectiveDurationInSeconds")]
		float EffectiveDurationInSeconds ();

		// -(_Bool)hasEnded;
		[Export ("hasEnded")]
		bool HasEnded ();
	}

	// @interface RiveStateMachineInstance : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveStateMachineInstance
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }

		// -(_Bool)advanceBy:(double)elapsedSeconds;
		[Export ("advanceBy:")]
		bool AdvanceBy (double elapsedSeconds);

		// -(const RiveSMIBool * _Nonnull)getBool:(NSString * _Nonnull)name;
		[Export ("getBool:")]
		RiveSMIBool GetBool (string name);

		// -(const RiveSMITrigger * _Nonnull)getTrigger:(NSString * _Nonnull)name;
		[Export ("getTrigger:")]
		RiveSMITrigger GetTrigger (string name);

		// -(const RiveSMINumber * _Nonnull)getNumber:(NSString * _Nonnull)name;
		[Export ("getNumber:")]
		RiveSMINumber GetNumber (string name);

		// -(NSArray<NSString *> * _Nonnull)inputNames;
		[Export ("inputNames")]
		//[Verify (MethodToProperty)]
		string[] InputNames { get; }

		// -(NSInteger)inputCount;
		[Export ("inputCount")]
		//[Verify (MethodToProperty)]
		nint InputCount { get; }

		// -(NSInteger)layerCount;
		[Export ("layerCount")]
		//[Verify (MethodToProperty)]
		nint LayerCount { get; }

		// -(RiveSMIInput * _Nullable)inputFromIndex:(NSInteger)index error:(NSError * _Nullable * _Nullable)error;
		[Export ("inputFromIndex:error:")]
		[return: NullAllowed]
		RiveSMIInput InputFromIndex (nint index, [NullAllowed] out NSError error);

		// -(RiveSMIInput * _Nullable)inputFromName:(NSString * _Nonnull)name error:(NSError * _Nullable * _Nullable)error;
		[Export ("inputFromName:error:")]
		[return: NullAllowed]
		RiveSMIInput InputFromName (string name, [NullAllowed] out NSError error);

		// -(NSInteger)stateChangedCount;
		[Export ("stateChangedCount")]
		//[Verify (MethodToProperty)]
		nint StateChangedCount { get; }

		// -(RiveLayerState * _Nullable)stateChangedFromIndex:(NSInteger)index error:(NSError * _Nullable * _Nullable)error;
		[Export ("stateChangedFromIndex:error:")]
		[return: NullAllowed]
		RiveLayerState StateChangedFromIndex (nint index, [NullAllowed] out NSError error);

		// -(NSArray<NSString *> * _Nonnull)stateChanges;
		[Export ("stateChanges")]
		//[Verify (MethodToProperty)]
		string[] StateChanges { get; }

		// -(NSInteger)reportedEventCount;
		[Export ("reportedEventCount")]
		//[Verify (MethodToProperty)]
		nint ReportedEventCount { get; }

		// -(const RiveEvent * _Nonnull)reportedEventAt:(NSInteger)index;
		[Export ("reportedEventAt:")]
		RiveEvent ReportedEventAt (nint index);

		// -(void)touchBeganAtLocation:(CGPoint)touchLocation;
		[Export ("touchBeganAtLocation:")]
		void TouchBeganAtLocation (CGPoint touchLocation);

		// -(void)touchMovedAtLocation:(CGPoint)touchLocation;
		[Export ("touchMovedAtLocation:")]
		void TouchMovedAtLocation (CGPoint touchLocation);

		// -(void)touchEndedAtLocation:(CGPoint)touchLocation;
		[Export ("touchEndedAtLocation:")]
		void TouchEndedAtLocation (CGPoint touchLocation);

		// -(void)touchCancelledAtLocation:(CGPoint)touchLocation;
		[Export ("touchCancelledAtLocation:")]
		void TouchCancelledAtLocation (CGPoint touchLocation);
	}

	// @interface RiveTextValueRun : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveTextValueRun
	{
		// -(NSString * _Nonnull)text;
		// -(void)setText:(NSString * _Nonnull)newValue;
		[Export ("text")]
		//[Verify (MethodToProperty)]
		string Text { get; set; }
	}

	/*// @interface RiveEventReport : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveEventReport
	{
		// -(float)secondsDelay;
		[Export ("secondsDelay")]
		//[Verify (MethodToProperty)]
		float SecondsDelay { get; }
	}*/

	// @interface RiveEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveEvent
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }

		// -(NSInteger)type;
		[Export ("type")]
		//[Verify (MethodToProperty)]
		nint Type { get; }

		// -(float)delay;
		[Export ("delay")]
		//[Verify (MethodToProperty)]
		float Delay { get; }

		// -(NSDictionary<NSString *,id> * _Nonnull)properties;
		[Export ("properties")]
		//[Verify (MethodToProperty)]
		NSDictionary<NSString, NSObject> Properties { get; }
	}

	// @interface RiveGeneralEvent : RiveEvent
	[BaseType (typeof(RiveEvent))]
	interface RiveGeneralEvent
	{
	}

	// @interface RiveOpenUrlEvent : RiveEvent
	[BaseType (typeof(RiveEvent))]
	interface RiveOpenUrlEvent
	{
		// -(NSString * _Nonnull)url;
		[Export ("url")]
		//[Verify (MethodToProperty)]
		string Url { get; }

		// -(NSString * _Nonnull)target;
		[Export ("target")]
		//[Verify (MethodToProperty)]
		string Target { get; }
	}

	// @interface RiveLayerState : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveLayerState
	{
		/*// -(const void * _Nonnull)rive_layer_state;
		[Export ("rive_layer_state")]
		//[Verify (MethodToProperty)]
		unsafe void* Rive_layer_state { get; }*/

		// -(_Bool)isEntryState;
		[Export ("isEntryState")]
		//[Verify (MethodToProperty)]
		bool IsEntryState { get; }

		// -(_Bool)isExitState;
		[Export ("isExitState")]
		//[Verify (MethodToProperty)]
		bool IsExitState { get; }

		// -(_Bool)isAnyState;
		[Export ("isAnyState")]
		//[Verify (MethodToProperty)]
		bool IsAnyState { get; }

		// -(_Bool)isAnimationState;
		[Export ("isAnimationState")]
		//[Verify (MethodToProperty)]
		bool IsAnimationState { get; }

		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }
	}

	// @interface RiveExitState : RiveLayerState
	[BaseType (typeof(RiveLayerState))]
	interface RiveExitState
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }
	}

	// @interface RiveEntryState : RiveLayerState
	[BaseType (typeof(RiveLayerState))]
	interface RiveEntryState
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }
	}

	// @interface RiveAnyState : RiveLayerState
	[BaseType (typeof(RiveLayerState))]
	interface RiveAnyState
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }
	}

	// @interface RiveAnimationState : RiveLayerState
	[BaseType (typeof(RiveLayerState))]
	interface RiveAnimationState
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }
	}

	// @interface RiveUnknownState : RiveLayerState
	[BaseType (typeof(RiveLayerState))]
	interface RiveUnknownState
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }
	}

	// @interface RenderContextManager : NSObject
	[BaseType (typeof(NSObject))]
	interface RenderContextManager
	{
		// @property RendererType defaultRenderer;
		[Export ("defaultRenderer", ArgumentSemantic.Assign)]
		RendererType DefaultRenderer { get; set; }

		// +(RenderContextManager *)shared;
		[Static]
		[Export ("shared")]
		//[Verify (MethodToProperty)]
		RenderContextManager Shared { get; }

		/*// -(RenderContext *)getDefaultContext;
		[Export ("getDefaultContext")]
		//[Verify (MethodToProperty)]
		RenderContext DefaultContext { get; }

		// -(RenderContext *)getSkiaContext;
		[Export ("getSkiaContext")]
		//[Verify (MethodToProperty)]
		RenderContext SkiaContext { get; }

		// -(RenderContext *)getRiveRendererContext;
		[Export ("getRiveRendererContext")]
		//[Verify (MethodToProperty)]
		RenderContext RiveRendererContext { get; }

		// -(RenderContext *)getCGRendererContext;
		[Export ("getCGRendererContext")]
		//[Verify (MethodToProperty)]
		RenderContext CGRendererContext { get; }*/

		// -(RiveFactory *)getDefaultFactory;
		[Export ("getDefaultFactory")]
		//[Verify (MethodToProperty)]
		RiveFactory DefaultFactory { get; }

		// -(RiveFactory *)getSkiaFactory;
		[Export ("getSkiaFactory")]
		//[Verify (MethodToProperty)]
		RiveFactory SkiaFactory { get; }

		// -(RiveFactory *)getCGFactory;
		[Export ("getCGFactory")]
		//[Verify (MethodToProperty)]
		RiveFactory CGFactory { get; }

		// -(RiveFactory *)getRiveRendererFactory;
		[Export ("getRiveRendererFactory")]
		//[Verify (MethodToProperty)]
		RiveFactory RiveRendererFactory { get; }
	}

	// @interface RiveFont : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveFont
	{
	}

	// @interface RiveRenderImage : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveRenderImage
	{
	}

	// @interface RiveAudio : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveAudio
	{
	}

	// @interface RiveFactory : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveFactory
	{
		// -(RiveFont * _Nonnull)decodeFont:(NSData * _Nonnull)data;
		[Export ("decodeFont:")]
		RiveFont DecodeFont (NSData data);

		// -(RiveRenderImage * _Nonnull)decodeImage:(NSData * _Nonnull)data;
		[Export ("decodeImage:")]
		RiveRenderImage DecodeImage (NSData data);

		// -(RiveAudio * _Nonnull)decodeAudio:(NSData * _Nonnull)data;
		[Export ("decodeAudio:")]
		RiveAudio DecodeAudio (NSData data);
	}

	// @interface RiveFileAsset : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveFileAsset
	{
		// -(NSString * _Nonnull)name;
		[Export ("name")]
		//[Verify (MethodToProperty)]
		string Name { get; }

		// -(NSString * _Nonnull)uniqueName;
		[Export ("uniqueName")]
		//[Verify (MethodToProperty)]
		string UniqueName { get; }

		// -(NSString * _Nonnull)uniqueFilename;
		[Export ("uniqueFilename")]
		//[Verify (MethodToProperty)]
		string UniqueFilename { get; }

		// -(NSString * _Nonnull)fileExtension;
		[Export ("fileExtension")]
		//[Verify (MethodToProperty)]
		string FileExtension { get; }

		// -(NSString * _Nonnull)cdnBaseUrl;
		[Export ("cdnBaseUrl")]
		//[Verify (MethodToProperty)]
		string CdnBaseUrl { get; }

		// -(NSString * _Nonnull)cdnUuid;
		[Export ("cdnUuid")]
		//[Verify (MethodToProperty)]
		string CdnUuid { get; }
	}

	// @interface RiveImageAsset : RiveFileAsset
	[BaseType (typeof(RiveFileAsset))]
	interface RiveImageAsset
	{
		// -(void)renderImage:(RiveRenderImage * _Nonnull)image;
		[Export ("renderImage:")]
		void RenderImage (RiveRenderImage image);
	}

	// @interface RiveFontAsset : RiveFileAsset
	[BaseType (typeof(RiveFileAsset))]
	interface RiveFontAsset
	{
		// -(void)font:(RiveFont * _Nonnull)font;
		[Export ("font:")]
		void Font (RiveFont font);
	}

	// @interface RiveAudioAsset : RiveFileAsset
	[BaseType (typeof(RiveFileAsset))]
	interface RiveAudioAsset
	{
		// -(void)audio:(RiveAudio * _Nonnull)audio;
		[Export ("audio:")]
		void Audio (RiveAudio audio);
	}

	// @interface RiveFileAssetLoader : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveFileAssetLoader
	{
		// -(BOOL)loadContentsWithAsset:(RiveFileAsset *)asset andData:(NSData *)data andFactory:(RiveFactory *)factory;
		[Export ("loadContentsWithAsset:andData:andFactory:")]
		bool LoadContentsWithAsset (RiveFileAsset asset, NSData data, RiveFactory factory);
	}

	// @interface CDNFileAssetLoader : RiveFileAssetLoader
	[BaseType (typeof(RiveFileAssetLoader))]
	interface CDNFileAssetLoader
	{
	}

	// @interface FallbackFileAssetLoader : RiveFileAssetLoader
	[BaseType (typeof(RiveFileAssetLoader))]
	interface FallbackFileAssetLoader
	{
		// -(void)addLoader:(RiveFileAssetLoader *)loader;
		[Export ("addLoader:")]
		void AddLoader (RiveFileAssetLoader loader);
	}

	// typedef _Bool (^LoadAsset)(RiveFileAsset *, NSData *, RiveFactory *);
	//delegate bool LoadAsset (RiveFileAsset arg0, NSData arg1, RiveFactory arg2);

	// @interface CustomFileAssetLoader : RiveFileAssetLoader
	[BaseType (typeof(RiveFileAssetLoader))]
	interface CustomFileAssetLoader
	{
		// @property (copy, nonatomic) LoadAsset loadAsset;
		[Export ("loadAsset", ArgumentSemantic.Copy)]
		LoadAsset LoadAsset { get; set; }

		// -(instancetype)initWithLoader:(LoadAsset)loader;
		[Export ("initWithLoader:")]
		NativeHandle Constructor (LoadAsset loader);
	}

	/*[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull RiveErrorDomain;
		[Field ("RiveErrorDomain", "__Internal")]
		NSString RiveErrorDomain { get; }
	}*/

	/*// @interface RiveRenderer : NSObject
	[BaseType (typeof(NSObject))]
	interface RiveRenderer
	{
		// -(instancetype _Nonnull)initWithContext:(CGContextRef _Nonnull)context;
		[Export ("initWithContext:")]
		NativeHandle Constructor (CGContext context);

		// -(void)alignWithRect:(CGRect)rect withContentRect:(CGRect)contentRect withAlignment:(RiveAlignment)alignment withFit:(RiveFit)fit;
		[Export ("alignWithRect:withContentRect:withAlignment:withFit:")]
		void AlignWithRect (CGRect rect, CGRect contentRect, RiveAlignment alignment, RiveFit fit);
	}*/

	// typedef _Bool (^LoadAsset)(RiveFileAsset * _Nonnull, NSData * _Nonnull, RiveFactory * _Nonnull);
	//delegate bool LoadAsset (RiveFileAsset arg0, NSData arg1, RiveFactory arg2);

	// @interface RiveRendererView : MTKView
	[BaseType (typeof(MTKView))]
	interface RiveRendererView
	{
		// -(instancetype)initWithFrame:(CGRect)frameRect;
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		// -(void)alignWithRect:(CGRect)rect contentRect:(CGRect)contentRect alignment:(RiveAlignment)alignment fit:(RiveFit)fit;
		[Export ("alignWithRect:contentRect:alignment:fit:")]
		void AlignWithRect (CGRect rect, CGRect contentRect, RiveAlignment alignment, RiveFit fit);

		// -(void)save;
		[Export ("save")]
		void Save ();

		// -(void)restore;
		[Export ("restore")]
		void Restore ();

		// -(void)transform:(float)xx xy:(float)xy yx:(float)yx yy:(float)yy tx:(float)tx ty:(float)ty;
		[Export ("transform:xy:yx:yy:tx:ty:")]
		void Transform (float xx, float xy, float yx, float yy, float tx, float ty);

		// -(void)drawWithArtboard:(RiveArtboard *)artboard;
		[Export ("drawWithArtboard:")]
		void DrawWithArtboard (RiveArtboard artboard);

		// -(void)drawRive:(CGRect)rect size:(CGSize)size;
		[Export ("drawRive:size:")]
		void DrawRive (CGRect rect, CGSize size);

		// -(_Bool)isPaused;
		[Export ("isPaused")]
		//[Verify (MethodToProperty)]
		bool IsPaused { get; }

		// -(CGPoint)artboardLocationFromTouchLocation:(CGPoint)touchLocation inArtboard:(CGRect)artboardRect fit:(RiveFit)fit alignment:(RiveAlignment)alignment;
		[Export ("artboardLocationFromTouchLocation:inArtboard:fit:alignment:")]
		CGPoint ArtboardLocationFromTouchLocation (CGPoint touchLocation, CGRect artboardRect, RiveFit fit, RiveAlignment alignment);
	}

	/*// @interface FPSCounterView : UILabel
	[BaseType (typeof(UILabel), Name = "_TtC11RiveRuntime14FPSCounterView")]
	interface FPSCounterView
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CGRect frame);

		/#1#/ -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
		[Export ("initWithCoder:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSCoder coder);#1#
	}*/

	// @protocol RiveStateMachineDelegate
	[Protocol (Name = "_TtP11RiveRuntime24RiveStateMachineDelegate_"), Model]
	[BaseType (typeof(NSObject))]
	interface RiveStateMachineDelegate
	{
		// @optional -(void)touchBeganOnArtboard:(RiveArtboard * _Nullable)artboard atLocation:(CGPoint)location;
		[Export ("touchBeganOnArtboard:atLocation:")]
		void TouchBeganOnArtboard ([NullAllowed] RiveArtboard artboard, CGPoint location);

		// @optional -(void)touchMovedOnArtboard:(RiveArtboard * _Nullable)artboard atLocation:(CGPoint)location;
		[Export ("touchMovedOnArtboard:atLocation:")]
		void TouchMovedOnArtboard ([NullAllowed] RiveArtboard artboard, CGPoint location);

		// @optional -(void)touchEndedOnArtboard:(RiveArtboard * _Nullable)artboard atLocation:(CGPoint)location;
		[Export ("touchEndedOnArtboard:atLocation:")]
		void TouchEndedOnArtboard ([NullAllowed] RiveArtboard artboard, CGPoint location);

		// @optional -(void)touchCancelledOnArtboard:(RiveArtboard * _Nullable)artboard atLocation:(CGPoint)location;
		[Export ("touchCancelledOnArtboard:atLocation:")]
		void TouchCancelledOnArtboard ([NullAllowed] RiveArtboard artboard, CGPoint location);

		// @optional -(void)stateMachine:(RiveStateMachineInstance * _Nonnull)stateMachine receivedInput:(StateMachineInput * _Nonnull)input;
		[Export ("stateMachine:receivedInput:")]
		void StateMachine (RiveStateMachineInstance stateMachine, StateMachineInput input);

		// @optional -(void)stateMachine:(RiveStateMachineInstance * _Nonnull)stateMachine didChangeState:(NSString * _Nonnull)stateName;
		[Export ("stateMachine:didChangeState:")]
		void StateMachine (RiveStateMachineInstance stateMachine, string stateName);

		// @optional -(void)onRiveEventReceivedOnRiveEvent:(RiveEvent * _Nonnull)riveEvent;
		[Export ("onRiveEventReceivedOnRiveEvent:")]
		void OnRiveEventReceivedOnRiveEvent (RiveEvent riveEvent);
	}

	// @interface RiveView : RiveRendererView
	[BaseType (typeof(RiveRendererView), Name = "_TtC11RiveRuntime8RiveView")]
	interface RiveView
	{
		/*// -(instancetype _Nonnull)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export ("initWithCoder:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSCoder aDecoder);*/

		// -(void)advanceWithDelta:(double)delta;
		[Export ("advanceWithDelta:")]
		void AdvanceWithDelta (double delta);

		// -(void)drawRive:(CGRect)rect size:(CGSize)size;
		[Export ("drawRive:size:")]
		void DrawRive (CGRect rect, CGSize size);

		// -(void)touchesBegan:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export ("touchesBegan:withEvent:")]
		void TouchesBegan (NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)touchesMoved:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export ("touchesMoved:withEvent:")]
		void TouchesMoved (NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)touchesEnded:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export ("touchesEnded:withEvent:")]
		void TouchesEnded (NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)touchesCancelled:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export ("touchesCancelled:withEvent:")]
		void TouchesCancelled (NSSet<UITouch> touches, [NullAllowed] UIEvent @event);
	}

	// @interface RiveViewModel : NSObject <RiveFileDelegate, RiveStateMachineDelegate>
	[BaseType (typeof(NSObject), Name = "_TtC11RiveRuntime13RiveViewModel")]
	[DisableDefaultCtor]
	interface RiveViewModel : RiveFileDelegate, RiveStateMachineDelegate
	{
		// -(void)updateWithView:(RiveView * _Nonnull)view;
		[Export ("updateWithView:")]
		void UpdateWithView (RiveView view);

		// -(void)setView:(RiveView * _Nonnull)view;
		[Export ("setView:")]
		void SetView (RiveView view);

		/*// -(BOOL)riveFileDidLoad:(RiveFile * _Nonnull)riveFile error:(NSError * _Nullable * _Nullable)error;
		[Export ("riveFileDidLoad:error:")]
		bool RiveFileDidLoad (RiveFile riveFile, [NullAllowed] out NSError error);*/
	}

	// @interface StateMachineInput : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC11RiveRuntime17StateMachineInput")]
	[DisableDefaultCtor]
	interface StateMachineInput
	{
	}
}
